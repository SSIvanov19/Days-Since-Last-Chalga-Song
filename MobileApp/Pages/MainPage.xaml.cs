using CommunityToolkit.Maui.Views;
using DSLCS.Services.Contracts;

namespace DSLCS.App.Pages;

public partial class MainPage : ContentPage
{
    private readonly IVideoService _videoService;

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
            VideoTitle.Text = video.title;
            VideoChannelName.Text = $"Uploaded by: {video.channelTitle}";
            VideoPublishedDate.Text = $"Release Date: {DateOnly.FromDateTime(video.publishedAt ?? DateTime.Now).ToString()}";
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
    }
}