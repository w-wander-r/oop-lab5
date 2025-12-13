using System;

public class MyComplex : IMyNumber<MyComplex>
{
    private double re;
    private double im;

    public MyComplex(double re, double im)
    {
        this.re = re;
        this.im = im;
    }

    public MyComplex Add(MyComplex b)
    {
        return new MyComplex(0, 0);
    }

    public MyComplex Subtract(MyComplex b)
    {
        return new MyComplex(0, 0);
    }

    public MyComplex Multiply(MyComplex b)
    {
        return new MyComplex(0, 0);
    }

    public MyComplex Divide(MyComplex b)
    {
        return new MyComplex(0, 0);
    }
}