using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture()]
    public class IdentifiableObjectTest
    {
        [Test()]
        public void TestCreation()
        {
            IdentifiableObject ids = new IdentifiableObject(new string[] { "scorlib", "lexrin" });
            Assert.IsNotNull(ids);
        }
        [Test()]
        public void TestAreYou()
        {
            IdentifiableObject ids = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(ids.AreYou("fred"));
        }
        [Test()]
        public void TestNotAreYou()
        {
            IdentifiableObject ids = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsFalse(ids.AreYou("wilma"));
        }
        [Test()]
        public void TestCaseSensitive()
        {
            IdentifiableObject ids = new IdentifiableObject(new string[] { "fred", "bob"});
            Assert.IsTrue(ids.AreYou("FrED"));
        }
        [Test()]
        public void TestFirstID()
        {
            IdentifiableObject ids = new IdentifiableObject(new string[] { "fred", "bob" });
            string first = ids.FirstID;
            StringAssert.AreEqualIgnoringCase(first, "fred");
        }
        [Test()]
        public void TestAddID()
        {
            IdentifiableObject ids = new IdentifiableObject(new string[] { "fred", "bob" });
            ids.AddIdentifier("wilma");

            Assert.IsTrue(ids.AreYou("fred"));
            Assert.IsTrue(ids.AreYou("bob"));
            Assert.IsTrue(ids.AreYou("wilma"));
        }
    }
}
