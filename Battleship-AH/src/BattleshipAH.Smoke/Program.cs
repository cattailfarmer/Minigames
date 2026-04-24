using BattleshipAH.Core;

var playerOne = BattleshipSide.PlayerOne;
var playerTwo = BattleshipSide.PlayerTwo;

Console.WriteLine("Battleship-AH Smoke");
Console.WriteLine("===================");
Console.WriteLine();

RunInvalidPlacementChecks();
RunPlayableMatchChecks();

Console.WriteLine();
Console.WriteLine("Smoke checks completed.");

void RunInvalidPlacementChecks()
{
    Console.WriteLine("Scenario: invalid placement checks");
    Console.WriteLine("----------------------------------");

    var match = new BattleshipMatch();
    ExpectThrows(
        "out-of-bounds placement is rejected",
        () => match.PlaceShip(playerOne, "J8:H"),
        "Cannot place ship");
    ExpectThrows(
        "readiness before full fleet placement is rejected",
        () => match.ConfirmReady(playerOne),
        "still has 5 ships to place");

    match.PlaceShip(playerOne, "A1:H");
    ExpectThrows(
        "overlapping placement is rejected",
        () => match.PlaceShip(playerOne, "A1:V"),
        "Cannot place ship");
    match.AutoPlaceRemainingFleet(playerTwo);
    ExpectEqual(
        "automatic fleet placement completes the full roster",
        "fleet-complete",
        match.BuildPrivateView(playerTwo).PlacementStatus);

    ExpectEqual(
        "player one still has only the carrier placed after rejected placements",
        "1/5-placed",
        match.BuildPrivateView(playerOne).PlacementStatus);

    Console.WriteLine();
}

void RunPlayableMatchChecks()
{
    Console.WriteLine("Scenario: full playable flow");
    Console.WriteLine("----------------------------");

    var match = new BattleshipMatch();

    var playerOnePlacements = new[] { "A1:H", "C4:V", "F6:H", "H8:V", "J1:H" };
    var playerTwoPlacements = new[] { "B9:V", "D2:H", "G5:V", "I7:H", "A1:V" };

    PlaceFleet(match, playerOne, playerOnePlacements);
    PlaceFleet(match, playerTwo, playerTwoPlacements);

    ExpectEqual("placement remains active until readiness", MatchPhase.Placement, match.Phase);

    match.ConfirmReady(playerOne);
    ExpectEqual("phase stays in placement until both players are ready", MatchPhase.Placement, match.Phase);
    ExpectThrows(
        "ready player cannot re-confirm",
        () => match.ConfirmReady(playerOne),
        "already confirmed readiness");
    ExpectThrows(
        "ready player cannot place extra ships",
        () => match.PlaceShip(playerOne, "J8:H"),
        "cannot change ship placement");

    match.ConfirmReady(playerTwo);
    ExpectEqual("phase advances to playing after both players confirm", MatchPhase.Playing, match.Phase);
    ExpectEqual("player one starts the match", playerOne, match.CurrentTurn);

    ExpectThrows(
        "out-of-turn firing is rejected",
        () => match.FireShot(playerTwo, "J10"),
        "not this player's turn");

    match.FireShot(playerOne, "B9");
    ExpectEqual("first shot lands as a hit", "player-1 fired at B9 and scored a hit.", match.LastEvent);
    ExpectEqual("turn passes after a valid shot", playerTwo, match.CurrentTurn);

    ExpectThrows(
        "same player cannot fire twice in a row",
        () => match.FireShot(playerOne, "C9"),
        "not this player's turn");

    match.FireShot(playerTwo, "J10");
    ExpectEqual("missed shot is recorded", "player-2 fired at J10 and missed.", match.LastEvent);
    ExpectEqual("turn returns to player one", playerOne, match.CurrentTurn);

    ExpectThrows(
        "duplicate targeting is rejected",
        () => match.FireShot(playerOne, "B9"),
        "already been fired upon");

    PlayTurn(match, playerOne, "C9", expectedLastEvent: "player-1 fired at C9 and scored a hit.");
    PlayTurn(match, playerTwo, "I10", expectedLastEvent: "player-2 fired at I10 and missed.");
    PlayTurn(match, playerOne, "D9", expectedLastEvent: "player-1 fired at D9 and scored a hit.");
    PlayTurn(match, playerTwo, "H10", expectedLastEvent: "player-2 fired at H10 and missed.");
    PlayTurn(match, playerOne, "E9", expectedLastEvent: "player-1 fired at E9 and scored a hit.");
    PlayTurn(match, playerTwo, "G10", expectedLastEvent: "player-2 fired at G10 and missed.");
    PlayTurn(match, playerOne, "F9", expectedLastEvent: "player-1 fired at F9 and sank player-2's Carrier.");
    PlayTurn(match, playerTwo, "F10", expectedLastEvent: "player-2 fired at F10 and missed.");

    RunVictorySequence(
        match,
        new[]
        {
            "D2", "D3", "D4", "D5",
            "G5", "H5", "I5",
            "I7", "I8", "I9",
            "A1", "B1"
        },
        new[]
        {
            "E10", "D10", "C10", "B10",
            "A10", "J9", "I9", "H9",
            "G9", "F8", "E8", "D8"
        });

    ExpectEqual("match completes after final ship cell is destroyed", MatchPhase.Completed, match.Phase);
    ExpectEqual("player one wins the scripted smoke match", playerOne, match.Winner);

    var shared = match.BuildSharedView();
    var playerOneView = match.BuildPrivateView(playerOne);
    var playerTwoView = match.BuildPrivateView(playerTwo);

    ExpectEqual("shared winner is reported", "player-1", shared.WinnerKey);
    ExpectEqual("player one victory view is reported", "player-1", playerOneView.WinnerKey);
    ExpectEqual("player two defeat view is reported", "player-1", playerTwoView.WinnerKey);
    ExpectTrue("player two target board shows a registered miss", playerTwoView.TargetBoard.Contains('o'));
    ExpectTrue("player one target board shows successful hits", playerOneView.TargetBoard.Contains('X'));

    PrintState("Completed match state", shared, playerOneView, playerTwoView);
    Console.WriteLine();
}

void RunVictorySequence(BattleshipMatch match, IReadOnlyList<string> playerOneTargets, IReadOnlyList<string> playerTwoMisses)
{
    if (playerOneTargets.Count != playerTwoMisses.Count)
    {
        throw new InvalidOperationException("Victory sequence requires a matching count of player-one targets and player-two misses.");
    }

    for (var index = 0; index < playerOneTargets.Count; index++)
    {
        match.FireShot(playerOne, playerOneTargets[index]);
        if (match.Phase == MatchPhase.Completed)
        {
            return;
        }

        match.FireShot(playerTwo, playerTwoMisses[index]);
    }
}

void PlayTurn(BattleshipMatch match, BattleshipSide side, string coordinate, string expectedLastEvent)
{
    match.FireShot(side, coordinate);
    ExpectEqual($"shot {side}:{coordinate} resolves correctly", expectedLastEvent, match.LastEvent);
}

void PlaceFleet(BattleshipMatch match, BattleshipSide side, IEnumerable<string> placements)
{
    foreach (var placement in placements)
    {
        match.PlaceShip(side, placement);
    }
}

void PrintState(string title, BattleshipSharedView shared, BattleshipPrivateView playerOneView, BattleshipPrivateView playerTwoView)
{
    Console.WriteLine(title);
    Console.WriteLine(new string('-', title.Length));
    Console.WriteLine($"shared.phase={shared.Phase}");
    Console.WriteLine($"shared.summary={shared.Summary}");
    Console.WriteLine($"shared.last_event={shared.LastEvent}");
    Console.WriteLine($"shared.placement={shared.PlacementStatus}");
    Console.WriteLine($"shared.winner={shared.WinnerKey ?? "-"}");
    PrintPrivate(playerOneView);
    PrintPrivate(playerTwoView);
}

void PrintPrivate(BattleshipPrivateView view)
{
    Console.WriteLine($"{view.PlayerKey}: {view.Summary}");
    Console.WriteLine($"  turn={(view.IsActiveTurn ? "active" : "waiting")} phase={view.Phase}");
    Console.WriteLine($"  placement={view.PlacementStatus} next_ship={view.NextShipName ?? "-"} next_length={view.NextShipLength?.ToString() ?? "-"}");
    Console.WriteLine($"  own_remaining={view.OwnRemainingShipCells} opponent_remaining={view.OpponentRemainingShipCells}");
    Console.WriteLine($"  own_board={view.OwnBoard}");
    Console.WriteLine($"  target_board={view.TargetBoard}");
    Console.WriteLine($"  winner={view.WinnerKey ?? "-"}");
}

void ExpectEqual<T>(string label, T expected, T actual)
{
    if (!EqualityComparer<T>.Default.Equals(expected, actual))
    {
        throw new InvalidOperationException($"{label}: expected '{expected}', got '{actual}'.");
    }

    Console.WriteLine($"PASS {label}");
}

void ExpectTrue(string label, bool condition)
{
    if (!condition)
    {
        throw new InvalidOperationException($"{label}: expected condition to be true.");
    }

    Console.WriteLine($"PASS {label}");
}

void ExpectThrows(string label, Action action, string expectedMessageFragment)
{
    try
    {
        action();
    }
    catch (InvalidOperationException ex) when (ex.Message.Contains(expectedMessageFragment, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"PASS {label}");
        return;
    }

    throw new InvalidOperationException($"{label}: expected InvalidOperationException containing '{expectedMessageFragment}'.");
}
