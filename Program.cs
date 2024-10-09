using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Program
{
    class Program
    {
        public static int BinarySearch(int[] arr, int x)
        {
          // Low = Første tallet i arrayen,
          // high = mengden elementer i array -1

           int low = 0;
           int high = arr.Length -1;
           while (low <= high)
           {

            // Formel for å finne midten, for å vite hvor binær algoritme skal søke.
            // Denne formellen er bedre enn low + ( high + low ) / 2; fordi det kan skape integer overflow,
            // Når vi jobber med store mengder av tall i en array.
            // https://research.google/blog/extra-extra-read-all-about-it-nearly-all-binary-searches-and-mergesorts-are-broken/

             int mid = low + ( high - low) / 2;
            
            // Søke logikk 

             if (arr[mid] == x)
             return mid;

             if (arr[mid] < x)
             low = mid + 1;
             else 
             high = mid - 1;
           }
           return -1;
        } 

        
         // Juster binærsøkeren til å finne flere av det samme elemente 

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
           int result = BinarySearch(RdmArray, x);

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