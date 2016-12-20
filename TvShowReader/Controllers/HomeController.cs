using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TvShowReader.Converters;
using TvShowReader.Models;
using TvShowReader.Services;

namespace TvShowReader.Controllers
{
	public class HomeController : Controller
	{
    IEpisodeService episodeService = new OfflineEpisodeService();
    TvShowViewModelConverter converter = new TvShowViewModelConverter();

    public ActionResult Index()
		{
			return View();
		}

    public ActionResult NextEpisode()
    {
      var episodes = episodeService.GetEpisodes();

      TvShowViewModel model = converter.Convert(episodes);

      return View(model);
    }
  }
}