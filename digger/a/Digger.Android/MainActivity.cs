using Android.App;
using Android.Content.PM;
using Avalonia.Android;
using Android.App;
using Android.Content.PM;
using static Android.Content.PM.ConfigChanges;
using Android.Runtime;
using Android.OS;

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