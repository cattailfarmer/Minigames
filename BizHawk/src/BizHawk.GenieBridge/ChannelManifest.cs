using System.Collections.Generic;

namespace BizHawk.GenieBridge;

public sealed class ChannelManifest
{
	public string ChannelName { get; set; } = "";
	public string SessionName { get; set; } = "";
	public string SessionMode { get; set; } = "";
	public string ManifestVersion { get; set; } = "1.0";

	public string RomId { get; set; } = "";
	public string RomLabel { get; set; } = "";
	public string RomSource { get; set; } = "";
	public string CoreProfile { get; set; } = "";
	public string LaunchProfile { get; set; } = "";

	public string HostUser { get; set; } = "";
	public string SeatPolicy { get; set; } = "";
	public string ReadyState { get; set; } = "";

	public bool GenieEnabled { get; set; }
	public string GenieRole { get; set; } = "";
	public string AgentPolicy { get; set; } = "";
	public string ProviderPolicy { get; set; } = "";

	public string ModPolicy { get; set; } = "";
	public string TransformationScope { get; set; } = "";
	public string ConsentMode { get; set; } = "";

	public string JoinReplayPolicy { get; set; } = "";
	public string StateSnapshotPolicy { get; set; } = "";
	public string AuditVisibility { get; set; } = "";

	public List<ManifestParticipant> Players { get; } = new();
	public List<ManifestParticipant> Spectators { get; } = new();
	public List<string> ActiveMods { get; } = new();
}

public sealed class ManifestParticipant
{
	public string Nick { get; set; } = "";
	public string DesiredSeat { get; set; } = "";
	public bool IsReady { get; set; }
}
