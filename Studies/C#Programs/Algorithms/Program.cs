using Algorithms;
using Algorithms.Kruskala;

namespace Program;



public class Program
{
    public static void Main()
    {
        int[] arr = { 79, 86, 97, 43, 64, 25, 12, 22, 11, 7, 23, 5 };

        // Using Bubble Sort
        Sorter sorter = new Sorter(new BubbleSortStrategy());
        Console.WriteLine("Sorting using Bubble Sort:");
        sorter.Sort(arr);
        PrintArray(arr);

        // Using Selection Sort
        int[] arr2 = { 79, 86, 97, 43, 64, 25, 12, 22, 11, 7, 23, 5 };
        sorter.SetStrategy(new SelectionSortStrategy());
        Console.WriteLine("Sorting using Selection Sort:");
        sorter.Sort(arr2);
        PrintArray(arr2);

        List<int> numbers = new List<int> { 14, 35, 45, 17, 23, 56, 34, 47, 29, 11 };
        int bucketCount = 5;

        IBucketSort sorter2 = new BucketSortAlgorithm();
        List<int> sortedNumbers = sorter2.Sort(numbers, bucketCount);

        Console.WriteLine("Posortowana lista:");
        foreach (int num in sortedNumbers)
        {
            Console.Write(num + " ");
        }

        int[] array = { 30, 60, 80, 90, 130, 150, 210, 260, 400, 460, 20, 90, 50, 330, 220 };
        int target = 50;

        SearchService searchService = new SearchService(new LinearSearchAlgorithm());
        int result = searchService.Search(array, target);

        if (result == -1)
            Console.WriteLine("Element {0} is not in the array", target);
        else
            Console.WriteLine("Element {0} is present at index {1} in the array", target, result);




        int vertices = 4;
        List<Edge> edges = new List<Edge>
        {
            new Edge { Source = 0, Destination = 1, Weight = 10 },
            new Edge { Source = 0, Destination = 2, Weight = 6 },
            new Edge { Source = 0, Destination = 3, Weight = 5 },
            new Edge { Source = 1, Destination = 3, Weight = 15 },
            new Edge { Source = 2, Destination = 3, Weight = 4 }
        };

        IGraph graph = new Graph(vertices, edges);
        IUnionFind unionFind = new UnionFind();
        KruskalMST kruskalMST = new KruskalMST(unionFind);
        kruskalMST.FindMST(graph);
    }

    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
            Console.Write(item + " ");
        Console.WriteLine();
    }
}