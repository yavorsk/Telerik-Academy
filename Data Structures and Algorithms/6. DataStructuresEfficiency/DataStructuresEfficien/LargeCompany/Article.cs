using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeCompany
{
    public class Article : IComparable<Article>
    {
        public int Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Article(int barcode, string vendor, string title, decimal price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }


        public int CompareTo(Article other)
        {
            if (other != null)
            {
                return this.Price.CompareTo(other.Price);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
