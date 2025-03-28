namespace APBD1;

public class Ship(string name, double maxSpeed, int maxContainerNum, double maxWeight)
{
    private string Name { get; } = name;
    private double MaxSpeed { get; } = maxSpeed;
    private int MaxContainerNum { get; } = maxContainerNum;
    private double MaxWeight { get; } = maxWeight;
    private List<Container> Containers { get; } = new List<Container>();

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerNum || TotalWeight() + container.MaxLoad > MaxWeight)
        {
            throw new Exception($"Statek {Name} nie może pomieścić więcej kontenerów lub przekroczono maksymalną wagę.");
        }

        Containers.Add(container);
        Console.WriteLine($"Dodano kontener {container.SerialNumber} na statek {Name}");
    }

    public void LoadContainers(List<Container> newContainers)
    {
        foreach (var container in newContainers)
        {
            LoadContainer(container);
        }
        Console.WriteLine($"Dodano następującą liczbę kontenerów: {newContainers.Count} na statek {Name}");
    }
    
    public bool RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            Console.WriteLine($"Usunięto kontener {serialNumber} ze statku {Name}");
            return true;
        }
        Console.WriteLine($"Nie znaleziono kontenera {serialNumber} na statku {Name}");
        return false;
    }
    
    public bool ReplaceContainer(string oldSerialNumber, Container newContainer)
    {
        var index = Containers.FindIndex(
            c => c.SerialNumber == oldSerialNumber);
        if (index != -1)
        {
            Containers[index] = newContainer;
            Console.WriteLine($"Zastąpiono kontener {oldSerialNumber} kontenerem " +
                              $"{newContainer.SerialNumber} na statku {Name}");
            return true;
        }
        Console.WriteLine($"Nie znaleziono kontenera {oldSerialNumber} na statku {Name}");
        return false;
    }
    
    public bool TransferContainer(Ship targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            if (targetShip.Containers.Count < targetShip.MaxContainerNum && 
                targetShip.TotalWeight() + container.MaxLoad <= targetShip.MaxWeight)
            {
                Containers.Remove(container);
                targetShip.LoadContainer(container);
                Console.WriteLine($"Przeniesiono kontener {serialNumber} " +
                                  $"ze statku {Name} na statek {targetShip.Name}");
                return true;
            }
            Console.WriteLine($"Nie można przenieść kontenera {serialNumber} " +
                              $"na statek {targetShip.Name} – brak miejsca lub przekroczona waga");
        }
        else
        {
            Console.WriteLine($"Nie znaleziono kontenera {serialNumber} na statku {Name}");
        }
        return false;
    }

    private double TotalWeight()
    {
        return Containers.Sum(c => c.CurrentLoad);
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Statek: {Name}, Prędkość: {MaxSpeed} węzłów, Liczba kontenerów: {Containers.Count}/{MaxContainerNum}, Waga: {TotalWeight()}/{MaxWeight} ton");
    }

    public void PrintAllContainers()
    {
        Console.WriteLine($"Kontenery na statku {Name}:");
        foreach (var container in Containers)
        {
            container.PrintInfo();
        }
    }
}