using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion {
    class Program {

        static void Main(string[] args) {
            List<int> unsortedList = new List<int>(100);

            while (unsortedList.Count < 100) {
                Random randomNumber = new Random();       
                var newRandomNumber = randomNumber.Next(0, 999);

                if (!unsortedList.Contains(newRandomNumber)) {
                    unsortedList.Add(newRandomNumber);
                }
            }

            Console.Write("Unsorted List: ");      
            foreach (var number in unsortedList) {
                Console.Write(number + ", ");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            List<int> sortedList = SortNumbers(unsortedList);

            Console.Write("Sorted List: ");
            foreach (var number in sortedList) {         
                Console.Write(number + ", ");
            }

            Console.ReadLine();
        }

        private static List<int> SortNumbers(List<int> unsortedList) {
            List<int> sortedNumbers = new List<int>();
            List<int> groupOne = new List<int>();
            List<int> groupTwo = new List<int>();

            if (unsortedList.Count == 1) {
                return unsortedList;
            }

            int middleNumber = unsortedList.Count / 2;

            for (int i = 0; i < middleNumber; i++) {
                groupOne.Add(unsortedList[i]);
            }

            for (int i = middleNumber; i < unsortedList.Count; i++) {
                groupTwo.Add(unsortedList[i]);
            }

            groupOne = SortNumbers(groupOne);
            groupTwo = SortNumbers(groupTwo);

            while (groupOne.Any() || groupTwo.Any()) {

                if (groupOne.Count > 0 && groupTwo.Count > 0) {

                    if (groupOne.FirstOrDefault() < groupTwo.FirstOrDefault()) {
                        sortedNumbers.Add(groupOne.FirstOrDefault());
                        groupOne.Remove(groupOne.FirstOrDefault());
                    } else {
                        sortedNumbers.Add(groupTwo.FirstOrDefault());
                        groupTwo.Remove(groupTwo.FirstOrDefault());
                    }
                } else if (groupOne.Any()) {
                    sortedNumbers.Add(groupOne.FirstOrDefault());
                    groupOne.Remove(groupOne.FirstOrDefault());

                } else if (groupTwo.Any()) {
                    sortedNumbers.Add(groupTwo.FirstOrDefault());
                    groupTwo.Remove(groupTwo.FirstOrDefault());
                }
            }

            return sortedNumbers;
        }
    }
}
