using System.Collections.Generic;

namespace BizHawk.GenieBridge;

public static class ManifestValidation
{
	public static IReadOnlyList<string> Validate(ChannelManifest manifest)
	{
		var errors = new List<string>();

		if (string.IsNullOrWhiteSpace(manifest.ChannelName)) errors.Add("ChannelName is required.");
		if (string.IsNullOrWhiteSpace(manifest.SessionName)) errors.Add("SessionName is required.");
		if (string.IsNullOrWhiteSpace(manifest.RomId)) errors.Add("RomId is required.");
		if (string.IsNullOrWhiteSpace(manifest.CoreProfile)) errors.Add("CoreProfile is required.");
		if (string.IsNullOrWhiteSpace(manifest.LaunchProfile)) errors.Add("LaunchProfile is required.");
		if (string.IsNullOrWhiteSpace(manifest.HostUser)) errors.Add("HostUser is required.");
		if (!manifest.GenieEnabled) errors.Add("Genie must be enabled for Game Genie bridge staging.");

		return errors;
	}
}
