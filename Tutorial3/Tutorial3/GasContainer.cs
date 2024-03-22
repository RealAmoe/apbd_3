namespace Tutorial3;

public class GasContainer : ContainerBase, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(int number, double pressure) : base("G", number)
    {
        this.Pressure = pressure;
    }

    public override void LoadCargo(double cargoMass)
    {
        if (cargoMass > MaxPayload)
        {
            throw new OverfillException($"Attempt to overfill a gas container (Serial: {SerialNumber}). Max allowed: {MaxPayload}, Attempted: {cargoMass}.");
        }
        this.Mass = cargoMass;
    }

    public override void EmptyCargo()
    {
        this.Mass *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification for {SerialNumber}: {message}");
    }
}
