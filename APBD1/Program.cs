using APBD1;

class Program
{
    static void Main()
    {
        Ship ship1 = new Ship(
            "Titanic", 30, 3, 25000);

        Container c1 = new LiquidContainer(
            10000, true);
        Container c2 = new GasContainer(
            5000, 10);
        Container c3 = new RefrigeratedContainer(
            8000, "Banany", -5, -3);

        ship1.LoadContainer(c1);
        ship1.LoadContainer(c2);
        ship1.LoadContainer(c3);

        c1.Load(5000); 
        c2.Load(5000); 
        c3.Load(8000); 
        
        Console.WriteLine();
        ship1.PrintShipInfo();
        Console.WriteLine();
        ship1.PrintAllContainers();

        c1.Unload();
        c2.Unload();
        c3.Unload();
        
        Console.WriteLine();
        Console.WriteLine("Po opróżnieniu kontenerów:");
        ship1.PrintAllContainers();
    }
}
