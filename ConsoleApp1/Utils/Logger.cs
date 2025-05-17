class UI
{
    public static void Print(string Message)
    {
        var Color = Console.ForegroundColor;
        Console.Write("["); Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("*"); Console.ForegroundColor = Color;
        Console.WriteLine($"] {Message}");
    }

    public static void Steps(string Message)
    {
        var Color = Console.ForegroundColor;
        Console.Write("["); Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("*"); Console.ForegroundColor = Color;
        Console.WriteLine($"] {Message}");
    }

    public static void Question(string Message)
    {
        var Color = Console.ForegroundColor;
        Console.Write("["); Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("?"); Console.ForegroundColor = Color;
        Console.Write($"] {Message}");
    }

    public static void Error(string Message)
    {
        var Color = Console.ForegroundColor;
        Console.Write("["); Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("?"); Console.ForegroundColor = Color;
        Console.Write($"] {Message}");
    }
}