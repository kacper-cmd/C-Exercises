using System;

namespace interfaces_2
{
    class Dictionary : ICRUDable
    {
        class Word
        {
            string inPolish;
            string inEnglish;

            public Word(string pol, string eng) { inPolish = pol; inEnglish = eng; }
            public override string ToString()
            {
                return string.Format("{0} - {1}", inPolish, inEnglish);
            }
        }

        Word[] dictionary = new Word[100];
        int wordsCount = 0;
        Word selectedElement;

        public int SelectFromMenu() {
            Console.Write("MENU \n1 - Show words\n2 - Add new word\nSelect a command number: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void ShowElementsList()
        {
            for (int i = 0; i < wordsCount; i++) Console.WriteLine(dictionary[i]);
            Console.WriteLine();
        }
        
        public void NewElement()
        {            
            Console.Write("Enter polish meaning: ");
            string pol = Console.ReadLine();
            Console.Write("Enter english meaning: ");
            string eng = Console.ReadLine();
            selectedElement = new Word(pol, eng);
            dictionary[wordsCount++] = selectedElement;
        }

        // complete the implementation

        public void SelectElement() { }
        public void EditElement() { }
        public void RemoveElement() { }
        public void ShowElement() { }

    }
}

// you can create an abstract class to save the code amount more