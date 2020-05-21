
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Permissions;
using Android.Runtime;

namespace Get_Root_Of.Droid
{
    [Activity(Label = "Get Root Of", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            MainPage.AppContext = this;
            PermissionHandler handler = new PermissionHandler(this, new string[] { Manifest.Permission.AccessWifiState, Manifest.Permission.ChangeWifiState });

            if (!handler.HasAllPermissions())
                handler.RequestAllPermissions();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}