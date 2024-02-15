using Microsoft.VisualStudio.TestTools.UnitTesting;
using StephenTechInterviewPack.Custom_Data_Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephenTechInterviewPack.Custom_Data_Structures.Tests
{
    [TestClass()]
    public class StephenDoublyLinkedList_Tests
    {
        [TestMethod()]
        public void AddElement_Test()
        {
            StephenDoublyLinkedList stephenSinglyLinkedList = new StephenDoublyLinkedList();

            stephenSinglyLinkedList.AddElement(1); //int
            stephenSinglyLinkedList.AddElement('a'); //char
            stephenSinglyLinkedList.AddElement(true); //bool
            stephenSinglyLinkedList.AddElement("Test"); //string
            stephenSinglyLinkedList.AddElement(new string[3] { "1", "2", "3" }); //array
        }

        [TestMethod()]
        public void DeleteElement_Test()
        {
            StephenDoublyLinkedList stephenSinglyLinkedList = new StephenDoublyLinkedList();

            stephenSinglyLinkedList.AddElement(1); //int
            stephenSinglyLinkedList.AddElement('a'); //char
            stephenSinglyLinkedList.AddElement(true); //bool
            stephenSinglyLinkedList.AddElement("Test"); //string
            stephenSinglyLinkedList.AddElement(new string[3] { "1", "2", "3" }); //array

            stephenSinglyLinkedList.DeleteElement(true);

            StephenDoublyLinkedList.Node root = stephenSinglyLinkedList.GetFirstElement;

            //although we have this extra step of creating a variable to hold this info - instead of accessing it directly in the FOR loop - this is more efficient, because we arent recalculating what the Size is, every time the loop runs
            int size = stephenSinglyLinkedList.Size;

            for (int i = 0; i < size; i++)
            {
                //break condition to throw error if the element was not deleted
                Debug.Assert(!root.Data.Equals(true));
                //write output -> just for sanity-sake
                Console.WriteLine(root.Data);
                //move the cursor over the list, to the next item
                root = root.Next;
            }
        }

        [TestMethod()]
        public void GetElementAt_Test()
        {
            StephenDoublyLinkedList.Node newNode = new StephenDoublyLinkedList.Node() { Data = 1 };

            StephenDoublyLinkedList stephenSinglyLinkedList = new StephenDoublyLinkedList();
            stephenSinglyLinkedList.AddElement(1); //int

            StephenDoublyLinkedList.Node? node = stephenSinglyLinkedList.GetElementAt(0);
            Debug.Assert(node.Data.Equals(newNode.Data));
        }

        [TestMethod()]
        public void GetSize_Test()
        {
            StephenDoublyLinkedList stephenSinglyLinkedList = new StephenDoublyLinkedList();

            stephenSinglyLinkedList.AddElement(1); //int
            stephenSinglyLinkedList.AddElement('a'); //char
            stephenSinglyLinkedList.AddElement(true); //bool
            stephenSinglyLinkedList.AddElement("Test"); //string
            stephenSinglyLinkedList.AddElement(new string[3] { "1", "2", "3" }); //array

            int i = stephenSinglyLinkedList.Size; 
            Debug.Assert(i >= 4);
            i++;
        }
    }
}