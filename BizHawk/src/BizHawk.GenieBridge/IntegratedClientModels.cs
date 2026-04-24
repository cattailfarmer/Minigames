namespace BizHawk.GenieBridge;

public enum IntegratedClientView
{
	GameView,
	ChannelConsole,
	SessionOverlay
}

public enum PausePolicy
{
	HostConsolePauses,
	AnyConsolePauses,
	ConsoleOverlayOnly,
	HostDecidesPerEvent
}

public enum StreamClientRole
{
	Host,
	Player,
	Spectator
}

public sealed class IntegratedClientState
{
	public string ClientId { get; set; } = "";
	public string ChannelName { get; set; } = "";
	public string SessionId { get; set; } = "";
	public string Nick { get; set; } = "";
	public bool IsHost { get; set; }
	public bool IsSessionPaused { get; set; }
	public bool IsStreamAttached { get; set; }
	public IntegratedClientView CurrentView { get; set; } = IntegratedClientView.ChannelConsole;
	public PausePolicy PausePolicy { get; set; } = PausePolicy.HostConsolePauses;
	public StreamClientRole StreamRole { get; set; } = StreamClientRole.Spectator;
}
