using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TvShowReader.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

    public ActionResult NextEpisode()
    {
      return View();
    }
  }
}