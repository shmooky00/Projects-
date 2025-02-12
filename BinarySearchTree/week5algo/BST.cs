using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace week5algo
{
    public class BST
    {
        public Node root {  get; set; }

        public BST()
        {

        }

        public void Add(int number)
        {
            //make a node
            var n = new Node(number);
            //check if there is a root
            if (this.root == null)
            {
                //if no root, make a root
                this.root = n;
            }
            else
            {
                //make resursive 
                this.AddNode(this.root, n);
            }

        }

        private void AddNode(Node root, Node n)
        {
            if(n.data <  root.data) //null or number
            {
                //go left
                if(root.left == null)
                {
                    root.left = n; 
                }
                else
                {
                    //if left is not null, use recursion with addnode
                    AddNode(root.left, n); //new root is now left of root

                }
            }
            else
            {
                //go right
                if(root.right ==null)
                {
                    root.right = n; //if no right = null, sees if anything is there first
                }
                else
                {
                    AddNode(root.right, n); 
                }

                
            }

            
        }

        public void PrintMax(Node n)
        {
            //base case
            if (n.right == null)
            {
                Console.WriteLine($"The Max is {n.data}");
            }
            else
            {
                PrintMax(n.right);
            }
        }

        public void PrintMin(Node n)
        {
            //base case
            if (n.left == null)
            {
                Console.WriteLine($"The min is {n.data}");

            }
            else
            {
                PrintMin(n.left);
            }
        }

        public void SortBigToSmall(Node n)
        {
            if(n != null)
            {
                SortBigToSmall(n.right); //recurse all the way right 

                Console.WriteLine(n.data); //print once all the way right is null
                
                SortBigToSmall(n.left); //recurse all the way left 
            }
        }

        public void SortSmallToBig(Node n)
        {
            if (n != null)
            {
                SortSmallToBig(n.left); //recurse all the way left

                Console.WriteLine(n.data); //print once all the way left is null

                SortSmallToBig(n.right); //recurse all the way right 
            }
        }
    }
}
