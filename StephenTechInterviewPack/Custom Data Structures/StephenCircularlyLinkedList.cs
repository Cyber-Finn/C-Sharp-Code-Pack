using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephenTechInterviewPack.Custom_Data_Structures
{
    public class StephenCircularlyLinkedList
    {
        private Node _Root;
        private int _Size;

        public Node GetFirstElement { get { return _Root; } }
        public int Size { get { return _Size; } }

        private Node GetLastNode
        {
            get
            {
                if (_Root.Next == null)
                    return _Root;

                //doing an Else statement/check here takes up a clock-cycle, which adds latency.
                //We know that the program will only ever reach this point if the Root node is not empty

                Node node = _Root;
                while (node.Next != _Root)
                {
                    //move the node to the next node in the list
                    node = node.Next;

                    //just an extra check to ensure we exit if there are any breaks in our circular list
                    if ((node.Next == null))
                        return null;

                }
                return node;
            }
        }

        private Node GetPreceedingNode(object data)
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
             
            else if (_Root.Next == null && _Size  == 1)
            {
                n.Next = _Root;
                _Root.Next = n;
            }

            else
            {
                //link this new node's next node to the Root node in the list (So that it points back to the start [making a circle])
                n.Next = _Root;
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
                    _Root = oldRoot.Next;
                }
                else
                {
                    _Root = null;
                }

                _Size--;
            }

            else
            {
                //this will essentially erase the node we need to, by moving the rest of the list up by 1 position
                Node n = GetPreceedingNode(data);
                Node ne = new Node();
                if((n.Next.Next != null) && (!n.Next.Next.Equals(_Root)) && (!n.Next.Next.Equals(n)))
                {
                    ne = n.Next.Next;
                    n.Next = ne;
                    _Size--;
                }
            }
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

            while (node.Next != _Root)
            {
                count++;
                if (count == target)
                    return node;

                //move the node to the next node in the list
                node = node.Next;

                //just an extra sanity check to make sure we dont have an infinite loop
                if((node.Next == null) || (count > _Size))
                    return null;
            }
            return null;
        }

        public void DeleteElementAt(int target)
        {
            if (target < 1)
                target = 1;

            if ((_Root == null))
            {
                //do nothing
            }
            else
            {
                if (target == 1 && _Root.Next == null)
                {
                    _Root = null;
                    _Size--;
                }

                else if (target == 1 && _Root.Next != null)
                {
                    if(_Root.Next.Next == _Root)
                        _Root.Next.Next = null;

                    _Root = _Root.Next;
                    _Size--;
                }

                else
                    DeleteNode(target);
            }
        }

        private void DeleteNode(int indexOfPreceedingNode)
        {
            Node n = GetElementAt(indexOfPreceedingNode-1);
            
            if ((n != null) && ((n.Next.Next != null) && (!n.Next.Next.Equals(_Root) && (!n.Next.Next.Equals(n)))))
            {
                Node ne = new Node();
                ne = n.Next.Next;
                n.Next = ne;

                _Size--;
            }
        }



        public class Node
        {
            // Doubly linked lists will have reference/links to the nodes on either side of it (Previous and next)
            // This data structure is still linear, but allows us to iterate over it in either direction (Forward or backwards)
            public Node Next;
            public object Data;
        }
    }
}
