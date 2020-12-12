using System.Drawing;

namespace CoffeeShopSystemApp
{
    class Coffee
    {
        private int id;
        private string product_name;
        private string category;
        private string unit_price;
        private string description;
        private Image image;
        public static int i = 0;
        public static User usersModel = new User();
        public Image Image { get => image; set => image = value; }
        public string Description { get => description; set => description = value; }
        public string Unit_price { get => unit_price; set => unit_price = value; }
        public string Category { get => category; set => category = value; }
        public string Product_name { get => product_name; set => product_name = value; }
        public int Id { get => id; set => id = value; }
    }
}
