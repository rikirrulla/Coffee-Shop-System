using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CoffeeShopSystemApp
{
    class Connection
    {
        static string host = "localhost";
        static string database = "coffee_db";
        static string userDB = "root";
        static string password = "";
        private string strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password;
        private MySqlConnection conn;


        public MySqlConnection Open()
        {
            try
            {
                strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password + ";pooling = false; convert zero datetime=True";
                conn = new MySqlConnection(strProvider);
                conn.Open();

            }
            catch (Exception er)
            {
                MessageBox.Show("Ju lutem aktivizoni databazen! " + er.Message, "Information");
            }
            return conn;

        }

        public MySqlConnection closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
            return conn;
        }


    }
}
