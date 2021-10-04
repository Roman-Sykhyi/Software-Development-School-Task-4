using System;

namespace Задача_1
{
    public class DairyProduct : Product
    {
     

        public DairyProduct(string name, float price, float weight, int expirationDate, DateTime manufactureDate) : base(name, price, weight, expirationDate, manufactureDate) { }

        public override void RaisePrice(int percent)
        {
            percent += expirationDate / 10;
            base.RaisePrice(percent);
        }

        public override bool Equals(object obj)
        {
            DairyProduct product = obj as DairyProduct;
            return product == null ? false : Name.Equals(product.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Назва: " + Name + ". Ціна: " + Price + ". Вага: " + Weight + ". Термін придатності: " + expirationDate + " днів.";
        }
    }
}
