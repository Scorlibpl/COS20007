using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture()]
    public class PlayerTest
    {
        [Test()]
        public void PlayerIsIdentifiableTest()
        {
            Player PlayerTest = new Player("Scorlib", "scorpio libra");
            Assert.IsTrue(PlayerTest.AreYou("me") && PlayerTest.AreYou("inventory"));
        }

        [Test()]
        public void PlayerLocatesItemsTest()
        {
            Player PlayerTest = new Player("Scorlib", "scorpio libra");
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
               "a bronze age sword in the black sea");
           
            PlayerTest.Inventory.Put(TestItem);
            Assert.IsTrue(PlayerTest.Locate("sword") == TestItem);
            Assert.IsTrue(PlayerTest.Locate("sword") == TestItem);
        }

        [Test()]
        public void PlayerLocatesItselfTest()
        {
            Player PlayerTest = new Player("Scorlib", "scorpio libra");
            Assert.IsTrue(PlayerTest.Locate("me") == PlayerTest);
        }

        [Test()]
        public void PlayerLocatesNothingTest()
        {
            Player PlayerTest = new Player("Scorlib", "scorpio libra");
            Assert.IsTrue(PlayerTest.Locate("sword") == null);
        }

        [Test()]
        public void PlayerFullDescriptionTest()
        {
            Player PlayerTest = new Player("Scorlib", "scorpio libra");
            Item TestItem1 = new Item(new string[] { "sword", "bronze" }, "bronze sword",
               "a bronze age sword in the black sea");
            Item TestItem2 = new Item(new string[] { "shovel", "golden" }, "golden shovel",
                "a mighty golden shovel");

            PlayerTest.Inventory.Put(TestItem1);
            PlayerTest.Inventory.Put(TestItem2);

            string expected = "You are carrying:\n" + "\tbronze sword (sword)\n" + "\tgolden shovel (shovel)\n";
            Assert.AreEqual(PlayerTest.FullDescription, expected);
        }

    }
}
