namespace Simulator;

internal class Program
{
    static void Lab5a()
    {
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          
        Console.WriteLine(p.NextDiagonal(Direction.Right));  

        Rectangle r1 = new Rectangle(1, 1, 5, 5);
        Console.WriteLine($"Rectangle: {r1}");

        Rectangle r2 = new(3, 4, 1, 2);
        Console.WriteLine($"Rectangle: {r2}");

        try
        {
            Rectangle r3 = new Rectangle(1, 1, 1, 5);
            Console.WriteLine($"Wrong rectangle: {r3}");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Point point1 = new Point(3, 3);
        Point point2 = new Point(6, 6);
        Point point3 = new Point(-1, -2);
        Point point4 = new Point(-8, -12);

        Rectangle r4 = new Rectangle(point1, point2);
        Console.WriteLine($"Rectangle: {r4}");

        Console.WriteLine("-----");

        Rectangle r5 = new Rectangle(-3, -5, 5, 5);
        Console.WriteLine($"Rectangle: {r5}");

        Console.WriteLine($"Contains (3,3) -  {r5.Contains(point1)}");
        Console.WriteLine($"Contains (6,6) -  {r5.Contains(point2)}");
        Console.WriteLine($"Contains (-1,-2) -  {r5.Contains(point3)}");
        Console.WriteLine($"Contains (-8,-12) -  {r5.Contains(point4)}");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }
}
