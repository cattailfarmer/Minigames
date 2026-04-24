using System.Collections.Generic;

namespace BizHawk.GenieBridge;

public static class SessionSnapshotFactory
{
	public static SessionSnapshot FromManifest(ChannelManifest manifest, BridgeLifecycleState lifecycle, IEnumerable<string> recentActions)
	{
		var snapshot = new SessionSnapshot
		{
			ChannelName = manifest.ChannelName,
			SessionName = manifest.SessionName,
			LaunchState = lifecycle.Phase.ToString(),
			ActiveRom = manifest.RomLabel,
			ActiveCoreProfile = manifest.CoreProfile,
			TransformedIdentity = "",
			SyncStatus = lifecycle.Phase >= BridgeLifecyclePhase.RuntimeActive ? "pending-runtime-report" : "not-started",
			SaveStateStatus = lifecycle.Phase >= BridgeLifecyclePhase.RuntimeActive ? "unknown" : "unavailable-before-launch",
			GenieState = manifest.GenieRole,
		};

		foreach (var player in manifest.Players)
		{
			snapshot.ActiveRoster.Add(player.Nick);
			if (!string.IsNullOrWhiteSpace(player.DesiredSeat))
			{
				snapshot.ActiveSeats[player.DesiredSeat] = player.Nick;
			}
		}

		foreach (var spectator in manifest.Spectators)
		{
			snapshot.ActiveRoster.Add(spectator.Nick);
		}

		foreach (var mod in manifest.ActiveMods)
		{
			snapshot.ActiveMods.Add(mod);
		}

		foreach (var action in recentActions)
		{
			snapshot.RecentActions.Add(action);
		}

		return snapshot;
	}
}
