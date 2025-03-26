namespace APBD1;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(double maxLoad, bool isHazardous)
        : base("L", maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double limit = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (weight + CurrentLoad > limit)
            NotifyHazard("Próba przeładowania niebezpiecznego kontenera!");
        else
            base.Load(weight);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"ALERT ({SerialNumber}): {message}");
    }
}