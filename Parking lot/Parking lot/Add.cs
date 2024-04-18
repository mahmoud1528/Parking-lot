using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Parking_lot
{
    public partial class Add : Form
    {
        private void Form2_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox1.Text = rnd.Next(0, 1000).ToString();
        }
       

        public Add()
        {
            InitializeComponent();
        }
       
        public void add_(int count,int res)
        {
            FileStream file = new FileStream("customer_filter.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(file);
            
               
                file.Seek(0, SeekOrigin.End);
                sw.WriteLine('|' + count.ToString() + '|' + res.ToString());
                this.Close();
                sw.Close();
                file.Close();
           
            
        }

       


        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            label5.Visible = true;
            label7.Visible = true;
            label6.Visible = false;
            label8.Visible = false;
            comboBox4.Visible = false;
            comboBox6.Visible = false;
            comboBox5.Visible = true;
            comboBox3.Visible = true;
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            comboBox5.Visible = true;
            comboBox6.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0, res = 0;
            string[] types = new string[3];
            string[] hours = new string[3];

            if (radioButton1.Checked)
            {
                types[0] = comboBox1.SelectedItem?.ToString();
                hours[0] = comboBox2.SelectedItem?.ToString();
                count = 1;
            }
            else if (radioButton2.Checked)
            {
                types[0] = comboBox1.SelectedItem?.ToString();
                hours[0] = comboBox2.SelectedItem?.ToString();
                types[1] = comboBox5.SelectedItem?.ToString();
                hours[1] = comboBox3.SelectedItem?.ToString();
                count = 2;
            }
            else if (radioButton3.Checked)
            {
                types[0] = comboBox1.SelectedItem?.ToString();
                hours[0] = comboBox2.SelectedItem?.ToString();
                types[1] = comboBox5.SelectedItem?.ToString();
                hours[1] = comboBox3.SelectedItem?.ToString();
                types[2] = comboBox6.SelectedItem?.ToString();
                hours[2] = comboBox4.SelectedItem?.ToString();
                count = 3;
            }

            for (int i = 0; i < count; i++)
            {
                if (string.IsNullOrEmpty(types[i]) || string.IsNullOrEmpty(hours[i]))
                {
                    MessageBox.Show("Please select Number of hour and Type");
                    return;
                }

                int hourValue = int.Parse(hours[i]);
                int rate;

                if (types[i] == "Bike")
                {
                    rate = 10;
                }
                else if (types[i] == "Normal Car")
                {
                    rate = 20;
                }
                else
                {
                    rate = 30;
                }

                res += rate * hourValue;
            }

            if (count == 0)
            {
                MessageBox.Show("Please select Number of slots.");
            }
            else
            {
                string message = "\t  Parking Elhamd\n\nDate : " + DateTime.Now + "\n";
                for (int i = 0; i < count; i++)
                {
                    message += $"slot {i + 1} : {types[i]}\t\tHour : {hours[i]}\n";
                }
                message += $"\nThe amount required = {res} L.E";
                
                MessageBox.Show(message);
                add_(count,res);
                
            }
        }

      
    }
}
