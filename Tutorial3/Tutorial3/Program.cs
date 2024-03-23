namespace Tutorial3;

using System;
using System.Collections.Generic;

class Program
{
    private static ContainerShipManager shipManager = new ContainerShipManager();
    private static Dictionary<string, IContainer> allContainers = new Dictionary<string, IContainer>();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nContainer Management System");
            Console.WriteLine("1. Add a container ship");
            Console.WriteLine("2. Add a container");
            Console.WriteLine("3. Load a container onto a ship");
            Console.WriteLine("4. Remove a container from a ship");
            Console.WriteLine("5. Transfer a container between ships");
            Console.WriteLine("6. Print ship info");
            Console.WriteLine("7. Print container info");
            Console.WriteLine("8. Load cargo into a container");
            Console.WriteLine("9. Unload cargo from a container");
            Console.WriteLine("10. Exit");
            Console.Write("Select an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddContainerShip();
                    break;
                case 2:
                    AddContainer();
                    break;
                case 3:
                    LoadContainerOntoShip();
                    break;
                case 4:
                    RemoveContainerFromShip();
                    break;
                case 5:
                    TransferContainerBetweenShips();
                    break;
                case 6:
                    PrintShipInfo();
                    break;
                case 7:
                    PrintContainerInfo();
                    break;
                case 8:
                    LoadCargoIntoContainer();
                    break;
                case 9:
                    UnloadContainer();
                    break;
                case 10:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddContainerShip()
    {
        Console.Write("Enter max speed (knots): ");
        int maxSpeed = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter max container count: ");
        int maxContainerCount = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter max weight (tons): ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());

        ContainerShip ship = new ContainerShip(maxSpeed, maxContainerCount, maxWeight);
        
        int shipIndex = shipManager.GetAllShips().Count();

        shipManager.AddShip(ship);
        
        Console.WriteLine($"Container ship added successfully. Ship Index: {shipIndex}");
    }

    static void AddContainer()
    {
        Console.WriteLine("Select container type (L - Liquid, G - Gas, C - Refrigerated): ");
        string type = Console.ReadLine();

        Console.WriteLine("Enter container height (cm): ");
        int height = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter container depth (cm): ");
        int depth = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter tare weight (kg): ");
        double tareWeight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter max payload (kg): ");
        double maxPayload = Convert.ToDouble(Console.ReadLine());

        try
        {
            IContainer newContainer = ContainerFactory.CreateContainer(type, height, depth, tareWeight, maxPayload, AskForHazardous(), AskForPressure(type), AskForProductType(type), AskForTemperature(type));
            allContainers.Add(newContainer.SerialNumber, newContainer);
            Console.WriteLine($"Container created with Serial Number: {newContainer.SerialNumber}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating container: {ex.Message}");
        }
    }

    static void LoadContainerOntoShip()
    {
        Console.Write("Enter the serial number of the container: ");
        string serialNumber = Console.ReadLine();

        Console.Write("Enter the index of the ship: ");
        int shipIndex = Convert.ToInt32(Console.ReadLine());

        try
        {
            if (allContainers.ContainsKey(serialNumber))
            {
                shipManager.AddContainerToShip(allContainers[serialNumber], shipIndex);
                Console.WriteLine($"Container {serialNumber} loaded onto ship {shipIndex}.");
            }
            else
            {
                Console.WriteLine("Container not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading container onto ship: {ex.Message}");
        }
    }

    static void TransferContainerBetweenShips()
    {
        Console.Write("Enter the serial number of the container to transfer: ");
        string serialNumber = Console.ReadLine();

        Console.Write("Enter the index of the source ship: ");
        int fromShipIndex = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the index of the destination ship: ");
        int toShipIndex = Convert.ToInt32(Console.ReadLine());

        try
        {
            shipManager.TransferContainer(serialNumber, fromShipIndex, toShipIndex);
            Console.WriteLine($"Container {serialNumber} transferred from ship {fromShipIndex} to ship {toShipIndex}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error transferring container: {ex.Message}");
        }
    }

    static void LoadCargoIntoContainer()
    {
        Console.Write("Enter the serial number of the container: ");
        string serialNumber = Console.ReadLine();

        Console.Write("Enter the cargo mass to load (in tons): ");
        double cargoMass = Convert.ToDouble(Console.ReadLine());

        try
        {
            if (allContainers.ContainsKey(serialNumber))
            {
                allContainers[serialNumber].LoadCargo(cargoMass);
                Console.WriteLine($"Cargo of {cargoMass} tons loaded into container {serialNumber} successfully.");
            }
            else
            {
                Console.WriteLine("Container not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading cargo into container: {ex.Message}");
        }
    }

    static void UnloadContainer()
    {
        Console.Write("Enter the serial number of the container to unload: ");
        string serialNumber = Console.ReadLine();

        if (allContainers.ContainsKey(serialNumber))
        {
            allContainers[serialNumber].EmptyCargo();
            Console.WriteLine($"Container {serialNumber} has been successfully unloaded.");
        }
        else
        {
            Console.WriteLine("Container not found.");
        }
    }

    static void RemoveContainerFromShip()
    {
        Console.Write("Enter the serial number of the container to remove: ");
        string serialNumber = Console.ReadLine();

        Console.Write("Enter the index of the ship to remove from: ");
        int shipIndex = Convert.ToInt32(Console.ReadLine());

        try
        {
            shipManager.RemoveContainerFromShip(serialNumber, shipIndex);
            Console.WriteLine($"Container {serialNumber} has been successfully removed from ship {shipIndex}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing container from ship: {ex.Message}");
        }
    }

    static void PrintContainerInfo()
    {
        Console.Write("Enter the serial number of the container to print info for: ");
        string serialNumber = Console.ReadLine();

        if (allContainers.ContainsKey(serialNumber))
        {
            Console.WriteLine(allContainers[serialNumber].ToString());
        }
        else
        {
            Console.WriteLine("Container not found.");
        }
    }

    static void PrintShipInfo()
    {
        Console.Write("Enter the index of the ship to print info for: ");
        int shipIndex = Convert.ToInt32(Console.ReadLine());

        try
        {
            var ship = shipManager.GetShip(shipIndex);
            ship.PrintShipInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error printing ship info: {ex.Message}");
        }
    }

    private static bool AskForHazardous()
    {
        Console.WriteLine("Is it hazardous? (true/false): ");
        return Convert.ToBoolean(Console.ReadLine());
    }

    private static double AskForPressure(string type)
    {
        if (type.ToUpper() == "G")
        {
            Console.WriteLine("Enter pressure (in atmospheres): ");
            return Convert.ToDouble(Console.ReadLine());
        }

        return 0;
    }

    private static string AskForProductType(string type)
    {
        if (type.ToUpper() == "C")
        {
            Console.WriteLine("Enter product type: ");
            return Console.ReadLine();
        }

        return null;
    }

    private static double AskForTemperature(string type)
    {
        if (type.ToUpper() == "C")
        {
            double temperature;
            Console.WriteLine("Enter temperature (°C): ");

            while (!double.TryParse(Console.ReadLine(), out temperature))
            {
                Console.WriteLine("Invalid input. Please enter a valid temperature in °C:");
            }
            return temperature;
        }

        return 0;
    }
}