using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_algo
{
    using System;

    public class Program
    {
        
        // time complexity: O(n) due to having to search each variable in the array until the end.
        // in my search the number 22 is not found, so we do step through the enitre array

        // space complexity: O(1) due to the limited varaibles and the memory is constanlty being used

        public static int lSearch(int[] a, int x)
        {
            int array = a.Length;
            

            int notFound = 0;

            //base case
            for (int i = 0; i < array; i++) //start at index 0, if not found step through the array until index (x) found
                                              //this is the worst case, and what will happen in my code
            {

                if (a [i] == x)

                    return i; //if found
            }

            return notFound;

            
        }
        //loop termination once x is either found, or at the end when its not found

        
        public static void Main(string[] args)
        {

            int x = 22;

            int[] numberA = { 0, 34, 66, 2, 91, 44, 80, 45, 72 }; 
                      
                
            
            int result = lSearch(numberA, x); //displays the result from the search method in result


            Console.WriteLine("The array holds: ");

            Console.WriteLine(string.Join(" ", numberA));

            if (result != 0) 
            {
                Console.WriteLine($"At index {result}, {x} was found in the array");
            }

            else
            {
                Console.WriteLine($"The number {x} was not found in the array");
            }
        }
    }
}
