using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static void WriteSerial<T>(this T[] arr, String outpath)
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
    }
}
