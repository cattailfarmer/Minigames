using AlienHand.Contracts;

namespace AlienHand.Core;

public sealed class SessionCoordinator
{
    private readonly Dictionary<StationId, StationAssignment> _assignments = new();

    public SessionCoordinator(IAlienHandGameSession gameSession)
    {
        GameSession = gameSession;

        foreach (var template in gameSession.BuildStations())
        {
            _assignments[template.StationId] = new StationAssignment(
                template.StationId,
                PlayerId: null,
                EndpointId: null,
                InputChannels: Array.Empty<InputChannelDescriptor>());
        }
    }

    public IAlienHandGameSession GameSession { get; }

    public IReadOnlyList<StationAssignment> Assignments => _assignments.Values.OrderBy(a => a.StationId.Value).ToList();

    public void AssignStation(StationId stationId, PlayerId playerId, EndpointId endpointId, IReadOnlyList<InputChannelDescriptor>? channels = null)
    {
        if (!_assignments.TryGetValue(stationId, out var current))
        {
            throw new InvalidOperationException($"Unknown station '{stationId}'.");
        }

        _assignments[stationId] = current with
        {
            PlayerId = playerId,
            EndpointId = endpointId,
            InputChannels = channels ?? current.InputChannels
        };
    }

    public LobbySnapshot BuildLobbySnapshot(string sessionName) =>
        GameSession.BuildLobbySnapshot(Assignments) with { SessionName = sessionName };

    public StationViewEnvelope BuildView(StationId stationId) => GameSession.BuildViewForStation(stationId);

    public void HandleInput(StationInputEvent inputEvent) => GameSession.HandleInput(inputEvent);
}
