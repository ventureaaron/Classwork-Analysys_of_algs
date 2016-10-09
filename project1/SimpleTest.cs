using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace testSorts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bucket test:");
            int[] bucket_test = MyExtensions.CreateRandomArray(20);
            bucket_test.DumpArray();
            bucket_test.SimpleBucketSort();
            bucket_test.DumpArray();

            Console.WriteLine("Insertion sort test");
            int[] insertion_test = MyExtensions.CreateRandomArray(20);
            insertion_test.DumpArray();
            insertion_test.InsertionSort();
            insertion_test.DumpArray();

            Console.WriteLine("Selection sort test");
            int[] selection_test = MyExtensions.CreateRandomArray(20);
            selection_test.DumpArray();
            selection_test.SelectionSort();
            selection_test.DumpArray();

            Console.WriteLine("Bubble sort test");
            int[] bubble_test = MyExtensions.CreateRandomArray(20);
            bubble_test.DumpArray();
            bubble_test.BubbleSort();
            bubble_test.DumpArray();

            
            Console.WriteLine("Merge sort test");
            int[] merge_test = MyExtensions.CreateRandomArray(20);
            merge_test.DumpArray();
            merge_test.MergeSort();
            merge_test.DumpArray();

            Console.WriteLine("quick sort test");
            int[] quick_test = MyExtensions.CreateRandomArray(20);
            quick_test.DumpArray();
            quick_test.QuickSort();
            quick_test.DumpArray();

            Console.ReadKey();
        }
    }
}
