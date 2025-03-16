namespace GaussSeidel_Method_;

public class Program
{
    public static void Main(string[] args)
    {
        double[,] matrix = {
            { 4.855, 1.239, 0.272, 0.258 },
            { 1.491, 4.954, 0.124, 0.236 },
            { 0.456, 0.285, 4.354, 0.254 },
            { 0.412, 0.335, 0.158, 2.874 }
        };

        double[] bMatrix = { 1.192, 0.256, 0.852, 0.862 };
        
        GaussSeidel gaussSeidel = new GaussSeidel(matrix, bMatrix);
        gaussSeidel.CreateGaussSeidel();
    }
}