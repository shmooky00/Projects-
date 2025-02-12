using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace week5algo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myTree = new BST();

            myTree.Add(50); //passes number from the bts class 
            myTree.Add(51);
            myTree.Add(49);

            //consider where left or right is not null
            //if its less than what trying to add

            myTree.Add(48);
            myTree.Add(52);
            myTree.Add(53);
                                 

            //add a max and min
            myTree.PrintMax(myTree.root); //can pass in root, start tree passing all the way right
            myTree.PrintMin(myTree.root);

            Console.WriteLine("\nSmall -> Big");
            myTree.SortSmallToBig(myTree.root);

            Console.WriteLine("\nBig -> Small \n");
            myTree.SortBigToSmall(myTree.root);


            var myDictionary = new Dictionary<string, string>(); //new dictionary of string

            myDictionary.Add("Anthony", "0000000");
            

            var phoneNum = myDictionary["Anthony"];
            
                        
            myDictionary.TryGetValue("Anthony", out phoneNum);

            Console.WriteLine($"\nDictionary: Anthony's Phone Number: {phoneNum} ");

        }
    }
}
