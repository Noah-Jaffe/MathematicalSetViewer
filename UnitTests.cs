using System;
using System.Diagnostics;

namespace MathematicalSetViewer
{
    class UnitTests
    {
        public UnitTests() {}
        public void RunAllTests() 
        {
            RunLinkedListUnitTests();
            // RunMSVDataTests();
        }

        // TODO: For production remove test functions and turn the neccisary properties to private
        public static bool RunMSVDataTests()
        {
            /*
            Debug.Assert(MSVData.CalculationsEnabled == default(bool));
            Debug.Assert(MSVData.DrawResolution.X == 0M && MSVData.DrawResolution.Y == 0M);
            Debug.Assert(MSVData.RenderEnabled == default(bool));
            Debug.Assert(MSVData.MenuVisible == default(bool));
            Debug.Assert(MSVData.MovementDown == default(bool));
            Debug.Assert(MSVData.MovementLeft == default(bool));

            Debug.Assert(MSVData.MovementRight == default(bool));
            Debug.Assert(MSVData.MovementUp == default(bool));
            Debug.Assert(MSVData.SmoothAccelerationEnabled == default(bool));
            
            Debug.Assert(MSVData._ZoomDeltas.Count == 0, MSVData._ZoomDeltas.Count.ToString());
            // Check more than once because we expect it to have nothing in there
            Debug.Assert(MSVData.ZoomSpeed == 0M);
            Debug.Assert(MSVData.ZoomSpeed == 0M);
            Debug.Assert(MSVData.ZoomSpeed == 0M);
            //Debug.Assert(MSVData._ZoomSpeed == default(Decimal));
            //Debug.Assert(MSVData._ZoomDeltas = new LinkedList(new[] { 0M });
            //Debug.Assert(MSVData.ZoomSpeed


            //Decimal[] smoothlist = MSVData.GetSmoothedList(1M);
            */
            return true;

        }

        public bool RunLinkedListUnitTests ()
        {
            Debug.Assert(LinkedListNodeTest());
            Debug.Assert(LinkedListEmptyInitalizationTest());
            Debug.Assert(LinkedListPopulatedInitalizationTest());
            Debug.Assert(LinkedListDataStorageTest());
            return false;
        }

        private bool LinkedListDataStorageTest()
        {
            // test that the linked list stores the values we expect
            Decimal[] data = new Decimal[5];
            Decimal expectedTotal = 0M;
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Convert.ToDecimal(i);
                expectedTotal += i;
            }

            LinkedList LList = new LinkedList(data);

            Debug.Assert(LList.Count == data.Length, LList.Count.ToString());
            LList.AddLast(0M);
            Debug.Assert(LList.Count == data.Length + 1, LList.Count.ToString());
            Debug.Assert(LList.TotalNumericVal == expectedTotal, LList.TotalNumericVal.ToString());
            expectedTotal -= LList.PopAll();
            Debug.Assert(expectedTotal == 0);

            LList.AddLast(1M);
            Debug.Assert(LList.Pop() == 1M);

            LList.AddLast(1M);
            Debug.Assert(LList.PopAll() == 1M);

            LList.AddLast(1M);
            LList.AddLast(-1M);
            LList.AddLast(2M);
            Debug.Assert(LList.TotalNumericVal == 2M);
            LList.AddLast(-2M);
            Debug.Assert(LList.Pop() == 1M);
            Debug.Assert(LList.Pop() == -1M);
            Debug.Assert(LList.Pop() == 2M);
            Debug.Assert(LList.Pop() == -2M);
            Debug.Assert(LList.Pop() == 0M);
            LList.AddLast(-10M);
            Debug.Assert(LList.TotalNumericVal == -10 && LList.Count == 1);
            Debug.Assert(LList.Pop() == -10M);
            LList.AddLast(-10M);
            LList.AddLast(-1.56E6m);
            LList.AddLast(350.5754M);
            Debug.Assert(LList.TotalNumericVal == -1559659.4246M, LList.TotalNumericVal.ToString());
            Debug.Assert(LList.Count == 3);
            Debug.Assert(LList.Pop() == -10M);
            Debug.Assert(LList.TotalNumericVal == -1559649.4246M, LList.TotalNumericVal.ToString());
            LList.AddLast(4710M);
            Debug.Assert(LList.PopAll() == -1554939.4246M, LList.TotalNumericVal.ToString());
            Debug.Assert(LList.Pop() == 0M);
            Debug.Assert(LList.Count == 0);
            Debug.Assert(LList.TotalNumericVal == 0);

            return true;
        }

        private bool LinkedListEmptyInitalizationTest()
        {
            // Test for initilization of empty linked list
            LinkedList LList = new LinkedList();
            Debug.Assert(LList.Count == 0, LList.Count.ToString());
            LList.AddLast(0M);
            Debug.Assert(LList.Count == 1, LList.Count.ToString());
            for (Decimal i = 0; i < 9; ++i)
            {
                LList.AddLast(0M);
            }
            Debug.Assert(LList.Count == 10, LList.Count.ToString());
            Debug.Assert(LList.TotalNumericVal == 0, LList.TotalNumericVal.ToString());
            Debug.Assert(LList.PopAll() == 0);
            
            return true;
        }

        private bool LinkedListPopulatedInitalizationTest()
        {
            // Test for initilization of a populated linked list
            Decimal[] zeroes = new Decimal[5];
            for (int i = 0; i < zeroes.Length; ++i)
            {
                zeroes[i] = 0M;
            }

            LinkedList LList = new LinkedList(zeroes);

            Debug.Assert(LList.Count == zeroes.Length, LList.Count.ToString());
            LList.AddLast(0M);
            Debug.Assert(LList.Count == zeroes.Length + 1, LList.Count.ToString());
            Debug.Assert(LList.TotalNumericVal == 0, LList.TotalNumericVal.ToString());
            Debug.Assert(LList.PopAll() == 0);

            return true;
        }
        private bool LinkedListNodeTest()
        {
            LinkedListNode node = new LinkedListNode(10M);
            Debug.Assert(node.item == 10M);
            return true;
        }
    }
}
