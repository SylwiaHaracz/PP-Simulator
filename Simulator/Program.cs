using Simulator.Maps;

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
        Console.WriteLine("\n");
    }
    static void Lab5b()
    {
        try
        {
            var map1 = new SmallSquareMap(10);
            Console.WriteLine($"Map {map1.Size}x{map1.Size} was created succesfully");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            var map2 = new SmallSquareMap(4);
            Console.WriteLine($"Map {map2.Size}x{map2.Size} was created succesfully");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            var map3 = new SmallSquareMap(20);
            Console.WriteLine($"Map {map3.Size}x{map3.Size} was created succesfully");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            var map4 = new SmallSquareMap(21);
            Console.WriteLine($"Map {map4.Size}x{map4.Size} was created succesfully");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("\n---Map 10x10---");
        var map = new SmallSquareMap(10);
        Point point1 = new Point(3, 3);
        Console.WriteLine($"Contains point (3,3) - {map.Exist(point1)}");
        Point point2 = new Point(10, 3);
        Console.WriteLine($"Contains point (10,3) - {map.Exist(point2)}");
        Point point3 = new Point(3, 15);
        Console.WriteLine($"Contains point (3,15) - {map.Exist(point3)}");
        Point point4 = new Point(-1, -2);
        Console.WriteLine($"Contains point (-1,-2) - {map.Exist(point4)}");
        Point point5 = new Point(9, 3);
        Console.WriteLine($"Contains point (9,3) - {map.Exist(point5)}");
        Console.WriteLine($"Next move up from (3,3) is: {map.Next(point1, Direction.Up)}");
        Console.WriteLine($"Next move up from (9,3) is: {map.Next(point5, Direction.Up)}");
        Console.WriteLine($"Next move right from (9,3) is: {map.Next(point5, Direction.Right)}");
        Console.WriteLine($"Next move diagonally up from (3,3) is: {map.NextDiagonal(point1, Direction.Up)}");
        Console.WriteLine($"Next move diagonally up from (9,3) is: {map.NextDiagonal(point5, Direction.Up)}");
        Console.WriteLine($"Next move diagonally down from (3,3) is: {map.NextDiagonal(point1, Direction.Down)}");
        Console.WriteLine($"Next move diagonally down from (9,3) is: {map.NextDiagonal(point5, Direction.Down)}");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        Lab5b();
    }
}
