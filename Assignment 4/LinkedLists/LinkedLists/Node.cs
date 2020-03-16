using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists {
    public class Node {
   
        private string Value;
        private Node NextNode;

        public Node(string nodeValue) {

            Value = nodeValue;
        }

        public Node GetNextNode() {

            return NextNode;
        }

        public void SetNextNode(Node node) {

            NextNode = node;
        }

        public string GetNodeValue() {

            return Value;
        }

    }
}
