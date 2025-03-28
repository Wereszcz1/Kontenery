namespace APBD1;

public abstract class Container
{
    private static int _counter = 1;
    public string SerialNumber { get; }
    public double MaxLoad { get; }
    public double CurrentLoad { get; protected set; }

    protected Container(string type, double maxLoad)
    {
        SerialNumber = $"KON-{type}-{_counter++}";
        MaxLoad = maxLoad;
        CurrentLoad = 0;
    }

    public virtual void Load(double weight)
    {
        if (weight + CurrentLoad > MaxLoad)
            throw new Exception("OverfillException: Przekroczona ładowność kontenera");
        CurrentLoad += weight;
    }

    public virtual void Unload()
    {
        CurrentLoad = 0;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"{SerialNumber}: Load {CurrentLoad}/{MaxLoad} kg");
    }
}