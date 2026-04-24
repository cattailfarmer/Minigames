using System.Text;

namespace BattleshipAH.Core;

public enum CellState
{
    Unknown,
    Water,
    Ship,
    Hit,
    Miss
}

public enum MatchPhase
{
    Placement,
    Playing,
    Completed
}

public enum ShotOutcome
{
    Miss,
    Hit,
    Sunk,
    Victory
}

public enum ShipOrientation
{
    Horizontal,
    Vertical
}

public enum BattleshipSide
{
    PlayerOne,
    PlayerTwo
}

public readonly record struct Coordinate(int Row, int Column)
{
    public override string ToString() => $"{(char)('A' + Row)}{Column + 1}";

    public static Coordinate Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Coordinate value is required.", nameof(value));
        }

        var trimmed = value.Trim().ToUpperInvariant();
        var row = trimmed[0] - 'A';
        if (row < 0 || row > 9)
        {
            throw new ArgumentException($"Invalid row in coordinate '{value}'.", nameof(value));
        }

        if (!int.TryParse(trimmed[1..], out var columnOneBased))
        {
            throw new ArgumentException($"Invalid column in coordinate '{value}'.", nameof(value));
        }

        var column = columnOneBased - 1;
        if (column < 0 || column > 9)
        {
            throw new ArgumentException($"Invalid column in coordinate '{value}'.", nameof(value));
        }

        return new Coordinate(row, column);
    }
}

public sealed record ShipDefinition(string Name, int Length);

public sealed record ShipPlacement(string Name, IReadOnlyList<Coordinate> Coordinates)
{
    public bool IsSunk(IReadOnlyDictionary<Coordinate, CellState> cells) =>
        Coordinates.All(coordinate => cells[coordinate] == CellState.Hit);
}

public sealed class BattleshipBoard
{
    private readonly Dictionary<Coordinate, CellState> _cells;

    public BattleshipBoard(Dictionary<Coordinate, CellState> cells, IReadOnlyList<ShipPlacement> ships)
    {
        _cells = cells;
        Ships = ships;
    }

    public IReadOnlyDictionary<Coordinate, CellState> Cells => _cells;

    public IReadOnlyList<ShipPlacement> Ships { get; private set; }

    public static BattleshipBoard CreateEmpty()
    {
        var cells = new Dictionary<Coordinate, CellState>();
        for (var row = 0; row < 10; row++)
        {
            for (var column = 0; column < 10; column++)
            {
                cells[new Coordinate(row, column)] = CellState.Water;
            }
        }

        return new BattleshipBoard(cells, Array.Empty<ShipPlacement>());
    }

    public int RemainingShipCells => _cells.Count(cell => cell.Value == CellState.Ship);

    public bool HasBeenTargeted(Coordinate coordinate) => _cells[coordinate] is CellState.Hit or CellState.Miss;

    public bool CanPlaceShip(Coordinate start, ShipOrientation orientation, int length)
    {
        foreach (var coordinate in BuildCoordinates(start, orientation, length))
        {
            if (!_cells.TryGetValue(coordinate, out var state) || state != CellState.Water)
            {
                return false;
            }
        }

        return true;
    }

    public void PlaceShip(string shipName, Coordinate start, ShipOrientation orientation, int length)
    {
        if (!CanPlaceShip(start, orientation, length))
        {
            throw new InvalidOperationException($"Cannot place ship '{shipName}' at {start} with {orientation} orientation.");
        }

        var coordinates = BuildCoordinates(start, orientation, length).ToArray();
        foreach (var coordinate in coordinates)
        {
            _cells[coordinate] = CellState.Ship;
        }

        var placements = Ships.ToList();
        placements.Add(new ShipPlacement(shipName, coordinates));
        Ships = placements;
    }

    public ShotOutcome ApplyShot(Coordinate coordinate, out ShipPlacement? sunkShip)
    {
        if (HasBeenTargeted(coordinate))
        {
            throw new InvalidOperationException($"Coordinate {coordinate} has already been targeted.");
        }

        if (_cells[coordinate] == CellState.Ship)
        {
            _cells[coordinate] = CellState.Hit;
            sunkShip = Ships.FirstOrDefault(ship => ship.Coordinates.Contains(coordinate) && ship.IsSunk(_cells));

            if (RemainingShipCells == 0)
            {
                return ShotOutcome.Victory;
            }

            return sunkShip is null ? ShotOutcome.Hit : ShotOutcome.Sunk;
        }

        _cells[coordinate] = CellState.Miss;
        sunkShip = null;
        return ShotOutcome.Miss;
    }

    public string RenderOwnBoard()
    {
        var builder = new StringBuilder();

        for (var row = 0; row < 10; row++)
        {
            if (row > 0)
            {
                builder.Append('|');
            }

            for (var column = 0; column < 10; column++)
            {
                var coordinate = new Coordinate(row, column);
                builder.Append(_cells[coordinate] switch
                {
                    CellState.Ship => 'S',
                    CellState.Hit => 'X',
                    CellState.Miss => 'o',
                    _ => '.'
                });
            }
        }

        return builder.ToString();
    }

    private static IEnumerable<Coordinate> BuildCoordinates(Coordinate start, ShipOrientation orientation, int length) =>
        orientation == ShipOrientation.Horizontal
            ? Enumerable.Range(start.Column, length).Select(column => new Coordinate(start.Row, column))
            : Enumerable.Range(start.Row, length).Select(row => new Coordinate(row, start.Column));
}
