namespace CalculMethods;

public class IterationMethod
{
    public static double MyFunction(double x) 
    {
        return 1 - 0.5 * Math.Pow(x, 2) * Math.Log(x) + 0.3 * Math.Sqrt(x);
    }

    public static double Functor(double x)
    {
        return -x * Math.Log(x) - 0.5 * x + 0.15/Math.Sqrt(x);
    }

    public static double Method(double a, double epsilon)
    {
        double max = -2.2802;
        double l = -1 / max;
        Console.WriteLine(l);
        double x = a + l * (1 - 0.5 * Math.Pow(a, 2) * Math.Log(a) + 0.3 * Math.Sqrt(a));
        double xPrev = x;
        double xNext = x;
        int count = 1;
        do
        {
            xPrev = xNext;
            xNext = MyFunction(xPrev);
            Console.WriteLine($"{count}: x - {xPrev}, x{count} - {xNext}");
            count++;
        }while (Math.Abs((xNext - xPrev)/2) > epsilon);
        
        return x;
    }
    
}