using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace Project1_createFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRandFiles = 10;
            int numberOfOrderedFiles = 1;
            int numberOfRevOrderedFiles = 1;

            int[] fiftyThouArray = new int[50000];
            int[] twoHundredThouArray = new int[200000];
            int[] fiveHundredThouArray = new int[500000];
            int[] oneMillionArray = new int[1000000];

            string baseOutPath = "C:\\Users\\aaron\\Desktop\\Serial_Array_Files\\";

            for (int i = 0; i < numberOfRandFiles; i++)
            {
                fiftyThouArray.RandomGenArray();
                fiftyThouArray.WriteSerial(baseOutPath + "Rand_50_thou_" + (i+1)+".ser");

                twoHundredThouArray.RandomGenArray();
                twoHundredThouArray.WriteSerial(baseOutPath + "Rand_200_thou_" + (i+1)+".ser");

                fiveHundredThouArray.RandomGenArray();
                fiveHundredThouArray.WriteSerial(baseOutPath + "Rand_500_thou_" + (i+1)+".ser");

                oneMillionArray.RandomGenArray();
                oneMillionArray.WriteSerial(baseOutPath + "Rand_million_" + (i + 1) + ".ser");
            }

            for (int i = 0; i < numberOfOrderedFiles; i++)
            {
                fiftyThouArray.OrderGenArray();
                fiftyThouArray.WriteSerial(baseOutPath + "Ordered_50_thou_" + (i + 1) + ".ser");

                twoHundredThouArray.OrderGenArray();
                twoHundredThouArray.WriteSerial(baseOutPath + "Ordered_200_thou_" + (i + 1) + ".ser");

                fiveHundredThouArray.OrderGenArray();
                fiveHundredThouArray.WriteSerial(baseOutPath + "Ordered_500_thou_" + (i + 1) + ".ser");

                oneMillionArray.OrderGenArray();
                oneMillionArray.WriteSerial(baseOutPath + "Ordered_million_" + (i + 1) + ".ser");
            }

            for (int i = 0; i < numberOfRevOrderedFiles; i++)
            {
                fiftyThouArray.ReverseOrderGenArray();
                fiftyThouArray.WriteSerial(baseOutPath + "Rev_Ordered_50_thou_" + (i + 1) + ".ser");

                twoHundredThouArray.ReverseOrderGenArray();
                twoHundredThouArray.WriteSerial(baseOutPath + "Rev_Ordered_200_thou_" + (i + 1) + ".ser");

                fiveHundredThouArray.ReverseOrderGenArray();
                fiveHundredThouArray.WriteSerial(baseOutPath + "Rev_Ordered_500_thou_" + (i + 1) + ".ser");

                oneMillionArray.ReverseOrderGenArray();
                oneMillionArray.WriteSerial(baseOutPath + "Rev_Ordered_million_" + (i + 1) + ".ser");
            }
        }
        
    }
}
