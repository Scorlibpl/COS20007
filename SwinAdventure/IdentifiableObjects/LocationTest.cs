using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture()]
    public class LocationTest
    {
        [Test()]
        public void LocationAreYouTest()
        {
            Location LocationTest = new Location(new string[] { "kuta" }, "kuta beach", 
                "bali indonesia");

            Assert.IsTrue(LocationTest.AreYou("kuta"));
        }

        [Test()]
        public void LocationLocateItemTest()
        {
            Location LocationTest = new Location(new string[] { "kuta" }, "kuta beach",
                "bali indonesia");
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
                "a bronze age sword in the black sea");

            LocationTest.Inventory.Put(TestItem);

            Assert.IsTrue(LocationTest.Locate("sword") == TestItem);
        }

        [Test()]
        public void PlayerLocateItemTest()
        {
            Player PlayerTest = new Player("Scorlib", "scorpio libra");
            Location LocationTest = new Location(new string[] { "kuta" }, "kuta beach",
               "bali indonesia");
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
                "a bronze age sword in the black sea");

            PlayerTest.Location = LocationTest;
            LocationTest.Inventory.Put(TestItem);

            Assert.IsTrue(PlayerTest.Location.Locate("sword") == TestItem);
        }

        [Test()]
        public void LocationLocatesNothing()
        {
            Location LocationTest = new Location(new string[] { "kuta" }, "kuta beach",
               "bali indonesia");
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
                "a bronze age sword in the black sea");

            LocationTest.Inventory.Put(TestItem);

            Assert.IsNull(LocationTest.Locate("star"));
        }
    }
}
