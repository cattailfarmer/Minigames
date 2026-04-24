namespace BizHawk.GenieBridge;

public enum ProviderRole
{
	Conversation,
	Transcription,
	Planning,
	MechanicAnalysis,
	PatchSynthesis,
	SpecializedSupport
}

public sealed class ProviderRoute
{
	public string ProviderName { get; set; } = "";
	public ProviderRole Role { get; set; }
	public string RoutingRule { get; set; } = "";
	public string ApprovalBoundary { get; set; } = "";
}
