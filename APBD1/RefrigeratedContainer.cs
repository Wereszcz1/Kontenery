namespace APBD1;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double RequiredTemperature { get; }
    public double CurrentTemperature { get; }

    public RefrigeratedContainer(double maxLoad, string productType, double requiredTemperature, double currentTemperature)
        : base("C", maxLoad)
    {
        ProductType = productType;
        RequiredTemperature = requiredTemperature;
        CurrentTemperature = currentTemperature;

        if (CurrentTemperature < RequiredTemperature)
            throw new Exception("Temperatura przechowywania jest za niska!");
    }
}