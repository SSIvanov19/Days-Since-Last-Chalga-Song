using DSLCS.Services.Contracts;
using DSLCS.Shared.Models;

namespace DSLCS.App.Pages;

public partial class SongPage : ContentPage, IQueryAttributable
{
    private VideoVM _video;
    protected readonly IVideoService _videoService;

    public SongPage(IVideoService videoSevice)
	{
        _videoService = videoSevice;
        InitializeComponent();
        BindingContext = this;
    }

    protected override bool OnBackButtonPressed()
    {
        Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//stats");
        });

        return true;
    }

    protected async void OnImageButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//stats");
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var videoId = query["videoId"] as String;

        var video = await _videoService.GetVideoByVideoId(videoId);

        var days = DateOnly.FromDateTime(DateTime.Now).DayNumber
                - DateOnly.FromDateTime(video.publishedAt ?? DateTime.Now).DayNumber;

        _video = video;
        VideoTitle.Text = video.title;
        VideoThumbnail.Source = video.thumbnailURL;
        VideoChannelName.Text = video.channelTitle;
        VideoPublishedDate.Text = $"{DateOnly.FromDateTime(video.publishedAt ?? DateTime.Now)} ({days} day{(days == 1 ? "" : "s")} ago)";
    }

    protected async void OnTappedOverVideoContainer(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new($"https://www.youtube.com/watch?v={_video.videoId}");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}