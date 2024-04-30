using System;

class UI
{
    private static void print(string message)
    {
        Console.WriteLine(message);
    }
    public static void header()
    {
        print("THE MAZE GAME");
        print("=============");
        print("Press H for help");
        Console.WriteLine();
    }

    public static void help()
    {
        print("Help");
        print("====");
        print("F -> Forward");
        print("L -> Left");
        print("R -> Right");
        print("H -> Help");
    }
}