using BattleshipAH.Core;

var match = new BattleshipMatch();
var playerOne = BattleshipSide.PlayerOne;
var playerTwo = BattleshipSide.PlayerTwo;

RunPlacementForSide(playerOne);
RunPlacementForSide(playerTwo);
RunCombatLoop();
RunCompletionScreens();

void RunPlacementForSide(BattleshipSide side)
{
    while (match.Phase == MatchPhase.Placement)
    {
        var view = match.BuildPrivateView(side);
        if (view.PlacementStatus == "fleet-ready")
        {
            return;
        }

        ShowTransitionScreen(
            "Placement Handoff",
            $"{DisplayName(side)}: prepare to place your fleet.",
            "Keep the board private before continuing.");
        BeginPrivateScreen(view.PlayerKey, "placement");
        RenderPrivateView(view);

        if (view.PlacementStatus == "fleet-complete")
        {
            Console.Write("Type READY to confirm your fleet: ");
            var input = Console.ReadLine()?.Trim();

            if (!string.Equals(input, "READY", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            TryAction(() => match.ConfirmReady(side));
            continue;
        }

        Console.Write($"Place {view.NextShipName} ({view.NextShipLength}) using format A1:H or B4:V, or type AUTO: ");
        var placement = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(placement))
        {
            continue;
        }

        if (string.Equals(placement, "AUTO", StringComparison.OrdinalIgnoreCase))
        {
            TryAction(() => match.AutoPlaceRemainingFleet(side));
            continue;
        }

        TryAction(() => match.PlaceShip(side, placement));
    }
}

void RunCombatLoop()
{
    while (match.Phase == MatchPhase.Playing)
    {
        var side = match.CurrentTurn;
        var view = match.BuildPrivateView(side);

        ShowTransitionScreen(
            "Turn Handoff",
            $"{DisplayName(side)}: take the controls.",
            "The next screen contains private board state.");
        BeginPrivateScreen(view.PlayerKey, "combat");
        RenderPrivateView(view);

        Console.Write("Fire at target coordinate (example A1): ");
        var target = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(target))
        {
            continue;
        }

        if (!TryAction(() => match.FireShot(side, target)))
        {
            continue;
        }

        ShowSharedResolutionScreen();
    }
}

void RunCompletionScreens()
{
    var shared = match.BuildSharedView();
    ShowTransitionScreen(
        "Match Complete",
        shared.Summary,
        shared.LastEvent);

    foreach (var side in new[] { playerOne, playerTwo })
    {
        var view = match.BuildPrivateView(side);
        ShowTransitionScreen(
            "Final Reveal",
            $"{DisplayName(side)}: review your final board.",
            "The next screen is private again.");
        BeginPrivateScreen(view.PlayerKey, "final");
        RenderPrivateView(view);
        Console.WriteLine();
        Console.WriteLine(view.Summary);
        PauseForHandoff();
    }
}

bool TryAction(Action action)
{
    try
    {
        action();
        return true;
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine();
        Console.WriteLine($"[rule] {ex.Message}");
        PauseForContinue();
        return false;
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine();
        Console.WriteLine($"[input] {ex.Message}");
        PauseForContinue();
        return false;
    }
}

void BeginPrivateScreen(string playerKey, string mode)
{
    Console.Clear();
    Console.WriteLine("AlienHand Battleship-AH");
    Console.WriteLine("=======================");
    Console.WriteLine($"private station: {playerKey}");
    Console.WriteLine($"mode: {mode}");
    Console.WriteLine();
}

void PauseForContinue()
{
    Console.WriteLine();
    Console.Write("Press ENTER to continue...");
    Console.ReadLine();
}

void PauseForHandoff()
{
    Console.WriteLine();
    Console.Write("Press ENTER when the next player is ready...");
    Console.ReadLine();
}

void ShowSharedResolutionScreen()
{
    var shared = match.BuildSharedView();
    ShowTransitionScreen(
        "Shot Resolution",
        shared.LastEvent,
        shared.Summary);
}

void ShowTransitionScreen(string title, params string[] lines)
{
    Console.Clear();
    Console.WriteLine("AlienHand Battleship-AH");
    Console.WriteLine("=======================");
    Console.WriteLine(title);
    Console.WriteLine(new string('-', title.Length));
    Console.WriteLine();

    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }

    Console.WriteLine();
    Console.Write("Press ENTER to continue...");
    Console.ReadLine();
}

void RenderPrivateView(BattleshipPrivateView view)
{
    Console.WriteLine(view.Summary);
    Console.WriteLine($"phase: {view.Phase}");
    Console.WriteLine($"last event: {view.LastEvent}");
    Console.WriteLine($"placement: {view.PlacementStatus}");
    Console.WriteLine($"next ship: {view.NextShipName ?? "-"} ({view.NextShipLength?.ToString() ?? "-"})");
    Console.WriteLine($"own remaining cells: {view.OwnRemainingShipCells}");
    Console.WriteLine($"opponent remaining cells: {view.OpponentRemainingShipCells}");
    Console.WriteLine($"fleet: {string.Join(", ", BattleshipMatch.Fleet.Select(ship => $"{ship.Name}:{ship.Length}"))}");
    Console.WriteLine();
    Console.WriteLine("Own Board");
    Console.WriteLine(RenderBoard(view.OwnBoard));
    Console.WriteLine();
    Console.WriteLine("Target Board");
    Console.WriteLine(RenderBoard(view.TargetBoard));
}

string RenderBoard(string packedBoard)
{
    var rows = packedBoard.Split('|', StringSplitOptions.None);
    var builder = new System.Text.StringBuilder();

    builder.Append("    1 2 3 4 5 6 7 8 9 10").AppendLine();
    builder.Append("  +---------------------+").AppendLine();

    for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
    {
        builder.Append((char)('A' + rowIndex)).Append(" |");

        foreach (var cell in rows[rowIndex])
        {
            builder.Append(' ').Append(RenderCell(cell));
        }

        builder.Append(" |").AppendLine();
    }

    builder.Append("  +---------------------+");
    return builder.ToString();
}

static char RenderCell(char cell) =>
    cell switch
    {
        'S' => '#',
        'X' => 'X',
        'o' => 'o',
        _ => '.'
    };

static string DisplayName(BattleshipSide side) =>
    side == BattleshipSide.PlayerOne ? "Player 1" : "Player 2";
