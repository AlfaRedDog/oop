using System;
using System.Collections.Generic;
using System.Text;
using oop_lab2.product;
using oop_lab2.Exceptions;
namespace oop_lab2.Shop
{
    class StoreСomparison
    {
        public IEnumerable<Store> AllStore { get; set; }

        public StoreСomparison()
        {
            AllStore = new List<Store>();
        }
        public StoreСomparison(IEnumerable<Store> stores)
        {
            AllStore = stores;
        }
        public string MinProductPrice (Product prod)
        {
            string ShopName = "";
            int MinPric = 0;
            foreach (var shop in AllStore)
            {
                foreach(var element in shop.Allproducts)
                {
                    if ((element.produce == prod) && ((element.price < MinPric) || (MinPric == 0)))
                    {
                        MinPric = element.price;
                        ShopName = shop.Name;
                    }
                }
            }
            if (ShopName == "")
                throw new ProductNotFound();
            return ShopName;
        }
        public string MinConsigmentPrice(IEnumerable<Consigment> products)
        {
            int MinPric = 0;
            string ShopName = "";
            foreach (var shop in AllStore)
            {
                int sum = 0;
                bool flag = true;
                foreach (var element in shop.Allproducts)
                {
                    foreach (var prod in products)
                    {
                        if (element.produce == prod.produce)
                        {
                            sum += element.price * prod.count;
                        }
                        if ((prod.count > element.count) && (element.produce == prod.produce))
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if(((sum < MinPric) || (MinPric == 0)) && (sum != 0) && (flag == true))
                {
                    MinPric = sum;
                    ShopName = shop.Name;
                }
            }
            if (ShopName == "")
                throw new ProductNotFound();
            return ShopName;
        }
    }
}
