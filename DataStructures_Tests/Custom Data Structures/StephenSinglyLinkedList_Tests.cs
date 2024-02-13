using Microsoft.VisualStudio.TestTools.UnitTesting;
using StephenTechInterviewPack.Custom_Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephenTechInterviewPack.Custom_Data_Structures.Tests
{
    [TestClass()]
    public class StephenSinglyLinkedList_Tests
    {
        [TestMethod()]
        public void AddElement_Test()
        {
            StephenSinglyLinkedList stephenSinglyLinkedList = new StephenSinglyLinkedList();

            stephenSinglyLinkedList.AddElement(1); //int
            stephenSinglyLinkedList.AddElement('a'); //char
            stephenSinglyLinkedList.AddElement(true); //bool
            stephenSinglyLinkedList.AddElement("Test"); //string
            stephenSinglyLinkedList.AddElement(new string[3] { "1","2","3"}); //array
        }

        [TestMethod()]
        public void GetElementAt_Test()
        {
            StephenSinglyLinkedList stephenSinglyLinkedList = new StephenSinglyLinkedList();
            StephenSinglyLinkedList.Node? node = stephenSinglyLinkedList.GetElementAt(0);
        }
    }
}