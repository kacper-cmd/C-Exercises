using System;
using System.Threading.Channels;
/// <summary>
/// https://www.programiz.com/csharp-programming/operators
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        double firstNumber = 14.40, secondNumber = 4.60, result;
        int num1 = 26, num2 = 4, rem;

        result = firstNumber + secondNumber;
        Console.WriteLine("{0} + {1} = {2}", firstNumber, secondNumber, result);

        result = firstNumber - secondNumber;
        Console.WriteLine("{0} - {1} = {2}", firstNumber, secondNumber, result);

        result = firstNumber * secondNumber;
        Console.WriteLine("{0} * {1} = {2}", firstNumber, secondNumber, result);

        result = firstNumber / secondNumber;
        Console.WriteLine("{0} / {1} = {2}", firstNumber, secondNumber, result);

        rem = num1 % num2;
        Console.WriteLine("{0} % {1} = {2}", num1, num2, rem);

        bool boolResult;
        int a = 10, b = 20;

        boolResult = (a == b);
        Console.WriteLine("{0} == {1} returns {2}", a, b, boolResult);

        boolResult = (a > b);
        Console.WriteLine("{0} > {1} returns {2}", a, b, boolResult);

        boolResult = (a < b);
        Console.WriteLine("{0} < {1} returns {2}", a, b, boolResult);

        boolResult = (a >= b);
        Console.WriteLine("{0} >= {1} returns {2}", a, b, boolResult);

        boolResult = (a <= b);
        Console.WriteLine("{0} <= {1} returns {2}", a, b, boolResult);

        boolResult = (a != b);
        Console.WriteLine("{0} != {1} returns {2}", a, b, boolResult);

        Console.WriteLine("a != b || a == b: " + (a != b || a == b));
        Console.WriteLine("a > b || a <= b: " + (a > b || a <= b));
        Console.WriteLine("true || false: " + (true || false));
        Console.WriteLine("true && !false: " + (true && !false));

        boolResult = (a == b) || (a > 5);
        Console.WriteLine(boolResult);

        boolResult = (a == b) && (a > 5);
        Console.WriteLine(boolResult);


        int number = 10;

        Console.WriteLine((number++));
        Console.WriteLine((number));

        Console.WriteLine((++number));
        Console.WriteLine((number));

         a = 10;
         b = 20;

        result = ~a;
        Console.WriteLine("~{0} = {1}", a, result);

        result = a & b;
        Console.WriteLine("{0} & {1} = {2}", a, b, result);

        result = a | b;
        Console.WriteLine("{0} | {1} = {2}", a, b, result);

        result = a ^ b;
        Console.WriteLine("{0} ^ {1} = {2}", a, b, result);

        result = a << 2;
        Console.WriteLine("{0} << 2 = {1}", a, result);

        result = a >> 2;
        Console.WriteLine("{0} >> 2 = {1}", a, result);

        a += 2;
        b *= 3;

        a++;
        b--;

        Func<int, int, int> add = (x, y) => x + y;
        Console.WriteLine("Lambda: " + add(a, b));
        int Square(int a) => a * a;//Func<int, int> square = x => x * x;
        Console.WriteLine("Lambda: " + Square(2));

        Console.WriteLine("a == a: " + (a == a));
        Console.WriteLine("a != b || a == b: " + (a != b || a == b));
        Console.WriteLine("a > b || a <= b: " + (a > b || a <= b));

        Console.WriteLine("Kalkulator");
        try
        {
            Console.Write("Wpisz 1 liczbę: ");
            double userInputNumber1 = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Wpisz operator: +, -, *, /   \n");
            char _operator = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.Write("Wpisz 2 liczbę: ");
            double userInputNumber2 = Convert.ToDouble(Console.ReadLine());

            result = 0;

            switch (_operator)
            {
                case '+':
                    result = userInputNumber1 + userInputNumber2;
                    break;
                case '-':
                    result = userInputNumber1 - userInputNumber2;
                    break;
                case '*':
                    result = userInputNumber1 * userInputNumber2;
                    break;
                case '/':
                    if (userInputNumber2 != 0)
                    {
                        result = userInputNumber1 / userInputNumber2;
                    }
                    else
                    {
                        Console.WriteLine("Nie dziel przez zero !!");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Podałeś nieprawidłowy operator ");
                    return;
            }
            Console.WriteLine($"Wynik: {userInputNumber1} {_operator} {userInputNumber2} = {result}");
        }
        catch (FormatException e)
        {
            Console.WriteLine("Błąd");
        }

    }
}


