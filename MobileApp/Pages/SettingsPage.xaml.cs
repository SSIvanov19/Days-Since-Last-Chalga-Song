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
}