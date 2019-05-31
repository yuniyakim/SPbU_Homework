using System;
using NUnit.Framework;

namespace _1._1
{
    public class QueueTests
    {
        private Queue queue;

        [SetUp]
        public void Setup()
        {
            queue = new Queue();
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void EnqueueWithPositivePriorityTest()
        {
            queue.Enqueue("Enqueue to empty queue test", 12);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void EnqueueWithNegativePriorityTest()
        {
            queue.Enqueue("Enqueue to empty queue test", -8);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void EnqueueWithZeroPriorityTest()
        {
            queue.Enqueue("Enqueue to empty queue test", 0);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void EnqueuToNonEmptyQueueWithHigherPriorityTest()
        {
            queue.Enqueue("Enqueue to non-empty queue with higher priority test", 0);
            queue.Enqueue("Another enqueue to non-empty queue with higher priority test", 97);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void EnqueuToNonEmptyQueueWithLowerPriorityTest()
        {
            queue.Enqueue("Enqueue to non-empty queue with lower priority test", 6);
            queue.Enqueue("Another enqueue to non-empty queue with lower priority test", -13);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void HighestPositivePriorityTest()
        {
            queue.Enqueue("Eleven", 11);
            queue.Enqueue("Three", 3);
            queue.Enqueue("Fourty two", 42);
            queue.Enqueue("One", 1);
            queue.Enqueue("Minus eight", -8);
            queue.Enqueue("One", 1);
            Assert.AreEqual(42, queue.HighestPriority());
        }

        [Test]
        public void HighestZeroPriorityTest()
        {
            queue.Enqueue("Minus three", -3);
            queue.Enqueue("Minus eight", -8);
            queue.Enqueue("Zero", 0);
            queue.Enqueue("Minus one", -1);
            Assert.AreEqual(0, queue.HighestPriority());
        }

        [Test]
        public void HighestNegativePriorityTest()
        {
            queue.Enqueue("Minus thirty three", -3);
            queue.Enqueue("Minus eight", -8);
            queue.Enqueue("Minus ninty four", -94);
            queue.Enqueue("Minus one", -1);
            Assert.AreEqual(-1, queue.HighestPriority());
        }

        [Test]
        public void HighestPriorityInEmptyQueueTest()
        {
            Assert.Throws<EmptyQueueException>(() => queue.HighestPriority());
        }

        [Test]
        public void HighestPriorityPositionTest()
        {
            queue.Enqueue("Eleven", 11);
            queue.Enqueue("Three", 3);
            queue.Enqueue("Minus seven", -7);
            queue.Enqueue("Twenty", 20);
            queue.Enqueue("Minus eight", -8);
            queue.Enqueue("One", 1);
            Assert.AreEqual(4, queue.HighestPriorityPosition());
        }

        [Test]
        public void HighestPriorityPositionInEmptyQueueTest()
        {
            Assert.Throws<EmptyQueueException>(() => queue.HighestPriorityPosition());
        }

        [Test]
        public void DequeueTest()
        {
            queue.Enqueue("Thirteen", 13);
            Assert.AreEqual("Thirteen", queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void DequeueWithNegativePriorityTest()
        {
            queue.Enqueue("Minus eight", -8);
            Assert.AreEqual("Minus eight", queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void DequeueFromEmptyQueueTest()
        {
            Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
        }

        [Test]
        public void SeveralDequeueTest()
        {
            queue.Enqueue("Thirteen", 13);
            queue.Enqueue("Eleven", 11);
            queue.Enqueue("Three", 3);
            queue.Enqueue("Minus seven", -7);
            queue.Enqueue("Twenty three", 23);
            queue.Enqueue("Minus eight", -8);
            queue.Enqueue("One", 1);
            Assert.AreEqual("Twenty three", queue.Dequeue());
            Assert.AreEqual("Thirteen", queue.Dequeue());
            Assert.AreEqual("Eleven", queue.Dequeue());
        }

        [Test]
        public void DequeueWithSameHighestPriorityTest()
        {
            queue.Enqueue("Thirteen", 13);
            queue.Enqueue("Eleven", 11);
            queue.Enqueue("Three", 3);
            queue.Enqueue("Minus seven", -7);
            queue.Enqueue("First", 55);
            queue.Enqueue("Minus eight", -8);
            queue.Enqueue("Second", 55);
            queue.Enqueue("One", 1);
            Assert.AreEqual("First", queue.Dequeue());
            Assert.AreEqual("Second", queue.Dequeue());
        }
    }
}