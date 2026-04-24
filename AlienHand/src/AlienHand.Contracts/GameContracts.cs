namespace AlienHand.Contracts;

public interface IAlienHandGameSession
{
    string GameKey { get; }
    SessionId SessionId { get; }
    SessionPhase Phase { get; }

    IReadOnlyList<StationTemplate> BuildStations();
    LobbySnapshot BuildLobbySnapshot(IReadOnlyList<StationAssignment> assignments);
    StationViewEnvelope BuildViewForStation(StationId stationId);
    void HandleInput(StationInputEvent inputEvent);
}
