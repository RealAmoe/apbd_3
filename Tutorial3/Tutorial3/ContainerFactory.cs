namespace Tutorial3;

public static class ContainerFactory
{
    private static int nextSerialNumber = 1;

    public static IContainer CreateContainer(string type, bool isHazardous, double pressure, string productType, double temperature)
    {
        switch (type.ToUpper())
        {
            case "L":
                return new LiquidContainer(nextSerialNumber++, isHazardous);
            case "G":
                return new GasContainer(nextSerialNumber++, pressure);
            case "C":
                return new RefrigeratedContainer(nextSerialNumber++, productType, temperature);
            default:
                throw new ArgumentException("Invalid container type specified.");
        }
    }
}
