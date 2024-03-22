namespace Tutorial3;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(int number, bool isHazardous) : base("L", number)
    {
        this.IsHazardous = isHazardous;
    }

    public override void LoadCargo(double cargoMass)
    {
        double allowedCapacity = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (cargoMass > allowedCapacity)
        {
            throw new OverfillException($"Attempt to overfill a liquid container (Serial: {SerialNumber}). Max allowed: {allowedCapacity}, Attempted: {cargoMass}.");
        }
        this.Mass = cargoMass;
    }

    public override void EmptyCargo()
    {
        this.Mass = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification for {SerialNumber}: {message}");
    }
}
