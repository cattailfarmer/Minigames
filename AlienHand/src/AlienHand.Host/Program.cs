using AlienHand.Contracts;
using AlienHand.Core;
using BattleshipAH.AlienHandAdapter;

var gameSession = BattleshipSession.CreateDefault();
var coordinator = new SessionCoordinator(gameSession);

coordinator.AssignStation(
    new StationId("station-p1"),
    new PlayerId("player-1"),
    new EndpointId("host-local"),
    new[]
    {
        new InputChannelDescriptor(new DeviceId("keyboard-1"), InputDeviceKind.Keyboard, "primary")
    });

coordinator.AssignStation(
    new StationId("station-p2"),
    new PlayerId("player-2"),
    new EndpointId("endpoint-lan-1"),
    new[]
    {
        new InputChannelDescriptor(new DeviceId("gamepad-1"), InputDeviceKind.Gamepad, "primary")
    });

Console.WriteLine("AlienHand Host");
Console.WriteLine("==============");
Console.WriteLine($"Session: {gameSession.SessionId}");
Console.WriteLine($"Game: {gameSession.GameKey}");
Console.WriteLine();

PrintViews("Initial station views");

PlaceFleet(new StationId("station-p1"), new[] { "A1:H", "C4:V", "F2:H", "G8:V", "J6:H" });
PrintViews("After Player 1 places fleet");

PlaceFleet(new StationId("station-p2"), new[] { "B9:V", "D2:H", "G5:V", "I7:H", "A1:V" });
PrintViews("After Player 2 places fleet");

coordinator.HandleInput(new StationInputEvent(gameSession.SessionId, new StationId("station-p1"), "ready"));
coordinator.HandleInput(new StationInputEvent(gameSession.SessionId, new StationId("station-p2"), "ready"));
PrintViews("After both players confirm readiness");

coordinator.HandleInput(new StationInputEvent(gameSession.SessionId, new StationId("station-p1"), "fire", "B9"));
PrintViews("After Player 1 fires at B9");

coordinator.HandleInput(new StationInputEvent(gameSession.SessionId, new StationId("station-p2"), "fire", "A1"));
PrintViews("After Player 2 fires at A1");

Console.WriteLine();
Console.WriteLine("Host shell now demonstrates bounded private views across real Battleship turn state.");

void PlaceFleet(StationId stationId, IEnumerable<string> placements)
{
    foreach (var placement in placements)
    {
        coordinator.HandleInput(new StationInputEvent(gameSession.SessionId, stationId, "place", placement));
    }
}

void PrintViews(string title)
{
    Console.WriteLine(title);
    Console.WriteLine(new string('-', title.Length));

    foreach (var assignment in coordinator.Assignments)
    {
        var view = coordinator.BuildView(assignment.StationId);
        Console.WriteLine($"{assignment.StationId}: {view.Summary}");
        Console.WriteLine($"  turn={view.Fields["turn"]} phase={view.Fields["phase"]}");
        Console.WriteLine($"  last_event={view.Fields["last_event"]}");
        Console.WriteLine($"  target_board={view.Fields["target_board"]}");
    }

    Console.WriteLine();
}
