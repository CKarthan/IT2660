using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformation {
    public class Node {
        public Student Student { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public void Insert(Node newStudentNode, Node root) {
            Node newNode = new Node() {
                Student = newStudentNode.Student
            };

            if(root == null) {
                root = newNode;
            } else {
                Node thisNode = root;
                Node parentNode;

                while (true) {
                    parentNode = thisNode;
                    if(newStudentNode.Student.Id < thisNode.Student.Id) {
                        thisNode = thisNode.Left;
                        if(thisNode == null) {
                            parentNode.Left = newNode;
                            break;
                        } else {
                            thisNode = thisNode.Right;
                            if(thisNode == null) {
                                parentNode.Right = newNode;
                                break;
                            }
                        }                     
                    }
                }
            }
        }

        public void Display() {

        }
    }
}
