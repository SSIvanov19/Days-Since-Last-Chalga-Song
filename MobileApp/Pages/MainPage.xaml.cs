using DSLCS.Services.Contracts;

namespace MobileApp;

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
			
		}

		
	}


}

