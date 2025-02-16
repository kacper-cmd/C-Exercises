using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.MyStack
{
    public class MyStack : IStack
    {
        private int stackSize;
        public int top;
        public object[] item;

        public int StackSize
        {
            get { return stackSize; }
            set { stackSize = value; }
        }
        public MyStack()
        {
            StackSize = 10;
            item = new object[StackSize];
            top = -1;
        }
        public MyStack(int capacity)
        {
            StackSize = capacity;
            item = new object[StackSize];
            top = -1;
        }
        public bool isEmpty()
        {
            if (top == -1) return true;

            return false;
        }
        public void Push(object element)
        {
            if (top == (stackSize - 1))
                Console.WriteLine("Stos jest pełny!");
            else
                item[++top] = element;
        }
        public object Pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stos jest pusty!");
                return "Bez elementów";
            }
            else
                return item[top--];
        }
        public object Peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stos jest pusty!");
                return "Bez elementów";
            }
            else
                return item[top];
        }
        public void Display()
        {
            if (isEmpty())
                Console.WriteLine("Brak elementów do wyświetlenia");

            for (int i = top; i > -1; i--)
                Console.WriteLine("Element{0}: {1}", (i + 1), item[i]);
        }
    }
}
