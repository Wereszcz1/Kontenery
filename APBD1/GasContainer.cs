namespace APBD1;

public class GasContainer(double maxLoad, double pressure) 
    : Container("G", maxLoad), IHazardNotifier
{
    public double Pressure { get; } = pressure;

    public override void Unload()
    {
        CurrentLoad *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"ALERT ({SerialNumber}): {message}");
    }
}
