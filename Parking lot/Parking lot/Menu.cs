using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_lot
{
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//sign in 
        {

            sign_in f4 = new sign_in();
            f4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)//login
        {
            Form f1 = new log_in();
            f1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)//squezz
        {
            FileStream file = new FileStream("customer_filter.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            FileStream sqfile = new FileStream("record.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sqsw = new StreamWriter(sqfile);
            file.Seek(0, SeekOrigin.Begin);


            string record;
            while ((record = sr.ReadLine()) != null)
            {
                if (record[0] != '*')
                {
                    sqsw.WriteLine(record);
                    sqsw.Flush();
                }
            }
            sqsw.Close();
            sr.Close();
            file.Close();
            sqfile.Close();
            MessageBox.Show("record squeezed");

        }

        private void button4_Click(object sender, EventArgs e)//record
        {
            FileStream sqfile = new FileStream("record.txt", FileMode.Open, FileAccess.Read);

            StreamReader sqsr = new StreamReader(sqfile);
            sqfile.Seek(0, SeekOrigin.Begin);
            string record;
            string[] field;
            string message = "\t\t  Parking Elhamd\n\nDate : " + DateTime.Now + "\n";
            while ((record = sqsr.ReadLine()) != null)
            {
                field = record.Split('|');

                message += "UserName : " + field[0];
                for (int i = 1; i < field.Length; i += 2)
                {
                    message += "\t" + $"slots : {field[i]} \t The amount required = {field[i + 1]} L.E\n";
                }


            }
            MessageBox.Show(message);
            sqfile.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
