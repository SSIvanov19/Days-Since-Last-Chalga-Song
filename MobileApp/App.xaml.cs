using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core;

namespace DSLCS.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		
        OneSignalSDK.DotNet.OneSignal.Default.Initialize("ec4e9923-e2ba-47fd-871c-f0d6c6e4debd");
        OneSignalSDK.DotNet.OneSignal.Default.PromptForPushNotificationsWithUserResponse();
    }
}
