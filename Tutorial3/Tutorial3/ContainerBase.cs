namespace Tutorial3;

public abstract class ContainerBase : IContainer
{
    public double Mass { get; set; }
    public int Height { get; set; }
    public double TareWeight { get; set; }
    public int Depth { get; set; }
    protected string serialNumber;
    public string SerialNumber => serialNumber;
    public double MaxPayload { get; set; }

    protected ContainerBase(string type, int number)
    {
        this.serialNumber = $"KON-{type.ToUpper()}-{number}";
    }

    public abstract void LoadCargo(double cargoMass);
    public abstract void EmptyCargo();
}

