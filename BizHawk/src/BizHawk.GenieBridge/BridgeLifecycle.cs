namespace BizHawk.GenieBridge;

public enum BridgeLifecyclePhase
{
	IrcBoot,
	HostBoot,
	ChannelReady,
	ManifestLoaded,
	RosterStaging,
	LaunchStaged,
	LaunchCommitted,
	RuntimeActive,
	Paused,
	Recovery,
	Ended
}

public sealed class BridgeLifecycleState
{
	public string ChannelName { get; set; } = "";
	public string SessionId { get; set; } = "";
	public BridgeLifecyclePhase Phase { get; set; } = BridgeLifecyclePhase.IrcBoot;
	public string LastNotice { get; set; } = "";
	public string FailureReason { get; set; } = "";

	public bool HasFailure => !string.IsNullOrWhiteSpace(FailureReason);
}
