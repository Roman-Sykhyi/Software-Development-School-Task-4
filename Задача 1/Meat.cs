using System;

namespace Задача_1
{
    public enum MeatGrade
    {
        Highest = 1,
        First,
        Second
    }

    public enum MeatType
    {
        Lamb = 1,
        Veal,
        Pork,
        Chicken
    }

    public class Meat : Product
    {
        private MeatGrade grade;
        private MeatType type;

        public Meat(string name, float price, float weight, MeatGrade grade, MeatType type, int expirationDate, DateTime manufactureDate) : base(name, price, weight, expirationDate, manufactureDate)
        {
            this.grade = grade;
            this.type = type;
        }

        public override void RaisePrice(int percent)
        {
            switch (grade)
            {
                case MeatGrade.Highest:
                    percent += 10;
                    break;
                case MeatGrade.First:
                    percent += 7;
                    break;
                case MeatGrade.Second:
                    percent += 5;
                    break;
            }

            base.RaisePrice(percent);
        }

        public override bool Equals(object obj)
        {
            Meat product = obj as Meat;
            return product == null ? false : Name.Equals(product.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string gradeText = string.Empty;
            switch(grade)
            {
                case MeatGrade.Highest:
                    gradeText = "вищий";
                    break;
                case MeatGrade.First:
                    gradeText = "перший";
                    break;
                case MeatGrade.Second:
                    gradeText = "другий";
                    break;
            }

            string typeText = string.Empty;
            switch (type)
            {
                case MeatType.Lamb:
                    typeText = "баранина";
                    break;
                case MeatType.Veal:
                    typeText = "телятина";
                    break;
                case MeatType.Pork:
                    typeText = "свинина";
                    break;
                case MeatType.Chicken:
                    typeText = "курятина";
                    break;
            }

            string result = base.ToString();
            result += ". Сорт: " + gradeText + ". Вид м'яса: " + typeText;
            return result;
            //return "Назва: " + Name + ". Ціна: " + Price + ". Вага: " + Weight + ". Сорт: " + gradeText + ". Вид м'яса: " + typeText + ". Термін придатності: " + ExpirationDate + " днів. Дата виготовлення: " + ManufactureDate.ToShortDateString();
        }
    }
}
