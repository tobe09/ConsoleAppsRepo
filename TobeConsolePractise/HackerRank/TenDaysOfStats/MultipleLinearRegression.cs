using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class MultipleLinearRegression
    {
        public static void Run()
        {
            //Test();
            //Check();
            
            int[] values = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int m = values[0], n = values[1];

            double[][] X = new double[n][];
            for (int i = 0; i < n; i++)
                X[i] = new double[m + 1];

            double[][] Y = new double[n][];
            for (int i = 0; i < n; i++)
                Y[i] = new double[1];

            for (int i = 0; i < n; i++)
            {
                double[] vals = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
                X[i][0] = 1;
                for (int j = 0; j < m; j++)
                {
                    X[i][j + 1] = vals[j];
                }
                Y[i][0] = vals[m];
            }

            Matrix yMat = Matrix.CreateWithArray(Y);
            Matrix xMat = Matrix.CreateWithArray(X);
            Matrix step1 = xMat.Transpose() * xMat;
            Matrix step2 = step1.Inverse();
            Matrix step3 = step2 * xMat.Transpose();
            Matrix B = step3 * yMat;

            int iterations = int.Parse(Console.ReadLine());
            for (int i = 0; i < iterations; i++)
            {
                double[] vals = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
                double[][] multiplier = new double[1][];
                multiplier[0] = new double[m + 1];
                multiplier[0][0] = 1;

                for (int j = 0; j < m; j++)
                    multiplier[0][j + 1] = vals[j];
                Matrix multMat = Matrix.CreateWithArray(multiplier);

                double y = (multMat * B).InnerMatrix[0][0];
                y = Math.Round(y, 2, MidpointRounding.AwayFromZero);

                Console.WriteLine(y);
            }

            Console.ReadKey();
        }

        static void Test()
        {
            double[] a0 = { 4, 7 }, a1 = { 2, 6 };
            double[][] a = new double[2][];
            a[0] = a0;
            a[1] = a1;

            Matrix inv = Matrix.CreateWithArray(a).Inverse();  //{ {0.6, -0.7}, {-0.2, 0.4} }
        }

        static void Check()
        {
            dynamic a = new double[3, 4];
            Console.WriteLine(a.Length);
            //Console.WriteLine(a[0].Length);           //does not exist due to array structure
            Console.WriteLine(a.GetLowerBound(0));
            Console.WriteLine(a.GetLowerBound(1));
            Console.WriteLine(a.GetUpperBound(0));
            Console.WriteLine(a.GetUpperBound(1));
            Console.WriteLine();
            dynamic b = new double[3, 4];
            Console.WriteLine(b.Length);
            //Console.WriteLine(b[0].Length);
            Console.WriteLine(b.GetLowerBound(0));
            Console.WriteLine(b.GetLowerBound(1));
            Console.WriteLine(b.GetUpperBound(0));
            Console.WriteLine(b.GetUpperBound(1));
            Console.WriteLine();
            Console.WriteLine();

            a = new double[3][];
            Console.WriteLine(a.Length);
            //Console.WriteLine(a[0].Length);           //has not been assignedd
            Console.WriteLine(a.GetLowerBound(0));
            //Console.WriteLine(a.GetLowerBound(1));  //only one dimension
            Console.WriteLine(a.GetUpperBound(0));
            //Console.WriteLine(a.GetUpperBound(1) + 1);
            Console.WriteLine();
            b = new double[3][];
            for (int i = 0; i < 1; i++)
                b[i] = new double[4];
            Console.WriteLine(b.Length);
            Console.WriteLine(b[0].Length);
            Console.WriteLine(b.GetLowerBound(0));
            Console.WriteLine(b.GetUpperBound(0));
        }


        class Matrix
        {
            private int _Row;
            private int _Column;
            public double[][] InnerMatrix { get; set; }

            private Matrix() { }

            public static Matrix Create(int row, int col)
            {
                Matrix m = new Matrix();

                m._Row = row;
                m._Column = col;

                m.InnerMatrix = new double[row][];
                for (int i = 0; i < row; ++i)
                    m.InnerMatrix[i] = new double[col];

                return m;
            }

            public static Matrix CreateWithArray(double[][] arr)
            {
                Matrix m = new Matrix();

                m._Row = arr.Length;
                m._Column = arr[0].Length;
                m.InnerMatrix = arr;

                return m;
            }

            public static Matrix operator *(Matrix a, Matrix b)
            {
                if (a._Column != b._Row) throw new Exception("Dimension mismatch");

                Matrix c = Create(a._Row, b._Column);

                for (int i = 0; i < c._Row; i++)
                {
                    for (int j = 0; j < c._Column; j++)
                    {
                        c.InnerMatrix[i][j] = 0;
                        for (int k = 0; k < b._Row; k++)        //can use a._Col
                            c.InnerMatrix[i][j] += a.InnerMatrix[i][k] * b.InnerMatrix[k][j];
                    }
                }

                return c;
            }

            public Matrix Transpose()
            {
                double[][] transpose = new double[_Column][];
                for (int i = 0; i < _Column; i++)
                    transpose[i] = new double[_Row];

                for (int i = 0; i < _Row; i++)
                    for (int j = 0; j < _Column; j++)
                        transpose[j][i] = InnerMatrix[i][j];

                return CreateWithArray(transpose);
            }

            public Matrix Inverse()
            {
                double[][] matrix = InnerMatrix;

                int n = matrix.Length;
                double[][] result = MatrixClone(matrix);

                int[] perm;
                int toggle;
                double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
                if (lum == null)
                    throw new Exception("Unable to compute inverse");

                double[] b = new double[n];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (i == perm[j])
                            b[j] = 1.0;
                        else
                            b[j] = 0.0;
                    }

                    double[] x = HelperSolve(lum, b); // 

                    for (int j = 0; j < n; ++j)
                        result[j][i] = x[j];
                }

                return CreateWithArray(result);
            }

            public static double[][] MatrixClone(double[][] matrix)
            {
                // allocates/creates a duplicate of a matrix.
                double[][] result = new double[matrix.Length][];

                for (int i = 0; i < matrix.Length; ++i) // copy the values
                {
                    result[i] = new double[matrix[i].Length];
                    for (int j = 0; j < matrix[i].Length; ++j)
                        result[i][j] = matrix[i][j];
                }

                return result;
            }

            static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
            {
                // Doolittle LUP decomposition with partial pivoting.
                // rerturns: result is L (with 1s on diagonal) and U;
                // perm holds row permutations; toggle is +1 or -1 (even or odd)
                int rows = matrix.Length;
                int cols = matrix[0].Length; // assume square
                if (rows != cols)
                    throw new Exception("Attempt to decompose a non-square m");

                int n = rows; // convenience

                double[][] result = MatrixClone(matrix);

                perm = new int[n]; // set up row permutation result
                for (int i = 0; i < n; ++i) { perm[i] = i; }

                toggle = 1; // toggle tracks row swaps.
                // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

                for (int j = 0; j < n - 1; ++j) // each column
                {
                    double colMax = Math.Abs(result[j][j]); // find largest val in col
                    int pRow = j;
                    //for (int i = j + 1; i < n; ++i)
                    //{
                    //  if (result[i][j] greater-than colMax)
                    //  {
                    //    colMax = result[i][j];
                    //    pRow = i;
                    //  }
                    //}

                    // reader Matt V needed this:
                    for (int i = j + 1; i < n; ++i)
                    {
                        if (Math.Abs(result[i][j]) > colMax)
                        {
                            colMax = Math.Abs(result[i][j]);
                            pRow = i;
                        }
                    }
                    // Not sure if this approach is needed always, or not.

                    if (pRow != j) // if largest value not on pivot, swap rows
                    {
                        double[] rowPtr = result[pRow];
                        result[pRow] = result[j];
                        result[j] = rowPtr;

                        int tmp = perm[pRow]; // and swap perm info
                        perm[pRow] = perm[j];
                        perm[j] = tmp;

                        toggle = -toggle; // adjust the row-swap toggle
                    }

                    // --------------------------------------------------
                    // This part added later (not in original)
                    // and replaces the 'return null' below.
                    // if there is a 0 on the diagonal, find a good row
                    // from i = j+1 down that doesn't have
                    // a 0 in column j, and swap that good row with row j
                    // --------------------------------------------------

                    if (result[j][j] == 0.0)
                    {
                        // find a good row to swap
                        int goodRow = -1;
                        for (int row = j + 1; row < n; ++row)
                        {
                            if (result[row][j] != 0.0)
                                goodRow = row;
                        }

                        if (goodRow == -1)
                            throw new Exception("Cannot use Doolittle's method");

                        // swap rows so 0.0 no longer on diagonal
                        double[] rowPtr = result[goodRow];
                        result[goodRow] = result[j];
                        result[j] = rowPtr;

                        int tmp = perm[goodRow]; // and swap perm info
                        perm[goodRow] = perm[j];
                        perm[j] = tmp;

                        toggle = -toggle; // adjust the row-swap toggle
                    }
                    // --------------------------------------------------
                    // if diagonal after swap is zero . .
                    //if (Math.Abs(result[j][j]) < 1.0E-20) 
                    //  return null; // consider a throw

                    for (int i = j + 1; i < n; ++i)
                    {
                        result[i][j] /= result[j][j];
                        for (int k = j + 1; k < n; ++k)
                        {
                            result[i][k] -= result[i][j] * result[j][k];
                        }
                    }


                } // main j column loop

                return result;
            } // MatrixDecompose

            static double[] HelperSolve(double[][] luMatrix, double[] b)
            {
                // before calling this helper, permute b using the perm array
                // from MatrixDecompose that generated luMatrix
                int n = luMatrix.Length;
                double[] x = new double[n];
                b.CopyTo(x, 0);

                for (int i = 1; i < n; ++i)
                {
                    double sum = x[i];
                    for (int j = 0; j < i; ++j)
                        sum -= luMatrix[i][j] * x[j];
                    x[i] = sum;
                }

                x[n - 1] /= luMatrix[n - 1][n - 1];
                for (int i = n - 2; i >= 0; --i)
                {
                    double sum = x[i];
                    for (int j = i + 1; j < n; ++j)
                        sum -= luMatrix[i][j] * x[j];
                    x[i] = sum / luMatrix[i][i];
                }

                return x;
            }
        }
    }
}