using Android.App;
using Android.Content.PM;
using Android.OS;
using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core;

namespace DSLCS.App.Platforms.Android;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        OneSignalSDK.DotNet.OneSignal.Default.Initialize("ec4e9923-e2ba-47fd-871c-f0d6c6e4debd");
        OneSignalSDK.DotNet.OneSignal.Default.PromptForPushNotificationsWithUserResponse();

    }
}
