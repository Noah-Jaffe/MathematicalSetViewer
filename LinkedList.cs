using System;
namespace MathematicalSetViewer
{
    public class LinkedList
    {
        internal LinkedListNode head;
        public int Count { get; private set; }
        public decimal TotalNumericVal { get; private set; }

        public LinkedList()
        {
        }

        /// <summary>
        /// Init a linked list with the specified values contained inside
        /// </summary>
        /// <param name="vals"></param>
        public LinkedList(Decimal[] vals)
        {
            foreach (Decimal item in vals)
            {
                AddLast(item);
            }
        }

        /// <summary>
        /// Adds an item to the end of the list
        /// </summary>
        /// <param name="value">Decimal</param>
        public void AddLast(Decimal value)
        {
            LinkedListNode newNode = new LinkedListNode(this, value);
            if (head == null)
            {
                // adding first item
                newNode.next = newNode;
                newNode.prev = newNode;
                head = newNode;

            }
            else
            {
                // Add item to the back of the list and to circularly point to the front
                newNode.next = head;
                newNode.prev = head.prev;
                head.prev.next = newNode;
                head.prev = newNode;
            }
            TotalNumericVal += value;

            ++Count;
        }

        /// <summary>
        /// Adds a list of items to the end of the list in the order they appear in the array.
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(Decimal[] values)
        {
            foreach (Decimal val in values)
            {
                AddLast(val);
            }
        }

        /// <summary>
        /// Returns the first item on the list if it exists, else it returns null;
        /// </summary>
        /// <returns></returns>
        public Decimal Pop()
        {
            if (head == null)
            {
                return 0M;
            }
            else if (head.next == head)
            {
                Decimal popped = head.Value;
                head.Invalidate();
                head = null;
                --Count;
                TotalNumericVal -= popped;
                return popped;

            }
            else
            {

                // Remove item from the front of the list and ensure the circular list is still intact
                LinkedListNode newHead = head.next;
                Decimal popped = head.Value;
                head.next.prev = head.prev;
                head.prev.next = head.next;
                head.Invalidate();
                head = newHead;
                TotalNumericVal -= popped;
                --Count;
                return popped;
            }
        }

        public Decimal PopAll()
        {
            //Decimal total = 0M;
            LinkedListNode current = head;
            while (current != null)
            {
                LinkedListNode temp = current;
                current = current.Next;   // use Next the instead of "next", otherwise it will loop forever
                temp.Invalidate();
            }
            Decimal ttl = TotalNumericVal;
            head = null;
            Count = 0;
            TotalNumericVal = 0;
            return ttl;
        }

    }

    public sealed class LinkedListNode
    {
        internal LinkedList list;
        internal LinkedListNode next;
        internal LinkedListNode prev;
        internal Decimal item;

        public LinkedListNode(Decimal value)
        {
            item = value;
        }

        internal LinkedListNode(LinkedList list, Decimal value)
        {
            this.list = list;
            item = value;
        }

        public LinkedList List
        {
            get { return list; }
        }

        public LinkedListNode Next
        {
            get { return next == null || next == list.head ? null : next; }
        }

        public LinkedListNode Previous
        {
            get { return prev == null || this == list.head ? null : prev; }
        }

        public Decimal Value
        {
            get { return item; }
            set { item = value; }
        }

        internal void Invalidate()
        {
            list = null;
            next = null;
            prev = null;
        }
    }
}