namespace Tutorial3;

public interface IContainer
{
    double Mass { get; set; }
    int Height { get; set; }
    double TareWeight { get; set; }
    int Depth { get; set; }
    string SerialNumber { get; }
    double MaxPayload { get; set; }

    void LoadCargo(double cargoMass);
    void EmptyCargo();
}
