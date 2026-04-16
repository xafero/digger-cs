using Android.App;
using Avalonia.Android;
using static Android.Content.PM.ConfigChanges;

namespace Digger.Android
{
    [Activity(
        Label = "Digger",
        Theme = "@style/MyTheme.NoActionBar",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ScreenSize | Orientation | UiMode | ScreenLayout | SmallestScreenSize)]
    public class MainActivity : AvaloniaMainActivity
    {
    }
}