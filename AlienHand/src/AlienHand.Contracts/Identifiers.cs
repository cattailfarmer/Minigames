namespace AlienHand.Contracts;

public readonly record struct SessionId(string Value)
{
    public static SessionId New() => new(Guid.NewGuid().ToString("N"));
    public override string ToString() => Value;
}

public readonly record struct PlayerId(string Value)
{
    public override string ToString() => Value;
}

public readonly record struct StationId(string Value)
{
    public override string ToString() => Value;
}

public readonly record struct EndpointId(string Value)
{
    public override string ToString() => Value;
}

public readonly record struct DeviceId(string Value)
{
    public override string ToString() => Value;
}
