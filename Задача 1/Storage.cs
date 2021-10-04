using System;
using System.Collections.Generic;
using System.Globalization;

namespace Задача_1
{
    public class Storage
    {
        private List<Product> products;
        public int Size { get { return products.Count; } }

        public Storage()
        {
            products = new List<Product>();
            FillStorageFromConsole();
            //FillStorageByInitialization();
        }

        public Product this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                products[index] = value;
            }
        }

        public void PrintProductsInfo()
        {
            Console.WriteLine("Інформація про наявні товари:");
            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public List<Meat> GetMeatProducts()
        {
            List<Meat> meats = new List<Meat>();

            foreach (Product product in products)
            {
                if (product is Meat)
                {
                    meats.Add(product as Meat);
                }
            }

            return meats;
        }

        public void RaisePrices(int percent)
        {
            foreach (Product product in products)
            {
                product.RaisePrice(percent);
            }
        }

        private void FillStorageFromConsole()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("N - додати новий продукт");
                Console.WriteLine("Q - завершити додавання продуктів");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.N:
                        Product product = GetNewProductFromConsole();
                        products.Add(product);
                        break;
                    case ConsoleKey.Q:
                        return;
                }
            }
        }

        private void FillStorageByInitialization()
        {
            Product bread = new Product("Хліб", 10f, 0.3f, 5, DateTime.Now);
            Product meat = new Meat("Стейк", 300f, 1f, MeatGrade.Highest, MeatType.Veal, 11, DateTime.Now);
            Product milk = new DairyProduct("Молоко", 28.5f, 1f, 7, DateTime.Now);

            products.Add(milk);
            products.Add(meat);
            products.Add(bread);
        }

        private Product GetNewProductFromConsole()
        {
            Console.Clear();
            Console.WriteLine("Виберіть тип продукту");
            Console.WriteLine("P - звичайний продукт");
            Console.WriteLine("M - м'ясний продукт");
            Console.WriteLine("D - молочний продукт");
            
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.P:
                    return GetProductFromConsole();
                case ConsoleKey.M:
                    return GetMeatProductFromConsole();
                case ConsoleKey.D:
                    return GetDairyProductFromConsole();
                default:
                    return null;
            }
        }

        private Product GetProductFromConsole()
        {
            Console.Clear();

            Console.Write("Введіть назву товару: ");
            string name = Console.ReadLine();
            Console.Write("Введіть ціну товару (xx,xx): ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Введіть вагу товару (xx,xx): ");
            float weigth = float.Parse(Console.ReadLine());
            Console.Write("Введіть термін придатності (к-сть днів): ");
            int expirationDate = int.Parse(Console.ReadLine());
            Console.Write("Введіть дату виготовлення (дд.мм.рррр): ");
            DateTime manufactureDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Product product = new Product(name, price, weigth, expirationDate, manufactureDate);
            return product;
        }

        private Meat GetMeatProductFromConsole()
        {
            Console.Clear();

            Console.Write("Виберіть вид м'яса (баранина - 1, телятина - 2, свинина - 3, курятина - 4): ");
            MeatType meatType = Enum.Parse<MeatType>(Console.ReadLine());

            Console.Write("Виберіть сорт м'яса (вищий - 1, перший - 2, другий - 3): ");
            MeatGrade meatGrade = Enum.Parse<MeatGrade>(Console.ReadLine());

            Console.Write("Введіть назву товару: ");
            string name = Console.ReadLine();
            Console.Write("Введіть ціну товару (xx,xx): ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Введіть вагу товару (xx,xx): ");
            float weigth = float.Parse(Console.ReadLine());
            Console.Write("Введіть термін придатності (к-сть днів): ");
            int expirationDate = int.Parse(Console.ReadLine());
            Console.Write("Введіть дату виготовлення (дд.мм.рррр): ");
            DateTime manufactureDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Meat meatProduct = new Meat(name, price, weigth, meatGrade, meatType, expirationDate, manufactureDate);
            return meatProduct;
        }

        private Product GetDairyProductFromConsole()
        {
            Console.Clear();

            Console.Write("Введіть назву товару: ");
            string name = Console.ReadLine();
            Console.Write("Введіть ціну товару (xx,xx): ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Введіть вагу товару (xx,xx): ");
            float weigth = float.Parse(Console.ReadLine());
            Console.Write("Введіть термін придатності (к-сть днів): ");
            int expirationDate = int.Parse(Console.ReadLine());
            Console.Write("Введіть дату виготовлення (дд.мм.рррр): ");
            DateTime manufactureDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            DairyProduct dairyProduct = new DairyProduct(name, price, weigth, expirationDate, manufactureDate);
            return dairyProduct;
        }
    }
}