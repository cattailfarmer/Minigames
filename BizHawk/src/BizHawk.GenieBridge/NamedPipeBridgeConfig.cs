namespace BizHawk.GenieBridge;

public sealed class NamedPipeBridgeConfig
{
	public string PipeName { get; set; } = "bizhawk-genie-bridge";
	public bool LocalOnly { get; set; } = true;
	public int MaxMessageBytes { get; set; } = 32768;
}
