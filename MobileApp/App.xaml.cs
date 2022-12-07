using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core;

namespace DSLCS.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }

    protected override async void OnStart()
    {
        OneSignalSDK.DotNet.OneSignal.Default.Initialize("ec4e9923-e2ba-47fd-871c-f0d6c6e4debd");
        await OneSignalSDK.DotNet.OneSignal.Default.PromptForPushNotificationsWithUserResponse();

        if (!Preferences.ContainsKey("NotificationPreference"))
        {
            Preferences.Set("NotificationPreference", true);
        }

        OneSignalSDK.DotNet.OneSignal.Default.PushEnabled = Preferences.Get("NotificationPreference", true);
    }
}
