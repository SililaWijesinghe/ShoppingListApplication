using EllipticCurve.Utils;
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

namespace ShoppingListApplication
{
    public partial class Form2 : Form
    {
        private ShoppingList shoppingList;

        public Form2()
        {
            InitializeComponent();
            shoppingList = new ShoppingList();
            UpdateDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newItem = textBox1.Text;
            int qty = int.Parse(textBox2.Text);
            string type = textBox3.Text;
            double price = double.Parse(textBox4.Text);

            shoppingList.AddItem(newItem, qty, type, price);
            UpdateDataGridView();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string selectedItem = row.Cells[0].Value.ToString();
                int selectedIndex = row.Index;

                // Get the quantity, type, and price of the selected item
                int qty = shoppingList.quantitys.ElementAt(selectedIndex);
                string type = shoppingList.types.ElementAt(selectedIndex);
                double price = shoppingList.prices.ElementAt(selectedIndex);
                
                // Remove the item from the shopping list
                shoppingList.RemoveItem(selectedItem, qty, type, price);
                UpdateDataGridView();
                MessageBox.Show(selectedItem+" was removed from the list!");
            }
            else
            {
                MessageBox.Show("Please select an item to remove!");
            }
        }

        private void UpdateDataGridView()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < shoppingList.items.Count; i++)
            {
                try
                {
                    string item = shoppingList.items.ElementAt(i);
                    int qty = shoppingList.quantitys.ElementAt(i);
                    string type = shoppingList.types.ElementAt(i);
                    double price = shoppingList.prices.ElementAt(i);

                    dataGridView1.Rows.Add(item, qty, type, price);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

     

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int selectedIndex = row.Index;

                string newItem = textBox1.Text;
                int qty = int.Parse(textBox2.Text);
                string type = textBox3.Text;
                double price = double.Parse(textBox4.Text);
                //textBox1.Text = row.Cells[0].Value.ToString();
                // Update the item in the shopping list
                shoppingList.UpdateItem(selectedIndex, newItem, qty, type, price);
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Please select an item to update.");
            }
        }


   

        private void ClearList()
        {
            shoppingList.Clear();
            UpdateDataGridView();
        }




    }
}
