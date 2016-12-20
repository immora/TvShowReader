using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TvShowReader.Models;

namespace TvShowReader.Services
{
  public class OfflineEpisodeService : IEpisodeService
  {
    public List<TvShow> GetEpisodes(string fileName = null)
    {
      List<TvShow> tvShows = new List<TvShow>();

      if (fileName != null)
      {
        tvShows = ReadEpisodesFromFile(fileName);
      }

      return tvShows;
    }

    public List<TvShow> ReadEpisodesFromFile(string fileName)
    {
      List<TvShow> tvShows = new List<TvShow>();

      var lines = File.ReadLines(fileName).Select(a => a);

      var notWatchedEpisodes = lines.Select(a => a.Split(',')).Skip(1).ToArray();

      var tvShowGroups = notWatchedEpisodes.GroupBy(x => x[0]).Select(x => x).ToList();

      foreach (var tvShowGroup in tvShowGroups)
      {
        var showName = tvShowGroup.Key;
        var episodes = tvShowGroup.Select(x => x[2]).ToList();

        TvShow tvshow = new TvShow(showName, episodes);

        tvShows.Add(tvshow);
      }

      return tvShows;
    }

  }
}