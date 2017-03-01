namespace _02ExtendedDatabaseTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _02ExtendedDatabase;

    [TestClass]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase db;

        [TestInitialize]
        public void TestInitialize()
        {
            List<Person> initalPeople = new List<Person>()
            {
                new Person(1, "Misho"),
                new Person(2, "Gosho")
            };

            this.db = new ExtendedDatabase(initalPeople);
        }

        [TestMethod]
        public void TestDatabaseCapacity()
        {
            Assert.AreEqual(16, this.db.Capacity, "Database capacity is not 16");
        }

        [TestMethod]
        public void TestAddOneElement()
        {
            this.db.Add(new Person(3, "Mitko"));
            Assert.AreEqual(3, this.db.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddDuplicateIdPersonShouldThrow()
        {
            this.db.Add(new Person(2, "Pesho"));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddDuplicateUsernamePersonShouldThrow()
        {
            this.db.Add(new Person(3, "Misho"));
        }

        [TestMethod]
        public void TestAddSeveralElements()
        {
            this.db.Add(new Person(3, "Mitko1"));
            this.db.Add(new Person(4, "Mitko2"));
            this.db.Add(new Person(5, "Mitko3"));
            Assert.AreEqual(5, this.db.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddMoreElementsThanCapacity()
        {
            for (int i = 0; i < 16; i++)
            {
                this.db.Add(new Person(i, "Mitko" + i));
            }
        }

        [TestMethod]
        public void TestRemoveOneElement()
        {
            this.db.Remove();
            Assert.AreEqual(1, this.db.Count);
        }

        [TestMethod]
        public void TestRemoveSeveralElements()
        {
            this.db.Remove();
            Assert.AreEqual(1, this.db.Count);
            CollectionAssert.AreEqual(new Person[] { new Person(1, "Misho") }, this.db.Elements);
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
            Person[] expectedPeople = new Person[]
            {
                new Person(3, "Mitko1"),
                new Person(4, "Mitko2"),
                new Person(5, "Mitko3")
            };
            this.db = new ExtendedDatabase(expectedPeople);
            CollectionAssert.AreEqual(expectedPeople, this.db.Elements);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestConstructorInValidParametersShouldThrow()
        {
            List<Person> expectedPeople = new List<Person>();
            for (int i = 3; i < 21; i++)
            {
                expectedPeople.Add(new Person(i, "Mitko" + i));

            }
            this.db = new ExtendedDatabase(expectedPeople);
        }

        [TestMethod]
        public void TestElementsGetterInitialValuesFromConstructor()
        {
            List<Person> expectedPeople = new List<Person>()
            {
                new Person(1, "Misho"),
                new Person(2, "Gosho")
            };
            CollectionAssert.AreEqual(expectedPeople, this.db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterNoElements()
        {
            this.db.Remove();
            this.db.Remove();
            CollectionAssert.AreEqual(new Person[] { }, this.db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterOneElement()
        {
            this.db.Remove();
            CollectionAssert.AreEqual(new Person[] { new Person(1, "Misho") }, this.db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterSeveralElements()
        {
            this.db.Add(new Person(3, "Mitko3"));
            this.db.Add(new Person(4, "Mitko4"));
            Person[] expectedPeople = new Person[]
            {
                new Person(1, "Misho"),
                new Person(2, "Gosho"),
                new Person(3, "Mitko3"),
                new Person(4, "Mitko4")
            };
            CollectionAssert.AreEqual(expectedPeople, this.db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterSixteenElements()
        {
            List<Person> expected = new List<Person>()
            {
                new Person(1, "Misho"),
                new Person(2, "Gosho")
            };
            for (int i = 3; i < 17; i++)
            {
                Person p = new Person(i, "Goshko" + i);
                this.db.Add(p);
                expected.Add(p);
            }

            CollectionAssert.AreEqual(expected, this.db.Elements);
        }

        [TestMethod]
        public void TestFindByIdValidParametersShouldPass()
        {
            Person expected = new Person(1, "Misho");
            Person actual = this.db.FindById(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFindByIdNegativeIdShouldThrow()
        {
            this.db.FindById(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindByUsernameNullParameterShouldThrow()
        {
            this.db.FindByUsername(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFindByIdUserNotFoundShouldThrow()
        {
            this.db.FindById(100);
        }

        [TestMethod]
        public void TestFindByUsernameValidParametersShouldPass()
        {
            Person expected = new Person(2, "Gosho");
            Person actual = this.db.FindByUsername("Gosho");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFindByUsernameUserNotFoundShouldThrow()
        {
            this.db.FindByUsername("Toshko");
        }
    }
}
