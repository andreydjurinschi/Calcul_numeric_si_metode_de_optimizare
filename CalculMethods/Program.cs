using System.Threading.Channels;

namespace CalculMethods;

public class Program
{
    public static void Main(string[] args)
    {
        double a = 2;
        double b = 3;
        double epsilon = 0.001;
        
        Console.WriteLine("__________Hord method_______________ ");
        double root = HordMetod.HordMethod(a, b, epsilon);
        Console.WriteLine($"          {root}                   ");
        Console.WriteLine("____________________________________");
        Console.WriteLine("__________Bisection method_______________ ");
        double root2 = BisectionMethod.Bisection(a, b, epsilon);
        Console.WriteLine($"          {root2}                   ");
    }
}