using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5algo
{
    public class Node
    {
        public int data {  get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(int d)
        {
            this.data = d;

            this.left = null;
            
            this.right = null;

        }

    }
}
