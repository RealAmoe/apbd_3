namespace Tutorial3;

using System;
using System.Collections.Generic;
using System.Linq;

public class ContainerShip
{
    public List<IContainer> Containers { get; private set; } = new List<IContainer>();
    public int MaxSpeed { get; private set; }
    public int MaxContainerCount { get; private set; }
    public double MaxWeight { get; private set; }

    public ContainerShip(int maxSpeed, int maxContainerCount, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }

    public void AddContainer(IContainer container)
    {
        if (Containers.Count >= MaxContainerCount || CurrentWeight + container.Mass + container.TareWeight > MaxWeight * 1000)
        {
            throw new InvalidOperationException("Cannot add more containers to the ship due to space or weight limit.");
        }
        Containers.Add(container);
    }

    public bool RemoveContainer(string serialNumber)
    {
        var containerToRemove = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (containerToRemove != null)
        {
            Containers.Remove(containerToRemove);
            return true;
        }
        else
        {
            Console.WriteLine($"Container {serialNumber} not found on the ship.");
            return false;
        }
    }

    public double CurrentWeight => Containers.Sum(c => c.Mass + c.TareWeight);

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Info: Max Speed={MaxSpeed} knots, Max Containers={MaxContainerCount}, Max Weight={MaxWeight} tons, Current Weight={CurrentWeight / 1000} tons");

        if (Containers.Count == 0)
        {
            Console.WriteLine("No containers on board.");
            return;
        }

        foreach (var container in Containers)
        {
            Console.WriteLine(container.ToString());
        }
    }
}
