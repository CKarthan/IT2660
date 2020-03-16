using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists {
    public class LinkedList {

        private Node firstNode;  
        private Node lastNode;
        private int length;

        public LinkedList(Node node) {

            firstNode = node;

            lastNode = node;

            length = 1;
        }

        private void AddToStart(Node node) {

            node.SetNextNode(firstNode);

            firstNode = node;

            length++;
        }

        public void AddToEnd(Node node) {

            lastNode.SetNextNode(node);

            lastNode = node;

            length++;
        }

        public Node AddAtIndex(Node node, int index) {

            Node tempNode = firstNode;     

            if (index == 0) {

                AddToStart(node);

            } else if (index >= length) {

                AddToEnd(node);

            } else {

                for (int i = 1; i <= index; i++) {

                    tempNode = tempNode.GetNextNode();

                }
            }

            return tempNode;
        }
    }
}
