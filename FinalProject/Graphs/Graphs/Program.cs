using System;
using System.Collections.Generic;

namespace Graphs {
    class Program {

        public class Student {
            public string Name { get; set; }
            public int Id { get; set; }
            public double Gpa { get; set; }
            public List<Student> Students => allStudents;

            public Student() {
                Id = Id;
                Name = Name;
                Gpa = Gpa;
            }

            public void AddChildNode(Student newStudent) {

                allStudents.Add(newStudent);
            }

            List<Student> allStudents = new List<Student>();
        }

        public class Search {
            public string PromptUser() {
                Console.WriteLine("Enter a student name to perform the search (Jim is a student in the list).");
                var name = Console.ReadLine();
                return name;
            }

            public Student LoadStudentGraph() {
                Student root = new Student { Id = 1, Name = "Calli", Gpa = 3.5 };
                Student bob = new Student { Id = 2, Name = "Bob", Gpa = 3.4 };
                Student jade = new Student { Id = 3, Name = "Jade", Gpa = 3.8 };
                Student nikki = new Student { Id = 4, Name = "Nikki", Gpa = 3.9 };
                Student steve = new Student { Id = 5, Name = "Steve", Gpa = 3.5 };
                Student dennis = new Student { Id = 6, Name = "Dennis", Gpa = 2.8 };
                Student heather = new Student { Id = 7, Name = "Heather", Gpa = 3.9 };
                Student kelsey = new Student { Id = 8, Name = "Kelsey", Gpa = 3.5 };
                Student jim = new Student { Id = 9, Name = "Jim", Gpa = 3.7 };
                Student warren = new Student { Id = 10, Name = "Warren", Gpa = 4.0 };

                root.AddChildNode(jade);
                root.AddChildNode(kelsey);
                root.AddChildNode(bob);
                bob.AddChildNode(steve);
                bob.AddChildNode(jim);
                steve.AddChildNode(warren);
                steve.AddChildNode(nikki);
                steve.AddChildNode(dennis);
                nikki.AddChildNode(heather);

                return root;
            }

            public Student BreadthSearch(Student root, string name) {
                Queue<Student> queue = new Queue<Student>();
                HashSet<Student> level = new HashSet<Student>();
                queue.Enqueue(root);
                level.Add(root);
                Console.WriteLine("Searching...");
                Console.WriteLine("Breadth First Search");
                while (queue.Count > 0) {
                    Student currentStudent = queue.Dequeue();
                    Console.WriteLine($"Id: {currentStudent.Id} - Name: {currentStudent.Name}");

                    if (currentStudent.Name == name) {
                        return currentStudent;
                    }

                    foreach (Student node in currentStudent.Students) {
                        if (!level.Contains(node)) {
                            queue.Enqueue(node);
                            level.Add(node);
                        }
                    }
                }

                return null;
            }

            public Student DepthSearch(Student root, string name) {
                if (name == root.Name)
                    return root;
                Student personFound = null;
                foreach (var student in root.Students) {
                    personFound = DepthSearch(student, name);
                    Console.WriteLine($"Id: {student.Id} - Name: {student.Name}");
                    if (personFound != null)
                        break;
                }

                return personFound;
            }
        }

        public class DijkstrasAlgorithm {
            public static int[,] GenerateGraph() {
                Random rng = new Random();
                int[,] graph = new int[20, 20];

                for (int i = 0; i < 20; i++) {

                    for (int j = 0; j < 20; j++) {

                        graph[i, j] = rng.Next(0, 99);
                    }
                }
                return graph;
            }

            public int MinimumDistance(int[] distance, bool[] isShortestPath, int verticesCount) {
                int min = int.MaxValue;
                int minIndex = 0;

                for (int i = 0; i < verticesCount; i++) {
                    if (isShortestPath[i] == false && distance[i] <= min) {
                        min = distance[i];
                        minIndex = i;
                    }
                }

                return minIndex;
            }

            public void FindShortestPath(int[,] graph, int source, int vertexCount) {
                int[] distance = new int[vertexCount];
                bool[] isShortestPath = new bool[vertexCount];

                for (int i = 0; i < vertexCount; i++) {
                    distance[i] = int.MaxValue;
                    isShortestPath[i] = false;
                }

                distance[source] = 0;

                for (int count = 0; count < vertexCount - 1; count++) {
                    int min = MinimumDistance(distance, isShortestPath, vertexCount);
                    isShortestPath[min] = true;

                    for (int i = 0; i < vertexCount; i++)
                        if (!isShortestPath[i] && Convert.ToBoolean(graph[min, i]) && distance[min] != int.MaxValue && distance[min] + graph[min, i] < distance[i])
                            distance[i] = distance[min] + graph[min, i];
                }

                DisplayResults(distance, vertexCount);
            }

            public void DisplayResults(int[] distance, int vertex) {
                Console.WriteLine("   Vertex    Distance");
                Console.WriteLine("========================");
                for (int i = 0; i < vertex; i++) {
                    Console.WriteLine($"     {i}        {distance[i]}");
                }
            }
        }

        static void Main(string[] args) {
            Search search = new Search();
            Student root = search.LoadStudentGraph();
            DijkstrasAlgorithm shortPath = new DijkstrasAlgorithm();

            var userName = search.PromptUser();

            Student breadthSearchName = search.BreadthSearch(root, userName);
            Console.WriteLine();
            Console.WriteLine(breadthSearchName != null ? $"Your search returned the following result; Student ID: {breadthSearchName.Id}, Student Name: {breadthSearchName.Name}, GPA: {breadthSearchName.Gpa}" : $"No results were found for Student Name: {userName}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Depth First Search");
            Student depthSearchName = search.DepthSearch(root, userName);
            Console.WriteLine();
            Console.WriteLine(depthSearchName != null ? $"Your search returned the following result; Student ID: {depthSearchName.Id}, Student Name: {depthSearchName.Name}, GPA: {depthSearchName.Gpa}" : $"No results were found for Student Name: {userName}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dijkstra's Algorithm Search");
            var graph = DijkstrasAlgorithm.GenerateGraph();
            shortPath.FindShortestPath(graph, 0, 20);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The End.");
            Console.ReadLine();
        }
    }
}




