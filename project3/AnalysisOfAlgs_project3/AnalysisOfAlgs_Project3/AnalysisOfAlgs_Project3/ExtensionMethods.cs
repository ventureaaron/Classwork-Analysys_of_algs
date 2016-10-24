using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static void Populate<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
        }
        public static void ArrayWriteSerial<T>(this T[] arr, String outpath)
        {
            try
            {
                using (Stream stream = File.Open(outpath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, arr);
                }
            }
            catch (IOException)
            {

            }
        }
        public static int TwoIndexMin(this int[] arr, int i, int j )
        {
           return Math.Min(arr[i], arr[j]);
        }
        public static int[] ArrayReadSerial(String inpath)
        {
            try
            {
                using (Stream stream = File.Open(inpath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    int[] temp = (int[])bin.Deserialize(stream);
                    return temp;
                }
            }
            catch (IOException)
            {
                return null;
            }
        }
        public static int[] CreateRandomArray(int size)
        {
            int[] arr = new int[size];
            Random rand = new Random(1);
            for (int i = 0; i<size; i++)
            {
                arr[i] = rand.Next(size);
            }
            return arr;
        }
        public static void DumpArray(this int[] arr)
        {
            foreach  (int item in arr)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
        public static void RandomGenArray(this int[] arr)
        {
            Random rnd = new Random();
            arr.Populate(0);
            for (int i = 0; i< arr.Length; i++)
            {
                while (true)
                {
                    int x = rnd.Next(0, arr.Length);
                    if (arr[x] == 0)
                    {
                        arr[x] = i + 1;
                        break;
                    }
                    else continue;
                }
            }
        }
        public static void OrderGenArray(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]= i + 1;
            }
        }
        public static void ReverseOrderGenArray(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr.Length - i;
            }
        }
        public static bool OrderTest(this int[] arr)
        {
            Boolean ordered = true;
            for (int i =1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    ordered = false;
                    break;
                }
            }
            return ordered;
        }
        public static TimeSpan SimpleBucketSort(this int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int max = 0;
            for (int i=0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            int[] bucket_array = new int[max+1];
            bucket_array.Populate(0);

            for (int i = 0; i < arr.Length; i++)
            {
                bucket_array[arr[i]]++;
            }

            int j = 0;
            for (int i = 0; i < bucket_array.Length; i++)
            {
                while (bucket_array[i] > 0)
                {
                    arr[j] = i;
                    j++;
                    bucket_array[i]--;
                }
            }
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
        public static TimeSpan InsertionSort(this int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i=1; i < arr.Length; i++)
            {
                int index = arr[i];
                int j = i;
                while (j > 0 && arr[j - 1] > index)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = index;
            }
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
        public static TimeSpan SelectionSort(this int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i=0; i < arr.Length - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min]) min = j;
                }
                int temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
        public static TimeSpan BubbleSort(this int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = (arr.Length - 1); i >= 0; i--)
            {
                bool finished = true;
                for (int j = 1; j <= i; j++)
                {
                    
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                        finished = false;
                    }
                    
                }
                if (finished) break;
            }
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
        public static TimeSpan MergeSort(this int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            MS_recursive_divide(arr,0,arr.Length-1);
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
        private static void MS_recursive_divide(this int[] arr, int begin_ptr, int end_ptr)
        {
            int split_ptr;
            if (end_ptr > begin_ptr)
            {
                split_ptr = (begin_ptr + end_ptr) / 2;
                MS_recursive_divide(arr, begin_ptr, split_ptr);
                MS_recursive_divide(arr, split_ptr + 1, end_ptr);

                MS_merge_step(arr, begin_ptr, split_ptr, end_ptr);
            }
        }
        private static void MS_merge_step(this int[] arr, int begin_ptr, int split_ptr, int end_ptr)
        {
            int[] temp = new int[end_ptr - begin_ptr + 1];
            int right_begin_ptr = split_ptr + 1;
            int left_begin_ptr = begin_ptr;

            for (int i = 0; i < temp.Length; i++)
            {
                if (left_begin_ptr <= split_ptr && right_begin_ptr < end_ptr)
                {
                    //prob here
                    //Console.WriteLine("left" + left_begin_ptr + "right" + right_begin_ptr + "split_ptr" + split_ptr);
                    if (arr[left_begin_ptr] < arr[right_begin_ptr])
                    {
                        temp[i] = arr[left_begin_ptr];
                        left_begin_ptr++;
                    }
                    else
                    {
                        temp[i] = arr[right_begin_ptr];
                        right_begin_ptr++;
                    }
                }
                else if (left_begin_ptr > split_ptr)
                {
                    temp[i] = right_begin_ptr;
                    right_begin_ptr++;
                }
                else
                {
                    temp[i] = left_begin_ptr;
                    left_begin_ptr++;
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                arr[begin_ptr + i] = temp[i];
            }
        }
        public static TimeSpan QuickSort(this int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Console.WriteLine(arr.Length);
            QS_recursive_divide(arr, 0, arr.Length - 1);
            
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
        private static void QS_recursive_divide(this int[] arr, int begin_ptr, int end_ptr)
        {
            //Console.WriteLine("begin" + begin_ptr + "end" + end_ptr);
            if (end_ptr > begin_ptr)
            {
                int pivot_ptr = QS_split(arr, begin_ptr, end_ptr);

               // Console.WriteLine("begin" + begin_ptr + "end" + end_ptr + "pivot" + pivot_ptr);
                //Console.ReadKey();

                /*
                Thread thread = new Thread(() => QS_recursive_divide(arr, begin_ptr, pivot_ptr - 1));
                thread.Start();
                Thread thread2 = new Thread(() => QS_recursive_divide(arr, pivot_ptr+1, end_ptr));
                thread2.Start();
                */
                QS_recursive_divide(arr, begin_ptr, pivot_ptr-1);
                QS_recursive_divide(arr, pivot_ptr + 1, end_ptr);

            }
            return;
            
        }
        private static int QS_split(this int[] arr, int begin_ptr, int end_ptr)
        {
            Random pivind = new Random();
            int pivotValue = arr[pivind.Next(begin_ptr,end_ptr)];
            int start = begin_ptr;
            int stop = end_ptr;
            //begin_ptr++;

            //Console.WriteLine("pivot" + pivotValue + " start" + start + " stop" + stop+"pivind"+ (begin_ptr + end_ptr) / 2);
            while (true)
            {
                //
                while (begin_ptr <= end_ptr && arr[begin_ptr] <= pivotValue)
                {
                    //no change needed, just increase pointer
                    begin_ptr++;
                    //Console.WriteLine("beg" + begin_ptr);                
                }
                while(arr[end_ptr] > pivotValue)
                {
                    //no action needed, decrment end pointer
                    end_ptr--;
                    //Console.WriteLine("end" + end_ptr+ " "+begin_ptr);
                }
                if (begin_ptr > end_ptr)
                {
                    arr[start] = arr[begin_ptr - 1];
                    arr[begin_ptr - 1] = pivotValue;
                    return begin_ptr - 1;
                }
                int temp = arr[begin_ptr];
                arr[begin_ptr] = arr[end_ptr];
                arr[end_ptr] = temp;
            }
        }
    }
}
