using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture()]
    public class InventoryTest
    {
        [Test()]
        public void FindItemTest()
        {
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
               "a bronze age sword in the black sea");
            Inventory InventoryTest = new Inventory();

            InventoryTest.Put(TestItem);
            Assert.IsTrue(InventoryTest.HasItem("sword"));
        }

        [Test()]
        public void NoItemFindTest()
        {
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
               "a bronze age sword in the black sea");
            Inventory InventoryTest = new Inventory();

            InventoryTest.Put(TestItem);
            Assert.IsFalse(InventoryTest.HasItem("golden"));
        }

        [Test()]
        public void FetchItemTest()
        {
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
               "a bronze age sword in the black sea");
            Inventory InventoryTest = new Inventory();

            InventoryTest.Put(TestItem);
            Assert.IsTrue(InventoryTest.Fetch("sword") == TestItem);
            Assert.IsTrue(InventoryTest.HasItem("sword"));
        }

        [Test()] 
        public void TakeItemTest()
        {
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
               "a bronze age sword in the black sea");
            Inventory InventoryTest = new Inventory();

            InventoryTest.Put(TestItem);
            Assert.IsTrue(InventoryTest.HasItem("sword"));
            InventoryTest.Take("sword");
            Assert.IsFalse(InventoryTest.HasItem("sword"));
        }

        [Test()] 
        public void ItemListTest()
        {
            Item TestItem1 = new Item(new string[] { "sword", "bronze" }, "bronze sword",
               "a bronze age sword in the black sea");
            Item TestItem2 = new Item(new string[] { "shovel", "golden" }, "golden shovel",
                "a mighty golden shovel");
            Inventory InventoryTest = new Inventory();

            InventoryTest.Put(TestItem1);
            InventoryTest.Put(TestItem2);

            string expected = "\tbronze sword (sword)\n" + "\tgolden shovel (shovel)\n";
            Assert.AreEqual(InventoryTest.ItemList, expected);
        }
    }
}
