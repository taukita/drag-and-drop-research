using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.ViewModels;
using NUnit.Framework;

namespace DragAndDropResearch.Tests
{
    [TestFixture]
    internal class CollectionAndItemTests
    {
        [Test]
        public void OneCollectionOneItemTest()
        {
            var c = new CollectionViewModel();
            var i = new ItemViewModel();

            Assert.AreEqual(null, i.Collection);
            Assert.AreEqual(0, c.Count);

            i.Collection = c;

            Assert.AreEqual(c, i.Collection);
            Assert.AreEqual(1, c.Count);

            i.Collection = null;

            Assert.AreEqual(null, i.Collection);
            Assert.AreEqual(0, c.Count);

            c.Add(i);

            Assert.AreEqual(c, i.Collection);
            Assert.AreEqual(1, c.Count);

            c.Remove(i);

            Assert.AreEqual(null, i.Collection);
            Assert.AreEqual(0, c.Count);
        }

        [Test]
        public void TwoCollectionsOneItemTest()
        {
            var c1 = new CollectionViewModel();
            var c2 = new CollectionViewModel();
            var i = new ItemViewModel();

            Assert.AreEqual(null, i.Collection);
            Assert.AreEqual(0, c1.Count);
            Assert.AreEqual(0, c2.Count);

            i.Collection = c1;

            Assert.AreEqual(c1, i.Collection);
            Assert.AreEqual(1, c1.Count);
            Assert.AreEqual(0, c2.Count);

            i.Collection = c2;

            Assert.AreEqual(c2, i.Collection);
            Assert.AreEqual(0, c1.Count);
            Assert.AreEqual(1, c2.Count);

            c1.Add(i);

            Assert.AreEqual(c1, i.Collection);
            Assert.AreEqual(1, c1.Count);
            Assert.AreEqual(0, c2.Count);
        }

        [Test]
        public void SameItemTest()
        {
            var c = new CollectionViewModel();
            var i = new ItemViewModel();

            c.Add(i);
            c.Add(i);

            Assert.AreEqual(c, i.Collection);
            Assert.AreEqual(1, c.Count);
        }
    }
}
