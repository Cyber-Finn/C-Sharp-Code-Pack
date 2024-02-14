using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephenTechInterviewPack.Custom_Data_Structures
{
    public class StephenDoublyLinkedList
    {
        private Node _Root;
        private int _Size;

        public Node GetFirstElement { get { return _Root; } }
        public int Size { get { return _Size; } }

        private Node GetLastNode
        {
            get
            {
                if (_Root == null)
                    return _Root; //we are intentionally passing back _Root - instead of Null, because it saves us the step of creating a new empty Node object (Which also saves some memory and clock-cycles)

                //doing an Else statement/check here takes up a clock-cycle, which adds latency.
                //We know that the program will only ever reach this point if the Root node is not empty

                Node node = _Root;
                while (node.Next != null)
                {
                    //move the node to the next node in the list
                    node = node.Next;
                }
                return node;
            }
        }

        private Node GetPreviousNode(object data)
        {
            Node node = _Root;
            Node preceedingNode = new Node();

            while (node.Next != null)
            {
                if (node.Next.Data.Equals(data))
                {
                    preceedingNode = node;
                    break;
                }

                //move the node to the next node in the list
                node = node.Next;
            }
            return preceedingNode;
        }

        public void AddElement(object data)
        {
            Node n = new Node { Data = data };

            if (_Root == null)
                _Root = n;
            else
            {
                //link this new node's previous node to the last node in the list (So that it points backwards)
                n.Previous = GetLastNode;
                //link the last node's Next to the new "last node"
                GetLastNode.Next = n;
            }

            _Size++;
        }


        public void DeleteElement(object data)
        {
            if (_Root.Data.Equals(data))
            {
                if (_Root.Next != null)
                {
                    Node oldRoot = _Root;
                    //reset the previous Node (We can't have the root node pointing to a non-existent node)
                    oldRoot.Next.Previous = new Node();
                    _Root = oldRoot.Next;
                }
                else
                {
                    _Root = null;
                }
            }

            else
            {
                //this will essentially erase the node we need to, by moving the rest of the list up by 1 position
                Node n = GetPreviousNode(data);
                Node ne = n.Next.Next;
                n.Next = ne;
            }
            _Size--;
        }


        /// <summary>
        /// Returns the element at the specified index, returns null if the element does not exist. (Starts at 1, not 0)
        /// </summary>
        ///     <param name="target">the nth element to find. <br></br> eg. If 5 is passed in, we will find the 5th element</param>
        /// <returns></returns>
        public Node? GetElementAt(int target)
        {
            int count = 1;

            if ((_Root == null) || (target <= 1))
                return _Root;

            Node node = _Root;

            while (node.Next != null)
            {
                count++;
                if (count == target)
                    return node;

                //move the node to the next node in the list
                node = node.Next;
            }
            return null;
        }




        public class Node
        {
            // Doubly linked lists will have reference/links to the nodes on either side of it (Previous and next)
            // This data structure is still linear, but allows us to iterate over it in either direction (Forward or backwards)
            public Node Previous;
            public Node Next;
            public object Data;
        }
    }
}
