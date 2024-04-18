using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Parking_lot
{
    public partial class log_in : Form
    {
        FileStream file;
        FileStream file2; 
        StreamReader sr ;
        StreamWriter sw ;
        bool flag = false;
       
        public void search_and_add(FileStream f, FileStream f2) {
            f = new FileStream("customer_information.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            f2 = new FileStream("customer_filter.txt", FileMode.Append, FileAccess.Write);
            sr = new StreamReader(f);
            sw = new StreamWriter(f2);
            f.Seek(0, SeekOrigin.Begin);
            
            string record;
            string[] field;
            
            while ((record = sr.ReadLine()) != null) { 
                field = record.Split('|');

                if (field[0] == textBox3.Text + textBox2.Text)
                {
                    f2.Seek(0, SeekOrigin.End);
                    sw.Write(textBox3.Text + textBox2.Text);
                    MessageBox.Show($"Welcome Again {textBox3.Text}");
                   
                    flag = true;
                }
               
            }
            if (!flag)
            {
               
                sw.Flush();
                MessageBox.Show("We cannot find this username and password :(((");
            }
            sr.Close();
            sw.Close();
            f.Close();
            f2.Close();
        }
        public log_in()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void button1_Click_1(object sender, EventArgs e)//Next
        {

            bool ischar = true;

            for (int i = 0; i < textBox3.TextLength; i++)
            {
                if (textBox3.TextLength == 0 || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    ischar = false;
                    break;
                }
            }

            if (!ischar)
            {
                MessageBox.Show("Name must contain only characters.");
                
            }
            else
            {
                if (textBox2.TextLength < 6)
                {
                    MessageBox.Show("Password must be more than 6 characters.");

                }
                else {
                    search_and_add(file,file2);
                    if (flag)
                    {
                        list f5 = new list();
                        f5.ShowDialog();
                    }
                }
            }

        }

    }

       
}
    
