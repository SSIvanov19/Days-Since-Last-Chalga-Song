namespace DSLCS.App.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        
        var notificationPreference = Preferences.Get("NotificationPreference", true);

        NotificationSwitch.IsToggled = notificationPreference;

        NotificationSwitch.Toggled += (sender, e) =>
        {
            Preferences.Set("NotificationPreference", e.Value);

            if (e.Value)
            {
                OneSignalSDK.DotNet.OneSignal.Default.PromptForPushNotificationsWithUserResponse();
                OneSignalSDK.DotNet.OneSignal.Default.PushEnabled = true;
            }
            else
            {
                OneSignalSDK.DotNet.OneSignal.Default.PushEnabled = false;
            }
        };
    }

    protected async void OpenNewIssue(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new($"https://github.com/SSIvanov19/Days-Since-Last-Chalga-Song/issues/new/choose");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected async void OpenPrivacyPolices(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new($"https://sites.google.com/view/dslcspp/home");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

}