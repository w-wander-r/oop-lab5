using System;
using System.Numerics;

public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
{
    private BigInteger nom; // чисельник
    private BigInteger denom; // знаменник

    public MyFrac(BigInteger nom, BigInteger denom)
    {
        if (denom == 0)
            throw new DivideByZeroException("Denominator cannot be zero");
        
        // Знаходження найбільшого спільного дільника (НСД)
        BigInteger gcd = BigInteger.GreatestCommonDivisor(nom, denom);
        
        // Скорочення дробу
        this.nom = nom / gcd;
        this.denom = denom / gcd;

        // Перевірка знаку знаменника
        if (this.denom < 0)
        {
            this.nom = -this.nom;
            this.denom = -this.denom;
        }
    }

    public MyFrac(string str)
    {
        string[] parts = str.Split('/');
        if (parts.Length != 2)
            throw new ArgumentException("Invalid format. Should be 'a/b'");

        if (!BigInteger.TryParse(parts[0], out nom) || !BigInteger.TryParse(parts[1], out denom))
            throw new ArgumentException("Invalid format. Num and denom must be integers");

        if (denom == 0)
            throw new DivideByZeroException("Denominator cannot be zero");

        BigInteger gcd = BigInteger.GreatestCommonDivisor(nom, denom);
        this.nom = nom / gcd;
        this.denom = denom / gcd;

        if (this.denom < 0)
        {
            this.nom = -this.nom;
            this.denom = -this.denom;
        }
    }

    public MyFrac Add(MyFrac b)
    {
        BigInteger newNom = this.nom * b.denom + this.denom * b.nom;
        BigInteger newDenom = this.denom * b.denom;
        return new MyFrac(newNom, newDenom);
    }

    public MyFrac Subtract(MyFrac b)
    {
        BigInteger newNom = this.nom * b.denom - this.denom * b.nom;
        BigInteger newDenom = this.denom * b.denom;
        return new MyFrac(newNom, newDenom);
    }

    public MyFrac Multiply(MyFrac b)
    {
        BigInteger newNom = this.nom * b.nom;
        BigInteger newDenom = this.denom * b.denom;
        return new MyFrac(newNom, newDenom);
    }

    public MyFrac Divide(MyFrac b)
    {
         if (b.nom == 0)
            throw new DivideByZeroException("Division by zero");
        
        BigInteger newNom = this.nom * b.denom;
        BigInteger newDenom = this.denom * b.nom;
        return new MyFrac(newNom, newDenom);
    }

    public override string ToString()
    {
        return $"{nom}/{denom}";
    }

    public int CompareTo(MyFrac other)
    {
        // Порівняння a/b з c/d: 
        // порівнюємо a*d та c*b
        BigInteger left = this.nom * other.denom;
        BigInteger right = other.nom * this.denom;
        return left.CompareTo(right);
    }
}