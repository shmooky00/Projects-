using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_1
{
    public partial class homeForm : Form
    {
        public homeForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e) //start button
        {
            this.Visible = false; //hides intro form
            Form courseselectForm = new courseSelectForm(); //"creates" course form in place of closed one
            courseselectForm.ShowDialog(); //displays course form
            
            this.Close(); // closes form
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // closes form
        }
    }

    

        
}
