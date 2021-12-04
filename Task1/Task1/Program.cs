using System;

namespace Task1
{
    class Program
    {
        /// <summary>
        /// calculate of winner
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static string check(string[][] matrix)
        {
            int counterx = 0;
            int countero = 0;
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (matrix[i][j] == "X")
                    {
                        counterx++;
                        countero = 0;
                    }
                    else if(matrix[i][j] == "O")
                    {
                        countero++;
                        counterx = 0;
                    }
                }
                if (counterx == 3 || countero == 3)
                {
                    if (counterx == 3)
                    {
                        return "X";
                    }
                    else
                    {
                        return "O";
                    }
                }
                counterx=0;
                countero=0;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[j][i] == "X")
                    {
                        counterx++;
                        countero = 0;
                    }
                    else if (matrix[j][i] == "O")
                    {
                        countero++;
                        counterx = 0;
                    }
                }
                if (counterx == 3 || countero == 3)
                {
                    if (counterx == 3)
                    {
                        return "X";
                    }
                    else
                    {
                        return "O";
                    }
                }
                counterx = 0;
                countero = 0;
            }
            if (matrix[0][0] == matrix[1][1] && matrix[1][1] == matrix[2][2])
            {
                if (matrix[0][0] == "X")
                {
                    return "X";
                }
                else
                {
                    return "O";
                }
            }
            else if(matrix[0][2] == matrix[1][1] && matrix[1][1] == matrix[2][0])
            {
                if (matrix[0][2] == "X")
                {
                    return "X";
                }
                else
                {
                    return "O";
                }
            }
            return "";
        }
        /// <summary>
        /// Output info of winner
        /// </summary>
        /// <param name="X_O"></param>
        protected static void tic_tac_winner(string[][] X_O)
        {
            Console.WriteLine("Winner: " + check(X_O));
        }
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[][] X_O = new string[3][];
            Console.WriteLine("Enter 3 in a row X or O, separated by commas ");
            string str = Console.ReadLine();
            X_O[0] = str.Split(',');
            str = Console.ReadLine();
            X_O[1] = str.Split(',');
            str = Console.ReadLine();
            X_O[2] = str.Split(',');
            tic_tac_winner(X_O);
        }
    }
}
