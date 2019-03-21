using System;
using NUnit.Framework;

namespace _4._2
{
    public class UniqueListTests
    {
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
            list.Push("A very looooooooooooong string with many words and letters", 12345);
            Assert.IsFalse(list.IsEmpty);
        }

        [Test]
        public void DeleteTest()
        {
            list.Push("Delete test string", -3012);
            list.Delete(1);
            Assert.IsTrue(list.IsEmpty);
        }

        [Test]
        public void PushExistingElementTest()
        {
            list.Push("Push existing element test string", 1);
            Assert.Throws<AddExistingException>(delegate ()
            {
                list.Push("Push existing element test string", 2);
            });
        }

        [Test]
        public void DeleteUnexistingElementFromEmptyListTest()
        {
            Assert.Throws<DeleteUnexistingException>(delegate ()
            {
                list.Delete(48);
            });
        }

        [Test]
        public void DeleteUnexistingElementTest()
        {
            list.Push("Delete unexisting element test string", 1);
            Assert.Throws<DeleteUnexistingException>(delegate ()
            {
                list.Delete(2);
            });
        }

        private UniqueList list;
    }
}
