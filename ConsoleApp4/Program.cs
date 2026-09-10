using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            while (true)
            {
                Console.WriteLine("\nМЕНЮ");
                Console.WriteLine("1 - Добавить товар");
                Console.WriteLine("2 - Удалить товар");
                Console.WriteLine("3 - Показать товары");
                Console.WriteLine("0 - Выход");

                Console.Write("Выберите пункт: ");
                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Write("Введите ID товара: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите название: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите цену: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Введите количество: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        Product product = new Product(id, name, price, quantity);

                        products.Add(product);

                        Console.WriteLine("Товар добавлен.");
                        break;

                    case 2:
                        Console.Write("Введите ID товара для удаления: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        bool found = false;

                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i].ProductID == deleteId)
                            {
                                products.RemoveAt(i);
                                found = true;
                                Console.WriteLine("Товар удалён.");
                                break;
                            }
                        }

                        if (found == false)
                        {
                            Console.WriteLine("Товар не найден.");
                        }
                        break;

                    case 3:
                        if (products.Count == 0)
                        {
                            Console.WriteLine("Список товаров пуст.");
                        }
                        else
                        {
                            Console.WriteLine("\nТОВАРЫ:\n");

                            for (int i = 0; i < products.Count; i++)
                            {
                                products[i].PrintInfo();
                            }
                        }
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Такого пункта меню нет.");
                        break;
                }

                if (menu == 0)
                {
                    break;
                }
            }
        }
    }

    class Product
    {
        public int ProductID;
        public string Name;
        public double Price;
        public int Quantity;

        public Product(int productID, string name, double price, int quantity)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void PrintInfo()
        {
            Console.WriteLine(
                "ID: " + ProductID +
                " | Название: " + Name +
                " | Цена: " + Price +
                " руб." +
                " | Количество: " + Quantity);
        }
    }
}