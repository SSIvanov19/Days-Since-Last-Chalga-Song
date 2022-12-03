using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLCS.Shared.Models;

public class VideoVM
{
	public string? id { get; set; }
	public string? videoId { get; set; }

	public DateTime? publishedAt { get; set; }

	public string? title { get; set; }

	public string? thumbnailURL { get; set; }
	
	public string? channelTitle { get; set;}
}
