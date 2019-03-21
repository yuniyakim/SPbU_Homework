using System;
using NUnit.Framework;

namespace _4._2
{
    public class ListTests
    {
        [SetUp]
        public void Initialize()
        {
            list = new List();
        }

        [Test]
        public void IsEmptyListTest()
        {
            Assert.IsTrue(list.IsEmpty);
        }

        [Test]
        public void PushTest()
        {
            list.Push("A very looooooooooooong string with many words and letters", 1245);
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
        public void ManyElementsPushTest()
        {
            for (int i = -10000; i < 10000; ++i)
            {
                list.Push("Many elements push test", 1);
            }
        }

        [Test]
        public void ManyPushAndDeleteTest()
        {
            for (int i = -10000; i < 10000; ++i)
            {
                list.Push(i.ToString(), i + 10000);
            }
            for (int i = 10000; i > 10000; --i)
            {
                list.Delete(1);
            }
        }

        [Test]
        public void PushOverflowListTest()
        {
            list.Push("Number1", 1);
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                list.Push("Number3", 3);
            });
        }

        [Test]
        public void DeleteFromEmptyListTest()
        {
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                list.Delete(542);
            });
        }

        [Test]
        public void DeleteOverflowListTest()
        {
            list.Push("Number1", 1);
            list.Push("Number3", 2);
            list.Push("Number2", 2);
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                list.Delete(-8);
            });
        }

        [Test]
        public void IsContainedByPositionListTest()
        {
            list.Push("One", 1);
            list.Push("Two", 1);
            list.Push("Three", 2);
            list.Push("Four", 4);
            Assert.IsTrue(list.IsContainedByPosition(3));
        }

        [Test]
        public void IsNotContainedByPositionListTest()
        {
            list.Push("One", 1);
            list.Push("Two", 1);
            list.Push("Three", 1);
            list.Push("Four", 2);
            Assert.IsFalse(list.IsContainedByPosition(-8));
        }

        [Test]
        public void IsContainedByValueListTest()
        {
            list.Push("One", 1);
            list.Push("Two", 2);
            list.Push("Three", 1);
            list.Push("Four", 1);
            Assert.IsTrue(list.IsContainedByValue("Four"));
        }

        [Test]
        public void IsNotContainedByValueListTest()
        {
            list.Push("One", 1);
            list.Push("Two", 1);
            list.Push("Three", 3);
            list.Push("Four", 1);
            Assert.IsFalse(list.IsContainedByValue("Five"));
        }

        [Test]
        public void PositionByValueTest()
        {
            list.Push("2", 1);
            list.Push("3", 2);
            list.Push("1", 1);
            list.Push("0", 1);
            Assert.AreEqual(3, list.PositionByValue("2"));
        }

        [Test]
        public void ZeroPositionByValueTest()
        {
            list.Push("2", 1);
            list.Push("3", 2);
            list.Push("1", 1);
            list.Push("0", 1);
            Assert.AreEqual(0, list.PositionByValue("5"));
        }

        [Test]
        public void GetValueFromEmptyListTest()
        {
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                list.GetValue(0);
            });
        }

        [Test]
        public void GetValueOverflowListTest()
        {
            list.Push("Number2", 1);
            list.Push("Number3", 2);
            list.Push("Number1", 1);
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                list.GetValue(-1356);
            });
        }

        [Test]
        public void SetValueInEmptyListTest()
        {
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                list.SetValue("Set value in empty list test", 1);
            });
        }

        [Test]
        public void SetValueOverflowListTest()
        {
            list.Push("22222", 1);
            list.Push("33333", 2);
            list.Push("11111", 1);
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                list.SetValue("Set value overflow list test", 0);
            });
        }

        private List list;
    }
}