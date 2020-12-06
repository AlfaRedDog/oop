using System;
using System.Collections.Generic;
using System.Text;
using oop_lab2.Exceptions;
namespace oop_lab2.product
{
    class Consigment
    {
        public Product produce { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public Consigment(Product p, int cont, int pric)
        {
            produce = p;
            if (cont <= 0)
                throw new CountException();
            if (pric <= 0)
                throw new PriceException();
            count = cont;
            price = pric;
        }
        public Consigment(string name, int id, int cont, int pric)
        {
            produce = new Product(name, id);
            if (cont <= 0)
                throw new CountException();
            if (pric <= 0)
                throw new PriceException();
            count = cont;
            price = pric;
        }
        public Consigment()
        {
            produce = new Product();
            count = 0;
            price = 0;
        }
    }
}
