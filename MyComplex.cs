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

    public MyComplex(string str)
    {
        // Формат: "a+bi" або "a-bi"
        str = str.Replace(" ", "");
        int plusIndex = str.LastIndexOf('+');
        int minusIndex = str.LastIndexOf('-');
        
        if (plusIndex <= 0 && minusIndex <= 0)
            throw new ArgumentException("Invalid number format. Should be 'a+bi' or 'a-bi'");

        int signIndex = Math.Max(plusIndex, minusIndex);
        string realPart = str.Substring(0, signIndex);
        string imagPart = str.Substring(signIndex, str.Length - signIndex - 1); // без 'i'

        if (!double.TryParse(realPart, out re) || !double.TryParse(imagPart, out im))
            throw new ArgumentException("Invalid number format. Real and imaginary parts must be numbers");

        if (str[signIndex] == '-')
            im = -im;
    }

    public MyComplex Add(MyComplex b)
    {
        return new MyComplex(this.re + b.re, this.im + b.im);
    }

    public MyComplex Subtract(MyComplex b)
    {
        return new MyComplex(this.re - b.re, this.im - b.im);
    }

    public MyComplex Multiply(MyComplex b)
    {
        double newRe = this.re * b.re - this.im * b.im;
        double newIm = this.re * b.im + this.im * b.re;
        return new MyComplex(newRe, newIm);
    }

    public MyComplex Divide(MyComplex b)
    {
        double denominator = b.re * b.re + b.im * b.im;
        if (denominator == 0)
            throw new DivideByZeroException("Division by zero");

        double newRe = (this.re * b.re + this.im * b.im) / denominator;
        double newIm = (this.im * b.re - this.re * b.im) / denominator;
        return new MyComplex(newRe, newIm);
    }

    public override string ToString()
    {
        string sign = im >= 0 ? "+" : "";
        return $"{re}{sign}{im}i";
    }
}