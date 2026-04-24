namespace BizHawk.GenieBridge;

public static class GenieBridgeStager
{
	public static StagingResult Stage(ChannelManifest manifest, string requestedBy)
	{
		var errors = ManifestValidation.Validate(manifest);
		if (errors.Count > 0)
		{
			return new StagingResult
			{
				Lifecycle = new BridgeLifecycleState
				{
					ChannelName = manifest.ChannelName,
					Phase = BridgeLifecyclePhase.ChannelReady,
					LastNotice = "Manifest validation failed.",
					FailureReason = string.Join(" ", errors),
				},
				Snapshot = SessionSnapshotFactory.FromManifest(
					manifest,
					new BridgeLifecycleState { ChannelName = manifest.ChannelName, Phase = BridgeLifecyclePhase.ChannelReady, FailureReason = string.Join(" ", errors) },
					new[] { "Genie refused to stage launch because the manifest is incomplete." }),
			};
		}

		var sessionId = BuildSessionId(manifest, requestedBy);
		var stagedLaunch = new StagedLaunch
		{
			SessionId = sessionId,
			ChannelName = manifest.ChannelName,
			RequestedBy = requestedBy,
			RomId = manifest.RomId,
			CoreProfile = manifest.CoreProfile,
			LaunchProfile = manifest.LaunchProfile,
		};

		foreach (var mod in manifest.ActiveMods)
		{
			stagedLaunch.ActiveMods.Add(mod);
		}

		var lifecycle = new BridgeLifecycleState
		{
			ChannelName = manifest.ChannelName,
			SessionId = sessionId,
			Phase = BridgeLifecyclePhase.LaunchStaged,
			LastNotice = "Launch staged from current channel manifest.",
		};

		var snapshot = SessionSnapshotFactory.FromManifest(
			manifest,
			lifecycle,
			new[] { "Genie staged launch from channel manifest.", $"Host requested staging: {requestedBy}" });

		return new StagingResult
		{
			StagedLaunch = stagedLaunch,
			Lifecycle = lifecycle,
			Snapshot = snapshot,
		};
	}

	private static string BuildSessionId(ChannelManifest manifest, string requestedBy)
	{
		static string Normalize(string value) => string.IsNullOrWhiteSpace(value)
			? "unknown"
			: value.Trim().ToLowerInvariant().Replace(' ', '-');

		return $"genie-{Normalize(manifest.ChannelName)}-{Normalize(manifest.RomId)}-{Normalize(requestedBy)}";
	}
}

public sealed class StagingResult
{
	public StagedLaunch StagedLaunch { get; set; } = new();
	public BridgeLifecycleState Lifecycle { get; set; } = new();
	public SessionSnapshot Snapshot { get; set; } = new();
}
