namespace Tutorial3;

public class Container
{
    public double Mass { get; protected set; }
    public int Height { get; private set; }
    public double TareWeight { get; private set; }
    public int Depth { get; private set; }
    public string SerialNumber { get; private set; }
    public double MaxPayload { get; private set; }
    
    protected Container(string serialNumber, double maxPayload, int height, double tareWeight, int depth)
    {
        SerialNumber = serialNumber;
        MaxPayload = maxPayload;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
    }

    public void Load()
    {
        throw new NotImplementedException();
    }
    public void Unload();
    {
        throw new NotImplementedException();
    }

}