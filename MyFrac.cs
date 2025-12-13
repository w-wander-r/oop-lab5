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
        return new MyFrac(0, 0);
    }

    public MyFrac Subtract(MyFrac b)
    {
        return new MyFrac(0, 0);
    }

    public MyFrac Multiply(MyFrac b)
    {
        return new MyFrac(0, 0);
    }

    public MyFrac Divide(MyFrac b)
    {
        return new MyFrac(0, 0);
    }

    
    public int CompareTo(MyFrac other)
    {
        return 0;
    }
}