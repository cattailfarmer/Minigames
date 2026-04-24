namespace BizHawk.GenieBridge;

public enum IpcTransportKind
{
	NamedPipe
}

public enum IpcCommandKind
{
	StageLaunch,
	CommitLaunch,
	ReportRuntimeState,
	ReportHostStatus,
	PauseSession,
	ResumeSession,
	SaveCheckpoint,
	LoadCheckpoint
}

public enum IpcResultKind
{
	Accepted,
	Rejected,
	Failed,
	Snapshot
}

public sealed class IpcCommandEnvelope
{
	public string RequestId { get; set; } = "";
	public IpcTransportKind TransportKind { get; set; } = IpcTransportKind.NamedPipe;
	public IpcCommandKind CommandKind { get; set; }
	public string SessionId { get; set; } = "";
	public string ChannelName { get; set; } = "";
	public string RequestedBy { get; set; } = "";
	public string PayloadJson { get; set; } = "";
}

public sealed class IpcResultEnvelope
{
	public string RequestId { get; set; } = "";
	public IpcResultKind ResultKind { get; set; }
	public bool Success { get; set; }
	public string Summary { get; set; } = "";
	public string PayloadJson { get; set; } = "";
}
