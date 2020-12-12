using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Write a C# program to obtain the determinant of a matrix of the form => int[,,,] = new [1,1,4,4].
// Using the data structure above, generate the result of the above squared and return the array

namespace MatricesWithArrays
{
    public class Program
    {
        public static int rows;
        public static int columns;
        public static int[,] tbt;
        public static int[,] twdMatrix = new int[rows, columns];
        public static int[,,,] fdMatrix = new int[1, 1, 4, 4];
        public static Random random = new Random();
        public static int i, j, k, l;

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This is a program that generates a Matrix and then determines the determinants and square!");
                Console.WriteLine("Select your preferred Matrix");
                Console.WriteLine("(1) 2D Matrix (2) 4D Matrix(DEMO)");
                int matrix = int.Parse(Console.ReadLine());
                if (matrix == 1)
                {
                    Console.WriteLine("2D Matrix Selected!");
                    Console.WriteLine("Enter Dimensions for 2D square matrix( Not more than 4. i.e 2x2, 3x3, 4x4 )");
                    Matrix2DGen();
                }
                else if (matrix == 2)
                {
                    Console.WriteLine("4D Matrix Selected!");
                    Console.WriteLine("Generating and Populating Matrix with random elements...");
                    Display4DMatrixGen(fdMatrix);
                    Matrix4DDeterminant(fdMatrix);
                }
                else
                {
                    Console.WriteLine("Wrong Input Entered!");
                    Console.WriteLine("Enter Valid Input");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void Display4DMatrixGen(int[,,,] array)//Generates a 4 Dimensional Matrix of dimensions [1,1,4,4], with it's elements randomly generated.
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine("[");
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine(" {");
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            fdMatrix[i, j, k, l] = random.Next(0, 20);   //Randomly generates elements in the matrix
                            Console.Write($"  { fdMatrix[i, j, k, l] }");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine(" }");
                }
                Console.WriteLine("]\n");
            }

        }

        public static void Matrix2DGen()//Generates a 2 Dimensional Square Matrix
        {
            try
            {
                Console.WriteLine("Enter number of Rows: ");//Collects Users' preferred square matrix demensions
                rows = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of Columns: ");
                columns = int.Parse(Console.ReadLine());

                if (rows == 1 && columns == 1 || rows > 4 && columns > 4)
                {
                    Console.WriteLine("Invalid Dimensions Selected");
                    Console.WriteLine("Dimensions entered do not match required input!");
                    return;
                }
                else if (rows == columns && rows != 1 && columns != 1)
                {
                    Console.WriteLine("Valid Dimensions Selected");
                    Console.WriteLine("Generating and Populating Matrix with random elements...");
                }
                else
                {
                    Console.WriteLine("Invalid Dimensions Selected");
                    Console.WriteLine("Dimensions entered do not match required input!");
                    return;
                }
                
                twdMatrix = new int[rows, columns];
                for (var i = 0; i < rows; i++)
                {
                    Console.WriteLine("{");
                    for (var j = 0; j < columns; j++)
                    {

                        twdMatrix[i, j] = random.Next(0, 20);
                        Console.Write($"  { twdMatrix[i, j] }");
                    }
                    Console.WriteLine(" }");
                }
                if (rows == 2 && columns == 2)
                {
                    tbt = Matrix2x2Determinant(twdMatrix);
                }
                else if (rows == 3 && columns == 3)
                {
                    tbt = Matrix3x3Determinant(twdMatrix);
                }
                else if (rows == 4 && columns == 4)
                {
                    tbt = Matrix3x3Determinant(twdMatrix);
                }
                else
                {
                    Console.WriteLine("Dimensions entered do not match required input!");
                }

            }
            catch (Exception q)
            {
                Console.WriteLine(q.Message);
            }

        }

        //Matrix Determinants
        public static void Matrix4DDeterminant(int[,,,] array)//4D Matrix Determinant method
        {
            var determinant = +fdMatrix[0, 0, 0, 0] * (fdMatrix[0, 0, 1, 1] * fdMatrix[0, 0, 2, 2] * fdMatrix[0, 0, 3, 3] - fdMatrix[0, 0, 1, 3] * fdMatrix[0, 0, 2, 2] * fdMatrix[0, 0, 3, 1])
            - fdMatrix[0, 0, 0, 1] * (fdMatrix[0, 0, 1, 0] * fdMatrix[0, 0, 2, 2] * fdMatrix[0, 0, 3, 3] - fdMatrix[0, 0, 1, 3] * fdMatrix[0, 0, 2, 2] * fdMatrix[0, 0, 3, 0])
            + fdMatrix[0, 0, 0, 2] * (fdMatrix[0, 0, 1, 0] * fdMatrix[0, 0, 2, 1] * fdMatrix[0, 0, 3, 3] - fdMatrix[0, 0, 1, 3] * fdMatrix[0, 0, 2, 1] * fdMatrix[0, 0, 3, 1])
            - fdMatrix[0, 0, 0, 3] * (fdMatrix[0, 0, 1, 0] * fdMatrix[0, 0, 2, 1] * fdMatrix[0, 0, 3, 2] - fdMatrix[0, 0, 1, 2] * fdMatrix[0, 0, 2, 1] * fdMatrix[0, 0, 3, 0]);

            Console.WriteLine($"The determinant of the matrix is {determinant}");

        }

        public static int[,] Matrix2x2Determinant(int[,] array)//2D (2x2) Matrix Determinant method
        {
            var determinant = (twdMatrix[0, 0] * twdMatrix[1, 1] - twdMatrix[0, 0] * twdMatrix[0, 1] * twdMatrix[1, 0]);

            Console.WriteLine($"The determinant of the matrix is {determinant}");
            return array;

        }

        public static int[,] Matrix3x3Determinant(int[,] array)//2D (3x3) Matrix Determinant method
        {
            var determinant = +twdMatrix[0, 0] * (twdMatrix[1, 1] * twdMatrix[2, 2] - twdMatrix[1, 2] * twdMatrix[2, 1])
                              - twdMatrix[0, 1] * (twdMatrix[1, 0] * twdMatrix[2, 2] - twdMatrix[1, 2] * twdMatrix[2, 0])
                              + twdMatrix[0, 2] * (twdMatrix[1, 0] * twdMatrix[2, 1] - twdMatrix[1, 1] * twdMatrix[2, 0]);

            Console.WriteLine($"The determinant of the matrix is {determinant}");
            return array;

        }

        public static int[,] Matrix4x4Determinant(int[,] array)//2D (4x4) Matrix Determinant method
        {
            var determinant = +twdMatrix[0, 0] * (twdMatrix[1, 1] * twdMatrix[2, 2] * twdMatrix[3, 3] - twdMatrix[1, 3] * twdMatrix[2, 2] * twdMatrix[3, 1])
            - twdMatrix[0, 1] * (twdMatrix[1, 0] * twdMatrix[2, 2] * twdMatrix[3, 3] - twdMatrix[1, 3] * twdMatrix[2, 2] * twdMatrix[3, 0])
            + twdMatrix[0, 2] * (twdMatrix[1, 0] * twdMatrix[2, 1] * twdMatrix[3, 3] - twdMatrix[1, 3] * twdMatrix[2, 1] * twdMatrix[3, 1])
            - twdMatrix[0, 3] * (twdMatrix[1, 0] * twdMatrix[2, 1] * twdMatrix[3, 2] - twdMatrix[1, 2] * twdMatrix[2, 1] * twdMatrix[3, 0]);

            Console.WriteLine($"The determinant of the matrix is {determinant}");
            return array;

        }


    }
}
        
