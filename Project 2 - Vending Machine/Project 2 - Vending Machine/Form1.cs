using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2___Vending_Machine
{
    public partial class Form1 : Form
    {
        private int[,] inventory = { { 5, 5, 5 }, //inventory amount 5
                                     { 5, 5, 5 } };

        private Label[] inventoryLabels; //method for labels to decrement 

        public Form1()
        {
            InitializeComponent();
            InitializeInventoryLabels(); //inventory labels 
            
        }
        
        private decimal[,] itemPrices = { { 5.5m, 2m, 3.5m }, //rootbeer array values 
                                          { 6m, 2.5m, 3m } }; 

        private int[] click = new int[6]; //initialize clicks 
        private const int max = 5; //max number of clicks

        private const int cans = 5; //inventory for cans 


        private void InitializeInventoryLabels()
        {
            
            inventoryLabels = new Label[6] { label8, label9, label10, label11, label12, label13 };
            //initialize inventory labels array

            for (int i = 0; i < inventoryLabels.Length; i++)
            //initial inventory counts in labels
            {
                int row = i / 3; //row inventory 
                int col = i % 3; //col inventory
                inventoryLabels[i].Text = $"{inventory[row, col]} in stock";
            }
        }

            private void button9_Click(object sender, EventArgs e)
        {
            this.Close(); //Exit button
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on the corresponding button to add the rootbeer to your cart."); 
            //help button

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); //clear listbox

            
            for (int i = 0; i < click.Length; i++) //reenable buttons once reset
            {
                click[i] = 0; //click

                Controls["button" + (i + 1)].Enabled = true; //enables 
            }
            for (int row = 0; row < inventory.GetLength(0); row++) //reset row
            {
                for (int col = 0; col < inventory.GetLength(1); col++) //reset col
                {
                    inventory[row, col] = cans; //reset inventory count
                }
            }

            //update inventory labels to display reset inventory counts
            UpdateInventoryLabels();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {

            decimal total = 0; //initialize total
            
            foreach (var item in listBox1.Items) //listbox items
            {
                string rootbeer = item.ToString(); //tostring items to rootbeer

                decimal price = decimal.Parse(rootbeer.Split('$')[1]); 
                //split rootbeer into substring using $, turns array into decimal

                total += price; //adds total to price 
            }

            MessageBox.Show("Your total is $" + total); //total message
          

        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox1.SelectedItem = "1x Bundaburg - $5.50"); //add item to list

            HandleButtonClick(button1, 0); //handle method

        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox1.SelectedItem = "1x Mug - $2.00"); //add item to list

            HandleButtonClick(button2, 1); //handle method
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox1.SelectedItem = "1x Dad's - $3.50"); //add item to list

            HandleButtonClick(button3, 2); //handle method
        }
         
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox1.SelectedItem = "1x Olipop - $6.00"); //add item to list

            HandleButtonClick(button4, 3); //handle method
        }
    
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox1.SelectedItem = "1x AW - $2.50"); //add item to list

            HandleButtonClick(button5, 4); //handle method
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox1.SelectedItem = "1x Barq's - $3.00"); //add item to list

            HandleButtonClick(button6, 5); //handle method
        }

        private void HandleButtonClick(Button button, int index) //method for disabling buttons
        {
            //increment the click count for button
            click[index]++;

            //disable the button if the click exceeds the limit
            if (click[index] >= max)
            {
                button.Enabled = false; //disable the button

                MessageBox.Show($"{button.Text} is out of stock."); //out of stock message 
            }
            int row = index / 3; // row
            int col = index % 3; // col
            inventory[row, col]--; //decrement row, col
            UpdateInventoryLabels(); //update corresponding labels
        }

        private void UpdateInventoryLabels()
        {
            // Update inventory counts in labels
            for (int i = 0; i < inventoryLabels.Length; i++)
            {
                int row = i / 3; //row 
                int col = i % 3; //column 
                inventoryLabels[i].Text = $"{inventory[row, col]} in stock"; 
                //show inventory amount in stock
            }


        }
    }
}
