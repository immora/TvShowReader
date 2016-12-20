using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using TvShowReader.Models;

namespace TvShowReader.Services
{
	public class OnlineEpisodeService : IEpisodeService
	{
		private string login = ConfigurationManager.AppSettings["NextEpisodeLogin"];
		private string password = ConfigurationManager.AppSettings["NextEpisodePassword"];

		public void Login()
		{
			if (login != null && password != null)
			{
				string url = "http://next-episode.net/";

				HtmlWeb web = new HtmlWeb();
				HtmlDocument doc;

				doc = web.Load(url);
			}
		}

	  public List<TvShow> GetEpisodes(string fileName = null)
	  {
	    throw new NotImplementedException();
	  }
	}
}