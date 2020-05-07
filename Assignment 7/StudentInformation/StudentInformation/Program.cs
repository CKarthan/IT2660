using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformation {
    class Program {
        static void Main(string[] args) {
            Program p = new Program();
            Node studentNode = new Node();
            studentNode.Student = new Student {
                Id = 1,
                Name = "Calli Karthan",
                GPA = 3.5
            };
            studentNode.Insert(studentNode, null);

            var selectedOption = p.PromptUser();

        }
        public int PromptUser() {
            Console.WriteLine("To add a new student: Press 1");
            Console.WriteLine("To delete a student: Press 2");
            Console.WriteLine("To update student information: Press 3");
            Console.WriteLine("To view all student records: Press 4");
            var userSelection = Console.ReadLine();
            var selectedNumber = GetUserSelection(userSelection);

            if (selectedNumber == 0) {
                Console.WriteLine("Your selection is invalid, please try again.");
                PromptUser();
            }
                return selectedNumber;
        }

        public int GetUserSelection(string selectedOption) {
            switch (selectedOption) {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
