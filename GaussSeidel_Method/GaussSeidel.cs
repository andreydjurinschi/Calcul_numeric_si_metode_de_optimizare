namespace GaussSeidel_Method_;

public class GaussSeidel
{
    
    /**
     * _array - matrix A
     * _BMatrix - matrix B
     * _epsilon - 0,001 (10^-6)
     */
    private double[,] _array;
    private double[] _BMatrix;
    private readonly double _epsilon = Math.Pow(10, -3);
    
    /**
     * Constructor - array (Matrix A), array(Matrix b)
     */
    public GaussSeidel(double[,] array, double[] bMatrix)
    {
        _array = array;
        _BMatrix = bMatrix;
    }
    
    /**
     * X generation dor every iteration
     * for every x I calculate it based on Gauss-Seidel method
     *
     * return type is an array
     */
    private double[] GenerateX(double[] xPrev)
    {
        int n = _BMatrix.Length;
        double[] xNew = new double[n];

        xNew[0] = 1 / _array[0, 0] * (_BMatrix[0] - (_array[0, 1] * xPrev[1] + _array[0, 2] * xPrev[2] + _array[0, 3] * xPrev[3]));

        
        xNew[1] = 1 / _array[1, 1] * (_BMatrix[1] - (_array[1, 0] * xPrev[0] + _array[1, 2] * xPrev[2] + _array[1, 3] * xPrev[3]));

        
        xNew[2] = 1 / _array[2, 2] * (_BMatrix[2] - (_array[2, 0] * xPrev[0] + _array[2, 1] * xPrev[1] + _array[2, 3] * xPrev[3]));

        
        xNew[3] = 1 / _array[3, 3] * (_BMatrix[3] - (_array[3, 0] * xPrev[0] + _array[3, 1] * xPrev[1] + _array[3, 2] * xPrev[2]));
        
        return xNew;
    }

    /**
     * function than calculate convergence
     * params: xPrev - x(n); xNext - x(n+1)
     * return: max value - max
     */
    private double Convergence(double[] xPrev, double[] xNext)
    {
        double max = 0;
        for (int i = 0; i < xPrev.Length; i++) 
        {
            double diff = Math.Abs(xNext[i] - xPrev[i]);
            if (diff > max)
            {
                max = diff;
            }
        }
        return max;
    }

    /**
     * Printing the matrix
     */
    private void PrintMatrix(double[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /**
     * Printing an intermediate X values
     */
    private void PrintIntermediateX(double[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + "\t");
        }

        Console.WriteLine();
    }

    
    /**
     * Usage of all methods in this class
     */
    public double[] CreateGaussSeidel()
    {
        Console.WriteLine("Creating Gauss Seidel for: ");
        PrintMatrix(_array);
        int n = _BMatrix.Length;
        double[] xPrev = new double[n];
        double[] xNext = new double[n];
        double maxDifference;
        int step = 0;
        
        for(int i = 0; i < n; i++)
        {
            xPrev[i] = 0;
        }

        do
        {
            Console.WriteLine("Iteration: " + step);
            xNext = GenerateX(xPrev);
            maxDifference = Convergence(xPrev, xNext);
            Console.WriteLine("max difference: " + maxDifference);

            for (int i = 0; i < n; i++) {
                xPrev[i] = xNext[i];
            }
            Console.WriteLine("previous:");
            PrintIntermediateX(xPrev);
            Console.WriteLine("next:");
            PrintIntermediateX(xNext);
            step++;
            Console.WriteLine("_____________________________________________________________________________");
        }while(maxDifference > _epsilon);

        Console.Write("Result:");
        PrintIntermediateX(xNext);
        return xNext;
    }




}