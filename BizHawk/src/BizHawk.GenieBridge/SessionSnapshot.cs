using System.Collections.Generic;

namespace BizHawk.GenieBridge;

public sealed class SessionSnapshot
{
	public string ChannelName { get; set; } = "";
	public string SessionName { get; set; } = "";
	public string LaunchState { get; set; } = "";
	public string ActiveRom { get; set; } = "";
	public string ActiveCoreProfile { get; set; } = "";
	public string TransformedIdentity { get; set; } = "";
	public string SyncStatus { get; set; } = "";
	public string SaveStateStatus { get; set; } = "";
	public string GenieState { get; set; } = "";

	public List<string> ActiveRoster { get; } = new();
	public List<string> ActiveMods { get; } = new();
	public List<string> RecentActions { get; } = new();
	public Dictionary<string, string> ActiveSeats { get; } = new();
}
