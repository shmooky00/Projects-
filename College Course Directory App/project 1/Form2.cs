using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_1
{
    public partial class courseSelectForm : Form
    {
        public courseSelectForm()
        {
            InitializeComponent();
        }

        private void courseSelectForm_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // close form
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            //help message information
            MessageBox.Show("Select a course from the listbox, then click the select button to see the required classes. Click the clear button to select a new course. Click the exit button to leave the application. ");
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            int major = majorListBox.SelectedIndex; //declares major as an int in place of mlistbox
            switch (major) //corresponds mlistbox to clistbox
            {
                case 0: //computer science case, manually typed in, found easier way after this, might as well keep :(
                    {
                        courseListBox.Items.Add("CSC 133 Survey of CS");
                        courseListBox.Items.Add("CSC 101 Intro Programming");
                        courseListBox.Items.Add("CSC 102 Object Oriented Program");
                        courseListBox.Items.Add("CSC 363 Database Systems");
                        courseListBox.Items.Add("MAT 105 Elem Stat Math");
                        courseListBox.Items.Add("MAT 130 Discrete Math");
                        courseListBox.Items.Add("CSC 203 Software Engineering");
                        courseListBox.Items.Add("CSC 204 Algorithms");
                        courseListBox.Items.Add("CSC 251 Networks and Security");
                        courseListBox.Items.Add("CSC 311 Cyberethics");
                        //add courses into list box

                        break; //stops case
                    }
                case 1: //biology 
                    {
                        string bio; //declare biology as a string
                        StreamReader file; //declare sr file
                        file = File.OpenText("bio.txt"); //open file
                        courseListBox.Items.Clear(); //clear listboxes
                            while (!file.EndOfStream) //read file content
                        {
                            bio = file.ReadLine(); //get bio file name
                            courseListBox.Items.Add(bio); //add bio to list box
                        }
                        break; //stops case
                    }
                case 2: //accounting 
                    {
                        string acc; //declare accounting as a string
                        StreamReader file1; //delcare streamreader file
                        file1 = File.OpenText("acc.txt"); //open file
                        courseListBox.Items.Clear(); //clear listboxes
                        while (!file1.EndOfStream) //read file content
                        {
                            acc = file1.ReadLine(); //get acc file name
                            courseListBox.Items.Add(acc);//add acc to list 
                        }
                        break; //stops case
                    }
                case 3: //criminal justice
                    {
                        string cri; //declare cj as a string
                        StreamReader file2; //read from file
                        file2 = File.OpenText("cri.txt"); //open file 
                        courseListBox.Items.Clear(); //clear listboxes
                        while (!file2.EndOfStream) //read file content 
                        {
                            cri = file2.ReadLine(); //get cri file name
                            courseListBox.Items.Add(cri); //add cri file to listbox
                        }
                        break; //stops case
                    }
                    
                    
                    

                    

                    
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            courseListBox.Items.Clear(); //clear listbox
        }

        private void courseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
