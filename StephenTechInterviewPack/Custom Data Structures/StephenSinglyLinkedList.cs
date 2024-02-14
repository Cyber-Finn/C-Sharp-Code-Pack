using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephenTechInterviewPack.Custom_Data_Structures
{
    public class StephenSinglyLinkedList
    {
        private Node _Root;
        private int _Size = 0;

        //doing the method like this allows us to call GetRoot, without using brackets "()", and lets us access the object returned directly (without making copies) since we use the Get modifier
        public Node GetFirstElement { get { return _Root; } }
        /// <summary>
        /// returns the index size of the collection (Starts at 1, not 0)
        /// </summary>
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

        private Node FindPreceedingNode(object data)
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
                GetLastNode.Next = n;

            _Size++;
        }

        /// <summary>
        /// Returns the element at the specified index, returns null if the element does not exist.
        /// </summary>
        ///     <param name="target">the nth element to find. <br></br> eg. If 5 is passed in, we will find the 5th element</param>
        /// <returns></returns>
        public Node? GetElementAt(int target)
        {
            int count = 0;

            if((_Root == null) || (target <= 0))
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
                    
            }
                
            else
            {
                //this will essentially erase the node we need to, by moving the rest of the list up by 1 position
                Node n = FindPreceedingNode(data);
                Node ne = n.Next.Next;
                n.Next = ne;
            }
            _Size--;
        }

        public class Node
        {
            public Node Next;
            public object Data;
        }
    }
}
