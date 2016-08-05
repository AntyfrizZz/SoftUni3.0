namespace _03ListIteratorTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _03ListIterator;

    [TestClass]
    public class ListIteratorTests
    {
        private List<string> strings;
        private ListIterator listIterator;

        [TestInitialize]
        public void Init()
        {
            this.strings = new List<string>();
        }

        [TestMethod]
        public void ConstructorInitializationShouldCopyAllItemsIntoInnerList()
        {
            this.strings.Add("Pesho");
            this.strings.Add("Gosho");
            this.listIterator = new ListIterator(this.strings);
            CollectionAssert.AreEqual(this.strings, this.listIterator.Collection);
        }

        [TestMethod]
        public void MoveShouldReturnTrueOnceWithTwoElements()
        {
            this.strings.Add("Pesho");
            this.strings.Add("Gosho");
            this.listIterator = new ListIterator(this.strings);
            bool result1 = this.listIterator.Move();
            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void MoveShouldReturnTrueOnceAndFalseOnceWithTwoElements()
        {
            this.strings.Add("Pesho");
            this.strings.Add("Gosho");
            this.listIterator = new ListIterator(this.strings);
            bool result1 = this.listIterator.Move();
            Assert.IsTrue(result1);
            bool result2 = this.listIterator.Move();
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void HasNextShouldReturnTrueWithTwoElementsAndNoMove()
        {
            this.strings.Add("Pesho");
            this.strings.Add("Gosho");
            this.listIterator = new ListIterator(this.strings);
            bool result1 = this.listIterator.HasNext();
            Assert.IsTrue(result1);
        }
        [TestMethod]
        public void HasNextShouldReturnFalseWithTwoElementsAndOneMove()
        {
            this.strings.Add("Pesho");
            this.strings.Add("Gosho");
            this.listIterator = new ListIterator(this.strings);
            this.listIterator.Move();
            bool result1 = this.listIterator.HasNext();
            Assert.IsFalse(result1);
        }
        [TestMethod]
        public void PrintShouldNotThrowWithNoMove()
        {
            this.strings.Add("Pesho");
            this.strings.Add("Gosho");
            this.listIterator = new ListIterator(this.strings);
            this.listIterator.Print();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PrintShouldThrowWithNoElements()
        {
            this.listIterator = new ListIterator(this.strings);
            this.listIterator.Print();
        }
    }
}
