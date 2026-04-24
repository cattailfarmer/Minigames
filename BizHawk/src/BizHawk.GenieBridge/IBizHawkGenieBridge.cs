namespace BizHawk.GenieBridge;

public interface IBizHawkGenieBridge
{
	BridgeLifecycleState StageLaunch(ChannelManifest manifest, string requestedBy);
	BridgeLifecycleState CommitLaunch(string sessionId, string requestedBy, string confirmationState);
	SessionSnapshot ReportRuntimeState(string sessionId);
	BridgeLifecycleState PauseSession(string sessionId, string requestedBy);
	BridgeLifecycleState ResumeSession(string sessionId, string requestedBy);
	CheckpointDescriptor SaveCheckpoint(string sessionId, string checkpointName, string requestedBy);
	BridgeLifecycleState LoadCheckpoint(string sessionId, string checkpointName, string requestedBy);
}
