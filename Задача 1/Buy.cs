using System;
using System.Collections.Generic;

namespace Задача_1
{
    public class Buy
    {
        private List<(Product, int)> products { get; }

        public float Price { get; }
        public float Weight { get; }

        public Buy(List<(Product, int)> products)
        {
            foreach ((Product, int) product in products)
            {
                if (product.Item1 == null)
                    throw new ArgumentNullException("Товар не може бути null", nameof(product.Item1));
                else if (product.Item2 <= 0)
                    throw new ArgumentOutOfRangeException("Кількість товару не може бути меншою або рівною 0", nameof(product.Item2));
            }
            this.products = products;

            foreach((Product, int) product in products)
            {
                Price += product.Item1.Price * product.Item2;
                Weight += product.Item1.Weight * product.Item2;
            }
        }

        public override string ToString()
        {
            string result = "";

            foreach((Product, int) product in products)
            {
                result += "Назва: " + product.Item1.Name + ". Кількість товару: " + product.Item2
                    + ". Ціна: " + (product.Item1.Price * product.Item2) + ". Вага: " + (product.Item1.Weight * product.Item2) + "\n";
            }
            result += "Повна ціна: " + Price + ". Повна вага: " + Weight;

            return result;
        }
    }
}
