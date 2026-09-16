using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            int nextId = 10000;

            while (true)
            {
                Console.WriteLine("\nМЕНЮ");
                Console.WriteLine("1 - Добавить товар");
                Console.WriteLine("2 - Удалить товар");
                Console.WriteLine("3 - Показать товары");
                Console.WriteLine("4 - Заказать поставку");
                Console.WriteLine("5 - Продать товар");
                Console.WriteLine("6 - Поиск товара");
                Console.WriteLine("0 - Выход");

                Console.Write("Выберите пункт: ");
                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Write("Введите название: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите цену: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Введите количество: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("1 - Еда");
                        Console.WriteLine("2 - Электроника");
                        Console.WriteLine("3 - Одежда");
                        Console.Write("Выберите категорию: ");
                        int categoryNumber = Convert.ToInt32(Console.ReadLine());

                        Category category;

                        if (categoryNumber == 1)
                            category = Category.Food;
                        else if (categoryNumber == 2)
                            category = Category.Electronics;
                        else
                            category = Category.Clothes;

                        if (name == "" || price < 0 || quantity < 0)
                        {
                            Console.WriteLine("Неверные данные.");
                            break;
                        }

                        Product product = new Product(
                            nextId,
                            name,
                            price,
                            quantity,
                            category);

                        products.Add(product);
                        nextId++;

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
                            Console.WriteLine("Товар не найден.");

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


                    case 4:
                        Console.Write("Введите ID товара: ");
                        int supplyId = Convert.ToInt32(Console.ReadLine());

                        Product supplyProduct = null;

                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i].ProductID == supplyId)
                            {
                                supplyProduct = products[i];
                                break;
                            }
                        }

                        if (supplyProduct == null)
                        {
                            Console.WriteLine("Товар не найден.");
                            break;
                        }

                        Console.Write("Введите количество поставки: ");
                        int supplyQuantity = Convert.ToInt32(Console.ReadLine());

                        if (supplyQuantity > 0)
                        {
                            supplyProduct.Quantity += supplyQuantity;
                            Console.WriteLine("Поставка добавлена.");
                        }
                        else
                        {
                            Console.WriteLine("Количество должно быть больше 0.");
                        }

                        break;


                    case 5:
                        Console.Write("Введите ID товара: ");
                        int sellId = Convert.ToInt32(Console.ReadLine());

                        Product sellProduct = null;

                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i].ProductID == sellId)
                            {
                                sellProduct = products[i];
                                break;
                            }
                        }

                        if (sellProduct == null)
                        {
                            Console.WriteLine("Товар не найден.");
                            break;
                        }

                        Console.Write("Введите количество: ");
                        int sellQuantity = Convert.ToInt32(Console.ReadLine());

                        if (sellQuantity <= 0)
                        {
                            Console.WriteLine("Количество должно быть больше 0.");
                        }
                        else if (sellQuantity > sellProduct.Quantity)
                        {
                            Console.WriteLine("Недостаточно товара на складе.");
                        }
                        else
                        {
                            sellProduct.Quantity -= sellQuantity;
                            Console.WriteLine("Товар продан.");
                        }

                        break;


                    case 6:
                        Console.Write("Введите название для поиска: ");
                        string search = Console.ReadLine();

                        bool searchFound = false;

                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i].Name.ToLower().Contains(search.ToLower()))
                            {
                                products[i].PrintInfo();
                                searchFound = true;
                            }
                        }

                        if (searchFound == false)
                            Console.WriteLine("Товар не найден.");

                        break;


                    case 0:
                        break;


                    default:
                        Console.WriteLine("Такого пункта меню нет.");
                        break;
                }

                if (menu == 0)
                    break;
            }
        }
    }


    enum Category
    {
        Food,
        Electronics,
        Clothes
    }


    class Product
    {
        public int ProductID;
        public string Name;
        public double Price;
        public int Quantity;
        public Category Category;

        public Product(
            int productID,
            string name,
            double price,
            int quantity,
            Category category)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public void PrintInfo()
        {
            Console.WriteLine(
                "ID: " + ProductID +
                " | Название: " + Name +
                " | Цена: " + Price +
                " руб." +
                " | Количество: " + Quantity +
                " | На складе: " + (Quantity > 0 ? "Да" : "Нет") +
                " | Категория: " + Category);
        }
    }
}