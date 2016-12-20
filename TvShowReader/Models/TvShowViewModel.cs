using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TvShowReader.Services;

namespace TvShowReader.Models
{
  public class TvShowViewModel
  {
    public Dictionary<string, List<Episode>> TvShows;
  }
}