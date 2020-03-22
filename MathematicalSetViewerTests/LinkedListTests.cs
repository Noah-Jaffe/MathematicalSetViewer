using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace MathematicalSetViewer.Tests
{
    [TestClass()]
    public class LinkedListTests
    {
        [TestMethod()]
        public void LinkedListTest()
        {
            // Test for initilization of empty linked list
            LinkedList LList = new LinkedList();
            Assert.IsNotNull(LList);
            Assert.IsInstanceOfType(LList, typeof(LinkedList));
            Assert.AreEqual(0, LList.Count);
            Assert.AreEqual(0, LList.TotalNumericVal);
            Assert.AreEqual(0, LList.PopAll());
        }

        [TestMethod()]
        public void LinkedListTest1()
        {
            // Test for initilization of a populated linked list
            int TestLength = 5;
            Decimal[] zeroes = new Decimal[TestLength];
            for (int i = 0; i < TestLength; ++i)
            {
                zeroes[i] = 0M;
            }

            LinkedList LList = new LinkedList(zeroes);
            Assert.IsNotNull(LList);
            Assert.IsInstanceOfType(LList, typeof(LinkedList));
            Assert.AreEqual(TestLength, LList.Count);
            Assert.AreEqual(0, LList.TotalNumericVal);
            Assert.AreEqual(0, LList.PopAll());
            Assert.AreEqual(0, LList.Count);
            Assert.AreEqual(0, LList.TotalNumericVal);
        }

        [TestMethod()]
        public void AddLastTest()
        {
            // test non argument AddLast
            LinkedList LList = new LinkedList();
            Assert.AreEqual(0, LList.Count);
            Assert.AreEqual(0, LList.TotalNumericVal);
            Assert.AreEqual(0, LList.PopAll());
            LList.AddLast(1M);
            Assert.AreEqual(1, LList.Count);
            Assert.AreEqual(1M, LList.TotalNumericVal);
            Assert.AreEqual(1M, LList.PopAll());
            int expectedCount;
            Decimal expectedNumericVal = 0;
            for (expectedCount = 0; expectedCount < 100; ++expectedCount)
            {
                Decimal value = expectedCount * 2;
                LList.AddLast(value);
                expectedNumericVal += value;
            }
            Assert.AreEqual(expectedCount, LList.Count);
            Assert.AreEqual(expectedNumericVal, LList.TotalNumericVal);
        }

        [TestMethod()]
        public void AddLastTest1()
        {
            // test AddLast which takes a Decimal[] as an argument

            int TestLength = 100;
            Decimal[] vals = new Decimal[TestLength];
            Decimal expectedNumericVal = 0;
            for (int i = 0; i < TestLength; ++i)
            {
                vals[i] = i * 2;
                expectedNumericVal += vals[i];
            }

            LinkedList LList = new LinkedList(vals);
            Assert.AreEqual(TestLength, LList.Count);
            Assert.AreEqual(expectedNumericVal, LList.TotalNumericVal);
        }

        [TestMethod()]
        public void PopTest()
        {
            // test singular pop at a time of a populated array
            int TestLength = 100;
            Decimal[] vals = new Decimal[TestLength];
            Decimal expectedNumericVal = 0;
            for (int i = 0; i < TestLength; ++i)
            {
                vals[i] = i * 2;
                expectedNumericVal += vals[i];
            }

            LinkedList LList = new LinkedList(vals);

            Assert.AreEqual(TestLength, LList.Count);
            Assert.AreEqual(expectedNumericVal, LList.TotalNumericVal);

            for (int i = 0; i < TestLength; ++i)
            {
                Decimal actual = LList.Pop();
                Assert.AreEqual(vals[i], actual);
                expectedNumericVal -= actual;
            }

            Assert.AreEqual(0, LList.Count);
            Assert.AreEqual(0, LList.TotalNumericVal);
        }

        [TestMethod()]
        public void PopAllTest()
        {
            // test PopAll elements at once of a populated array
            int TestLength = 100;
            Decimal[] vals = new Decimal[TestLength];
            Decimal expectedNumericVal = 0;
            for (int i = 0; i < TestLength; ++i)
            {
                vals[i] = i * 2;
                expectedNumericVal += vals[i];
            }

            LinkedList LList = new LinkedList(vals);

            Assert.AreEqual(TestLength, LList.Count);
            Assert.AreEqual(expectedNumericVal, LList.TotalNumericVal);

            Decimal actual = LList.PopAll();
            Assert.AreEqual(expectedNumericVal, actual);

            Assert.AreEqual(0, LList.Count);
            Assert.AreEqual(0, LList.TotalNumericVal);
        }

        [TestMethod()]
        public void LinkedListNodeTest()
        {
            // Test to ensure nodes store the correct values
            Decimal TestVal = 10.2452E25M;
            LinkedListNode node = new LinkedListNode(TestVal);
            Assert.IsNull(node.List);
            Assert.IsNull(node.Next);
            Assert.IsNull(node.Previous);
            Assert.AreEqual(TestVal, node.Value);
        }
    }
}