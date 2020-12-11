using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab2.product
{
    public class Product
    {
        public string Name { get; }

        public Guid ID { get; }

        public Product(string name, Guid id)
        {
            Name = name;
            ID = id;
        }
        public Product()
        {
            Name = "";
            ID = Guid.NewGuid();
        }
    }
}
