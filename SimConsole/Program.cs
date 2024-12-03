using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.OutputEncoding = Encoding.UTF8;
            SmallTorusMap map = new(8,6);
            List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals("Rabbits", 23), new Birds("Eagles", 8), new Birds("Ostriches", 15, false)];
            List<Point> points = [new(2, 2), new(3, 1), new(4,3), new(1,1), new(0, 4)];
            string moves = "dlrludlrlldurdl";
            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);

            var current_move = 1;
            mapVisualizer.Draw();
            while (simulation.Finished != true)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine($"Turn: {current_move}");
                //Console.WriteLine($"{simulation.CurrentCreature.Info} {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}\n");
                Console.WriteLine();
                simulation.Turn();
                mapVisualizer.Draw();
                current_move++;
            }
        }
    }
}
