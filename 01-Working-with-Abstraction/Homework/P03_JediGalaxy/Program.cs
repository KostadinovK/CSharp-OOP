using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimensions[0];
            int y = dimensions[1];

            int[,] matrix = new int[x, y];

            FillMatrixWithStars(ref matrix,x,y);
            
            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int xE = evil[0];
                int yE = evil[1];

                while (xE >= 0 && yE >= 0)
                {
                    if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                    {
                        matrix[xE, yE] = 0;
                    }
                    xE--;
                    yE--;
                }

                int xI = ivoS[0];
                int yI = ivoS[1];

                while (xI >= 0 && yI < matrix.GetLength(1))
                {
                    if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                    {
                        sum += matrix[xI, yI];
                    }

                    yI++;
                    xI--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static void FillMatrixWithStars(ref int[,] matrix, int rows, int cols)
        {
            int value = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = value++;
                }
            }

        }
    }
}
