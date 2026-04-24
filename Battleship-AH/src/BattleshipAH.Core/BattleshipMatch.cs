namespace BattleshipAH.Core;

public sealed record BattleshipPlayerState(
    string PlayerKey,
    BattleshipSide Side,
    BattleshipBoard OwnBoard,
    Dictionary<Coordinate, CellState> ShotsAtOpponent,
    bool Ready,
    int PlacementCursor);

public sealed class BattleshipMatch
{
    private static readonly IReadOnlyList<ShipDefinition> FleetDefinition =
        new[]
        {
            new ShipDefinition("Carrier", 5),
            new ShipDefinition("Battleship", 4),
            new ShipDefinition("Cruiser", 3),
            new ShipDefinition("Submarine", 3),
            new ShipDefinition("Destroyer", 2)
        };

    private readonly Dictionary<BattleshipSide, BattleshipPlayerState> _players;
    private readonly Random _random;

    public BattleshipMatch()
        : this(random: null)
    {
    }

    public BattleshipMatch(Random? random)
    {
        _random = random ?? new Random();
        _players = new Dictionary<BattleshipSide, BattleshipPlayerState>
        {
            [BattleshipSide.PlayerOne] = new(
                "player-1",
                BattleshipSide.PlayerOne,
                BattleshipBoard.CreateEmpty(),
                new Dictionary<Coordinate, CellState>(),
                Ready: false,
                PlacementCursor: 0),
            [BattleshipSide.PlayerTwo] = new(
                "player-2",
                BattleshipSide.PlayerTwo,
                BattleshipBoard.CreateEmpty(),
                new Dictionary<Coordinate, CellState>(),
                Ready: false,
                PlacementCursor: 0)
        };

        CurrentTurn = BattleshipSide.PlayerOne;
        Phase = MatchPhase.Placement;
        LastEvent = "Placement phase initialized. Each player must place their fleet.";
    }

    public static IReadOnlyList<ShipDefinition> Fleet => FleetDefinition;

    public MatchPhase Phase { get; private set; }

    public BattleshipSide CurrentTurn { get; private set; }

    public string LastEvent { get; private set; }

    public BattleshipSide? Winner { get; private set; }

    public BattleshipPrivateView BuildPrivateView(BattleshipSide side)
    {
        var player = GetPlayer(side);
        var opponent = GetOpponent(side);
        var summary = BuildSummaryForSide(side, player, opponent);

        return new BattleshipPrivateView(
            player.PlayerKey,
            Phase.ToString().ToLowerInvariant(),
            CurrentTurn == side,
            summary,
            LastEvent,
            BuildPlacementStatus(player),
            player.PlacementCursor < FleetDefinition.Count ? FleetDefinition[player.PlacementCursor].Name : null,
            player.PlacementCursor < FleetDefinition.Count ? FleetDefinition[player.PlacementCursor].Length : null,
            player.OwnBoard.RenderOwnBoard(),
            RenderTargetBoard(player.ShotsAtOpponent),
            player.OwnBoard.RemainingShipCells,
            opponent.OwnBoard.RemainingShipCells,
            Winner is null ? null : GetPlayer(Winner.Value).PlayerKey);
    }

    public BattleshipSharedView BuildSharedView()
    {
        var activePlayer = GetPlayer(CurrentTurn);
        var summary = Phase switch
        {
            MatchPhase.Completed => $"{GetPlayer(Winner!.Value).PlayerKey} won the match.",
            MatchPhase.Placement => "Both players are placing ships.",
            _ => $"{activePlayer.PlayerKey} is the active player."
        };

        return new BattleshipSharedView(
            Phase.ToString().ToLowerInvariant(),
            summary,
            LastEvent,
            activePlayer.PlayerKey,
            BuildSharedPlacementStatus(),
            Winner is null ? null : GetPlayer(Winner.Value).PlayerKey);
    }

    public void PlaceShip(BattleshipSide side, string placement)
    {
        if (Phase != MatchPhase.Placement)
        {
            throw new InvalidOperationException("Ship placement is only allowed during the placement phase.");
        }

        var player = GetPlayer(side);
        if (player.Ready)
        {
            throw new InvalidOperationException("A ready player cannot change ship placement.");
        }

        if (player.PlacementCursor >= FleetDefinition.Count)
        {
            throw new InvalidOperationException("All ships have already been placed for this player.");
        }

        if (string.IsNullOrWhiteSpace(placement))
        {
            throw new InvalidOperationException("A placement action requires an argument such as A1:H or B4:V.");
        }

        var parts = placement.Split(':', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
        {
            throw new InvalidOperationException("Placement must be formatted like A1:H or B4:V.");
        }

        var start = Coordinate.Parse(parts[0]);
        var orientation = ParseOrientation(parts[1]);
        var ship = FleetDefinition[player.PlacementCursor];

        player.OwnBoard.PlaceShip(ship.Name, start, orientation, ship.Length);
        _players[side] = player with { PlacementCursor = player.PlacementCursor + 1 };
        LastEvent = $"{player.PlayerKey} placed {ship.Name} at {start} ({orientation}).";
    }

    public void ConfirmReady(BattleshipSide side)
    {
        if (Phase != MatchPhase.Placement)
        {
            throw new InvalidOperationException("Readiness can only be confirmed during the placement phase.");
        }

        var player = GetPlayer(side);
        if (player.Ready)
        {
            throw new InvalidOperationException($"{player.PlayerKey} already confirmed readiness.");
        }

        if (player.PlacementCursor < FleetDefinition.Count)
        {
            var remaining = FleetDefinition.Count - player.PlacementCursor;
            throw new InvalidOperationException($"{player.PlayerKey} still has {remaining} ships to place.");
        }

        _players[side] = player with { Ready = true };
        LastEvent = $"{player.PlayerKey} confirmed readiness.";

        if (_players.Values.All(p => p.Ready))
        {
            Phase = MatchPhase.Playing;
            CurrentTurn = BattleshipSide.PlayerOne;
            LastEvent = "Both players are ready. Player 1 fires first.";
        }
    }

    public void AutoPlaceRemainingFleet(BattleshipSide side)
    {
        if (Phase != MatchPhase.Placement)
        {
            throw new InvalidOperationException("Automatic placement is only allowed during the placement phase.");
        }

        var player = GetPlayer(side);
        if (player.Ready)
        {
            throw new InvalidOperationException("A ready player cannot change ship placement.");
        }

        while (player.PlacementCursor < FleetDefinition.Count)
        {
            var ship = FleetDefinition[player.PlacementCursor];
            var placed = false;

            for (var attempt = 0; attempt < 500 && !placed; attempt++)
            {
                var orientation = _random.Next(2) == 0 ? ShipOrientation.Horizontal : ShipOrientation.Vertical;
                var coordinate = new Coordinate(_random.Next(10), _random.Next(10));

                if (!player.OwnBoard.CanPlaceShip(coordinate, orientation, ship.Length))
                {
                    continue;
                }

                player.OwnBoard.PlaceShip(ship.Name, coordinate, orientation, ship.Length);
                player = player with { PlacementCursor = player.PlacementCursor + 1 };
                _players[side] = player;
                placed = true;
            }

            if (!placed)
            {
                throw new InvalidOperationException($"Automatic placement failed for {player.PlayerKey} while placing {ship.Name}.");
            }
        }

        LastEvent = $"{player.PlayerKey} auto-placed the remaining fleet.";
    }

    public void FireShot(BattleshipSide side, string coordinateText)
    {
        if (Phase != MatchPhase.Playing)
        {
            throw new InvalidOperationException("Cannot fire before the match is in playing state.");
        }

        if (CurrentTurn != side)
        {
            throw new InvalidOperationException("It is not this player's turn.");
        }

        if (string.IsNullOrWhiteSpace(coordinateText))
        {
            throw new InvalidOperationException("A fire action requires a target coordinate such as A1.");
        }

        var coordinate = Coordinate.Parse(coordinateText);
        var player = GetPlayer(side);
        var opponent = GetOpponent(side);

        if (player.ShotsAtOpponent.ContainsKey(coordinate))
        {
            throw new InvalidOperationException($"Coordinate {coordinate} has already been fired upon.");
        }

        var outcome = opponent.OwnBoard.ApplyShot(coordinate, out var sunkShip);
        player.ShotsAtOpponent[coordinate] = outcome is ShotOutcome.Miss ? CellState.Miss : CellState.Hit;

        LastEvent = outcome switch
        {
            ShotOutcome.Miss => $"{player.PlayerKey} fired at {coordinate} and missed.",
            ShotOutcome.Hit => $"{player.PlayerKey} fired at {coordinate} and scored a hit.",
            ShotOutcome.Sunk => $"{player.PlayerKey} fired at {coordinate} and sank {opponent.PlayerKey}'s {sunkShip!.Name}.",
            ShotOutcome.Victory => $"{player.PlayerKey} fired at {coordinate}, destroyed the final ship, and won the match.",
            _ => LastEvent
        };

        if (outcome == ShotOutcome.Victory)
        {
            Phase = MatchPhase.Completed;
            Winner = side;
            return;
        }

        CurrentTurn = OpponentOf(side);
    }

    private BattleshipPlayerState GetPlayer(BattleshipSide side) => _players[side];

    private BattleshipPlayerState GetOpponent(BattleshipSide side) => _players[OpponentOf(side)];

    private string BuildSummaryForSide(BattleshipSide side, BattleshipPlayerState player, BattleshipPlayerState opponent)
    {
        if (Phase == MatchPhase.Completed)
        {
            return Winner == side
                ? $"{player.PlayerKey} won. Enemy fleet destroyed."
                : $"{player.PlayerKey} lost. Enemy fleet survived with {opponent.OwnBoard.RemainingShipCells} ship cells remaining.";
        }

        if (Phase == MatchPhase.Placement)
        {
            if (player.PlacementCursor < FleetDefinition.Count)
            {
                var nextShip = FleetDefinition[player.PlacementCursor];
                return $"{player.PlayerKey} is placing ships. Next ship: {nextShip.Name} ({nextShip.Length}).";
            }

            return player.Ready
                ? $"{player.PlayerKey} is ready. Waiting for the other player."
                : $"{player.PlayerKey} has placed the full fleet and can confirm readiness.";
        }

        return CurrentTurn == side
            ? $"{player.PlayerKey} is active. Choose a target on the enemy grid."
            : $"{player.PlayerKey} is waiting. Enemy board remains hidden except for known shot results.";
    }

    private string BuildPlacementStatus(BattleshipPlayerState player)
    {
        if (player.PlacementCursor >= FleetDefinition.Count)
        {
            return player.Ready ? "fleet-ready" : "fleet-complete";
        }

        return $"{player.PlacementCursor}/{FleetDefinition.Count}-placed";
    }

    private string BuildSharedPlacementStatus()
    {
        var playerOne = GetPlayer(BattleshipSide.PlayerOne);
        var playerTwo = GetPlayer(BattleshipSide.PlayerTwo);

        return $"p1:{BuildPlacementStatus(playerOne)} p2:{BuildPlacementStatus(playerTwo)}";
    }

    private static BattleshipSide OpponentOf(BattleshipSide side) =>
        side == BattleshipSide.PlayerOne ? BattleshipSide.PlayerTwo : BattleshipSide.PlayerOne;

    private static string RenderTargetBoard(IReadOnlyDictionary<Coordinate, CellState> shots)
    {
        var builder = new System.Text.StringBuilder();

        for (var row = 0; row < 10; row++)
        {
            if (row > 0)
            {
                builder.Append('|');
            }

            for (var column = 0; column < 10; column++)
            {
                var coordinate = new Coordinate(row, column);
                builder.Append(shots.TryGetValue(coordinate, out var state)
                    ? state switch
                    {
                        CellState.Hit => 'X',
                        CellState.Miss => 'o',
                        _ => '?'
                    }
                    : '.');
            }
        }

        return builder.ToString();
    }

    private static ShipOrientation ParseOrientation(string value) =>
        value.Trim().ToUpperInvariant() switch
        {
            "H" => ShipOrientation.Horizontal,
            "V" => ShipOrientation.Vertical,
            _ => throw new InvalidOperationException("Orientation must be H or V.")
        };
}
