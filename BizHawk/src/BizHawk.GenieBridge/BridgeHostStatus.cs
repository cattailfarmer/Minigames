namespace BizHawk.GenieBridge;

public sealed class BridgeHostStatus
{
	public string HostName { get; set; } = Environment.MachineName;
	public string HostProcess { get; set; } = "EmuHawk";
	public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.UtcNow;
	public DateTimeOffset LastHeartbeatAt { get; set; } = DateTimeOffset.UtcNow;
	public string Status { get; set; } = "starting";
	public string Notice { get; set; } = "";
}
