using AlienHand.Contracts;

var endpointId = args.Length > 0 ? args[0] : "endpoint-lan-1";
var stationId = args.Length > 1 ? args[1] : "station-p2";

var hello = new EndpointDescriptor(new EndpointId(endpointId), "LAN PC Endpoint", EndpointKind.LanPc);

Console.WriteLine("AlienHand Endpoint");
Console.WriteLine("==================");
Console.WriteLine($"Endpoint: {hello.EndpointId}");
Console.WriteLine($"Kind: {hello.Kind}");
Console.WriteLine($"Assigned station (placeholder): {stationId}");
Console.WriteLine();
Console.WriteLine("This shell will later connect to the host and render bounded station views.");
