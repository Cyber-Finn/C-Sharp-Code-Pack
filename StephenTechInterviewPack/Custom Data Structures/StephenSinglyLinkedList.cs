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

        //doing the method like this allows us to call GetRoot, without using brackets "()" -> just looks a bit nicer
        public Node GetRoot { get { return Root; } }

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

        public void AddNode(object data)
        {
            Node n = new Node { Data = data };

            if (Root == null)
                Root = n;
            else
                GetLastNode.Next = n;
        }

        public class Node
        {
            public Node Next;
            public object Data;
        }
    }
}
