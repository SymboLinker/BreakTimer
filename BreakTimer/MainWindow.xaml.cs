using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BreakTimer;

public partial class MainWindow : Window
{
    private readonly MediaPlayer _player = new MediaPlayer();

    public MainWindow()
    {
        InitializeComponent();
        Settings? settings = Settings.Get();
        try
        {
            SoundBox.SelectedIndex = settings.Sound;
        }
        catch
        { }
        SoundBox.SelectionChanged += SoundBox_SelectionChanged;
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        int minutes = int.Parse(((Button)sender).Content.ToString()!);
        Hide();
        await Task.Delay(minutes * 60 * 1000);
        Show();
        PlaySound();
    }

    private void SoundBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Settings.Save(new Settings
        {
            Sound = SoundBox.SelectedIndex
        });
        PlaySound();
    }

    private void PlaySound()
    {
        _player.Stop();
        string? fileName = ((ComboBoxItem)SoundBox.SelectedItem).Content.ToString() switch
        {
            "Annoying alarm" => "Annoying alarm.mp3",
            "Applause" => "Applause.mp3",
            "Chimes" => "Chimes.wav",
            "Water droplet" => "Water droplet.wav",
            _ => null
        };
        if (fileName is not null)
        {
            Uri? uri = new Uri("Sounds/" + fileName, UriKind.RelativeOrAbsolute);
            _player.Open(uri);
            _player.Play();
        }
    }
}

public class Settings
{
    private static readonly string _path = Path.Combine(Environment.CurrentDirectory, "BreakTimer.config");
    public static Settings Get()
    {
        if (!File.Exists(_path))
        {
            return new Settings();
        }
        else
        {
            try
            {
                return JsonSerializer.Deserialize<Settings>(File.ReadAllText(_path)) ?? new Settings();
            }
            catch
            {
                return new Settings();
            }
        }

    }
    public static void Save(Settings settings)
    {
        try
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(settings));
        }
        catch
        { }
    }
    public int Sound { get; set; }
}
