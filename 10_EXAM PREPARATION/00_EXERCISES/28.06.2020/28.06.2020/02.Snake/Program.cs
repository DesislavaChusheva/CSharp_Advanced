using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];

            int snakeRow = 0;
            int snakeCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = currRow[col];
                    if (territory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            int foodEaten = 0;
            bool lost = false;

            while (foodEaten < 10)
            {
                string movement = Console.ReadLine();
                int nextRow = MoveRow(snakeRow, movement);
                int nextCol = MoveCol(snakeCol, movement);

                territory[snakeRow, snakeCol] = '.';

                if (!IsPositionValid(nextRow, nextCol, n, n))
                {
                    Console.WriteLine("Game over!");
                    lost = true;
                    break;
                }

                if (territory[nextRow, nextCol] == '-')
                {
                    territory[nextRow, nextCol] = 'S';
                    snakeRow = nextRow;
                    snakeCol = nextCol;
                }
                else if (territory[nextRow, nextCol] == 'B')
                {
                    territory[nextRow, nextCol] = '.';

                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (territory[row,col] == 'B')
                            {
                                territory[row, col] = 'S';
                                snakeRow = row;
                                snakeCol = col;
                            }
                        }
                    }
                }
                else if (territory[nextRow, nextCol] == '*')
                {
                    foodEaten++;
                    territory[nextRow, nextCol] = 'S';
                    snakeRow = nextRow;
                    snakeCol = nextCol;
                }
            }
            if (!lost)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodEaten}");
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }

                Console.WriteLine();
            }

        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
