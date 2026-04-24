using AlienHand.Contracts;

namespace AlienHand.Core;

public static class PairingService
{
    public static PairingChallenge CreateKeyboardChallenge(ProjectionMode projectionMode, string instruction) =>
        new(Guid.NewGuid().ToString("N")[..6], instruction, InputDeviceKind.Keyboard, projectionMode);

    public static PairingChallenge CreateGamepadChallenge(ProjectionMode projectionMode, string instruction) =>
        new(Guid.NewGuid().ToString("N")[..6], instruction, InputDeviceKind.Gamepad, projectionMode);

    public static PairingChallenge CreateMouseChallenge(ProjectionMode projectionMode, string instruction) =>
        new(Guid.NewGuid().ToString("N")[..6], instruction, InputDeviceKind.Mouse, projectionMode);

    public static PairingResult Accept(StationId stationId, string message) => new(true, message, stationId);

    public static PairingResult Reject(string message) => new(false, message, null);
}
