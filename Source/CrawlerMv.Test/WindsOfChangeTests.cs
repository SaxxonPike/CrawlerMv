using System;
using System.IO;
using NUnit.Framework;

namespace CrawlerMv.Test
{
    [TestFixture]
    public class WindsOfChangeTests : ExportBaseTest
    {
        [Test]
        [TestCase("http://windsofchangegame.com/", "winds-of-change.txt")]
        [Explicit("This makes web requests. Use at your own discretion.")]
        public void Export_WindsOfChange_Web(string url, string filename)
        {
            /*
             * Something you should know about this particular testcase: it was designed to crawl the Winds of Change
             * demo located at http://windsofchangegame.com. The site hasn't existed for a couple years since the game
             * came out, and the release runs on RenPy now. Nonetheless, this test is preserved. The online demo no
             * longer exists, but a local version does if you have Major\Minor Definitive Edition, see below.
             */
            ExportWeb(url, filename);
        }
        
        [Test]
        [TestCase(@"C:\Program Files (x86)\Steam\steamapps\common\MajorMinorDefinitive\windsdemo\www", "winds-of-change-demo.txt")]
        [Explicit("Assumes you have the game installed via Steam. Use at your own discretion.")]
        public void Export_WindsOfChange_Local(string path, string filename)
        {
            /*
             * If you have Major\Minor Definitive Edition installed, you can crawl the Winds of Change demo script.
             */
            ExportLocal(path, filename);
        }
    }
}
