namespace BizHawk.GenieBridge;

public static class IpcCommandPolicy
{
	public static bool IsAllowed(IpcCommandKind commandKind) => commandKind switch
	{
		IpcCommandKind.StageLaunch => true,
		IpcCommandKind.CommitLaunch => true,
		IpcCommandKind.ReportRuntimeState => true,
		IpcCommandKind.ReportHostStatus => true,
		IpcCommandKind.PauseSession => true,
		IpcCommandKind.ResumeSession => true,
		IpcCommandKind.SaveCheckpoint => true,
		IpcCommandKind.LoadCheckpoint => true,
		_ => false,
	};
}
