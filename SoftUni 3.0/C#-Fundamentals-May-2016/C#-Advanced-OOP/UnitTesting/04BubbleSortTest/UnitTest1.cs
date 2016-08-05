namespace _04BubbleSortTest
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _04BubbleSort;

    [TestClass]
    public class BubbleSortTest
    {
        private BubbleSort bubble;
        private List<int> collection;

        [TestInitialize]
        public void Init()
        {
            this.bubble = new BubbleSort();
            this.collection = new List<int>();
        }
        [TestMethod]
        public void ShouldSortCorrectlyInAscendingOrder()
        {
            this.collection = new List<int>() { 23, 4, 1, 2, 32, 1, 512, 31231, 123, 11241, 5, 12311, 545 };
            var sorted = this.bubble.Sort(this.collection);
            this.collection.Sort();
            CollectionAssert.AreEqual(this.collection, sorted);
        }

        [TestMethod]
        public void ShouldSortZerosCorrectlyInAscendingOrder()
        {
            this.collection = new List<int>() { 0, 0 };
            var sorted = this.bubble.Sort(this.collection);
            this.collection.Sort();
            CollectionAssert.AreEqual(this.collection, sorted);
        }

    }
}
