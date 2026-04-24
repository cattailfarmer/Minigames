using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace BizHawk.GenieBridge;

public sealed class NamedPipeGenieBridgeServer : IDisposable
{
	private readonly GenieBridgeService _service;
	private readonly NamedPipeBridgeConfig _config;
	private readonly CancellationTokenSource _cancellation = new();
	private Thread? _thread;

	public NamedPipeGenieBridgeServer(GenieBridgeService service, NamedPipeBridgeConfig? config = null)
	{
		_service = service ?? throw new ArgumentNullException(nameof(service));
		_config = config ?? new NamedPipeBridgeConfig();
	}

	public void Start()
	{
		if (_thread != null)
		{
			return;
		}

		_thread = new Thread(Run) { IsBackground = true, Name = "GenieBridgeNamedPipeServer" };
		_thread.Start();
	}

	public void Dispose()
	{
		_cancellation.Cancel();
	}

	private void Run()
	{
		while (!_cancellation.IsCancellationRequested)
		{
			using var pipe = new NamedPipeServerStream(_config.PipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 1024, 1024);
			try
			{
				pipe.WaitForConnection();

				using var reader = new StreamReader(pipe, Encoding.UTF8, false, 1024, true);
				using var writer = new StreamWriter(pipe, Encoding.UTF8, 1024, true) { AutoFlush = true };

				while (!_cancellation.IsCancellationRequested && pipe.IsConnected)
				{
					var line = reader.ReadLine();
					if (string.IsNullOrWhiteSpace(line))
					{
						continue;
					}

					var envelope = JsonConvert.DeserializeObject<IpcCommandEnvelope>(line) ?? new IpcCommandEnvelope();
					var result = _service.Handle(envelope);
					writer.WriteLine(JsonConvert.SerializeObject(result));
				}
			}
			catch
			{
				// keep the server resilient; later layers can add audit/logging here
			}
		}
	}
}
