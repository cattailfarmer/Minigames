namespace BizHawk.GenieBridge;

public enum BridgeCommandKind
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

public enum BridgeCommandRisk
{
	Low,
	Medium,
	High,
	Experimental
}

public sealed class BridgeCommand
{
	public BridgeCommandKind Kind { get; set; }
	public BridgeCommandRisk Risk { get; set; } = BridgeCommandRisk.Low;
	public string SessionId { get; set; } = "";
	public string ChannelName { get; set; } = "";
	public string CheckpointName { get; set; } = "";
	public string RequestedBy { get; set; } = "";
	public string ConfirmationState { get; set; } = "";
}

public static class BridgeCommands
{
	public static BridgeCommand StageLaunch(string channelName, string requestedBy) => new()
	{
		Kind = BridgeCommandKind.StageLaunch,
		Risk = BridgeCommandRisk.Low,
		ChannelName = channelName,
		RequestedBy = requestedBy,
	};

	public static BridgeCommand CommitLaunch(string sessionId, string requestedBy, string confirmationState) => new()
	{
		Kind = BridgeCommandKind.CommitLaunch,
		Risk = BridgeCommandRisk.Medium,
		SessionId = sessionId,
		RequestedBy = requestedBy,
		ConfirmationState = confirmationState,
	};

	public static BridgeCommand ReportHostStatus(string requestedBy) => new()
	{
		Kind = BridgeCommandKind.ReportHostStatus,
		Risk = BridgeCommandRisk.Low,
		RequestedBy = requestedBy,
	};
}
