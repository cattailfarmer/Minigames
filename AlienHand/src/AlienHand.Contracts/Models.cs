namespace AlienHand.Contracts;

public enum EndpointKind
{
    HostWindow,
    LanPc
}

public enum InputDeviceKind
{
    Keyboard,
    Mouse,
    Gamepad,
    EndpointRemote
}

public enum ProjectionMode
{
    PrivateStation,
    SharedPublic,
    TurnTransition,
    Lobby,
    Spectator
}

public enum SessionPhase
{
    Lobby,
    Pairing,
    Ready,
    Playing,
    Transition,
    Completed
}

public sealed record StationTemplate(
    StationId StationId,
    string DisplayName,
    ProjectionMode DefaultProjectionMode,
    bool RequiresPrivateView);

public sealed record EndpointDescriptor(
    EndpointId EndpointId,
    string DisplayName,
    EndpointKind Kind);

public sealed record InputChannelDescriptor(
    DeviceId DeviceId,
    InputDeviceKind DeviceKind,
    string Role);

public sealed record StationAssignment(
    StationId StationId,
    PlayerId? PlayerId,
    EndpointId? EndpointId,
    IReadOnlyList<InputChannelDescriptor> InputChannels);

public sealed record LobbySnapshot(
    SessionId SessionId,
    string SessionName,
    SessionPhase Phase,
    IReadOnlyList<StationAssignment> StationAssignments);

public sealed record PairingChallenge(
    string ChallengeKey,
    string Instruction,
    InputDeviceKind DeviceKind,
    ProjectionMode ProjectionMode);

public sealed record PairingResponse(
    EndpointId EndpointId,
    string ChallengeKey,
    InputDeviceKind DeviceKind,
    string ResponseValue);

public sealed record PairingResult(
    bool Accepted,
    string Message,
    StationId? StationId);

public sealed record StationInputEvent(
    SessionId SessionId,
    StationId StationId,
    string Action,
    string? Argument = null);

public sealed record StationViewEnvelope(
    SessionId SessionId,
    StationId StationId,
    ProjectionMode ProjectionMode,
    string ViewKind,
    string Summary,
    IReadOnlyDictionary<string, string> Fields);
