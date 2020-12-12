namespace CoffeeShopSystemApp
{
    class User
    {
        private string id;
        private string firstname;
        private string lastname;
        private string username;
        private string pincode;
        private string telephonenumber;
        private string type;
        private string date_created;
        private string date_modified;

        public string Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Username { get => username; set => username = value; }
        public string Pincode { get => pincode; set => pincode = value; }
        public string Telephonenumber { get => telephonenumber; set => telephonenumber = value; }
        public string Type { get => type; set => type = value; }
        public string Date_created { get => date_created; set => date_created = value; }
        public string Date_modified { get => date_modified; set => date_modified = value; }
    }
}
