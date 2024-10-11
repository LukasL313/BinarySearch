using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Program
{
    class Program
    {
      // Ignore denne delen
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
     // Bruker to binære søkere til å finne alle hendelsene av tallet X,
     // F.eks av output
     // Sjekker at Element X eksisterer, deretter sjekker hvor mange av X eksisterer. 

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
          int high = arr.Length - 1;
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

         public static int AllOcc(int[] arr, int x) 
         {
           int FirstOccuerence = FirstOcc(arr, x);
    
           int LastOccuerence = LastOcc(arr, x); 
          
           return LastOccuerence - FirstOccuerence;
         }

         public static void IndexRange(int[] arr, int x)
         {
           int firstIndex = FirstOcc(arr, x);
           int lastIndex = LastOcc(arr, x);
            
           Console.WriteLine($"\nIndex rangeringen er {firstIndex} til {lastIndex} \n");
         }
          

         public static int[] RdmArray() 
          {

           Random Rdm = new Random(); 
           int[] RdmArray = new int[1000];
           for (int i = 0; i < RdmArray.Length; i++)
           {
              RdmArray[i] = Rdm.Next(1,30);
           }
           Array.Sort(RdmArray);
           Console.WriteLine(string.Join(", ", RdmArray));

            return RdmArray;
        }  

        public static void Main(string[] args)
        { 
          int x = 7;
          int[] arr = RdmArray();

          // For å sjekke om X eksisterer, og hvor mange av X eksisterer. 
           int result = AllOcc(arr, x);
           // Sjekker index rangering av tallene i tabellen. 

            if(result == 0)
           { 
               Console.WriteLine($"\nElemente {x} eksisteres ikke i denne tabellen.\n");
           } else 
           {
             Console.WriteLine($"\nElemente {x} eksisterer i denne tabellen,\nog finnes {result} ganger i tabellen.");
             IndexRange(arr, x);
           }
        }
    }
}
