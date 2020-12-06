using System;
using System.Collections.Generic;
using oop_lab2.product;
using oop_lab2.Shop;
using oop_lab2.Exceptions;
namespace oop_lab2
{
    class Program
    {
        static void WriteStore(Store a)
        {
            Console.WriteLine(a.Name);
            Console.WriteLine(a.adress);
            foreach (var element in a.Allproducts)
            {
                Console.WriteLine($"{element.produce.Name} {element.produce.ID} {element.count} {element.price}");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                    //create product
                Product prod1 = new Product("beer", 14);
                Product prod2 = new Product("apple", 15);
                Product prod3 = new Product("pear", 16);
                Product prod4 = new Product("peach", 17);
                Product prod5 = new Product("orange", 18);
                Product prod6 = new Product("glok", 19);
                Product prod7 = new Product("ak-47", 20);
                Product prod8 = new Product("granate", 21);
                Product prod9 = new Product("pineapple", 22);
                Product prod10 = new Product("book", 23);
                    //create store
                Store Shop1 = new Store("perekrestok", "Sitymoll");
                Store Shop2 = new Store("7ya", "kolomyzskiy prospect 26");
                Store Shop3 = new Store("pyaterochka", "bogatyrsiy prospect 4");
                
                    //add consigment or change product list
                Shop1.AddConsigment(new Consigment(prod1, 1, 132));
                Shop1.AddConsigment(new Consigment(prod2, 113, 73));
                Shop1.AddConsigment(new Consigment(prod3, 5, 12));
                Shop1.AddConsigment(new Consigment(prod1, 13, 132));
                Shop1.AddConsigment(new Consigment(prod4, 22, 15));
                Shop1.AddConsigment(new Consigment(prod5, 121, 23));
                Shop1.AddConsigment(new Consigment(prod6, 128, 82));
                WriteStore(Shop1);

                Shop2.AddConsigment(new Consigment(prod1, 13, 32));
                Shop2.AddConsigment(new Consigment(prod2, 13, 43));
                Shop2.AddConsigment(new Consigment(prod3, 50, 122));
                Shop2.AddConsigment(new Consigment(prod7, 29, 25));
                Shop2.AddConsigment(new Consigment(prod8, 11, 13));
                Shop2.AddConsigment(new Consigment(prod9, 18, 42));
                Shop2.AddConsigment(new Consigment(prod10, 150, 1302));

                Shop3.AddConsigment(new Consigment(prod4, 34, 2));
                Shop3.AddConsigment(new Consigment(prod5, 22, 33));
                Shop3.AddConsigment(new Consigment(prod6, 7, 52));
                Shop3.AddConsigment(new Consigment(prod7, 9, 225));
                Shop3.AddConsigment(new Consigment(prod8, 113, 233));
                Shop3.AddConsigment(new Consigment(prod9, 45, 24));
                Shop3.AddConsigment(new Consigment(prod10, 223, 1));
                    //buy consigment
                Console.WriteLine(Shop1.BuyConsigment(prod1, 28));
                WriteStore(Shop1);
                    //How much i can buy on my cash
                Shop1.HowMuchCanBuy(47);
                    //where product have min price
                StoreСomparison example = new StoreСomparison(new[] {Shop1, Shop2, Shop3});
                Console.WriteLine(example.MinProductPrice(prod10));
                    //where Consigment have min price
                Consigment con1 = new Consigment(prod1, 20, 123);
                Consigment con2 = new Consigment(prod2, 10, 123);
                Console.WriteLine(example.MinConsigmentPrice(new[] { con1, con2 }));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
