﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Program
{
    class Program
    {

      // ---------------------------------------------------------
      // Tar i utgangspunkt denne modellen. 

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
            // Når vi jobber med store mengder av data i en array.
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
        
        // ---------------------------------------------------------

         public static int FirstOcc(int[] arr, int x)
         {
           int low = 0;
           int high = arr.Length -1;
           int result = -1;
           

           while (low <= high) 
           {
              int mid = low + (high - low) / 2;
               
                if (arr[mid] == x)
                {
                  result = mid;
                  high = mid - 1;
                } else if (arr[mid] < x)
                {
                  low = mid + 1;
                } else
                {
                  high = mid - 1;
                }
               }  
               return result;
           }
         
         public static int LastOcc(int[] arr, int x)
         {
          int low = 0;
          int high = arr.Length -1;
          int result = -1;

          while (low <= high)
          {
            int mid = low + (high - low) / 2;
            
                if (arr[mid] == x)
                {
                  result = mid;
                  low = mid + 1;
                } else if (arr[mid] > x)
                {
                  high = mid - 1;
                } else
                {
                  low = mid + 1;
                }
               }  
               return result;
          }  
         
         public static int AllOcc(int[] arr, int x)
         {
           int FirstOccuerence = FirstOcc(arr, x);
           if (FirstOccuerence == -1)
           {
             return 0;
           } 
           
           int LastOccuerence = LastOcc(arr, x);

           return LastOccuerence - FirstOccuerence + 1;
         }
  
         public static void RdmArray()
          {
           Random Rdm = new Random();
           int x = 5;
           int[] RdmArray = new int[10];
           for (int i = 0; i < RdmArray.Length; i++)
           {
              RdmArray[i] = Rdm.Next(1,7);
           }

           Array.Sort(RdmArray);
           int result = AllOcc(RdmArray, x);

           Console.WriteLine(string.Join(", ", RdmArray));
           if(result == 0)
           {
             Console.WriteLine($"Element {x} is not present.");
           } else {
             Console.WriteLine($"Element {x} is present {result} times.");
           }

        }  

        public static void fixedArray()
        {
            int[] arr = { 20, 40, 2, 7, 10 , 2 };
            int x = 7;
            int result = BinarySearch(arr, x);

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
