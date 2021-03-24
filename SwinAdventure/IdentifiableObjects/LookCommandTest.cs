using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture()]
    public class LookCommandTest
    {
        [Test()] 
        public void LookAtMeTest()
        {
            LookCommand TestLook = new LookCommand();
            Player TestPlayer = new Player("Scorlib", "Perjuangan Lexrin");
            Item TestItem = new Item(new string[] { "gem", "shiny" }, "shiny gem", 
                "a shiny red gem");
            TestPlayer.Inventory.Put(TestItem);

            var expected = "You are carrying:\n" + "\tshiny gem (gem)\n";
            string[] text = new string[] { "look", "at", "inventory" };
            var result = TestLook.Execute(TestPlayer, text);

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void LookAtGemTest()
        {
            LookCommand TestLook = new LookCommand();
            Player TestPlayer = new Player("Scorlib", "Perjuangan Lexrin");
            Item TestItem = new Item(new string[] { "gem", "shiny" }, "shiny gem",
                "a shiny red gem");
            TestPlayer.Inventory.Put(TestItem);

            var expected = "a shiny red gem";
            string[] text = new string[] { "look", "at", "gem" };
            var result = TestLook.Execute(TestPlayer, text);

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void LookAtUnkTest()
        {
            LookCommand TestLook = new LookCommand();
            Player TestPlayer = new Player("Scorlib", "Perjuangan Lexrin");

            var expected = "I cannot find the gem";
            string[] text = new string[] { "Look", "at", "gem"};
            var result = TestLook.Execute(TestPlayer, text);

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void LookAtGemInMeTest()
        {
            LookCommand TestLook = new LookCommand();
            Player TestPlayer = new Player("Scorlib", "Perjuangan Lexrin");
            Item TestItem = new Item(new string[] { "gem", "shiny" }, "shiny gem",
                "a shiny red gem");
            TestPlayer.Inventory.Put(TestItem);

            var expected = "a shiny red gem";
            string[] text = new string[] { "look", "at", "gem", "in", "inventory" };
            var result = TestLook.Execute(TestPlayer, text);

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void LookAtGemInBagTest()
        {
            LookCommand TestLook = new LookCommand();
            Player TestPlayer = new Player("Scorlib", "Perjuangan Lexrin");
            Item TestItem = new Item(new string[] { "gem", "shiny" }, "shiny gem",
                "a shiny red gem");
            Bag TestBag = new Bag(new string[] { "bag", "school" }, "school bag",
                "my favourite school bag");
            TestPlayer.Inventory.Put(TestBag);
            TestBag.Inventory.Put(TestItem);

            var expected = "a shiny red gem";
            string[] text = new string[] { "look", "at", "gem", "in", "bag" };
            var result = TestLook.Execute(TestPlayer, text);

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void LookAtGemInNoBagTest()
        {
            LookCommand TestLook = new LookCommand();
            Player TestPlayer = new Player("Scorlib", "Perjuangan Lexrin");
            Item TestItem = new Item(new string[] { "gem", "shiny" }, "shiny gem",
                "a shiny red gem");
            TestPlayer.Inventory.Put(TestItem);

            var expected = "I cannot find the bag";
            string[] text = new string[] { "look", "at", "gem", "in", "bag" };
            var result = TestLook.Execute(TestPlayer, text);

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void LookAtNoGemInBagTest()
        {
            LookCommand TestLook = new LookCommand();
            Player TestPlayer = new Player("Scorlib", "Perjuangan Lexrin");
            Bag TestBag = new Bag(new string[] { "bag", "school" }, "school bag",
                "my favourite school bag");
            TestPlayer.Inventory.Put(TestBag);

            var expected = "Cannot locate gem in bag";
            string[] text = new string[] { "look", "at", "gem", "in", "bag" };
            var result = TestLook.Execute(TestPlayer, text);

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void InvalidLookTest()
        {
            LookCommand TestLook = new LookCommand();
            Player TestPlayer = new Player("Scorlib", "Perjuangan Lexrin");

            var expected1 = "Error in look input";
            var expected2 = "What do you want to look at?";
            var expected3 = "What do you want to look in?";

            string[] text1 = new string[] { "Hello" };
            string[] text2 = new string[] { "Look", "around" };
            string[] text3 = new string[] { "look", "at", "a", "at", "b" };

            var result1 = TestLook.Execute(TestPlayer, text1);
            var result2 = TestLook.Execute(TestPlayer, text2);
            var result3 = TestLook.Execute(TestPlayer, text3);

            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
            Assert.AreEqual(expected3, result3);
        }
    }
}
