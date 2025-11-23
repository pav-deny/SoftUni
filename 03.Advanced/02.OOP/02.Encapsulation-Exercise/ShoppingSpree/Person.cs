using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            ProductBag = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                this.name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");

                this.money = value;
            }
        }
        public List<Product> ProductBag { get; set; }


        public string Buy(Product product)
        {
            if (Money < product.Cost)
                return $"{Name} can't afford {product.Name}";

            ProductBag.Add(product);
            Money -= product.Cost;
            return $"{Name} bought {product.Name}";
        }

        public override string ToString()
        {
            string[] productsBoughtArr = new string[ProductBag.Count];
            string productsBought;

            if (productsBoughtArr.Length <= 0)
            {
                productsBought = "Nothing bought";
            }
            else
            {
                for (int i = 0; i < productsBoughtArr.Length; i++)
                {
                    productsBoughtArr[i] = ProductBag[i].Name;
                }

                productsBought = string.Join(", ", productsBoughtArr);
            }

            return $"{Name} - {productsBought}";
        }
    }
}
