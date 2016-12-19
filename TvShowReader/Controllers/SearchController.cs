using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;

namespace TvShowReader.Controllers
{
  public class SearchController : Controller
  {
    public static List<string> LastSearches = new List<string>();
     
    [HttpGet]
    public JsonResult GetSearchResults(string tvShowName)
    {
      tvShowName = tvShowName.Replace(' ', '+');

      string url = "https://seriescr.com/?s=" + tvShowName;

      HtmlWeb web = new HtmlWeb();
      HtmlDocument doc;

      if (ConfigurationManager.AppSettings["UseProxy"] == "true")
      {
        doc = web.Load(url, ConfigurationManager.AppSettings["proxyAddress"], int.Parse(ConfigurationManager.AppSettings["proxyPort"]), ConfigurationManager.AppSettings["proxyLogin"], ConfigurationManager.AppSettings["proxyPassword"]);
      }
      else
      {
        doc = web.Load(url);
      }

      List<string> links = new List<string>();

      var elements = doc.DocumentNode.SelectNodes("//div[contains(@class, 'sbox')]");

      if (elements != null)
      {
        foreach (HtmlNode post in elements)
        {
          string linkForEpisode = post.ChildNodes.FindFirst("h2").ChildNodes.FindFirst("a").OuterHtml;
          linkForEpisode = linkForEpisode.Insert(linkForEpisode.IndexOf("title") - 1, "target=\"_blank\"");

          links.Add(linkForEpisode);
        }
      }

      return new JsonResult { Data = links, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    }

    [HttpGet]
    public JsonResult GetLastSearches()
    {
      return new JsonResult { Data = LastSearches, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    }

    [HttpPost]
    public void SaveSearch(string query)
    {
      //jakiś zapis do pliku

      if (LastSearches.Contains(query) == false)
      {
        LastSearches.Add(query);
      }
      else
      {
        LastSearches.Remove(query);
        LastSearches.Add(query);
      }
    }
  }
}