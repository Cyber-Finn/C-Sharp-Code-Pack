using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephenTechInterviewPack.Custom_Data_Structures
{
    internal class StephenSinglyLinkedList
    {
        public Node Root;

        //doing the method like this allows us to call GetRoot, without using brackets "()", and lets us access the object returned directly (without making copies) since we use the Get modifier
        public Node GetFirstElement { get { return Root; } }

        private Node GetLastNode
        {
            get
            {
                if (Root == null)
                    return null;

                //doing an Else statement/check here takes up a clock-cycle, which adds latency.
                //We know that the program will only ever reach this point if the Root node is not empty

                Node node = Root;
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
            Node node = Root;
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

            if (Root == null)
                Root = n;
            else
                GetLastNode.Next = n;
        }



        public void DeleteElement(object data)
        {
            if (Root.Data.Equals(data))
            {
                if (Root.Next != null)
                {
                    Node oldRoot = Root;
                    Root = oldRoot.Next;
                }
                else
                {
                    Root = null;
                }
                    
            }
                
            else
            {
                //this will essentially erase the node we need to, by moving the rest of the list up by 1 position
                Node n = FindPreceedingNode(data);
                Node ne = n.Next.Next;
                n.Next = ne;
            }

        }

        public class Node
        {
            public Node Next;
            public object Data;
        }
    }
}
