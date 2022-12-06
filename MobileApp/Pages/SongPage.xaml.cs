using DSLCS.Services.Contracts;
using DSLCS.Shared.Models;

namespace DSLCS.App.Pages;

public partial class SongPage : ContentPage, IQueryAttributable
{
    //private Task<VideoVM> _video;
    protected readonly IVideoService _videoService;

    public SongPage(IVideoService videoSevice)
	{
        _videoService = videoSevice;
        InitializeComponent();
        BindingContext = this;
	}

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var videoId = query["videoId"] as String;

        var video = await _videoService.GetVideoByVideoId(videoId);
        
        

        PlaceholderText.Text = video.title;
    }
}