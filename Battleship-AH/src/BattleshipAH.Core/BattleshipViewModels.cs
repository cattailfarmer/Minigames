namespace BattleshipAH.Core;

public sealed record BattleshipPrivateView(
    string PlayerKey,
    string Phase,
    bool IsActiveTurn,
    string Summary,
    string LastEvent,
    string PlacementStatus,
    string? NextShipName,
    int? NextShipLength,
    string OwnBoard,
    string TargetBoard,
    int OwnRemainingShipCells,
    int OpponentRemainingShipCells,
    string? WinnerKey);

public sealed record BattleshipSharedView(
    string Phase,
    string Summary,
    string LastEvent,
    string ActivePlayerKey,
    string PlacementStatus,
    string? WinnerKey);
