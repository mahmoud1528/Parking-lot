namespace Parking_lot
{
    public partial class Form1 : Form
    {

        class Vehicle_Owner
        {
            protected int License_Num, Num_of_Vehicles;
            protected string type;

            public int Num
            {
                get
                {
                    return Num_of_Vehicles;
                }
                set
                {
                    if (value > 3)
                    {
                        Console.WriteLine("num should be at most 3");
                        Num = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Num_of_Vehicles = value;
                    }
                }
            }

            public string Type
            {
                get
                {
                    return type;
                }
                set
                {
                    if (value.Contains("bike") || value.Contains("Bike") || value.Contains("normal") || value.Contains("Normal") || value.Contains("large") || value.Contains("Large"))
                        type = value;
                    else
                    {
                        Console.WriteLine("Invalid input");
                        type = Console.ReadLine();
                    }
                }
            }

            public Vehicle_Owner(int license_Num, int num_of_Vehicles, string T)
            {
                License_Num = license_Num;
                Num = num_of_Vehicles;
                Type = T;
            }

            public void display()
            {

                Console.WriteLine("license num : {0}\nnum of vehicle : {1}\nType : {2}", License_Num, Num_of_Vehicles, type);

            }

        }


    

    public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}