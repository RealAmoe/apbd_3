namespace Tutorial3;

public static class ContainerFactory
{
    private static int nextSerialNumber = 1;

    public static IContainer CreateContainer(
        string type,
        int height,
        int depth,
        double tareWeight,
        double maxPayload,
        bool isHazardous = false,
        double pressure = 0,
        string productType = null,
        double temperature = 0)
    {
        switch (type.ToUpper())
        {
            case "L":
                var liquidContainer = new LiquidContainer(GetNextSerialNumber(), isHazardous)
                {
                    Height = height,
                    Depth = depth,
                    TareWeight = tareWeight,
                    MaxPayload = maxPayload
                };
                return liquidContainer;
            case "G":
                var gasContainer = new GasContainer(GetNextSerialNumber(), pressure)
                {
                    Height = height,
                    Depth = depth,
                    TareWeight = tareWeight,
                    MaxPayload = maxPayload
                };
                return gasContainer;
            case "C":
                var refrigeratedContainer = new RefrigeratedContainer(GetNextSerialNumber(), productType, temperature)
                {
                    Height = height,
                    Depth = depth,
                    TareWeight = tareWeight,
                    MaxPayload = maxPayload
                };
                return refrigeratedContainer;
            default:
                throw new ArgumentException("Invalid container type specified.");
        }
    }
    
    private static int GetNextSerialNumber()
    {
        return nextSerialNumber++;
    }
}