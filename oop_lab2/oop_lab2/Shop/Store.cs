using System;
using System.Collections.Generic;
using System.Text;
using oop_lab2.product;
using oop_lab2.Exceptions;
namespace oop_lab2.Shop
{
    class Store
    {
        public string Name { get; }
        public string adress { get; }
        public List<Consigment> Allproducts { get; set; }

        public Store(string name, string adres)
        {
            Name = name;
            adress = adres;
            Allproducts = new List<Consigment>();
        }
        public Store()
        {
            Name = "";
            adress = "";
            Allproducts = new List<Consigment>();
        }
        public void AddConsigment(Consigment consig)
        {
            Consigment temp = consig;
            bool flag = false;

            foreach (var element in Allproducts)
            {
                if (element.produce == consig.produce)
                {
                    flag = true;
                    temp = element;
                    break;
                }
            }

            if(flag == false)
                Allproducts.Add(temp);
            else
            {
                Allproducts.Remove(temp);
                temp.count += consig.count;
                temp.price = consig.price;
                Allproducts.Add(temp);
            }
        }
        public int BuyConsigment(Product a, int cont)
        {
            Consigment temp = new Consigment();
            foreach(var element in Allproducts)
            {
                if (element.produce == a)
                    if (element.count >= cont)
                    {
                        temp = element;
                        break;
                    }
                    else
                        throw new BuyItemException();
            }
            Allproducts.Remove(temp);
            temp.count -= cont;
            Allproducts.Add(temp);
            return temp.price * cont;
        }
        public void HowMuchCanBuy(int cash)
        {
            foreach(var element in Allproducts)
            {
                Console.WriteLine($"{element.produce.Name} {Math.Floor((double)(cash / element.price))}");
            }
        }
    }
}
