namespace BizHawk.GenieBridge;

public static class IpcCommandFactory
{
	private static string BuildRequestId(string requestedBy, IpcCommandKind kind, string sessionId)
	{
		static string Normalize(string value) => string.IsNullOrWhiteSpace(value)
			? "unknown"
			: value.Trim().ToLowerInvariant().Replace(' ', '-');

		return $"{Normalize(requestedBy)}-{kind}-{Normalize(sessionId)}";
	}

	public static IpcCommandEnvelope ForBridgeCommand(BridgeCommand command, string payloadJson = "")
		=> new()
		{
			RequestId = BuildRequestId(command.RequestedBy, (IpcCommandKind) command.Kind, command.SessionId),
			CommandKind = (IpcCommandKind) command.Kind,
			SessionId = command.SessionId,
			ChannelName = command.ChannelName,
			RequestedBy = command.RequestedBy,
			PayloadJson = payloadJson,
		};
}
