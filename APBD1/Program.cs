namespace APBD1;

class Program
{
    static void Main()
    {
        Ship ship1 = new Ship
        (
            "Titanic", 
            40, 
            5, 
            5000
        );
        Ship ship2 = new Ship
        (
            "Poseidon", 
            30, 
            3, 
            3000
        );
        Console.WriteLine("Dodano statki:\n");
        
        LiquidContainer milkContainer = new LiquidContainer
        (
            1000, 
            false
        );
        GasContainer heliumContainer = new GasContainer
        (
            500, 
            10
        );
        
        RefrigeratedContainer bananaContainer;
        try
        {
            bananaContainer = new RefrigeratedContainer
            (
                800, 
                "Banany", 
                5, 
                7
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd przy tworzeniu kontenera: {ex.Message}");
            return;
        }
        
        RefrigeratedContainer fishContainer;
        try
        {
            fishContainer = new RefrigeratedContainer
            (
                1200, 
                "Ryby", 
                -5, 
                -3
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd przy tworzeniu kontenera: {ex.Message}");
            return;
        }
        
        ship1.LoadContainer(milkContainer);
        ship1.LoadContainer(heliumContainer);
        ship1.LoadContainer(bananaContainer);
        Console.WriteLine("\nDodano pojedyncze kontenery na statek 1:\n");
        ship1.PrintAllContainers();
        
        List<Container> newContainers = new List<Container> { fishContainer };
        Console.WriteLine();
        ship1.LoadContainers(newContainers);
        Console.WriteLine("\nDodano listę kontenerów na statek 1:\n");
        ship1.PrintAllContainers();
        
        try
        {
            milkContainer.Load(900);
            heliumContainer.Load(400);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd przy załadunku: {ex.Message}");
        }
        
        Console.WriteLine("\nZaładowano kontenery:\n");
        ship1.PrintAllContainers();
        
        Console.WriteLine("\nPróba przeładowania konteneru i sprawdzenie NotifyHazard:");
        try
        {
            milkContainer.Load(200);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd przy załadunku: {ex.Message}");
        }
        
        heliumContainer.Unload();
        Console.WriteLine("\nRozładowano kontener z gazem:\n");
        ship1.PrintAllContainers();
        
        ship1.RemoveContainer(milkContainer.SerialNumber);
        Console.WriteLine("\nUsunięto kontener ze statku 1:\n");
        ship1.PrintAllContainers();
        
        ship1.ReplaceContainer(heliumContainer.SerialNumber, fishContainer);
        Console.WriteLine("\nZastąpiono kontener na statku 1:\n");
        ship1.PrintAllContainers();
        
        ship1.TransferContainer(ship2, fishContainer.SerialNumber);
        Console.WriteLine("\nPrzeniesiono kontener do innego statku:\n");
        
        Console.WriteLine("Statek 1:");
        ship1.PrintAllContainers();
        
        Console.WriteLine("\nStatek 2:");
        ship2.PrintAllContainers();
        
        Console.WriteLine("\nInformacje o statkach:");
        ship1.PrintShipInfo();
        ship2.PrintShipInfo();

        Ship ship3 = new Ship
        (
            "Maria", 
            40, 
            5, 
            5000
        );
        Ship ship4 = new Ship
        (
            "Hermes", 
            30, 
            3, 
            3000
        );
        Console.WriteLine("Dodano statki:\n");

        RefrigeratedContainer bananaContainer2;
        try
        {
            bananaContainer2 = new RefrigeratedContainer
            (
                800,
                "Banany",
                5,
                5
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd przy tworzeniu kontenera: {ex.Message}");
            return;
        }

        bananaContainer2.Load(300, "Banany");
        bananaContainer2.Load(100, "Banany");
        bananaContainer2.Load(500, "Ryby");
        bananaContainer2.Load(800, "Banany");

        bananaContainer2.PrintInfo();
        
        ship3.LoadContainer(milkContainer);
        ship3.PrintAllContainers();
    }
}