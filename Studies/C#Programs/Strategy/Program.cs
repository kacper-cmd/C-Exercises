using Strategy.Enums;
using Strategy;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ISortingStrategy sortingStrategy = null;
            // W pierwszej kolejności sorotwanie po nazwiskach mieszkańców
            List<string> voivodeshipResidence = new List<string> { "ab", "ac", "xa", "td" };
            sortingStrategy = GetSortingOption(ObjectToSort.NazwiskoMieszkanca);
            sortingStrategy.Sort(voivodeshipResidence);
            // W trakcie wykonywania zmiana algorytmu:
            // Posortujemy teraz studentów po numerach indeksów
            List<int> studentNumbers = new List<int> { 123456, 9876543, 345432 };
            sortingStrategy = GetSortingOption(ObjectToSort.NumerAlbumuStudenta);
            sortingStrategy.Sort(studentNumbers);
            // Kolejna zmiana algorytmu
            List<string> cityCartNumbers = new List<string> { "A123456", "B9876543", "C345432" };
            sortingStrategy = GetSortingOption(ObjectToSort.NumerKartyMiejskiej);
            sortingStrategy.Sort(cityCartNumbers);
        }
        private static ISortingStrategy GetSortingOption(ObjectToSort objectToSort)
        {
            ISortingStrategy sortingStrategy = null;
            // w zależności od przekazanych danych użyjemy innego sortowania
            // zmiana algorytmu odbywa się w trakcie wykonywania programu
            switch (objectToSort)
            {
                case ObjectToSort.NumerAlbumuStudenta:
                    sortingStrategy = new MergeSort();
                    break;
                case ObjectToSort.NumerKartyMiejskiej:
                    sortingStrategy = new HeapSort();
                    break;
                case ObjectToSort.NazwiskoMieszkanca:
                    sortingStrategy = new QuickSort();
                    break;
                default:
                    break;
            }
            return sortingStrategy;
        }
    }
}