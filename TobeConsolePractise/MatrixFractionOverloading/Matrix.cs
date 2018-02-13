using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Matrix
    {
        private int _Row;
        public int Row
        {
            get { return _Row; }
            set { _Row = value; matrix = new double[Row, Column]; }
        }
        private int _Column;
        public int Column
        {
            get { return _Column; }
            set { _Column = value; matrix = new double[Row, Column]; }
        }
        public double[,] matrix { get; set; }

        public Matrix() : this(2, 2) { }
        public Matrix(int a, int b)
        {
            this.Row = a;
            this.Column = b;
            matrix = new double[Row, Column];
        }

        //fill matriRow with values
        public void fill()
        {
            Console.WriteLine("\r\nPlease fill the matriRow");
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    Console.Write("Enter the value of MatriRow[" + (i + 1) + "," + (j + 1) + "]: ");
                    double val;
                    string s = Console.ReadLine();
                    while (!double.TryParse(s, out val))
                    {
                        Console.Write("Please enter a valid number for MatriRow[" + (i + 1) + "," + (j + 1) + "]: ");
                        s = Console.ReadLine();
                    }
                    this.matrix[i, j] = val;
                }
            }
        }

        //overload operators
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Row != b.Row || a.Column != b.Column) { throw new Exception("Dimension mismatch"); }
            Matrix c = new Matrix(a.Row, a.Column);
            for (int i = 0; i < c.Row; i++)
            {
                for (int j = 0; j < c.Column; j++)
                {
                    c.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }
            return c;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Row != b.Row || a.Column != b.Column) { throw new Exception("Dimension mismatch"); }
            Matrix c = new Matrix(a.Row, a.Column);
            for (int i = 0; i < c.Row; i++)
            {
                for (int j = 0; j < c.Column; j++)
                {
                    c.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }
            return c;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Column != b.Row) throw new Exception("Dimension mismatch");
            Matrix c = new Matrix(a.Row, b.Column);
            for (int i = 0; i < c.Row; i++)
            {
                for (int j = 0; j < c.Column; j++)
                {
                    c.matrix[i, j] = 0;
                    for (int k = 0; k < b.Row; k++)
                    {
                        c.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];
                    }
                }
            }
            return c;
        }

        public static double determinant2(Matrix a)
        {
            if (a.Column != 2 && a.Row != 2) throw new Exception("Not a 2 X 2 matrix");
            double d = a.matrix[0, 0] * a.matrix[1, 1] - a.matrix[0, 1] * a.matrix[1, 0];
            return d;
        }

        public static double determinant3(Matrix a)
        {
            if (a.Column != 3 && a.Row != 3) throw new Exception("Not a 3 X 3 matrix");
            Matrix m = new Matrix();
            Matrix n = new Matrix();
            Matrix o = new Matrix();
            m.matrix[0, 0] = a.matrix[1, 1]; m.matrix[0, 1] = a.matrix[1, 2];
            m.matrix[1, 0] = a.matrix[2, 1]; m.matrix[1, 1] = a.matrix[2, 2];
            n.matrix[0, 0] = a.matrix[1, 0]; n.matrix[0, 1] = a.matrix[1, 2];
            n.matrix[1, 0] = a.matrix[2, 0]; n.matrix[1, 1] = a.matrix[2, 2];
            o.matrix[0, 0] = a.matrix[1, 0]; o.matrix[0, 1] = a.matrix[1, 1];
            o.matrix[1, 0] = a.matrix[2, 0]; o.matrix[1, 1] = a.matrix[2, 1];
            double d = a.matrix[0, 0] * determinant2(m) - a.matrix[0, 1] * determinant2(n) + a.matrix[0, 2] * determinant2(o);
            return d;
        }

        public static Matrix inverse2(Matrix a)
        {
            if (a.Column != 2 && a.Row != 2) throw new Exception("Not a 2 X 2 matrix");
            if (determinant2(a) == 0) throw new Exception("No unique solution");
            Matrix b = new Matrix(a.Row, a.Column);
            b.matrix[0, 0] = a.matrix[1, 1] / determinant2(a); b.matrix[0, 1] = -a.matrix[0, 1] / determinant2(a);
            b.matrix[1, 0] = -a.matrix[1, 0] / determinant2(a); b.matrix[1, 1] = a.matrix[0, 0] / determinant2(a);
            return b;
        }

        public static Matrix inverse3(Matrix a)
        {
            if (a.Column != 3 && a.Row != 3) throw new Exception("Not a 3 X 3 matrix");
            if (determinant3(a) == 0) throw new Exception("No unique solution");
            Matrix b = new Matrix(a.Row, a.Column);
            b.matrix[0, 0] = (a.matrix[1, 1] * a.matrix[2, 2] - a.matrix[1, 2] * a.matrix[2, 1]) / determinant3(a);
            b.matrix[0, 1] = (a.matrix[0, 2] * a.matrix[2, 1] - a.matrix[0, 1] * a.matrix[2, 2]) / determinant3(a);
            b.matrix[0, 2] = (a.matrix[0, 1] * a.matrix[1, 2] - a.matrix[0, 2] * a.matrix[1, 1]) / determinant3(a);
            b.matrix[1, 0] = (a.matrix[1, 2] * a.matrix[2, 0] - a.matrix[1, 0] * a.matrix[2, 2]) / determinant3(a);
            b.matrix[1, 1] = (a.matrix[0, 0] * a.matrix[2, 2] - a.matrix[0, 2] * a.matrix[2, 0]) / determinant3(a);
            b.matrix[1, 2] = (a.matrix[0, 2] * a.matrix[1, 0] - a.matrix[0, 0] * a.matrix[1, 2]) / determinant3(a);
            b.matrix[2, 0] = (a.matrix[1, 0] * a.matrix[2, 1] - a.matrix[1, 1] * a.matrix[2, 0]) / determinant3(a);
            b.matrix[2, 1] = (a.matrix[0, 1] * a.matrix[2, 0] - a.matrix[0, 0] * a.matrix[2, 1]) / determinant3(a);
            b.matrix[2, 2] = (a.matrix[0, 0] * a.matrix[1, 1] - a.matrix[0, 1] * a.matrix[1, 0]) / determinant3(a);
            return b;
        }

        public static Matrix simulFill(int a)
        {
            Matrix b = new Matrix(a, a + 1);
            if (a == 2 || a == 3)
            {
                if (a == 2) Console.WriteLine("\r\nEnter the values (In the form aX + bY = c)!");
                else Console.WriteLine("\r\nEnter the values (In the form aX + bY + cZ = c)!");
                for (int i = 0; i < a; i++)
                {
                    Console.Write("\r\nEnter the co-efficient of X: ");
                    b.matrix[i, 0] = CheckClass.checkDouble(Console.ReadLine());
                    Console.Write("Enter the co-efficient of y: ");
                    b.matrix[i, 1] = CheckClass.checkDouble(Console.ReadLine());
                    if (a == 3) { Console.Write("Enter the co-efficient of Z: "); b.matrix[i, 2] = CheckClass.checkDouble(Console.ReadLine()); }
                    Console.Write("Enter the constant term: ");
                    if (a == 2) b.matrix[i, 2] = CheckClass.checkDouble(Console.ReadLine());
                    else b.matrix[i, 3] = CheckClass.checkDouble(Console.ReadLine()); ;
                }
            }
            else Console.WriteLine("\r\nWrong dimension. Only for 2 or 3 unknowns!\r\n");
            return b;
        }

        public static Matrix simul2(Matrix a)
        {
            if (a.Column - 1 != a.Row) throw new Exception("Wrong input format");
            Matrix b = new Matrix(a.Row, a.Row);
            for (int i = 0; i < b.Row; i++)
            {
                for (int j = 0; j < b.Column; j++)
                {
                    b.matrix[i, j] = a.matrix[i, j];
                }
            }
            Matrix c = new Matrix(a.Row, 1);
            for (int i = 0; i < c.Row; i++)
            {
                c.matrix[i, 0] = a.matrix[i, a.Column - 1];
            }
            Matrix d = new Matrix(2, 1);
            d = inverse2(b) * c;
            return d;
        }

        public static Matrix simul3(Matrix a)
        {
            if (a.Column - 1 != a.Row) throw new Exception("Wrong input format");
            Matrix b = new Matrix(a.Row, a.Row);
            for (int i = 0; i < b.Row; i++)
            {
                for (int j = 0; j < b.Column; j++)
                {
                    b.matrix[i, j] = a.matrix[i, j];
                }
            }
            Matrix c = new Matrix(a.Row, 1);
            for (int i = 0; i < c.Row; i++)
            {
                c.matrix[i, 0] = a.matrix[i, a.Column - 1];
            }
            Matrix d = new Matrix(3, 1);
            d = inverse3(b) * c;
            return d;
        }

        public override string ToString()
        {
            string s = "\r\n";
            for (int i = 0; i < this.Row; i++)
            {
                s += "{ ";
                for (int j = 0; j < this.Column; j++)
                {
                    s += this.matrix[i, j] + ", ";
                }
                s = s.Remove(s.Length - 2);
                s += " }\r\n";
            }
            return s;
        }

        public static void run()
        {
        //    Console.WriteLine("A program to multiply two matrices \r\n");
        //    Console.WriteLine("\r\nFirst MatriRow\r\n");
        //    Matrix a = new Matrix();
        //    Console.Write("Enter the Row-dimension: ");
        //    a.Row = CheckClass.checkInt(Console.ReadLine());
        //    Console.Write("Enter the Column-dimension: ");
        //    a.Column = CheckClass.checkInt(Console.ReadLine());
        //    a.fill();
        //    Console.WriteLine("\r\nSecond MatriRow\r\n");
        //    Matrix b = new Matrix();
        //    Console.Write("Enter the Row-dimension: ");
        //    b.Row = CheckClass.checkInt(Console.ReadLine());
        //    Console.Write("Enter the Column-dimension: ");
        //    b.Column = CheckClass.checkInt(Console.ReadLine());
        //    b.fill();
        //    //MatriRow c = new MatriRow();
        //    Matrix c = a * b;
        //    Console.WriteLine("");
        //    Console.WriteLine("The first matriRow is: " + a);
        //    Console.WriteLine("The second matriRow is: " + b);
        //    Console.WriteLine("Their product is: " + c);
        //    Console.ReadKey();
            Console.WriteLine("A program to solve simultaneous equations!");
            string cont = "y";
            while (cont.ToUpper() == "Y" || cont.ToUpper() == "YES")
            {
                Console.Write("\r\nHow many variables/unknowns: ");
                int var = CheckClass.checkInt(Console.ReadLine());
                if (var == 2 || var == 3)
                {
                    try
                    {
                        Matrix simul = Matrix.simulFill(var);
                        Matrix ans;
                        if (var == 2) { ans = Matrix.simul2(simul); Console.Write("\r\nValue of X and Y is: {0, 30}", ans); }
                        else { ans = Matrix.simul3(simul); Console.Write("\r\nValue of X and Y is: {0, 30}", ans); }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\r\nError: " + ex.Message);
                        Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    }
                }
                else Console.WriteLine("Wrong variable input. Can resolve 2 or 3 variables/unknowns");
                Console.Write("\r\nDo you wish to continue? Enter 'y' for yes and 'n' for no: ");
                cont = Console.ReadLine();
            }
            Console.WriteLine("\r\nTHE END!    Press any key to exit.");
            Console.ReadKey();
        }
    }

    class MatrixSlow
    {
        private int _Row;
        private int _Column;
        public double[,] InnerMatrix { get; set; }

        private MatrixSlow() { }
        public static MatrixSlow Create(int a, int b)
        {
            MatrixSlow m = new MatrixSlow();

            m._Row = a;
            m._Column = b;
            m.InnerMatrix = new double[a, b];

            return m;
        }
        public static MatrixSlow CreateWithArray(double[,] arr)
        {
            MatrixSlow m = new MatrixSlow();

            m._Row = arr.GetUpperBound(0) + 1;
            m._Column = arr.GetUpperBound(1) + 1;
            m.InnerMatrix = arr;

            return m;
        }

        public static MatrixSlow operator *(MatrixSlow a, MatrixSlow b)
        {
            if (a._Column != b._Row) throw new Exception("Dimension mismatch");

            MatrixSlow c = MatrixSlow.Create(a._Row, b._Column);

            for (int i = 0; i < c._Row; i++)
            {
                for (int j = 0; j < c._Column; j++)
                {
                    c.InnerMatrix[i, j] = 0;
                    for (int k = 0; k < b._Row; k++)
                        c.InnerMatrix[i, j] += a.InnerMatrix[i, k] * b.InnerMatrix[k, j];
                }
            }

            return c;
        }

        public MatrixSlow Transpose()
        {
            double[,] transpose = new double[_Column, _Row];

            for (int i = 0; i < _Row; i++)
                for (int j = 0; j < _Column; j++)
                    transpose[j, i] = InnerMatrix[i, j];

            return MatrixSlow.CreateWithArray(transpose);
        }

        // Function to calculate and store inverse, returns false if  Matrix is singular
        public MatrixSlow Inverse()
        {
            int N = InnerMatrix.GetUpperBound(0) + 1;
            double[,] inverse = new double[N, N];

            // Find determinant of A[][]
            double det = Determinant(InnerMatrix, N);

            if (det == 0) throw new Exception("Singular Matrix, can't find its inverse");

            // Find adjoint
            double[,] adj = Adjoint(InnerMatrix);

            // Find Inverse using formula "inverse(A) = adj(A)/det(A)"
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    inverse[i, j] = adj[i, j] / det;

            return MatrixSlow.CreateWithArray(inverse);
        }

        /* Recursive function for finding determinant of Matrix.n is current dimension of A[][]. */
        public double Determinant(double[,] A, int n)
        {
            double D = 0; // Initialize result

            //  Base case : if Matrix contains single element
            if (n == 1)
                return A[0, 0];

            double[,] temp; // To store cofactors

            int sign = 1;  // To store sign multiplier

            // Iterate for each element of first row
            for (int f = 0; f < n; f++)
            {
                // Getting Cofactor of A[0][f]
                temp = GetCofactor(A, 0, f);
                D += sign * A[0, f] * Determinant(temp, n - 1);

                // terms are to be added with alternate sign
                sign = -sign;
            }

            return D;
        }

        // Function to get cofactor of A[p][q] in temp[][]. n is current dimension of A[][]
        public double[,] GetCofactor(double[,] A, int p, int q)
        {
            int i = 0, j = 0, n = A.GetUpperBound(0) + 1;
            double[,] temp = new double[n, n];

            // Looping for each element of the Matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    //  Copying into temporary Matrix only those element which are not in given row and column
                    if (row != p && col != q)
                    {
                        temp[i, j++] = A[row, col];

                        // Row is filled, so increase row index and reset col index
                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }

            return temp;
        }

        // Function to get adjoint of A[N][N] in adj[N][N].
        public double[,] Adjoint(double[,] A)
        {
            int N = A.GetUpperBound(0) + 1;
            double[,] adj = new double[N, N];

            if (N == 1)
            {
                adj[0, 0] = 1;
                return adj;
            }

            // temp is used to store cofactors of A[][]
            int sign = 1;
            double[,] temp = new double[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // Get cofactor of A[i][j]
                    temp = GetCofactor(A, i, j);

                    // sign of adj[j][i] positive if sum of row and column indexes is even.
                    sign = ((i + j) % 2 == 0) ? 1 : -1;

                    // Interchanging rows and columns to get the transpose of the cofactor Matrix
                    adj[j, i] = (sign) * (Determinant(temp, N - 1));
                }
            }

            return adj;
        }
    }
}
