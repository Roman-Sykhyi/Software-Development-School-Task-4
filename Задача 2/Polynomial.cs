﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Задача_2
{
    public class Polynomial
    {
        public List<PolynomialPart> parts { get; set; }

        public Polynomial()
        {
            parts = new List<PolynomialPart>();

            parts.Add(new PolynomialPart(10, 0));
            parts.Add(new PolynomialPart(1, 1));
            parts.Add(new PolynomialPart(7, 2));
            parts.Add(new PolynomialPart(5, 3));

            parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));
        }

        public int this[int c]
        {
            set
            {
                PolynomialPart part = parts.FirstOrDefault(x => x.PolynomRank == c);

                if (value != 0)
                {
                    if(part != null)
                    {
                        part.RealPart = value;
                    }
                    else
                    {
                        PolynomialPart newPart = new PolynomialPart(value, c);
                        parts.Add(newPart);
                    }
                }
                else if(value == 0)
                {
                    if(part != null)
                    {
                        parts.Remove(part);
                    }
                }

                parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));
            }
        }

        public void Add(Polynomial polynomial)
        {
            foreach(PolynomialPart polynomialPart in polynomial.parts)
            {
                PolynomialPart part = parts.FirstOrDefault(x => x.PolynomRank == polynomialPart.PolynomRank);
                if(part != null)
                {
                    part.RealPart += polynomialPart.RealPart;

                    if (part.RealPart == 0)
                    {
                        parts.Remove(part);
                    }
                }
                else
                {
                    parts.Add(polynomialPart);
                }
            }

            parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));
        }

        public void Subtract(Polynomial polynomial)
        {
            foreach (PolynomialPart polynomialPart in polynomial.parts)
            {
                PolynomialPart part = parts.FirstOrDefault(x => x.PolynomRank == polynomialPart.PolynomRank);
                if (part != null)
                {
                    part.RealPart -= polynomialPart.RealPart;

                    if(part.RealPart == 0)
                    {
                        parts.Remove(part);
                    }
                }
                else
                {
                    PolynomialPart newPart = new PolynomialPart(-polynomialPart.RealPart, polynomialPart.PolynomRank);
                    parts.Add(newPart);
                }
            }

            parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));
        }

        public void Multiply(Polynomial polynomial)
        {
            foreach (PolynomialPart polynomialPart in polynomial.parts)
            {
                PolynomialPart part = parts.FirstOrDefault(x => x.PolynomRank == polynomialPart.PolynomRank);
                if (part != null)
                {
                    part.RealPart *= polynomialPart.RealPart;
                }
            }

            parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));
        }

        public void Parse(string s)
        {

        }

        public override string ToString()
        {
            string result = "";

            for(int i = 0; i < parts.Count; i++)
            {
                if (i == 0)
                {
                    result += parts[i].ToString();
                }
                else
                {
                    if (parts[i].RealPart > 0)
                    {
                        result += "+";
                    }
                    result += parts[i].ToString();
                }
            }

            //result += parts.Last().ToString();

            return result;
        }
    }
}
