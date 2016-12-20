using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TvShowReader.Models
{
  public class TvShow
  {
    public string Name;

    public List<Season> Seasons;

    public TvShow()
    {

    }

    public TvShow(string name, List<string> episodes)
    {
      Name = name;

      Seasons = new List<Season>
      {
        new Season
        {
          Number = GetSeasonNumber(episodes.First()),
          Episodes = episodes.Select(e => new Episode {Number = GetEpisodeNumber(e), FullEpisodeNumber = e}).ToList()
        }
      };
    }

    private int GetSeasonNumber(string episodeFullNumber)
    {
      if (episodeFullNumber.Equals("\"Special\""))
      {
        return -1;
      }

      episodeFullNumber = CleanEpisodeFullNumber(episodeFullNumber);

      return int.Parse(episodeFullNumber.Split('x')[0]);
    }

    private int GetEpisodeNumber(string episodeFullNumber)
    {
      if (episodeFullNumber.Equals("\"Special\""))
      {
        return -1;
      }

      episodeFullNumber = CleanEpisodeFullNumber(episodeFullNumber);

      return int.Parse(episodeFullNumber.Split('x')[1]);
    }

    private string CleanEpisodeFullNumber(string episodeFullNumber)
    {
      return episodeFullNumber.Substring(1, episodeFullNumber.Length - 2);
    }
  }

}