namespace CalculMethods;

public class HordMetod
{
    public static double MyFunction(double x) 
    {
        return 1 - 0.5 * Math.Pow(x, 2) * Math.Log(x) + 0.3 * Math.Sqrt(x);
    }

    public static double HordMethod(double a, double b, double epsilon)
    {
        double x = 0;
        int count = 1;
        while (!(b - a < epsilon))
        {
            x = a - (MyFunction(a) * (b - a)) / (MyFunction(b) - MyFunction(a));
            Console.WriteLine($"{count}: \t root - {x}");
            
            if (Math.Abs(MyFunction(x)) < epsilon)
            {
                return x;
            }
            
            if (MyFunction(x) * MyFunction(a) < 0)
            {
                b = x;
            }
            else
            {
                a = x;
            }
            
            count++;
        }
        return x;
    }
}