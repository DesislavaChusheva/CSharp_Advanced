using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class CustomLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int[] ToArray { get; set; }

        private int count = 0;

        public void AddFirst(Node node)
        {
            count++;
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Next = Head;
        }

        public void AddLast(Node node)
        {
            if (Tail == null)
            {
                count++;
                Head = node;
                Tail = node;
                return;
            }
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public Node RemoveHead()
        {
            count--;
            if (Head == null)
            {
                return null;
            }
            var nodeReturn = Head;
            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }
            return nodeReturn;
        }
        public Node RemoveTail()
        {
            count--;
            if (Tail == null)
            {
                return null;
            }
            var nodeReturn = Tail;
            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Tail = null;
                Head = null;
            }
            return nodeReturn;
        }
        public void ForeachromHead(Action<Node> action)
        {
            Node currNode = Head;
            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Next;
            }
        }
        public void ForeachromTail(Action<Node> action)
        {
            Node currNode = Tail;
            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Previous;
            }
        }
        public int[] ToArray()
        {
            int index = 0;
            int[] array = new int[count];

            ForeachromHead ((node) =>
                {
                    array[index] = node.Value;
                    index++;
                })
        }
    }
}
