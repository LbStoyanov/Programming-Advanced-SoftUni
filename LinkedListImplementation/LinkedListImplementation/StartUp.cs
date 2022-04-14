using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MyDoublyLinkedList myDoublyLinkedList = new MyDoublyLinkedList();

            myDoublyLinkedList.AddFirst(new Node(1));
            myDoublyLinkedList.AddFirst(new Node(2));
            myDoublyLinkedList.AddFirst(new Node(3));

            Node node = myDoublyLinkedList.Head;

            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            
        }
    }
}
