namespace Tutorial3;

using System;
using System.Collections.Generic;

class Program
{
    private static ContainerShipManager shipManager = new ContainerShipManager();
    private static int containerNumber = 1;

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nContainer Management System");
            Console.WriteLine("1. Add a container ship");
            Console.WriteLine("2. Add a container");
            Console.WriteLine("3. Load a container onto a ship");
            Console.WriteLine("4. Transfer a container between ships");
            Console.WriteLine("5. Print ship info");
            Console.WriteLine("6. Exit");
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
                    TransferContainerBetweenShips();
                    break;
                case 5:
                    PrintShipInfo();
                    break;
                case 6:
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
        shipManager.AddShip(ship);
        Console.WriteLine("Container ship added successfully.");
    }

    static void AddContainer()
    {
        Console.WriteLine("Select container type (L - Liquid, G - Gas, C - Refrigerated): ");
        string type = Console.ReadLine();

        switch (type.ToUpper())
        {
            case "L":
                Console.WriteLine("Is it hazardous? (true/false): ");
                bool isHazardous = Convert.ToBoolean(Console.ReadLine());
                var liquidContainer = ContainerFactory.CreateContainer(type, isHazardous, 0, null, 0);
                Console.WriteLine($"Liquid container created with Serial Number: {liquidContainer.SerialNumber}");
                break;
            case "G":
                Console.WriteLine("Enter pressure (in atmospheres): ");
                double pressure = Convert.ToDouble(Console.ReadLine());
                var gasContainer = ContainerFactory.CreateContainer(type, false, pressure, null, 0);
                Console.WriteLine($"Gas container created with Serial Number: {gasContainer.SerialNumber}");
                break;
            case "C":
                Console.WriteLine("Enter product type: ");
                string productType = Console.ReadLine();
                Console.WriteLine("Enter temperature (°C): ");
                double temperature = Convert.ToDouble(Console.ReadLine());
                var refrigeratedContainer = ContainerFactory.CreateContainer(type, false, 0, productType, temperature);
                Console.WriteLine($"Refrigerated container created with Serial Number: {refrigeratedContainer.SerialNumber}");
                break;
            default:
                Console.WriteLine("Invalid container type.");
                return;
        }
        containerNumber++;
    }

    static void LoadContainerOntoShip()
    {
        Console.Write("Enter the serial number of the container: ");
        string serialNumber = Console.ReadLine();

        Console.Write("Enter the index of the ship: ");
        int shipIndex = Convert.ToInt32(Console.ReadLine());

        // Here, add logic to load the specified container onto the specified ship
        // This might involve locating the container by serial number, then using the ship manager to add it to the ship
    }

    static void TransferContainerBetweenShips()
    {
        Console.Write("Enter the serial number of the container to transfer: ");
        string serialNumber = Console.ReadLine();

        Console.Write("Enter the index of the source ship: ");
        int fromShipIndex = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the index of the destination ship: ");
        int toShipIndex = Convert.ToInt32(Console.ReadLine());

        shipManager.TransferContainer(serialNumber, fromShipIndex, toShipIndex);
        Console.WriteLine("Container transferred successfully.");
    }

    static void PrintShipInfo()
    {
        Console.Write("Enter the index of the ship to print info for: ");
        int shipIndex = Convert.ToInt32(Console.ReadLine());

        var ship = shipManager.GetShip(shipIndex);
        ship.PrintShipInfo();
    }
}
