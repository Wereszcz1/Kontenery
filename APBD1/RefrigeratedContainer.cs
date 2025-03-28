namespace APBD1;

public class RefrigeratedContainer : Container
{
    private string ProductType { get; set; }
    private double RequiredTemperature { get; }
    private double _currentTemperature;

    private double CurrentTemperature
    {
        get => _currentTemperature;
        set
        {
            if (value < RequiredTemperature)
                throw new Exception($"Temperatura w kontenerze nie może być niższa niż {RequiredTemperature}°C!");
            _currentTemperature = value;
        }
    }

    public RefrigeratedContainer
    (
        double maxLoad, 
        string productType, 
        double requiredTemperature, 
        double currentTemperature
    )
        : base("C", maxLoad)
    {
        ProductType = productType;
        RequiredTemperature = requiredTemperature;
        CurrentTemperature = currentTemperature;
    }

    public void Load(double weight, string productType)
    {
        if (CurrentLoad > 0 && ProductType != productType)
        {
            Console.WriteLine($"Kontener już zawiera produkt {ProductType}, nie można dodać {productType}.");
            return;
        }

        if (CurrentLoad >= MaxLoad)
        {
            Console.WriteLine($"Kontener już jest pełny. Nie można dodać więcej produktu {productType}.");
            return;
        }

        if (CurrentLoad + weight > MaxLoad)
        {
            double remainingCapacity = MaxLoad - CurrentLoad;
            double notLoaded = weight - remainingCapacity;
            CurrentLoad = MaxLoad;
            Console.WriteLine($"Kontener został uzupełniony do maksymalnej pojemności ({MaxLoad} kg). " +
                              $"{notLoaded} kg produktu {productType} nie zostało dodane.");
            weight = remainingCapacity;
        }

        if (CurrentLoad == 0)
        {
            ProductType = productType;
        }

        if (CurrentLoad + weight <= MaxLoad)
        {
            CurrentLoad += weight;
            Console.WriteLine($"Załadowano {weight} kg {productType} do kontenera.");
        }
        else
        {
            Console.WriteLine("Kontener jest już pełny, nie dodano żadnego produktu.");
        }
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"{SerialNumber}: {ProductType}, Ładunek: " +
                          $"{CurrentLoad}/{MaxLoad} kg, Temp: {CurrentTemperature}°C " +
                          $"(wymagana: {RequiredTemperature}°C)");
    }
}