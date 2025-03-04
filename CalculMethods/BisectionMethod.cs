namespace CalculMethods;

public class BisectionMethod
{
    public static double MyFunction(double x)
    {
        return 1 - 0.5 * Math.Pow(x, 2) * Math.Log(x) + 0.3 * Math.Sqrt(x);
    }

    public static double Bisection(double a, double b, double epsilon)
    {
        int count = 1;
        while (!(Math.Abs(b - a) < epsilon))
        {
            double c = (a + b) / 2;
            Console.WriteLine($"{count}: c - {c}");
            count++;
            if (Math.Abs(MyFunction(c)) < epsilon)
            {
                return c;
            }
            if (MyFunction(c)*MyFunction(a) < 0)
            {
                b = c;
            }
            else
            {
                a = c;
            }
        }
        return (a+b)/2;
    }
}
    