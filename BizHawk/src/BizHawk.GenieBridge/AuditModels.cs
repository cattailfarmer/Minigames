namespace BizHawk.GenieBridge;

public sealed class AuditEvent
{
	public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
	public string EventType { get; set; } = "";
	public string Actor { get; set; } = "";
	public string Summary { get; set; } = "";
	public string BeforeState { get; set; } = "";
	public string AfterState { get; set; } = "";
}

public sealed class CheckpointDescriptor
{
	public string SessionId { get; set; } = "";
	public string CheckpointName { get; set; } = "";
	public string CreatedBy { get; set; } = "";
	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
