namespace BizHawk.GenieBridge;

public sealed class StreamAttachment
{
	public string SessionId { get; set; } = "";
	public string StreamId { get; set; } = "";
	public string ClientId { get; set; } = "";
	public StreamClientRole Role { get; set; } = StreamClientRole.Spectator;
	public bool IsAttached { get; set; }
	public string AttachmentState { get; set; } = "";
}

public sealed class GenieNotice
{
	public string NoticeType { get; set; } = "";
	public string Summary { get; set; } = "";
	public string Actor { get; set; } = "";
	public string SessionId { get; set; } = "";
}
