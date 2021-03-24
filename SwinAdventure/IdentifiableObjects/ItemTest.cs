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
    public class ItemTest
    {
        [Test()]
        public void ItemIsIdentifiableTest()
        {
            Item TestItem = new Item( new string[] { "sword", "bronze" }, "bronze sword", 
                "a bronze age sword in the black sea");

            Assert.IsTrue(TestItem.AreYou("sword"));
        }

        [Test()]
        public void ShortDescriptionTest()
        {
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
                "a bronze age sword in the black sea");
            string expected = "bronze sword (sword)";

            Assert.AreEqual(TestItem.ShortDescription, expected);
        }

        [Test()]
        public void FullDescriptionTest()
        {
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
                "a bronze age sword in the black sea");
            string expected = "a bronze age sword in the black sea";

            Assert.AreEqual(TestItem.FullDescription, expected);
        }
    }
}
