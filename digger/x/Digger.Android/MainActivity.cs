using Android.App;
using Android.Content.PM;
using static Android.Content.PM.ConfigChanges;
using Android.Runtime;
using Android.OS;

namespace Digger.Droid
{
	[Activity(Label = "Digger", Icon = "@mipmap/logo", Theme = "@style/MainTheme", MainLauncher = true, 
        ConfigurationChanges = ScreenSize | Orientation | UiMode | ScreenLayout | SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static MainActivity()
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            global::Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}