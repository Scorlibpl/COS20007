using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture()]
    public class BagTest
    {
        [Test()]
        public void BagLocatesItemsTest()
        {
            Bag TestBag = new Bag(new string[] { "bag", "school" }, "school bag",
                "my favourite school bag");
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
                "a bronze age sword in the black sea");

            TestBag.Inventory.Put(TestItem);
            Assert.IsTrue(TestBag.Locate("sword") == TestItem);
        }

        [Test()]
        public void BagLocatesItselfTest()
        {
            Bag TestBag = new Bag(new string[] { "bag", "school" }, "school bag",
                "my favourite school bag");

            Assert.IsTrue(TestBag.Locate("bag") == TestBag);
        }

        [Test()]
        public void BagLocatesNothingTest()
        {
            Bag TestBag = new Bag(new string[] { "bag", "school" }, "school bag",
               "my favourite school bag");

            Assert.IsNull(TestBag.Locate("backpack"));
        }

        [Test()]
        public void BagFullDescriptionTest()
        {
            Bag TestBag = new Bag(new string[] { "bag", "school" }, "school bag",
                "my favourite school bag");
            Item TestItem = new Item(new string[] { "sword", "bronze" }, "bronze sword",
                "a bronze age sword in the black sea");

            TestBag.Inventory.Put(TestItem);

            string expected = "In the school bag you can see:\n" + "\tbronze sword (sword)\n";

            Assert.AreEqual(TestBag.FullDescription, expected);
        }

        [Test()]
        public void BaginBagTest()
        {
            Bag b1 = new Bag(new string[] { "bag1", "school" }, "school1 bag",
                "my favourite school bag1");
            Bag b2 = new Bag(new string[] { "bag2", "school" }, "school2 bag",
                "my favourite school bag2");
            Item TestItem1 = new Item(new string[] { "sword", "bronze" }, "bronze sword",
                "a bronze age sword in the black sea");
            Item TestItem2 = new Item(new string[] { "shovel", "bronze" }, "bronze shovel",
                "a bronze age shovel in the black sea");

            b1.Inventory.Put(TestItem1);
            b2.Inventory.Put(TestItem2);
            b1.Inventory.Put(b2);

            Assert.IsTrue(b1.Locate("sword") == TestItem1);
            Assert.IsFalse(b1.Locate("shovel") == TestItem2);
            Assert.IsTrue(b1.Locate("bag2") == b2);
            
        }
    }
}
