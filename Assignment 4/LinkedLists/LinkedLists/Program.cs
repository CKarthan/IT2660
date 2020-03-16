using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists {
    class Program {
        static void Main(string[] args) {
            LinkedList linkedList = new LinkedList(new Node("1"));

            linkedList.AddToEnd(new Node("2"));

            linkedList.AddToEnd(new Node("3"));

            linkedList.AddAtIndex(new Node("100"), 2);

            Console.WriteLine(linkedList);
        }
    }
}
