using System;
using NUnit.Framework;
using System.Collections;

namespace _3._2
{
    [TestFixtureSource(typeof(FixtureDataStack), "FixtureParameters")]
    public class HashTableTests
    {
        public HashTableTests(IHash hash)
        {
            this.hash = hash;
        }

        [SetUp]
        public void Initialize()
        {
            hashTable = new HashTable(50, hash);
        }

        [Test]
        public void IsContainedInEmptyHashTableTest()
        {
            Assert.IsFalse(hashTable.IsContained("Is contained in empty hash table test"));
        }

        [Test]
        public void PushTest()
        {
            hashTable.Push("Push test");
            Assert.IsTrue(hashTable.IsContained("Push test"));
        }

        [Test]
        public void ManyPushTest()
        {
            for (int i = 0; i < 50000; ++i)
            {
                hashTable.Push(i.ToString());
                Assert.IsTrue(hashTable.IsContained(i.ToString()));
            }
        }

        [Test]
        public void DeleteTest()
        {
            hashTable.Push("Delete test");
            hashTable.Delete("Delete test");
            Assert.IsFalse(hashTable.IsContained("Delete test"));
        }

        [Test]
        public void DeleteFromEmptyHashTableTest()
        {
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                hashTable.Delete("Delete from empty hash table test");
            });
        }

        [Test]
        public void ManyPushAndDeleteTest()
        {
            for (int i = 0; i < 20000; ++i)
            {
                hashTable.Push(i.ToString());
            }
            for (int i = 0; i < 20000; ++i)
            {
                hashTable.Delete(i.ToString());
            }
            for (int i = 0; i < 20000; ++i)
            {
                Assert.IsFalse(hashTable.IsContained(i.ToString()));
            }
        }

        private HashTable hashTable;
        private IHash hash;
    }

    public class FixtureDataStack
    {
        public static IEnumerable FixtureParameters()
        {
            yield return new HashFunction1();
            yield return new HashFunction2();
        }
    }
}