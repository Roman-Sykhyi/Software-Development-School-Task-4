using System;
using System.Text;

namespace Задача_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Storage storage = new Storage();
            PrintProductsInfo(storage);

            Console.Write("Введіть шлях до файлу в який буде збережено інформацію про молочні продукти у яких вийшов термін придатності: ");
            storage.RemoveOutOfDateDairyProducts(Console.ReadLine());

            Console.ReadKey();
        }
       
        private static void PrintProductsInfo(Storage storage)
        {
            Console.Clear();
            Console.WriteLine("Інформація про наявні продукти:");

            for (int i = 0; i < storage.Size; i++)
                Console.WriteLine(storage[i].ToString());
        }

    }
}