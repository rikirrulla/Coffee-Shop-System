using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CoffeeShopSystemApp
{
    public partial class Form_Dashboard : Form
    {
        private Connection conn = new Connection();
        double amount;
        //UserSettings userSettings = new UserSettings();

        public static string ORDER_ID = "";

        public Form_Dashboard()
        {
            InitializeComponent();
            timerTime.Start();

            //UC_Home uch = new UC_Home();
            //AddControlsToPanel(uch);
            //initTimer();
            //UC_Home uch = new UC_Home();
            //AddControlsToPanel(uch);
        }

        private void initTimer()
        {
            timer2 = new Timer();
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 2000; // in miliseconds
            timer2.Start();
        }

        public Form RefToFormLogin { get; set; }


        public void populateLabels()
        {
            if (Coffee.usersModel != null)
            {
                labelFullName.Text = Coffee.usersModel.Firstname + " " + Coffee.usersModel.Lastname;
                labelType.Text = Coffee.usersModel.Type;
            }
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            populateLabels();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //UC_Home uch = new UC_Home();
            //AddControlsToPanel(uch);
        }


        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.RefToFormLogin.Show();
            this.Hide();

            if (System.Windows.Forms.Application.OpenForms["Login"] != null)
            {
                //  MessageBox.Show("t");
                (System.Windows.Forms.Application.OpenForms["Login"] as Login).clear();
            }
        }



        private void btnDrinks_Click(object sender, EventArgs e)
        {
            //UC_Drinks uch = new UC_Drinks();
            //AddControlsToPanel(uch);
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panepComOrders.Controls.Clear();
            panepComOrders.Controls.Add(c);
        }

        public void populateTotal(double s, ListItem[] l, int i)
        {
            amount += s;
            labelTotalAmount.Text = "€ " + amount.ToString();
            flowLayoutPanel1.Controls.Add(l[i]);

        }

        public void deleteListItemDrinks(int i)
        {
            flowLayoutPanel1.Controls.Remove(Coffee.listItems[i]);

        }
        public void deleteListItemCoffee(int i)
        {
            flowLayoutPanel1.Controls.Remove(Coffee.listItems[i]);

        }

        internal void dTotal(string text)
        {
            if (amount > 0)
            {
                amount -= Double.Parse(text);
                labelTotalAmount.Text = "€ " + amount.ToString();
            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= Coffee.i; i++)
            {
                flowLayoutPanel1.Controls.Remove(Coffee.listItems[i]);
            }
            Coffee.i = 0;
            //duhet me kqyr edhe niher
            labelTotalAmount.Text = "€ 00.00";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            MySqlConnection connection;
            MySqlCommand cmd = new MySqlCommand();

            connection = conn.Open();
            cmd.Connection = connection;




            for (int i = 1; i <= Coffee.i; i++)
            {
                cmd.CommandText = "insert into orders (order_date, type, date_modified, status, userID, productID) values ('" + dt.ToString("yyyy/MM/dd") + "','desktop','" + dt.ToString("yyyy/MM/dd") + "','rregullt','" + Coffee.usersModel.Id + "','" + Coffee.listItems[i].myId + "')";
                cmd.ExecuteNonQuery();

                flowLayoutPanel1.Controls.Remove(Coffee.listItems[i]);
            }
            conn.closeConnection();
            connection.Close();
            Coffee.i = 0;
            //duhet me kqyr edhe niher
            labelTotalAmount.Text = "€ 00.00";
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //userSettings.ShowDialog();
        }

        private void checkForOrders()
        {
            MySqlConnection connection;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader dr;




            connection = conn.Open();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM orders";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["status"].ToString().Equals("pa_pranuar"))
                    {
                        ORDER_ID = dr["ordersID"].ToString();
                        //OrdersFromPhone orders = new OrdersFromPhone();
                        //orders.Show();

                    }
                }
            }
            conn.closeConnection();
            connection.Close();
            accpetOrders();

        }

        private void accpetOrders()
        {
            MySqlConnection connection;
            MySqlCommand cmd = new MySqlCommand();

            connection = conn.Open();
            cmd.Connection = connection;

            cmd.CommandText = "update orders set status = 'pranuar' where ordersID = '" + ORDER_ID + "'";
            cmd.ExecuteNonQuery();
            conn.closeConnection();
            connection.Close();


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            checkForOrders();
        }
    }
}
