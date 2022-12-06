using DSLCS.Services.Contracts;
using DSLCS.Shared.Models;
using System.Diagnostics;
using System.Text.Json;

namespace DSLCS.Services.Implentations;

internal class VideoService : IVideoService
{
	private readonly HttpClient _httpClient;
	private readonly JsonSerializerOptions _serializerOptions;

	public VideoService()
	{
		_httpClient = new HttpClient();
		_serializerOptions = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true
		};
	}
	
	public async Task<VideoVM?> GetLatestVideo()
	{
		VideoVM? video = new();
		
		Uri uri = new("https://days-since-last-chalga-song.vercel.app/api/video/getLatestVideo");
		try
		{
			var response = await _httpClient.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				video = JsonSerializer.Deserialize<VideoVM?>(content, _serializerOptions);
			}
			else
			{
				return null;
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(@"\tERROR {0}", ex.Message);
		}

		return video;
	}

    public async Task<VideoVM?> GetVideoByVideoId(string videoId)
    {
        VideoVM? video = new();

        Uri uri = new($"https://days-since-last-chalga-song.vercel.app/api/video/getVideoByVideoId?videoId={videoId}");
        try
        {
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                video = JsonSerializer.Deserialize<VideoVM?>(content, _serializerOptions);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return video;
    }

    public async Task<List<VideoVM>?> GetVideosInRange(DateTime startDate, DateTime endDate)
    {
        List<VideoVM>? videos = new();

        Uri uri = new($"https://days-since-last-chalga-song.vercel.app/api/video/getVideoBetweenDates?startDate={startDate:s}&endDate={endDate:s}");
        
        try
        {
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                videos = JsonSerializer.Deserialize<List<VideoVM>?>(content, _serializerOptions);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        
        return videos;
    }
}
