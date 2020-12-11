using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Write a C# program to obtain the determinant of a matrix of the form => int[,,,] = new [1,1,4,4].
// Using the data structure above, generate the result of the above squared and return the array

namespace Arrays
{
    public class Program
    {
        public static int rows;
        public static int columns;
        public static int[,] twdMatrix = new int[rows, columns];
        public static int[,,,] fdMatrix = new int[1, 1, 4, 4];
        public static int[,,,] storedArray;
        public static System.Random random = new System.Random();
        public static int i, j, k, l;

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This is a program that generates a Matrix and then determines the determinants and square!");
                Console.WriteLine("Select your preferred Matrix");
                Console.WriteLine("(1) 2D Matrix (2) 4D Matrix.");
                int matrix = int.Parse(Console.ReadLine());
                if (matrix == 1)
                {
                    Console.WriteLine("2D Matrix Selected!");
                    Console.WriteLine("Enter Dimensions for 2D square matrix( eg. 2x2, 3x3, 4x4 etc )");
                    Matrix2DGen();
                }
            
                else if (matrix == 2)
                {
                    Console.WriteLine("4D Matrix Selected!");
                    Display4DMatrixGen(fdMatrix);
                }
                else
                {
                    Console.WriteLine("Wrong Input Entered!");
                    Console.WriteLine("Enter Valid Input");
                }
                MatrixDeterminant(fdMatrix);



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        public static int[,,,] RandomElementGen(int[,,,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            fdMatrix[i, j, k, l] = random.Next(0, 9);
                        }

                    }
                }
            }
            return array;
        }

        public static void Display4DMatrixGen(int[,,,] array)//Generates a 4 Dimensional Matrix of dimensions [1,1,4,4], with it's elements randomly generated.
        {
            RandomElementGen(fdMatrix);
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
                            //fdMatrix[i, j, k, l] = random.Next(0, 20);   //Randomly generates elements in the matrix
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
                if (rows == columns)
                {
                    Console.WriteLine("Valid Dimensions Selected");
                }
                else
                {
                    Console.WriteLine("Invalid Dimensions Selected");
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
            }
            catch (Exception q)
            {
                Console.WriteLine(q.Message);
            }
        }

        private static void MatrixSquared(int[,,,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            var entry = fdMatrix[i, j, k, l];
                            var squaredEntry = (int)Math.Pow(entry, 2);
                            fdMatrix[i, j, k, l] = squaredEntry;
                        }
                    }
                }
            }
        }

        private static void MatrixDeterminant(int[,,,] array)
        {
            var determinant = 0;
            for (var i = 0; i < columns; i++)
                {
                    determinant += fdMatrix[0,0,0,i] * (fdMatrix[1, 0, 0,(i + 1) % columns] * fdMatrix[2,0,0, (i + 2) % columns] -
                                                     fdMatrix[1,0,0,(i + 2) % columns] * fdMatrix[2,0,0, (i + 1) % columns]);
                }
            
            Console.WriteLine($"The determinant of the 3x3 matrix is {determinant}.");
        }






        //ABANDONED CODE!!!!
        //public static int[,,] tdmatrix = new int[row1, rows, columns];

        /*public static void Matrix3DGen()
        {
            Console.WriteLine("Enter number of Row1: ");
            row1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of Rows: ");
            rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of Columns: ");
            columns = int.Parse(Console.ReadLine());
            if (row1 == rows && row1 == columns)
            {
                Console.WriteLine("Valid Dimensions Selected");
            }
            else
            {
                Console.WriteLine("Invalid Dimensions Selected");
            }
            tdmatrix = new int[row1, rows, columns];
            for (var i = 0; i < row1; i++)
            {
                Console.WriteLine("{");
                for (var j = 0; j < rows; j++)
                {
                    //Console.WriteLine("}");
                    for(var k = 0; k < columns; k++)
                    {
                        tdmatrix[i, j, k] = random.Next(0, 9);
                        Console.Write($"  { tdmatrix[i, j, k] }");
                    }
                }
                Console.WriteLine(" }");

            }


        }*/

        //Console.WriteLine($"This is a program that generates a randomized 4D matrix of dimensions [1,1,4,4] and then determines the determinant ");
        //Console.WriteLine("Press Enter Key to get started!");
        //var start = Console.ReadLine();
        //Console.WriteLine("Random Generated Matrix");
        //Matrix2D(twdmatrix);



    }



}
        
