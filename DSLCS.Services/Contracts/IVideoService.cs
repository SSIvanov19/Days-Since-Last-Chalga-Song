using DSLCS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLCS.Services.Contracts;

public interface IVideoService
{
	Task<VideoVM?> GetLatestVideo();
}
