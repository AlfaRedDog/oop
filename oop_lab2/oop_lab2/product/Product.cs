using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab2.product
{
    public class Product
    {
        public string Name { get; }

        public int ID { get; }

        public Product(string name, int id)
        {
            Name = name;
            ID = id;
        }
        public Product()
        {
            Name = "";
            ID = 0;
        }
    }
}
