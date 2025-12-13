class Program
{
    static void Main(string[] args)
    {
        // MyFrac
        TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
        TestSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));

        // MyComplex
        TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
        TestSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));

        // Сортування MyFrac
        List<MyFrac> fractions = new List<MyFrac>
        {
            new MyFrac(3, 4),
            new MyFrac(1, 2),
            new MyFrac(5, 6),
            new MyFrac(1, 3)
        };

        Console.WriteLine("----------------------------");
        Console.WriteLine("Before sorting:");
        foreach (var f in fractions)
            Console.WriteLine(f);

        fractions.Sort();

        Console.WriteLine("----------------------------");
        Console.WriteLine("After sorting:");
        foreach (var f in fractions)
            Console.WriteLine(f);
    }
    
    public static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine($"=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = {a}, b = {b} ===");
        T aPlusB = a.Add(b);
        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");
        Console.WriteLine($"(a + b) = {aPlusB}");
        Console.WriteLine($"(a+b)^2 = {aPlusB.Multiply(aPlusB)}");
        Console.WriteLine(" = = ");
        T curr = a.Multiply(a);
        Console.WriteLine($"a^2 = {curr}");
        T wholeRightPart = curr;
        curr = a.Multiply(b);
        curr = curr.Add(curr); // 2ab
        Console.WriteLine($"2*a*b = {curr}");
        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine($"b^2 = {curr}");
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine($"a^2+2ab+b^2 = {wholeRightPart}");
        Console.WriteLine($"=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = {a}, b = {b} ===");
    }

    public static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine($"=== Starting testing (a-b) and (a^2-b^2)/(a+b) with a = {a}, b = {b} ===");
        
        T aMinusB = a.Subtract(b);
        Console.WriteLine($"(a - b) = {aMinusB}");

        T aSquared = a.Multiply(a);
        T bSquared = b.Multiply(b);
        T numerator = aSquared.Subtract(bSquared);
        T denominator = a.Add(b);
        
        if (denominator is MyFrac frac && frac.CompareTo(new MyFrac(0, 1)) == 0)
            throw new DivideByZeroException("Denominator (a+b) is zero.");
        
        T quotient = numerator.Divide(denominator);
        Console.WriteLine($"(a^2 - b^2)/(a+b) = {quotient}");

        Console.WriteLine($"=== Finishing testing (a-b) and (a^2-b^2)/(a+b) with a = {a}, b = {b} ===");
    }
}