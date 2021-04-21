using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;
using NuGet.Frameworks;

namespace BlackJackUnitTests
{
    [TestClass]
    public class DealerTests
    {
        [TestMethod]
        public void Deal_Test()
        {
            Dealer dealer = new Dealer();
            Player player = new Player();

            Assert.AreEqual(null, null);
        }
    }
}
