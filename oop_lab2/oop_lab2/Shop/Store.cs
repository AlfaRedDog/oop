using System;
using System.Collections.Generic;
using System.Text;
using oop_lab2.product;
using System.Linq;
using oop_lab2.Exceptions;
namespace oop_lab2.Shop
{
    class Store
    {
        public Guid ID { get; }
        public string Name { get; }
        public string adress { get; }
        public List<Consigment> Allproducts { get; set; }

        public Store(string name, string adres, Guid id)
        {
            Name = name;
            adress = adres;
            Allproducts = new List<Consigment>();
            ID = id;
        }
        public Store()
        {
            Name = "";
            adress = "";
            Allproducts = new List<Consigment>();
            ID = Guid.NewGuid();
        }
        public void AddConsigment(Consigment consig)
        {
            Consigment temp = consig;
            bool flag = false;

            foreach (var element in Allproducts)
            {
                if (element.produce.ID == consig.produce.ID)
                {
                    flag = true;
                    temp = element;
                    break;
                }
            }

            if (flag == false)
                Allproducts.Add(temp);
            else
            {
                Allproducts.Remove(temp);
                temp.count += consig.count;
                temp.price = consig.price;
                Allproducts.Add(temp);
            }
        }
        public int BuyConsigment(IEnumerable<Consigment> consig)
        {
            int sum = 0;
            foreach (var element in consig)
            {
                var product = Allproducts.SingleOrDefault(item => item.produce.ID == element.produce.ID);
                if((product != null) && (element.count <= product.count))
                {
                    product.count -= element.count;
                    sum += element.count * product.price;
                }
            }
            return sum;
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
