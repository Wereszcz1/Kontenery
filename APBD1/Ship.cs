namespace APBD1;

public class Ship
{
    public string Name { get; }
    public double MaxSpeed { get; }
    public int MaxContainerNum { get; }
    public double MaxWeight { get; }
    private List<Container> Containers { get; } = new List<Container>();

    public Ship(string name, double maxSpeed, int maxContainerNum, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerNum = maxContainerNum;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerNum || TotalWeight() + container.MaxLoad > MaxWeight)
            throw new Exception("Statek nie może pomieścić więcej kontenerów");
        Containers.Add(container);
    }

    public double TotalWeight()
    {
        double weight = 0;
        foreach (var container in Containers)
            weight += container.CurrentLoad;
        return weight;
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