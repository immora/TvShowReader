using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace TvShowReader.Services
{
	public class NextEpisodeService : IEpisodeService
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

	}
}