using DSLCS.Services.Contracts;
using DSLCS.Shared.Models;

namespace DSLCS.App.Pages;

public partial class MainPage : ContentPage
{
    private readonly IVideoService _videoService;
    public VideoVM Video { get; set; }


    public MainPage(IVideoService videoService)
    {
        _videoService = videoService;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var video = await _videoService.GetLatestVideo();

        if (video != null)
        {
            Video = video;
            VideoTitle.Text = video.title;
            VideoChannelName.Text = $"Uploaded by: {video.channelTitle}";
            VideoPublishedDate.Text = $"Release Date: {DateOnly.FromDateTime(video.publishedAt ?? DateTime.Now)}";
            VideoThumbnail.Source = video.thumbnailURL;
            // Calculate days between now and the release of the video
            Days.Text = (DateOnly.FromDateTime(DateTime.Now).DayNumber
                - DateOnly.FromDateTime(video.publishedAt ?? DateTime.Now).DayNumber).ToString();
            LoadingLayout.IsVisible = false;
            MainLayout.IsVisible = true;
        }
        else
        {
            LoadingIndicator.IsVisible = false;
            LoadingText.Text = "There was a problem! Please try again later!";
        }

        var today = DateTime.Now;

        if (today.Month == 1 && today.Day == 1)
        {
            HolidayBanner.IsVisible = true;
        }
    }

    protected async void OnTappedOverVideoContainer(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new($"https://www.youtube.com/watch?v={Video.videoId}");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected async void OnTappedOverHolidayBanner(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//newyear");
    }
}