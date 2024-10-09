using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Program
{
    class Program
    {
        public static int Binary(int[] arr, int x)
        {
           int low = 0, high = arr.Length -1;
           while (low <= high)
           {
             int mid = low + ( high - low) / 2;

             if (arr[mid] == x)
             return mid;

             if (arr[mid] < x)
             low = mid + 1;

             if (arr[mid] > x)
             high = mid - 1;
           }
           return -1;
        }

         public static void RdmArray()
        {
           Random Rdm = new Random();
           int x = 7;
           int[] RdmArray = new int[10];
           for (int i = 0; i < RdmArray.Length; i++)
           {
              RdmArray[i] = Rdm.Next(1,15);
           }

           Array.Sort(RdmArray);
           int result = Binary(RdmArray, x);

           Console.WriteLine(string.Join(", ", RdmArray));
           if(result == -1)
           {
             Console.WriteLine("Element not present"); 
           } else {
             Console.WriteLine("Element is present at " + "index " + result);
           }

        }  

        public static void fixedArray()
        {
            int[] arr = { 20, 40, 2, 7, 10 , 2 };
            int x = 7;
            int result = Binary(arr, x);

            Console.WriteLine(string.Join(", ", arr));

            if (result == -1)
            {
                Console.WriteLine("Element is not present");
            } else
            {
                    Console.WriteLine("Element is present at " + "index " + result);
            }
        }

        public static void Main(string[] args)
        { 
            RdmArray();
            fixedArray();
        }
    }
}