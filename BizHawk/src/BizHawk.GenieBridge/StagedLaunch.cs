using System.Collections.Generic;

namespace BizHawk.GenieBridge;

public sealed class StagedLaunch
{
	public string SessionId { get; set; } = "";
	public string ChannelName { get; set; } = "";
	public string RequestedBy { get; set; } = "";
	public string RomId { get; set; } = "";
	public string CoreProfile { get; set; } = "";
	public string LaunchProfile { get; set; } = "";
	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	public List<string> ActiveMods { get; } = new();
}
