namespace BizHawk.GenieBridge;

public sealed class ConsoleTransitionResult
{
	public IntegratedClientState ClientState { get; set; } = new();
	public GenieNotice Notice { get; set; } = new();
	public bool PauseTriggered { get; set; }
}

public static class ConsoleTransition
{
	public static ConsoleTransitionResult EnterConsole(IntegratedClientState clientState)
	{
		clientState.CurrentView = IntegratedClientView.ChannelConsole;

		var shouldPause = clientState.PausePolicy switch
		{
			PausePolicy.HostConsolePauses => clientState.IsHost,
			PausePolicy.AnyConsolePauses => true,
			PausePolicy.ConsoleOverlayOnly => false,
			PausePolicy.HostDecidesPerEvent => clientState.IsHost,
			_ => false,
		};

		if (shouldPause)
		{
			clientState.IsSessionPaused = true;
		}

		return new ConsoleTransitionResult
		{
			ClientState = clientState,
			PauseTriggered = shouldPause,
			Notice = new GenieNotice
			{
				NoticeType = shouldPause ? "pause" : "console",
				Actor = clientState.Nick,
				SessionId = clientState.SessionId,
				Summary = shouldPause
					? $"Console entry paused the session under {clientState.PausePolicy}."
					: "Console entry did not pause the session.",
			},
		};
	}
}
