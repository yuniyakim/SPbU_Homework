using System;
using NUnit.Framework;
using System.Collections;

namespace _3._1
{
    [TestFixtureSource(typeof(FixtureDataStack), "FixtureParameters")]
    public class StackTests
    {
        private IStack stack;

        public StackTests(IStack stack)
        {
            this.stack = stack;
        }

        [SetUp]
        public void Clear()
        {
            stack.Clear();
        }

        [Test]
        public void PushTest()
        {
            stack.Push(10);
            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public void PopTest()
        {
            stack.Push(165);
            Assert.AreEqual(165, stack.Pop());
        }

        [Test]
        public void TwoElementsPopTest()
        {
            stack.Push(12345);
            stack.Push(67890);
            Assert.AreEqual(67890, stack.Pop());
            Assert.AreEqual(12345, stack.Pop());
        }

        [Test]
        public void PopFromEmptyStackTest()
        {
            Assert.Throws<InvalidOperationException>(delegate()
            {
                stack.Pop();
            });
        }

        [Test]
        public void ManyElementsPushTest()
        {
            for (int i = -1000000; i < 1000000; ++i)
            {
                stack.Push(i);
            }
        }

        [Test]
        public void ManyElementsPushAndPopTest()
        {
            for (int i = -100000; i < 100000; ++i)
            {
                stack.Push(i);
            }
            for (int i = 100000; i > 100000; --i)
            {
                Assert.AreEqual(i, stack.Pop());
            }
        }

        [Test]
        public void IsEmptyStackTest()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void IsEmptyAfterPushAndPopTest()
        {
            stack.Push(123456);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void ClearTest()
        {
            for (int i = 0; i < 20; ++i)
            {
                stack.Push(i);
            }
            stack.Clear();
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void LengthTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                stack.Push(5);
            }
            Assert.AreEqual(10, stack.Length());
        }
    }

    public class FixtureDataStack
    {
        public static IEnumerable FixtureParameters()
        {
            yield return new StackArray();
            yield return new StackList();
        }
    }
}
