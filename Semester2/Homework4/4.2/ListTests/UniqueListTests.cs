using System;
using NUnit.Framework;

namespace _4._2
{
    public class UniqueListTests
    {
        private UniqueList list;

        [SetUp]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [Test]
        public void IsEmptyListTest()
        {
            Assert.IsTrue(list.IsEmpty);
        }

        [Test]
        public void PushTest()
        {
            list.Add("A very looooooooooooong string with many words and letters", 12345);
            Assert.IsFalse(list.IsEmpty);
        }

        [Test]
        public void DeleteTest()
        {
            list.Add("Delete test string", -3012);
            list.Delete(1);
            Assert.IsTrue(list.IsEmpty);
        }

        [Test]
        public void AddExistingElementTest()
        {
            list.Add("Add existing element test string", 1);
            Assert.Throws<AddExistingException>(() => list.Add("Add existing element test string", 2));
        }

        [Test]
        public void DeleteUnexistingElementFromEmptyListTest()
        {
            Assert.Throws<DeleteUnexistingException>(() => list.Delete(48));
        }

        [Test]
        public void DeleteUnexistingElementTest()
        {
            list.Add("Delete unexisting element test string", 1);
            Assert.Throws<DeleteUnexistingException>(() => list.Delete(2));
        }
    }
}
