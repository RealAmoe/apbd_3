namespace Tutorial3;

using System;
using System.Collections.Generic;
using System.Linq;

public class ContainerShipManager
{
    private List<ContainerShip> ships = new List<ContainerShip>();

    public void AddShip(ContainerShip ship)
    {
        ships.Add(ship);
    }

    public ContainerShip GetShip(int index)
    {
        if (index >= 0 && index < ships.Count)
        {
            return ships[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Ship index is out of range.");
        }
    }
    public IEnumerable<ContainerShip> GetAllShips()
    {
        return ships;
    }

    public void AddContainerToShip(IContainer container, int shipIndex)
    {
        var ship = GetShip(shipIndex);
        ship.AddContainer(container);
    }

    public void TransferContainer(string serialNumber, int fromShipIndex, int toShipIndex)
    {
        var fromShip = GetShip(fromShipIndex);
        var toShip = GetShip(toShipIndex);
        var container = fromShip.Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        
        if (container != null)
        {
            fromShip.RemoveContainer(serialNumber);
            toShip.AddContainer(container);
        }
        else
        {
            throw new InvalidOperationException("Container not found on the source ship.");
        }
    }
    
    public void RemoveContainerFromShip(string serialNumber, int shipIndex)
    {
        if (shipIndex >= 0 && shipIndex < ships.Count)
        {
            ships[shipIndex].RemoveContainer(serialNumber);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Ship index is out of range.");
        }
    }
}
