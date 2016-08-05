namespace _01TestDatabase
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _01Database;

    [TestClass]
    public class TestDatabase
    {
        private Database db;

        [TestInitialize]
        public void TestInitialize()
        {
            this.db = new Database(new int[] { 1, 2, 3, 4 });
        }

        public void TestDatabaseCapacity()
        {
            Assert.AreEqual(16, this.db.Capacity, "Database capacity is not 16");
        }

        [TestMethod]
        public void TestAddOneElement()
        {
            this.db.Add(10);
            Assert.AreEqual(5, this.db.Count, "Database count not increasing properly");
        }

        [TestMethod]
        public void TestAddSeveralElements()
        {
            this.db.Add(19);
            this.db.Add(10);
            this.db.Add(-1);
            Assert.AreEqual(7, this.db.Count, "Database count not increasing properly when adding more than one element");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddMoreElementsThanCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.db.Add(i);
            }
        }

        [TestMethod]
        public void TestRemoveOneElement()
        {
            this.db.Remove();
            Assert.AreEqual(3, this.db.Count, "Database Remove method not working properly");
        }

        [TestMethod]
        public void TestRemoveSeveralElements()
        {
            this.db.Remove();
            this.db.Remove();
            this.db.Remove();
            Assert.AreEqual(1, this.db.Count);
            CollectionAssert.AreEqual(new int[] { 1 }, this.db.Elements, "Database Remove method not working properly when removing more than one element");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemoveFromEmptyDatabase()
        {
            this.db.Remove();
            this.db.Remove();
            this.db.Remove();
            this.db.Remove();
            this.db.Remove();
        }

        [TestMethod]
        public void TestConstructorValidParameters()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 9 };
            this.db = new Database(numbers);
            CollectionAssert.AreEqual(numbers, this.db.Elements);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestConstructorInValidParametersShouldThrow()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 9, -1, -2, -3, -5, 10, 15, 20, 30, 40, 50 };
            this.db = new Database(numbers);
        }

        [TestMethod]
        public void TestElementsGetterInitialValuesFromConstructor()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, this.db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterNoElements()
        {
            this.db.Remove();
            this.db.Remove();
            this.db.Remove();
            this.db.Remove();
            CollectionAssert.AreEqual(new int[] { }, this.db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterOneElement()
        {
            this.db.Remove();
            this.db.Remove();
            this.db.Remove();
            CollectionAssert.AreEqual(new int[] { 1 }, this.db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterSeveralElements()
        {
            this.db.Add(10);
            this.db.Add(15);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 10, 15 }, this.db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterSixteenElements()
        {
            List<int> expected = new List<int>(new int[] { 1, 2, 3, 4 });
            for (int i = 0; i < 12; i++)
            {
                this.db.Add(i);
                expected.Add(i);
            }

            CollectionAssert.AreEqual(expected, this.db.Elements);
        }
    }
}
