using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TvShowReader.Models;

namespace TvShowReader.Services
{
	public interface IEpisodeService
	{
		List<TvShow> GetEpisodes(string fileName = null);
	}
}
