namespace Tutorial3;

public class RefrigeratedContainer : ContainerBase
{
    public string ProductType { get; private set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(int number, string productType, double temperature) : base("C", number)
    {
        this.ProductType = productType;
        this.Temperature = temperature;
    }

    public override void LoadCargo(double cargoMass)
    {
        if (cargoMass > MaxPayload)
        {
            throw new OverfillException($"Attempt to overfill a refrigerated container (Serial: {SerialNumber}). Max allowed: {MaxPayload}, Attempted: {cargoMass}.");
        }
        this.Mass = cargoMass;
    }

    public override void EmptyCargo()
    {
        this.Mass = 0;
    }
}
