using System.IO;
using System.Windows;

string? currentDirectory = Environment.CurrentDirectory;
Console.Title = "BreakTimer";
Console.WriteLine("BreakTimer has started.");
Console.WriteLine("Location: " + currentDirectory);
string? configPath = Path.Combine(currentDirectory, "BreakTimer.config");

int minutes;
const string CONFIGKEY_minutes_between_breaks = "minutes between breaks";
while (true)
{
    try
    {
        string[]? configLines = File.ReadAllLines(configPath);
        minutes = int.Parse(configLines.First(x => x.StartsWith(CONFIGKEY_minutes_between_breaks + ":", StringComparison.OrdinalIgnoreCase)).Split(':')[1]);
    }
    catch
    {
        minutes = 45;
        if (!File.Exists(configPath))
        {
            File.WriteAllText(configPath, $"{CONFIGKEY_minutes_between_breaks}: {minutes}");
        }
    }

    Console.WriteLine();
    Console.WriteLine($"If you would like to change the time between breaks (currently {minutes} minutes), then modify the contents of:");
    Console.WriteLine(configPath);
    Console.WriteLine();
    Console.WriteLine("Minimize[-] this window to let BreakTimer remind you of breaks.");
    Console.WriteLine("Close[X] this window to stop BreakTimer.");


    await Task.Delay(minutes * 60 * 1000);

    MessageBoxResult answer = MessageBox.Show(
        messageBoxText: $"Press OK to repeat the timer.",
        caption: "Break time!",
        button: MessageBoxButton.OKCancel,
        icon: MessageBoxImage.Information,
        defaultResult: MessageBoxResult.Cancel,
        options: MessageBoxOptions.DefaultDesktopOnly);
    if (answer != MessageBoxResult.OK)
    {
        Environment.Exit(0);
    }
}