using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.MyStack
{
    interface IStack
    {
        void Push(object element);
        object Pop();
        object Peek();
        bool isEmpty();
        void Display();
    }
}
