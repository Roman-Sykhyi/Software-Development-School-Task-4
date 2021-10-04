namespace Задача_2
{
    public class PolynomialPart
    {
        public int RealPart { get; set; }
        public int PolynomRank { get; set; }

        public PolynomialPart(int realPart, int polynomRank)
        {
            RealPart = realPart;
            PolynomRank = polynomRank;
        }

        public override string ToString()
        {
            string result = "";
            if (RealPart != 1)
            {
                result += RealPart;
            }

            if(PolynomRank == 1)
            {
                result += "x";
            }
            else if(PolynomRank != 0)
            {
                result += "x^" + PolynomRank;
            }
            return result;
        }
    }
}