using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {

    public class StudentListings {
        public Student[] Listings;

        public void MainMenu() {
            Console.Clear();
            Console.WriteLine("Welcome to the Student Listing Information System!");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("Enter your option: (V)iew, (A)dd, (E)dit, (D)elete: ");
            var selectedAction = Console.ReadLine();
            ActionSelect(selectedAction);
        }

        public void ActionSelect(string selectedAction) {
            var action = selectedAction.Substring(0, 1).ToUpper();

            switch (action) {
                case "V":
                    DisplayAllListings();
                    break;

                case "A":
                    PromptUserForNewListing();
                    DisplayAllListings();
                    break;

                case "E":
                    //EditListing();
                    DisplayAllListings();
                    break;

                case "D":
                    DeleteStudentListing();
                    break;

                case "X":
                    break;
            }
            MainMenu();
        }

        public void PromptUserForNewListing() {
            Student newStudent = new Student();
            Console.WriteLine("Enter the full name of the student: ");
            newStudent.FullName = Console.ReadLine();
            Console.WriteLine("Enter the students current GPA: ");
            bool isDouble = double.TryParse(Console.ReadLine(), out double studentGpa);

            if (isDouble) {
                newStudent.Gpa = studentGpa;
            }

            AddStudentListing(newStudent);
            DisplayAllListings();
        }

        public void DisplayAllListings() {
            if (Listings == null) {

                Console.WriteLine("There are no current student listings.");
            } else {
                var counter = Listings.Length;
                Console.Clear();
                for (int i = 0; i < counter; i++) {

                    Console.WriteLine("Student Id: " + Listings[i].Id + " Name: " + Listings[i].FullName + " GPA: " + Listings[i].Gpa);
                }
            }

            Console.ReadLine();
        }

        public Student[] GetStudentListings() {
            return Listings;
        }



        public void AddStudentListing(Student listing) {
            if (Listings == null) {
                Listings = new Student[1];
                listing.Id = 1;
                Listings[0] = listing;

            } else {
                var currentArraySize = Listings.Length;
                var copyOfOriginalArray = Listings;           
                Listings = new Student[currentArraySize + 1];
           
                for (int i = 0; i < copyOfOriginalArray.Length; i++) {
                    Listings[i] = copyOfOriginalArray[i];
                }

                listing.Id = currentArraySize + 1;
                Listings[currentArraySize] = listing;       
            }
        }

        public void DeleteStudentListing() {
            DisplayAllListings();
            Console.WriteLine("Enter the ID of the student you would like to delete: ");
            var idToDelete = Int32.Parse(Console.ReadLine());     
            var copyOfArray = Listings;
            var newArray = new Student[Listings.Length - 1];
            var indexCounter = 0;

            for (int i = 0; i < Listings.Length - 1; i++) {

                if (idToDelete != Listings[i].Id) {

                    copyOfArray[indexCounter] = Listings[i];

                    indexCounter++;

                }

            }
        }
    }
}
