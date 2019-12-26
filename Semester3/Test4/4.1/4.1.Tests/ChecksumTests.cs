using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace _4._1
{
    public class ChecksumTests
    {
        private Checksum checksum;

        [SetUp]
        public void Setup()
        {
            checksum = new Checksum();
        }

        [Test]
        public void InvalidPathExceptionSingleThreaded()
        {
            Assert.Throws<InvalidPathException>(() => checksum.ChecksumSingleThreaded("trololo"));
        }

        [Test]
        public void InvalidPathExceptionMultipleThreaded()
        {
            Assert.ThrowsAsync<InvalidPathException>(async () => await checksum.ChecksumMultipleThreaded("trololo"));
        }

        [Test]
        public void ChecksumSingleThreaded()
        {
            Assert.NotNull(checksum.ChecksumSingleThreaded(Directory.GetCurrentDirectory()));
        }

        [Test]
        public void ChecksumMultipleThreaded()
        {
            Assert.NotNull(checksum.ChecksumMultipleThreaded(Directory.GetCurrentDirectory()));
        }

        [Test]
        public void Compare()
        {
            Assert.NotNull(checksum.Compare(Directory.GetCurrentDirectory()));
        }
    }
}