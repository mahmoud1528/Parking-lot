using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_lot
{
    public partial class list : Form
    {
        public list()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//add_button
        {
            Add f = new Add();
            f.ShowDialog();
            button1.Visible = false;
        }


        private void button2_Click(object sender, EventArgs e)//remove button
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            button3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            button4.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)//back button
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            button3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            
        }
        private void button3_Click(object sender, EventArgs e)//ok for delete
        {
            
            string searchText = textBox1.Text + textBox2.Text;
            string path = "customer_filter.txt";

            string[] record = File.ReadAllLines(path);
           
            int last = -1; 
            for (int i = 0; i < record.Length; i++)
            {
                string field = record[i];
                if (field.StartsWith(searchText))
                {
                    last = i;
                }
            }

            if (last != -1)
            {
                record[last] = "*" + record[last]; 
                File.WriteAllLines(path, record);
                MessageBox.Show("Record deleted");
            }
            else
            {
                MessageBox.Show("Record not found");
            }
           

        }

       
    }
}
