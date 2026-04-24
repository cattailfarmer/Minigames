namespace BizHawk.GenieBridge;

public interface IBizHawkRuntimePipe
{
	IpcResultEnvelope Send(IpcCommandEnvelope command);
}
