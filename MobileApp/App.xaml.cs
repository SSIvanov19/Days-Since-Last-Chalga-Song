using DSLCS.App.Pages;
using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core;

namespace DSLCS.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    ~App()
    {
        Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
    }

    protected override async void OnStart()
    {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        
        if (accessType == NetworkAccess.ConstrainedInternet || accessType != NetworkAccess.Internet)
        {
            await MainPage.DisplayAlert("No Internet Connection", "Please check your internet connection and try again.", "Quit App");
            Application.Current.Quit();
        }
        
        OneSignalSDK.DotNet.OneSignal.Default.Initialize("ec4e9923-e2ba-47fd-871c-f0d6c6e4debd");
        await OneSignalSDK.DotNet.OneSignal.Default.PromptForPushNotificationsWithUserResponse();

        if (!Preferences.ContainsKey("NotificationPreference"))
        {
            Preferences.Set("NotificationPreference", true);
        }

        OneSignalSDK.DotNet.OneSignal.Default.PushEnabled = Preferences.Get("NotificationPreference", true);
    }

    async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        if (e.NetworkAccess == NetworkAccess.ConstrainedInternet || e.NetworkAccess != NetworkAccess.Internet)
        {
            await MainPage.DisplayAlert("No Internet Connection", "Please check your internet connection and try again.", "OK");
            Application.Current.Quit();
        }
    }
}
