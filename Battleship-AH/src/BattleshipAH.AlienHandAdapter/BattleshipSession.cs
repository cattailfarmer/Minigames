using AlienHand.Contracts;
using BattleshipAH.Core;

namespace BattleshipAH.AlienHandAdapter;

public sealed class BattleshipSession : IAlienHandGameSession
{
    private readonly Dictionary<StationId, BattleshipSide> _stationMap = new()
    {
        [new StationId("station-p1")] = BattleshipSide.PlayerOne,
        [new StationId("station-p2")] = BattleshipSide.PlayerTwo
    };

    private BattleshipSession(SessionId sessionId, BattleshipMatch match)
    {
        SessionId = sessionId;
        Match = match;
    }

    public string GameKey => "battleship-ah";

    public SessionId SessionId { get; }

    public BattleshipMatch Match { get; }

    public SessionPhase Phase => Match.Phase switch
    {
        MatchPhase.Placement => SessionPhase.Ready,
        MatchPhase.Playing => SessionPhase.Playing,
        MatchPhase.Completed => SessionPhase.Completed,
        _ => SessionPhase.Playing
    };

    public static BattleshipSession CreateDefault() => new(SessionId.New(), new BattleshipMatch());

    public IReadOnlyList<StationTemplate> BuildStations() =>
        new[]
        {
            new StationTemplate(new StationId("station-p1"), "Player 1", ProjectionMode.PrivateStation, RequiresPrivateView: true),
            new StationTemplate(new StationId("station-p2"), "Player 2", ProjectionMode.PrivateStation, RequiresPrivateView: true)
        };

    public LobbySnapshot BuildLobbySnapshot(IReadOnlyList<StationAssignment> assignments) =>
        new(SessionId, "Battleship-AH", Phase, assignments);

    public StationViewEnvelope BuildViewForStation(StationId stationId)
    {
        var privateView = Match.BuildPrivateView(MapStation(stationId));

        var fields = new Dictionary<string, string>
        {
            ["player"] = privateView.PlayerKey,
            ["phase"] = privateView.Phase,
            ["turn"] = privateView.IsActiveTurn ? "active" : "waiting",
            ["own_board"] = privateView.OwnBoard,
            ["target_board"] = privateView.TargetBoard,
            ["own_remaining_ship_cells"] = privateView.OwnRemainingShipCells.ToString(),
            ["opponent_remaining_ship_cells"] = privateView.OpponentRemainingShipCells.ToString(),
            ["last_event"] = privateView.LastEvent,
            ["placement_status"] = privateView.PlacementStatus
        };

        if (!string.IsNullOrWhiteSpace(privateView.NextShipName))
        {
            fields["next_ship_name"] = privateView.NextShipName;
        }

        if (privateView.NextShipLength is not null)
        {
            fields["next_ship_length"] = privateView.NextShipLength.Value.ToString();
        }

        if (!string.IsNullOrWhiteSpace(privateView.WinnerKey))
        {
            fields["winner"] = privateView.WinnerKey;
        }

        return new StationViewEnvelope(
            SessionId,
            stationId,
            ProjectionMode.PrivateStation,
            "BattleshipPrivateView",
            privateView.Summary,
            fields);
    }

    public void PlaceShip(StationId stationId, string placement) =>
        Match.PlaceShip(MapStation(stationId), placement);

    public void ConfirmReady(StationId stationId) =>
        Match.ConfirmReady(MapStation(stationId));

    public void FireShot(StationId stationId, string coordinate) =>
        Match.FireShot(MapStation(stationId), coordinate);

    public void HandleInput(StationInputEvent inputEvent)
    {
        _ = MapStation(inputEvent.StationId);

        if (inputEvent.Action.Equals("place", StringComparison.OrdinalIgnoreCase))
        {
            Match.PlaceShip(MapStation(inputEvent.StationId), inputEvent.Argument ?? string.Empty);
            return;
        }

        if (inputEvent.Action.Equals("ready", StringComparison.OrdinalIgnoreCase))
        {
            Match.ConfirmReady(MapStation(inputEvent.StationId));
            return;
        }

        if (inputEvent.Action.Equals("fire", StringComparison.OrdinalIgnoreCase))
        {
            Match.FireShot(MapStation(inputEvent.StationId), inputEvent.Argument ?? string.Empty);
            return;
        }

        throw new InvalidOperationException($"Unsupported Battleship action '{inputEvent.Action}'.");
    }

    private BattleshipSide MapStation(StationId stationId) =>
        _stationMap.TryGetValue(stationId, out var side)
            ? side
            : throw new InvalidOperationException($"Unknown station '{stationId}'.");
}
