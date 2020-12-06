using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab2.Exceptions
{
    class ProductNotFound : Exception
    {
        public ProductNotFound() : base("product not found")
        {
        }
    }
}
