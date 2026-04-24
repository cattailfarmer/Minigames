using System.IO;
using System.IO.Pipes;
using System.Text;
using Newtonsoft.Json;

namespace BizHawk.GenieBridge;

public sealed class IpcBridgeClient
{
	private readonly NamedPipeBridgeConfig _config;

	public IpcBridgeClient(NamedPipeBridgeConfig config)
	{
		_config = config ?? throw new ArgumentNullException(nameof(config));
	}

	public IpcResultEnvelope Send(IpcCommandEnvelope command)
	{
		using var pipe = new NamedPipeClientStream(".", _config.PipeName, PipeDirection.InOut, PipeOptions.None);
		pipe.Connect(1000);

		using var reader = new StreamReader(pipe, Encoding.UTF8, false, 1024, true);
		using var writer = new StreamWriter(pipe, Encoding.UTF8, 1024, true) { AutoFlush = true };

		writer.WriteLine(JsonConvert.SerializeObject(command));
		var response = reader.ReadLine();
		return JsonConvert.DeserializeObject<IpcResultEnvelope>(response ?? "") ?? new IpcResultEnvelope
		{
			RequestId = command.RequestId,
			ResultKind = IpcResultKind.Failed,
			Success = false,
			Summary = "No response received from bridge.",
		};
	}
}
