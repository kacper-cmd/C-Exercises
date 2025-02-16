using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace C_Programs
{

    /// <summary>
    /// Filter: This method takes a predicate (a function that specifies a filter condition) and returns a new list containing only those elements that satisfy the condition.
    //Transform: This method accepts a function that defines how each list element is to be transformed(for example, multiplied).
    //AsString: This method converts the list to a string, separating the elements with commas.
    //In the Main method, we create a list of numbers and then apply our string-style extension methods to it.
    /// </summary>

    public static class ListExtensions
    {
        public static List<int> Filter(this List<int> list, Func<int, bool> predicate)
        {
            return list.Where(predicate).ToList();
        }

        public static List<int> Transform(this List<int> list, Func<int, int> transformer)
        {
            return list.Select(transformer).ToList();
        }

        public static string AsString(this List<int> list)
        {
            return string.Join(", ", list);
        }
    }
}
