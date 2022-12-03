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
		
		Uri uri = new("http://10.0.2.2:3000/api/video/getLatestVideo");
		try
		{
			HttpResponseMessage response = await _httpClient.GetAsync(uri);
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
}
