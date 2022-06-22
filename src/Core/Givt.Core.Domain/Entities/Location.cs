namespace Givt.Core.Domain.Entities;

public class Location : Medium
{
    public string Name { get; set; }
    public float Lat { get; set; }
    public float Lon { get; set; }
    public int Radius { get; set; }
}