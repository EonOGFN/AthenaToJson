using Newtonsoft.Json;
using Spectre.Console;

static class AthenaToJson
{
    private const string Publish = "AthenaToJson 1.0.0";

    static void Main()
    {
        Console.Title = Publish;
        AnsiConsole.MarkupLine($"[{Project.Color}]{Project.MainScreen}[/]\n");
        UI.Print("AthenaToJson made by Plague. Check it out at github.com/EonOGFN/AthenaToJson.\n");

        UI.Steps("Step 1: Add all your Cosmetic IDs, one per line.");
        UI.Steps("Step 2: Press Enter twice when you’re done to convert all cosmetic IDs to JSON format for Athena Profiles.\n");

        var IDList = new List<string>();
        string InputLine;

        while ((InputLine = Console.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(InputLine))
                break;

            foreach (var Cosmetic in InputLine.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
            {
                IDList.Add(Cosmetic);
            }
        }

        if (IDList.Count == 0)
        {
            UI.Error("No Cosmetic IDs provided. Please restart and try again.");
            Thread.Sleep(Timeout.Infinite);
        }

        UI.Question($"You’ve added {IDList.Count} Cosmetic IDs. Is that correct? (Yes/No) ");
        var Confirmation = Console.ReadLine()?.Trim();
        if (!string.Equals(Confirmation, "Yes", StringComparison.OrdinalIgnoreCase))
        {
            UI.Error("Aborted. Please restart and try again.");
            Thread.Sleep(Timeout.Infinite);
        }

        var Entries = new SortedDictionary<string, object>();
        foreach (var ID in IDList)
        {
            Entries[ID] = new
            {
                templateId = ID,
                attributes = new
                {
                    item_seen = false,
                    variants = Array.Empty<string>(),
                    favorite = false
                },
                quantity = 1
            };
        }

        var OutputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "AthenaToJson.json");

        File.WriteAllText(OutputPath, JsonConvert.SerializeObject(Entries, Formatting.Indented));

        UI.Print($"Done! Your cosmetics have been converted to JSON and saved at: {Path.GetFullPath(OutputPath)}");
        Thread.Sleep(Timeout.Infinite);
    }
}