
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TvShowReader.Services;

namespace TvShowReader.Tests
{
  [TestClass]
  public class UnitTest2
  {
    public IEpisodeService _episodeService = new OfflineEpisodeService();

   [TestMethod]
    public void GetEpisodes()
   {
     _episodeService.GetEpisodes("next-episode.csv");
   }
  }
}
