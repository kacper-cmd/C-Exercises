using C_Programs;
using System;
using System.Text;

namespace MyApp
{

    public class Program
    {
        private static bool Solution(string input)
        {
            Stack<char> brackets = new Stack<char>();
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
          { '(', ')' },
          { '{', '}' },
          { '[', ']' },
          { '<', '>' }
         };

            try
            {
                foreach (char mark in input)
                {
                    if (bracketPairs.Keys.Contains(mark))
                        brackets.Push(mark);
                    else if (bracketPairs.Values.Contains(mark))
                    {
                        if (mark == bracketPairs[brackets.First()])
                            brackets.Pop();
                        else
                            return false;
                    }
                    else
                        continue;
                }
            }
            catch
            {
                return false;
            }

            return brackets.Count() == 0 ? true : false;
        }
        private static void PasswordGuessing()
        {
            string[] listwords = new string[10];
            listwords[0] = "królik";
            listwords[1] = "marchewka";
            listwords[2] = "komputer";
            listwords[3] = "lodówka";
            listwords[4] = "telewizor";
            listwords[5] = "samochód";
            listwords[6] = "drzewo";
            listwords[7] = "jabłko";
            listwords[8] = "melon";
            listwords[9] = "krzesło";

            Random rand = new Random();
            var idx = rand.Next(0, 9);

            string mysteryWord = listwords[idx];
            char[] wordToGuess = new char[mysteryWord.Length];
            for (int p = 0; p < mysteryWord.Length; p++)
                wordToGuess[p] = '*';

            Console.WriteLine("Odgadywanie hasła !");
            Console.WriteLine(wordToGuess);

            while (true)
            {
                Console.Write("Podaj litere do odsłonięcia: ");
                char mark = char.Parse(Console.ReadLine());

                for (int i = 0; i < mysteryWord.Length; i++)
                {
                    if (mark == mysteryWord[i])
                        wordToGuess[i] = mark;
                }

                Console.WriteLine(wordToGuess);
                if (!wordToGuess.Any(x => x == '*'))
                {
                    Console.WriteLine("Brawo odgadłeś hasło");
                    break;
                }
            }
        }
        private static bool CheckPalindrom(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return false;

            text = text.Replace(" ", "").ToLower();

            return text == new string(text.ToCharArray().Reverse().ToArray());
        }
       private static void FindAllSubstring(string str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                StringBuilder subString = new StringBuilder(str.Length - i);

                for (int j = i; j < str.Length; ++j)
                {
                    subString.Append(str[j]);
                    Console.Write(subString + "\n");
                }
            }
        }
        public static bool FindPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var squareRoot = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= squareRoot; i += 2)
                if (number % i == 0) return false;

            return true;
        }
        private static Dictionary<char, int> CountCharacters(string text)
        {
            var countCharacters = new Dictionary<char, int>();

            foreach (var mark in text)
            {
                if (mark != ' ') //if (char.IsDigit(mark))
                {
                    if (!countCharacters.ContainsKey(mark))
                        countCharacters.Add(mark, 1);
                    else
                        countCharacters[mark]++;
                }
            }
            return countCharacters;
        }
        private static Dictionary<int, int> CountDigits(string text)
        {
            var countDigits = new Dictionary<int, int>();

            foreach (var mark in text)
            {
                if (char.IsDigit(mark))
                {
                    int digit = mark - '0'; // convertion char na int

                    if (!countDigits.ContainsKey(digit))
                        countDigits.Add(digit, 1);
                    else
                        countDigits[digit]++;
                }
            }
            return countDigits;
        }

        private static void DisplayResults(Dictionary<char, int> result)
        {
            Console.WriteLine("Oto ile było wystąpień każdego znaku w ciągu");
            foreach (var keyValue in result)
            {
                Console.WriteLine($"Znak : {keyValue.Key}   Ilość wystąpień : {keyValue.Value}");
            }
        }
        private static Dictionary<char, int> CountDigits2(string text)
        {
            var countDigits = new Dictionary<char, int>();

            foreach (var mark in text)
            {
                if (char.IsDigit(mark)) // Sprawdza, czy znak to cyfra (0-9)
                {
                    if (!countDigits.ContainsKey(mark))
                        countDigits.Add(mark, 1);
                    else
                        countDigits[mark]++;
                }
            }
            return countDigits;
        }

        private static void ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                charArray[i] = str[j];
                charArray[j] = str[i];
            }
            string reversedstring = new string(charArray);
            Console.WriteLine(reversedstring);
        }
        private static void ReverseWordInString(string words)
        {
            var rev = words.Split(' ').Where(x => !String.IsNullOrEmpty(x)).Reverse();

            Console.WriteLine(string.Join(" ", rev));
        }
        private static long silnia(int n)
        {
            long result = n;
            while (--n > 0)
            {
                result *= n;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string expression = Console.ReadLine();
            Console.WriteLine(Solution(expression));
            PasswordGuessing();

            string[] array = { "kayak", "level", "radar", "Ala", "kobyła ma mały bok", "a tu mam mamuta", "Zakopane na pokaz", "a kilku tu klika", "atak kata", "nawijaj Iwan", "", "deska" };

            foreach (string value in array)
            {
                Console.WriteLine("{0} = {1}", value, CheckPalindrom(value));
            }

            FindAllSubstring("Hello World");


            string[,] matrix = new string[3, 5]
              {
                    {"0000", "0000", "0000", "FFFF", "0000"},
                    {"0000", "0000", "0000", "0000", "0000"},
                    {"0000", "0000", "FFFF", "0000", "0000"}
              };
            //  var tMatrix = ArrayExtensions<string>.Transpose(matrix);  
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            using (TextWriter tw = new StreamWriter("text.txt"))
            {
                tw.WriteLine("Original Matrix");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        tw.Write(matrix[i, j] + " ");
                    }
                    tw.WriteLine();
                }
                tw.WriteLine("Transpose Matrix");
                for (int j = 0; j < columns; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        tw.Write(matrix[i, j] + " ");
                    }
                    tw.WriteLine();
                }
            }


            string[,] rectangularMatrix = new string[,]
            {
                { "0000", "0000", "0000", "FFFF", "0000" },
                { "0000", "0000", "0000", "0000", "0000" },
                { "0000", "0000", "FFFF", "0000", "0000" }
            };

            string[][] jaggedMatrix = rectangularMatrix.ToJaggedArray();

            string[][] transposed = jaggedMatrix.Transpose();

            foreach (var row in transposed)
            {
                Console.WriteLine(string.Join(" ", row));
            }


            var array2 = new int[][] {new int[]{ 1, 2, 3, 4, 5 },
                               new int[]{ 6, 7, 8, 9, 10 },
                               new int[]{ 11, 12, 13, 14, 15 },
                               new int[]{ 16, 17, 18, 19, 20 },
                               new int[]{ 21, 22, 23, 24, 25 }};

            var transposedArray = Enumerable.Range(0, array2.Length).Select(x => array2.Select(y => y[x]));

            foreach (var row in transposedArray)
            {
                foreach (var number in row)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }


            var text = @"ala ma kota i psa i inne zwierzaki oraz x-mana";
            var result = CountCharacters(text);
            DisplayResults(result);


            var words = "string do odwrócenia    , super";
            ReverseString(words);
            ReverseWordInString(words);
            Console.WriteLine(silnia(6));

            int[] numbers = { 5, 3, 9, 1, 4 };
            var (min, max) = ArrayUtils.FindMinMax(numbers);
            Console.WriteLine($"Min: {min}, Max: {max}");

            double[] doubles = { 3.14, 2.71, 1.41, 6.28 };
            var (minDouble, maxDouble) = ArrayUtils.FindMinMax(doubles);
            Console.WriteLine($"Min: {minDouble}, Max: {maxDouble}");


            StringBuilder sb = new StringBuilder();
            sb.AppendLineChainable("Hello, World!")
              .AppendFormatted("The current date and time: {0}", DateTime.Now)
              .AppendLineChainable("Goodbye, World!");

            Console.WriteLine(sb.ToString());

            List<int> numbers3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            string result3 = numbers3.Filter(n => n % 2 == 0) //  Filters even numbers
                                 .Transform(n => n * 2)      // Doubles every number
                                 .AsString();               // Converts list to string

            Console.WriteLine(result3);




            var myComparer = new ReverseComparer();
            var set = new SortedSet<int>(myComparer);
            set.Add(1);
            set.Add(3);
            set.Add(2);
            // set będzie teraz posortowany w kolejności malejącej: { 3, 2, 1 }


            Console.WriteLine("Wprowadź ciąg nazw oddzielonych średnikiem:");
            string input = Console.ReadLine();

            string[] names = input.Split(';');

            Console.WriteLine("Wybierz sposób sortowania: 1 dla rosnącego, 2 dla malejącego");
            int choice = int.Parse(Console.ReadLine());

            Func<string[], string[]> sortFunction = choice == 1 ?
                (Func<string[], string[]>)(array => array.OrderBy(n => n).ToArray()) :
                array => array.OrderByDescending(n => n).ToArray();

            var sortedNames = sortFunction(names);

            Console.WriteLine("Posortowane nazwy:");
            foreach (var name in sortedNames)
            {
                Console.WriteLine(name);
            }

            //Extract unique words from the text and sort them by number of occurrences.

            string text2 = "To jest przykład zastosowania LINQ w analizie tekstu. LINQ to potężne narzędzie.";
            var uniqueWords = text2.Split(' ')
                                .Select(word => word.ToLower())
                                .Where(word => !string.IsNullOrWhiteSpace(word))
                                .GroupBy(word => word)
                                .OrderByDescending(group => group.Count())
                                .Select(group => $"{group.Key}: {group.Count()}");
            //Process the list of phrases into acronyms.
            var phrases = new List<string>
                        { "Language Integrated Query", "World Wide Web", "Artificial Intelligence" };
            var acronyms = phrases
            .Select(phrase => new string(phrase.Split(' ')
            .Select(word => word[0]).ToArray()));

            while (true)
            {
                Console.Write("Give the number: ");
                int num1 = Int32.Parse(Console.ReadLine());

                if (FindPrime(num1))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}