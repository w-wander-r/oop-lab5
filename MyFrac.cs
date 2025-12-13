using System;
using System.Numerics;

public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
{
    private BigInteger nom; // чисельник
    private BigInteger denom; // знаменник

    public MyFrac(BigInteger nom, BigInteger denom)
    {
        if (denom == 0)
            throw new DivideByZeroException("Denominator cannot be zero.");
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
        BigInteger left = this.nom * other.denom;
        BigInteger right = other.nom * this.denom;
        return left.CompareTo(right);
    }
}