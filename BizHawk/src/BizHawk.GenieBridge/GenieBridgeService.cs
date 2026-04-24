using System.Collections.Generic;
using Newtonsoft.Json;

namespace BizHawk.GenieBridge;

public sealed class GenieBridgeService
{
	private readonly Dictionary<string, SessionRecord> _sessions = new(System.StringComparer.OrdinalIgnoreCase);
	private readonly BridgeHostStatus _hostStatus = new();

	public BridgeHostStatus ReportHostBoot(string notice)
	{
		_hostStatus.Status = "host-online";
		_hostStatus.Notice = notice;
		_hostStatus.LastHeartbeatAt = DateTimeOffset.UtcNow;
		return _hostStatus;
	}

	public BridgeHostStatus ReportHostHeartbeat(string notice)
	{
		_hostStatus.Status = "host-heartbeat";
		_hostStatus.Notice = notice;
		_hostStatus.LastHeartbeatAt = DateTimeOffset.UtcNow;
		return _hostStatus;
	}

	public StagingResult StageLaunch(ChannelManifest manifest, string requestedBy)
	{
		var result = GenieBridgeStager.Stage(manifest, requestedBy);
		_sessions[result.Lifecycle.SessionId] = new SessionRecord
		{
			Manifest = manifest,
			Lifecycle = result.Lifecycle,
			Snapshot = result.Snapshot,
			StagedLaunch = result.StagedLaunch,
		};
		return result;
	}

	public BridgeLifecycleState CommitLaunch(string sessionId, string requestedBy, string confirmationState)
	{
		if (!_sessions.TryGetValue(sessionId, out var record))
		{
			return new BridgeLifecycleState
			{
				SessionId = sessionId,
				Phase = BridgeLifecyclePhase.ChannelReady,
				LastNotice = "No staged launch exists for this session.",
				FailureReason = "Missing staged launch.",
			};
		}

			record.Lifecycle.Phase = BridgeLifecyclePhase.LaunchCommitted;
			record.Lifecycle.LastNotice = $"Launch committed by {requestedBy} with confirmation state {confirmationState}.";
			record.Snapshot.LaunchState = nameof(BridgeLifecyclePhase.LaunchCommitted);
			record.Snapshot.RecentActions.Add(record.Lifecycle.LastNotice);
			return record.Lifecycle;
		}

	public SessionSnapshot ReportRuntimeState(string sessionId)
	{
		if (_sessions.TryGetValue(sessionId, out var record))
		{
			return record.Snapshot;
		}

		return new SessionSnapshot
		{
			LaunchState = nameof(BridgeLifecyclePhase.ChannelReady),
			GenieState = "unknown-session",
			RecentActions =
			{
				"Runtime state requested for unknown session.",
			},
		};
	}

	public IpcResultEnvelope Handle(IpcCommandEnvelope envelope)
	{
		if (!IpcCommandPolicy.IsAllowed(envelope.CommandKind))
		{
			return Reject(envelope, "Command is not allowed.");
		}

		switch (envelope.CommandKind)
		{
			case IpcCommandKind.StageLaunch:
			{
				var manifest = JsonConvert.DeserializeObject<ChannelManifest>(envelope.PayloadJson ?? "") ?? new ChannelManifest();
				var staged = StageLaunch(manifest, envelope.RequestedBy);
				return Snapshot(envelope, staged.Lifecycle.LastNotice, staged.Snapshot);
			}

			case IpcCommandKind.CommitLaunch:
			{
				var lifecycle = CommitLaunch(envelope.SessionId, envelope.RequestedBy, "confirmed");
				return Envelope(envelope, IpcResultKind.Accepted, lifecycle.LastNotice, JsonConvert.SerializeObject(lifecycle));
			}

			case IpcCommandKind.ReportRuntimeState:
			{
				var snapshot = ReportRuntimeState(envelope.SessionId);
				return Snapshot(envelope, "Runtime snapshot returned.", snapshot);
			}

			case IpcCommandKind.ReportHostStatus:
			{
				var status = ReportHostHeartbeat($"Host heartbeat received from {envelope.RequestedBy}.");
				return Envelope(envelope, IpcResultKind.Snapshot, status.Notice, JsonConvert.SerializeObject(status));
			}

			case IpcCommandKind.PauseSession:
			case IpcCommandKind.ResumeSession:
			case IpcCommandKind.SaveCheckpoint:
			case IpcCommandKind.LoadCheckpoint:
				return Envelope(envelope, IpcResultKind.Accepted, $"{envelope.CommandKind} accepted by local bridge.");

			default:
				return Reject(envelope, "Unsupported command kind.");
		}
	}

	private static IpcResultEnvelope Snapshot(IpcCommandEnvelope envelope, string summary, SessionSnapshot snapshot)
		=> Envelope(envelope, IpcResultKind.Snapshot, summary, JsonConvert.SerializeObject(snapshot));

	private static IpcResultEnvelope Envelope(IpcCommandEnvelope envelope, IpcResultKind kind, string summary, string payloadJson = "")
		=> new()
		{
			RequestId = envelope.RequestId,
			ResultKind = kind,
			Success = kind != IpcResultKind.Failed && kind != IpcResultKind.Rejected,
			Summary = summary,
			PayloadJson = payloadJson,
		};

	private static IpcResultEnvelope Reject(IpcCommandEnvelope envelope, string summary)
		=> Envelope(envelope, IpcResultKind.Rejected, summary);
}

public sealed class SessionRecord
{
	public ChannelManifest Manifest { get; set; } = new();
	public BridgeLifecycleState Lifecycle { get; set; } = new();
	public SessionSnapshot Snapshot { get; set; } = new();
	public StagedLaunch StagedLaunch { get; set; } = new();
}
