using BizHawk.GenieBridge;
using Newtonsoft.Json;
using System.IO;

namespace BizHawk.Client.EmuHawk
{
	internal sealed class GenieBridgeHost : System.IDisposable
	{
		private readonly GenieBridgeService _service;
		private readonly NamedPipeGenieBridgeServer _server;
		private bool _started;

		public GenieBridgeHost(NamedPipeBridgeConfig config = null)
		{
			_service = new GenieBridgeService();
			_server = new NamedPipeGenieBridgeServer(_service, config);
		}

		public bool IsStarted => _started;

		public BridgeHostStatus ReportHostStatus(string notice = "host queried.")
			=> _service.ReportHostHeartbeat(notice);

		public SessionSnapshot ReportRuntimeState(string sessionId)
			=> _service.ReportRuntimeState(sessionId);

		public StagingResult TryBootstrapFromManifest(string manifestPath, string requestedBy)
		{
			if (!File.Exists(manifestPath)) return null;
			var manifest = JsonConvert.DeserializeObject<ChannelManifest>(File.ReadAllText(manifestPath)) ?? new ChannelManifest();
			return _service.StageLaunch(manifest, requestedBy);
		}

		public void Start()
		{
			if (_started) return;
			_server.Start();
			_ = _service.ReportHostBoot($"{System.Diagnostics.Process.GetCurrentProcess().ProcessName} bridge host started.");
			_started = true;
		}

		public void Dispose()
		{
			if (!_started) return;
			_server.Dispose();
			_started = false;
		}
	}
}
