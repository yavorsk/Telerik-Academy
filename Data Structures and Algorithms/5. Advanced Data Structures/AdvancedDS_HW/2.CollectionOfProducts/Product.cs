using System;

namespace _2.CollectionOfProducts
{
    public class Product : IComparable
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Product otherProduct = obj as Product;

            if (otherProduct != null)
            {
                return this.Price.CompareTo(otherProduct.Price);
            }
            else
            {
                throw new ArgumentException("Object is not a Product!");
            }
        }
    }
}
