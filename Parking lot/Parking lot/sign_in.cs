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
    public partial class sign_in : Form
    {
        

        public void search_and_add()
        {
            FileStream file = new FileStream("customer_information.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(file);
            StreamWriter sw = new StreamWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            string record;
            string[] field;
            bool flag = false;

            while ((record = sr.ReadLine()) != null)
            {
                field = record.Split('|');

                if (field[0] == textBox3.Text + textBox4.Text && field[1] == textBox1.Text && field[2] == textBox2.Text)
                {
                    MessageBox.Show($"There is a log_in with this name!!!");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = null;
                    flag = true;
                }
            }
            if (!flag)
            {
                
                sw.WriteLine(textBox3.Text + textBox4.Text + '|' + textBox1.Text + '|' + textBox2.Text+'|' + textBox3.Text + '|' + textBox4.Text);
                
                MessageBox.Show($"ooh!!! we have a new customer here");
               
                this.Close();
            }
            sw.Close();
            sr.Close();
            file.Close();
        }
        
        public sign_in()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Next
        {
            bool ischar = true;
            

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)|| string.IsNullOrWhiteSpace(textBox3.Text))
                ischar = false;

            if (!ischar)
            {
                MessageBox.Show("Name must contain any characters.");

            }

            else
            {
                if (textBox4.TextLength < 6)
                {
                    MessageBox.Show("Password must be more than 6 characters.");

                }
                else
                {
                    search_and_add();
                   
                }

            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)//first
        {
            if(e.KeyCode == Keys.Enter)
            textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)//second
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)//username
        {
            if (e.KeyCode == Keys.Enter)
                textBox4.Focus();
        }
       
    }
}
    

