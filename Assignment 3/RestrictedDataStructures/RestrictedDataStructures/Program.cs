using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrictedDataStructures {

    class Program {
        static void Main(string[] args) {
            Program program = new Program();
            int max = 3;
            Stack<int> numbers = new Stack<int>(3);

            Console.WriteLine("Stack populated");
            program.Push(numbers);
            Console.WriteLine("Stack reinitialized");
            program.ReinitializeToEmpty(numbers);
            Console.WriteLine("Stack re-populated");
            program.Push(numbers);
            program.StackPeek(numbers);
            program.IsStackEmpty(numbers);
            program.IsStackFull(numbers, max);
            Console.WriteLine("==================================================");

            program.ExpandStack(numbers, max);
            program.ReduceStack(numbers, max);

            Console.ReadLine();
        }

        public void Push(Stack<int> numbers) {
            numbers.Push(0);
            numbers.Push(1);
            numbers.Push(2);

            foreach (var number in numbers) {
                Console.WriteLine(number);
            }
            Console.WriteLine("Number of elements in the stack after push: " + numbers.Count);
        }

        public void ReinitializeToEmpty(Stack<int> numbers) {
            numbers.Clear();
            Console.WriteLine("Number of elements after re-initialization of stack: " + numbers.Count);
        }

        public void IsStackEmpty(Stack<int> numbers) {
            if (numbers.Count == 0) {
                Console.WriteLine("The stack is empty: " + true);
            } else {
                Console.WriteLine("The stack is empty: " + false);
            }
        }

        public void IsStackFull(Stack<int> numbers, int max) {
            if (numbers.Count == max) {
                Console.WriteLine("The stack is full: " + true);
            } else {
                Console.WriteLine("The stack is full: " + false);
            }
        }

        public void StackPeek(Stack<int> numbers) {
            Console.WriteLine("The value of the top entry is: " + numbers.Peek());
        }

        public void ExpandStack(Stack<int> stack, int max) {
            var size = stack.Count;

            if (size == max) {
                Stack<int> biggerStack = new Stack<int>(max + 1);
                biggerStack = stack;
                biggerStack.Push(99);
                foreach (var number in biggerStack) {
                    Console.WriteLine(number);
                }
                Console.WriteLine("Max size is: " + biggerStack.Count);
            }
        }

        public void ReduceStack(Stack<int> stack, int max) {
            stack.Pop();
            stack.Pop();
            stack.Pop();
            var size = stack.Count;

            if (size < max) {
                Stack<int> smallerStack = new Stack<int>(size);
                smallerStack = stack;
                foreach (var number in smallerStack) {
                    Console.WriteLine(number);
                }
      
                Console.WriteLine("Max size is: " + smallerStack.Count());
            }
        }
    }
}