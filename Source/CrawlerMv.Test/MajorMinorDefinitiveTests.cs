using System;
using System.IO;
using NUnit.Framework;

namespace CrawlerMv.Test
{
    [TestFixture]
    public class MajorMinorDefinitiveTests : ExportBaseTest
    {
        [Test]
        [TestCase(@"C:\Program Files (x86)\Steam\steamapps\common\MajorMinorDefinitive\www", "major-minor-definitive.txt")]
        [Explicit("Assumes you have the game installed via Steam. Use at your own discretion.")]
        public void Export_MajorMinorDefinitive_Steam(string path, string filename)
        {
            /*
             * This operates on the "definitive edition" but should also work on the original release of the game if
             * you change the testcase path. I don't remember what that is right now.
             */
            ExportLocal(path, filename, false);
        }
    }
}