using System;
using System.Diagnostics.CodeAnalysis;

namespace Fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        /* Zadania:
        Utwórz klasę Ułamek, a w niej:
        prywatne zmienne licznik i mianownik(typu całkowitego ze znakiem),
          konstruktor domyślny(bez argumentów),
        konstruktor z dwoma argumentami,
        konstruktor kopiujący(1 argument).
        Dodaj metodę ToString().
        Przeładuj operatory + - * /.
        Zaimplementuj interfejsy IEquatable i IComparable(posortuj tablice ułamków aby sprawdzić czy IComparable działa poprawnie).
        klasę tak, aby możliwe było, tylko i wyłącznie, odczytywanie licznika i mianownika(wykorzystaj gettery).
        Zaproponuj dwie dodatkowe publiczne metody np.zaokrąglij do liczby całkowitej w dół i w góre (wykorzystaj konwersję jawną typów).
        Dodaj testy jednostkowe dla pkt. 1 - 6 (warto dodawać testy jednostkowe w trakcie tworzenie klasy Ułamek).
        Dodaj dokumentację dla klasy Ułamek.
       */
        public class Fraction: IEquatable<Fraction>, IComparable<Fraction>
        {
            /// <summary>
            /// test

            /// </summary>
            private int num = 1;
            private int den = 2;

            public Fraction()
            {
                this.num = 1;
                this.den = 2;
            }
            public Fraction(int x, int y)
            {
                
            this.num = x;
            this.den = y;
            }
            public Fraction(Fraction fraction)
            {
                this.num = fraction.num;
                this.den = fraction.den;
            }

            public static Fraction operator +(Fraction a) => a;
            public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

            public static Fraction operator +(Fraction a, Fraction b)
                => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

            public static Fraction operator -(Fraction a, Fraction b)
                => a + (-b);

            public static Fraction operator *(Fraction a, Fraction b)
                => new Fraction(a.num * b.num, a.den * b.den);

            public static Fraction operator /(Fraction a, Fraction b)
            {
                if (b.num == 0)
                {
                    throw new DivideByZeroException();
                }
                return new Fraction(a.num * b.den, a.den * b.num);
            }
            public override string ToString()
            {
                return base.ToString();
            }

            public bool Equals([AllowNull] Fraction other)
            {
                
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;
                if (this.num * other.den == other.num * this.den) return true;
                else return false;
             
            }

            public int CompareTo([AllowNull] Fraction other)
            {
                if (other ==null && this.num*this.den > 0 ) return 1;
                if (other == null && this.num * this.den < 0) return -1;
                if (this.num * other.den == other.num * this.den) return 0;
                if (this.num * other.den < other.num * this.den) return 1;
                if (this.num * other.den > other.num * this.den) return -1;
                else return -1;
            }

        }
    }

    
}
