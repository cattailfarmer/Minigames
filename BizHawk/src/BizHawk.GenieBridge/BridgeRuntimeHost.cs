namespace BizHawk.GenieBridge;

public sealed class BridgeRuntimeHost : IBizHawkRuntimePipe
{
	private readonly IpcBridgeClient _client;

	public BridgeRuntimeHost(NamedPipeBridgeConfig config)
	{
		_client = new IpcBridgeClient(config);
	}

	public IpcResultEnvelope Send(IpcCommandEnvelope command) => _client.Send(command);
}
