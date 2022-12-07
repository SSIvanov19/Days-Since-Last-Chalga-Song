import * as OneSignal from '@onesignal/node-onesignal';

export default class NotificationService {
    private app_key_provider = {
        getToken() {
            return process.env.ONESIGNAL_REST_API_KEY!;
        }
    };

    private configuration = OneSignal.createConfiguration({
        authMethods: {
            app_key: {
                tokenProvider: this.app_key_provider
            }
        }
    });
    
    public async sendNotification(videoTitle: string, channelTitle: string, thumbnailURL: string) {
        const client = new OneSignal.DefaultApi(this.configuration);
        const notification = new OneSignal.Notification();

        notification.app_id = process.env.ONESIGNAL_APP_ID!;
        notification.included_segments = ['Subscribed Users'];
        notification.headings = {
            en: "New Chalga Song"
        };
        notification.contents = {
            en: `${channelTitle} just released ${videoTitle}`
        };
        notification.big_picture = thumbnailURL;
        notification.large_icon = "https://cdn.discordapp.com/attachments/728527943604764692/1050117432674623488/favicon.png";

        await client.createNotification(notification);
    }
}