using DevExpress.Maui.Editors;
using DSLCS.Services.Contracts;
using DSLCS.Shared.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace DSLCS.App.Pages;

public partial class StatsPage : ContentPage
{
    private readonly IVideoService _videoService;

    public List<VideoVM> Videos { get; set; } = new List<VideoVM>();

    public DateTime LastSelectedDate { get; set; } = DateTime.Now;

    public StatsPage(IVideoService videoService)
    {
        _videoService = videoService;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var firstDayOfMonth = new DateTime(Calendar.DisplayDate.Year, Calendar.DisplayDate.Month, 1).AddMonths(-1);

        var lastDayOfMonth = new DateTime(Calendar.DisplayDate.Year, Calendar.DisplayDate.Month, DateTime.DaysInMonth(Calendar.DisplayDate.Year, Calendar.DisplayDate.Month)).AddMonths(1);

        var videos = await _videoService.GetVideosInRange(firstDayOfMonth, lastDayOfMonth);

        if (videos == null)
        {
            await DisplayAlert("Error", "There was a problem! Please try again later!", "OK");
            return;
        }

        Videos = Videos.Concat(videos).ToList();

        Calendar.DisplayDate = Calendar.DisplayDate.AddSeconds(1);
    }

    protected void CustomDayCellStyle(object sender, CustomSelectableCellStyleEventArgs e)
    {
        if (Videos == null)
        {
            return;
        }

        foreach (var video in Videos)
        {
            if (e.Date.Day == video.publishedAt.Value.Day && e.Date.Month == video.publishedAt.Value.Month && e.Date.Year == video.publishedAt.Value.Year)
            {
                e.FontAttributes = FontAttributes.Bold;
                Color textColor = Color.FromArgb("#F44848");
                e.EllipseBackgroundColor = Color.FromRgba(textColor.Red, textColor.Green, textColor.Blue, 0.25);
                e.TextColor = textColor;
            }
        }
    }

    protected async void OnTappedOverCalendar(object sender, EventArgs e)
    {
        var videoContainerChildCount = VideosContainer.Children.Count;
        
        for (int i = 0; i < videoContainerChildCount; i++)
        {
            VideosContainer.Children.RemoveAt(0);
        }
        
        if (!(LastSelectedDate.Year == Calendar.SelectedDate.Value.Year && LastSelectedDate.Month == Calendar.SelectedDate.Value.Month))
        {
            var firstDayOfMonth = new DateTime(Calendar.SelectedDate.Value.Year, Calendar.SelectedDate.Value.Month, 1).AddMonths(-1);

            var lastDayOfMonth = new DateTime(Calendar.SelectedDate.Value.Year, Calendar.SelectedDate.Value.Month, DateTime.DaysInMonth(Calendar.SelectedDate.Value.Year, Calendar.SelectedDate.Value.Month)).AddMonths(1);

            var localVideos = await _videoService.GetVideosInRange(firstDayOfMonth, lastDayOfMonth);

            if (localVideos == null)
            {
                await DisplayAlert("Error", "There was a problem! Please try again later!", "OK");
                return;
            }

            Videos = Videos.Concat(localVideos).ToList();

            Calendar.DisplayDate = Calendar.DisplayDate.AddSeconds(1);
        }

        LastSelectedDate = Calendar.SelectedDate.Value;
        
        Videos = Videos.DistinctBy(x => x.videoId).ToList();

        var videos = Videos.Where(x =>
            x.publishedAt.Value.Day == Calendar.SelectedDate.Value.Day &&
            x.publishedAt.Value.Month == Calendar.SelectedDate.Value.Month &&
            x.publishedAt.Value.Year == Calendar.SelectedDate.Value.Year).ToList();

        if (videos.Count == 0)
        {
            VideoLayout.IsVisible = false;
            return;
        }

        VideoLayout.IsVisible = true;
        VideoCollectionLabel.Text = $"Chalga songs released on {Calendar.SelectedDate.Value.Date.ToShortDateString()}";

        foreach (var video in videos)
        {
            var label = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                Padding = new(10, 0, 0, 0),
                Text = video.title,
                FontSize = 12,
                FontFamily = "Inter",
                FontAttributes = FontAttributes.Bold,
                MinimumWidthRequest = 240,
                MaximumWidthRequest = 240,
                TextColor = Colors.Black
            };

            var image = new Image
            {
                MaximumWidthRequest = 220,
                MinimumWidthRequest = 220,
                Source = video.thumbnailURL,
                Aspect = Aspect.AspectFill
            };

            var border = new Border
            {
                MinimumWidthRequest = 220,
                MaximumWidthRequest = 220,
                StrokeShape = new RoundRectangle()
                {
                    CornerRadius = 12
                },
                Content = image
            };

            var flexLayout = new FlexLayout();

            flexLayout.Children.Add(border);
            flexLayout.Children.Add(label);

            var frame = new Frame
            {
                Margin = new(0, 15, 0, 0),
                HeightRequest = 120,
                CornerRadius = 24,
                Content = flexLayout
            };

            var tapGestureRecognizer = new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Shell.Current.GoToAsync($"//video?videoId={video.videoId}");
                })
            };

            frame.GestureRecognizers.Add(tapGestureRecognizer);
            VideosContainer.Children.Add(frame);
        }
    }
}