using System;
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
           int location = -1;
           

           while (low <= high) 
           {
              int mid = low + (high - low) / 2;
               
                if (arr[mid] == x)
                {
                  location = mid;
                  high = mid - 1;
                } else if (arr[mid] < x)
                {
                  low = mid +1;
                } else
                {
                  high = mid - 1;
                }
               }  
               return location;
           }
         
         public static int LastOcc(int[] arr, int x)
         {
          int low = 0;
          int high = arr.Length -1;
          int location = -1;

          while (low <= high)
          {
            int mid = low + (high - low) / 2;
            
                if (arr[mid] == x)
                {
                  location = mid;
                  low = mid + 1;
                } else if (arr[mid] > x)
                {
                  high = mid - 1;
                } else
                {
                  low = mid + 1;
                }
               }  
               return location;
             }  
         
         // Viser bare hvor mange tallet kommer opp, men ikke indexen av tallene. 
         // Lag en løsning til å vise indexen rangeringen av tallene i tillegg.
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
           int x = 9;
           int[] RdmArray = new int[1000];
           for (int i = 0; i < RdmArray.Length; i++)
           {
              RdmArray[i] = Rdm.Next(1,50);
           }
           Array.Sort(RdmArray);
           int result = AllOcc(RdmArray, x);
          
           Console.WriteLine(string.Join(", ", RdmArray ));
           if(result == 0)
           {
             Console.WriteLine($"\nElement {x} is not present.\n");
           } else {
             Console.WriteLine($"\nElement {x} is present {result} time");
             
      
           }
        }  

       /* public static void fixedArray()
        {
            int[] arr = { 20, 20, 40, 40, 40, 42, 22, 42, 64 };
            int x = 40;

           int result = AllOcc(arr, x);

           Console.WriteLine(string.Join(", ", arr));
           if(result == 0)
           {
             Console.WriteLine($"\nElement {x} is not present.\n");
           } else {
             Console.WriteLine($"\nElement {x} is present {result} time.\n");
           }
        } */

        public static void Main(string[] args)
        { 
            RdmArray();
        }
    }
}
