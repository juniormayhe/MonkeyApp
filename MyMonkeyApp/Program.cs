using System;
using System.Linq;
using MyMonkeyApp;

namespace MyMonkeyApp;

public class Program
{
    private static readonly string[] AsciiArt = new[]
    {
        @"  (o.o)   ",
        @" (" + '"' + @"." + '"' + @")  ",
        @"  ( : )   ",
        @"  (" + '>' + @"." + '<' + @")  ",
        @"  ( ^.^ )  ",
        @"  (='.'=)  ",
        @"  (o\_/o)  "
    };

    public static void Main(string[] args)
    {
        var random = new Random();
        while (true)
        {
            //Console.Clear();
            // Show random ASCII art sometimes
            if (random.Next(0, 3) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(AsciiArt[random.Next(AsciiArt.Length)]);
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine("==== Monkey App ====");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for monkey by name");
            Console.WriteLine("3. Get random monkey");
            Console.WriteLine("4. Exit app");
            Console.Write("Select an option (1-4): ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListAllMonkeys();
                    break;
                case "2":
                    GetMonkeyByName();
                    break;
                case "3":
                    GetRandomMonkey();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void ListAllMonkeys()
    {
        var monkeys = MonkeyHelper.GetMonkeys();
        Console.WriteLine("\n| Name                 | Location                              | Population |");
        Console.WriteLine("|----------------------|---------------------------------------|------------|");
        foreach (var m in monkeys)
        {
            Console.WriteLine($"| {m.Name,-20} | {m.Location,-37} | {m.Population,10} |");
        }
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    private static void GetMonkeyByName()
    {
        Console.Write("Enter monkey name: ");
        var name = Console.ReadLine() ?? string.Empty;
        var monkey = MonkeyHelper.GetMonkeyByName(name);
        if (monkey == null)
        {
            Console.WriteLine($"Monkey '{name}' not found.");
        }
        else
        {
            PrintMonkeyDetails(monkey);
            Console.WriteLine($"Accessed {MonkeyHelper.GetAccessCount(monkey.Name)} times.");
        }
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    private static void GetRandomMonkey()
    {
        var monkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine("Random monkey:");
        PrintMonkeyDetails(monkey);
        Console.WriteLine($"Accessed {MonkeyHelper.GetAccessCount(monkey.Name)} times.");
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    private static void PrintMonkeyDetails(Monkey m)
    {
        Console.WriteLine($"\nName: {m.Name}");
        Console.WriteLine($"Location: {m.Location}");
        Console.WriteLine($"Population: {m.Population}");
        Console.WriteLine($"Latitude: {m.Latitude}");
        Console.WriteLine($"Longitude: {m.Longitude}");
        Console.WriteLine($"Details: {m.Details}");
        Console.WriteLine($"Image: {m.Image}");
    }
}
