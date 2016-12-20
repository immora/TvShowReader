using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using TvShowReader.Models;

namespace TvShowReader.Converters
{
  public class TvShowViewModelConverter
  {
    public TvShowViewModel Convert(List<TvShow> tvShows)
    {
      List<Episode> allEpisodes = new List<Episode>();

      Dictionary<string, List<Episode>> episodesWithShowName = new Dictionary<string, List<Episode>>();

      foreach (var tvShow in tvShows)
      {
        foreach (var season in tvShow.Seasons)
        {
          allEpisodes.AddRange(season.Episodes.Select(x => x));
        }

        foreach (var episode in allEpisodes)
        {
          episodesWithShowName.Add(tvShow.Name, episode);
        }
      }


      return new TvShowViewModel { TvShows = episodesWithShowName };
    }
  }
}