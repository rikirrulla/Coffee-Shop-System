using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopSystemApp
{
    public partial class Login : Form
    {
        private Connection conn = new Connection();
        string id, username, firstname, lastname, pin_code, telephone_number, type;
        string usernameRadioButton = null;
        Form_Dashboard form_Dashboard = new Form_Dashboard();
        //Form_Dashboard_Admin form_Dashboard_Admin = new Form_Dashboard_Admin();



        public Login()
        {
            InitializeComponent();

            form_Dashboard.RefToFormLogin = this;
            //form_Dashboard_Admin.RefToFormLogin = this;
            timerTime.Start();
            hideButtons();
            btnManualisht.Checked = true;
            populateButtons();
        }

        private void hideButtons()
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            radioButton9.Visible = false;
            radioButton10.Visible = false;
        }

        public void populateButtons()
        {
            MySqlConnection connection;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader dr;




            connection = conn.Open();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users";
            dr = cmd.ExecuteReader();

            int count = 0;

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    username = dr["username"].ToString();
                    count++;
                    if (count == 1)
                    {
                        radioButton1.Visible = true;
                        radioButton1.Text = username;
                    }
                    else if (count == 2)
                    {
                        radioButton2.Visible = true;
                        radioButton2.Text = username;
                    }
                    else if (count == 3)
                    {
                        radioButton3.Visible = true;
                        radioButton3.Text = username;
                    }
                    else if (count == 4)
                    {
                        radioButton4.Visible = true;
                        radioButton4.Text = username;
                    }
                    else if (count == 5)
                    {
                        radioButton5.Visible = true;
                        radioButton5.Text = username;
                    }
                    else if (count == 6)
                    {
                        radioButton6.Visible = true;
                        radioButton6.Text = username;
                    }
                    else if (count == 7)
                    {
                        radioButton7.Visible = true;
                        radioButton7.Text = username;
                    }
                    else if (count == 8)
                    {
                        radioButton8.Visible = true;
                        radioButton8.Text = username;
                    }
                    else if (count == 9)
                    {
                        radioButton8.Visible = true;
                        radioButton8.Text = username;
                    }
                    else if (count == 10)
                    {
                        radioButton8.Visible = true;
                        radioButton8.Text = username;
                    }
                }

            }
            else
            {
                MessageBox.Show("Perdoruesi ose fjalkalimi gabim!");
            }
            conn.closeConnection();
            connection.Close();
        }

        public void clear()
        {
            txtPassword.Text = "";
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }



        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginMethod();
            }
        }

        private void chkHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHide.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }



        private void button11_Click(object sender, EventArgs e)
        {
            loginMethod();
        }


        private void loginMethod()
        {
            isChecked();
            string user = usernameRadioButton;

            byte[] encodedPassword = new UTF8Encoding().GetBytes(txtPassword.Text);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            string pass = encoded;

            MySqlConnection connection;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader dr;




            connection = conn.Open();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users where username='" + user + "' AND password_hash='" + pass + "' OR pin_code= '" + txtPassword.Text + "'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    id = dr["id"].ToString();
                    username = dr["username"].ToString();
                    firstname = dr["first_name"].ToString();
                    lastname = dr["last_name"].ToString();
                    pin_code = dr["pin_code"].ToString();
                    telephone_number = dr["telephone_number"].ToString();
                    type = dr["type"].ToString();
                }

                id = dr["id"].ToString();
                username = dr["username"].ToString();
                firstname = dr["first_name"].ToString();
                lastname = dr["last_name"].ToString();
                pin_code = dr["pin_code"].ToString();
                telephone_number = dr["telephone_number"].ToString();
                type = dr["type"].ToString();

                Coffee.usersModel.Id = dr["id"].ToString();
                Coffee.usersModel.Firstname = dr["first_name"].ToString();
                Coffee.usersModel.Lastname = dr["last_name"].ToString();
                Coffee.usersModel.Username = dr["username"].ToString();
                Coffee.usersModel.Pincode = dr["pin_code"].ToString();
                Coffee.usersModel.Telephonenumber = dr["telephone_number"].ToString();
                Coffee.usersModel.Type = dr["type"].ToString();
                DateTime myDateTime = dr.GetDateTime("date_created");
                Coffee.usersModel.Date_created = myDateTime.ToString("MM/dd/yyyy");
                DateTime myDateTime2 = dr.GetDateTime("date_modified");
                Coffee.usersModel.Date_modified = dr["date_modified"].ToString();


                if (type.Equals("user"))
                {
                    form_Dashboard.Show();
                    this.Hide();
                }
                else if (type.Equals("admin"))
                {
                    //form_Dashboard_Admin.Show();
                    this.Hide();
                }
                //MessageBox.Show(username);

            }
            else
            {
                MessageBox.Show("Perdoruesi ose fjalkalimi gabim!");
            }
            conn.closeConnection();
            connection.Close();
        }

        private void btnRFID_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void btnManualisht_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = false;

        }

        private void isChecked()
        {
            if (radioButton1.Checked == true)
            {
                usernameRadioButton = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                usernameRadioButton = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                usernameRadioButton = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                usernameRadioButton = radioButton4.Text;
            }
            else if (radioButton5.Checked == true)
            {
                usernameRadioButton = radioButton5.Text;
            }
            else if (radioButton6.Checked == true)
            {
                usernameRadioButton = radioButton6.Text;
            }
            else if (radioButton7.Checked == true)
            {
                usernameRadioButton = radioButton7.Text;
            }
            else if (radioButton8.Checked == true)
            {
                usernameRadioButton = radioButton8.Text;
            }
            else if (radioButton9.Checked == true)
            {
                usernameRadioButton = radioButton9.Text;
            }
            else if (radioButton10.Checked == true)
            {
                usernameRadioButton = radioButton10.Text;
            }
        }

    }
}
