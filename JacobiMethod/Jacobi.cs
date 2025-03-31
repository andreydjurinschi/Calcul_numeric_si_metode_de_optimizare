namespace JacobiMethod;

public class Jacobi
{
    private double[,] _array;
    private double[] _B_array;
    private readonly double _epsilon = Math.Pow(10, -3);

    public Jacobi(double[,] array,  double[]  b_array)
    {
        this._array = array;
        this._B_array = b_array;
    }

    private double[] GenerateX(double[] xPrev)
    {
        int n = _B_array.Length;
        double[] xNew = new double[n];
        
        xNew[0] = (_B_array[0] - _array[0,1] * xPrev[1] - _array[0,2] * xPrev[2] - _array[0,3] * xPrev[3]) / _array[0,0];
        xNew[1] = (_B_array[1] - _array[1,0] * xPrev[0] - _array[1,2] * xPrev[2] - _array[1,3] * xPrev[3]) / _array[1,1];
        xNew[2] = (_B_array[2] - _array[2,0] * xPrev[0] - _array[2,1] * xPrev[1] - _array[2,3] * xPrev[3]) / _array[2,2];
        xNew[3] = (_B_array[3] - _array[3,0] * xPrev[0] - _array[3,1] * xPrev[1] - _array[3,2] * xPrev[2]) / _array[3,3];
        return xNew;
    }
    
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
    
    private void PrintIntermediateX(double[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + "\t");
        }

        Console.WriteLine();
    }
    
    public double[] CreateJacobi()
    {
        Console.WriteLine("Creating Jacobi for: ");
        PrintMatrix(_array);
        int n = _B_array.Length;
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