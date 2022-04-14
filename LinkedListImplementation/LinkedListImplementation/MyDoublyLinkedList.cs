using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class MyDoublyLinkedList
    {
        private bool IsReversed = false;
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public void Reverse()
        {
            IsReversed = !IsReversed;
        }
        public Node[] ToArray()
        {
            List<Node> list = new List<Node>();

            var node = Head;

            while (node != null)
            {
                list.Add(node);
                node = node.Next;
            }
            return list.ToArray();
        }
        public void ForEach(Action<Node> action)
        {
            var node = Head;

            if (IsReversed)
            {
                node = Tail;
            }

            while (node != null)
            {
                action(node);
                if (IsReversed)
                {
                    node = node.Previuous;
                }
                else
                {
                    node = node.Next;
                }
                
            }
        }
        public Node RemoveLast()
        {
            if (Tail == null)
            {
                return null;
            }

            var previousTail = Tail;
            var nextTail = Tail.Previuous;

            if (nextTail != null)
            {
                nextTail.Next = null;
            }
            else
            {
                Head = null;
            }

            Tail = nextTail;

            return previousTail;
        }

        public Node RemoveFirst()
        {
            if (Head == null)
            {
                return null;
            } 
            var previousHead = Head;
            var nextHead = Head.Next;

            if (nextHead != null)
            {
                nextHead.Previuous = null;
            }
            else
            {
                Tail = null;    
            }
            Head = nextHead;

            return previousHead;
        }

        public void AddFirst(Node node)
        {
            
            if(!CheckIfFirstElement(node))
            {
                Node previousHead = Head;
                Head = node;
                previousHead.Previuous = Head;
                Head.Next = previousHead;
            }
        }

        public void AddLast(Node node)
        {
            if(!CheckIfFirstElement(node))
            {
                Node previousTail = Tail;
                Tail = node;
                previousTail.Next = Tail;
                Tail.Previuous = previousTail;
            }
        }

        private bool CheckIfFirstElement(Node node)
        {
            //Check if first element added to the linked list
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return true;
            }

            return false;
        }
    }
}
