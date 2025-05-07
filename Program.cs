using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPr3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuOption = 0;

            ShoppingCart myCart = new ShoppingCart();

            Console.WriteLine("ONLINE STORE");
            do
            {
                Console.WriteLine("Menu\n1. Add Product\n2. Remove Product\n3. Caculate Total Price\n4. Exit");
                Console.Write("Select an Option: ");
                menuOption = Convert.ToInt32(Console.ReadLine());

                switch (menuOption) 
                {
                    case 1:
                        Console.Write("Enter a Prduct ID: ");
                        string productID = Console.ReadLine();
                        Console.Write("Enter a Product Name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Enter a Product Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Product product = new Product(productID, productName, price);
                        myCart.AddProduct(product);
                        break;
                    case 2:
                        Console.Write("Enter the prodcut ID to Remove: ");
                        productID = Console.ReadLine();
                        myCart.RemoveProduct(productID);
                        break;
                    case 3:
                        myCart.CalculateTotalPrice();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Enter a valid numver (1-4)");
                        break;
                
                
                
                }

            } while (menuOption != 4);

        }
    }
    class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        
        public Product(string productID, string productName, double price)
        {
            ProductID = productID;
            ProductName = productName;
            Price = price;
        }
    }
    class ShoppingCart 
    { 
        List<Product> products = new List<Product>();
        
        public void AddProduct(Product product)
        {
           
            
                products.Add(product);
                Console.WriteLine("Product Added Successfully!");
           
        }
        public void RemoveProduct(string productID)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Cart is empty!");
                return;
            }

            Product toRemove = null;
            foreach (var p in products)
            {
                if (p.ProductID == productID) 
                {
                    toRemove = p;
                    break; 
                }
            }

            if (toRemove != null)
            {
                products.Remove(toRemove);
                Console.WriteLine("Product Removed Successfully!");
            }
            else
            {
                Console.WriteLine("Product not found in the cart.");
            }
        }
        public void CalculateTotalPrice() 
        {
            double sum = 0;
            foreach (var p in products)
            {
                sum += p.Price;
            }

            Console.WriteLine($"The total price of products in cart is: ${sum}");
        }
    }
}
