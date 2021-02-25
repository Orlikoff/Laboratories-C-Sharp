using System;

namespace Lab_1
{
    class Program // tic tac toe
    {
        static void Main(string[] args)
        {
            // initializing the board
            char[] BOARD = new char[9];
            for (int i = 0; i < BOARD.Length; i++)
            {
                BOARD[i] = '_';
            }

            // setting up game variables
            char turn = 'X';
            bool isFinished = false;
            int[,] winningCases = new int[8, 3]
            {
                {0, 1, 2 }, // verical
                {3, 4, 5 }, // verical
                {6, 7, 8 }, // verical
                {0, 3, 6 }, // horizontal
                {1, 4, 7 }, // horizontal
                {2, 5, 8 }, // horizontal
                {0, 4, 8 }, // diagonal
                {2, 4, 6 }  // diagonal
            };

            //Main game cycle with all implemented fucntions
            welcome();
            Console.ReadKey();
            Console.Clear();
            while (!isFinished)
            {
                BOARD = makeTurn(turn, BOARD);
                if (turn == 'X')
                {
                    turn = 'O';
                } 
                else
                {
                    turn = 'X';
                }
                isFinished = gameProcess(winningCases, BOARD);
            }

            //Waiting for user
            Console.ReadKey();
        }

        static void welcome()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tWelcome to TIC TAC TOE!");
            Console.WriteLine("\tX is to move first\n");
            Console.WriteLine("\tFollow next pattern to play\n\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"\t1 | 2 | 3");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t4 | 5 | 6");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t7 | 8 | 9\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static char[] makeTurn(char turn, char[] BOARD)
        {
            int countVars = 0;
            int[] vars = new int[9];
            for (int i = 0; i < 9; i++)
            {
                if (BOARD[i] == '_')
                {
                    vars[countVars] = i;
                    countVars++;
                }
            }
            Console.WriteLine($"Choose from empty fields fields:\n");
            Console.WriteLine($"\t{BOARD[0]} | {BOARD[1]} | {BOARD[2]}");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{BOARD[3]} | {BOARD[4]} | {BOARD[5]}");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{BOARD[6]} | {BOARD[7]} | {BOARD[8]}\n");

            bool isValid = false;
            while (!isValid)
            {
                int input = 10;
                Console.Write($"Input the field you want to put the {turn} in: ");
                try 
                {
                    input = Int32.Parse(Console.ReadLine()) - 1;
                }
                catch (SystemException Error)
                {
                    //without showing it to the user
                }
                             
                for(int i = 0; i < countVars; i++)
                {
                    if (vars[i] == input)
                    {
                        isValid = true;
                        BOARD[input] = turn;
                    }
                }
            }

            Console.Clear();

            return BOARD;
        }

        static bool gameProcess(int[,] winningCases, char[] BOARD)
        {
            // check all the fields that are used
            int[] usedByX = new int[5]; // 5 is max that X can fill
            int xCount = 0;
            int[] usedByO = new int[4]; // 4 is max that O can fill
            int oCount = 0;
            int[] free = new int[9]; // 9 is full field
            int unused = 0;

            for (int i = 0; i < BOARD.Length; i++)
            {
                if (BOARD[i] == 'X')
                {
                    usedByX[xCount] = i;
                    xCount++;
                }
                else if (BOARD[i] == 'O')
                {
                    usedByO[oCount] = i;
                    oCount++;
                }
                else
                {
                    free[unused] = i;
                    unused++;
                }
            }

            if (unused == 0)
            {
                if (checkWin('X', xCount, usedByX, winningCases, BOARD))
                {
                    return true;
                };

                if (checkWin('O', oCount, usedByO, winningCases, BOARD))
                {
                    return true;
                };

                draw(BOARD);
                return true;
            }

            if (unused <= 5 && unused != 0)
            {
                if (xCount > 2)
                {
                    if (checkWin('X', xCount, usedByX, winningCases, BOARD))
                    {
                        return true;
                    };
                }

                if (oCount > 2)
                {
                    if (checkWin('O', oCount, usedByO, winningCases, BOARD))
                    {
                        return true;
                    };
                }
            }
            
            return false;
        }

        static void draw(char[] BOARD)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n\t{BOARD[0]} | {BOARD[1]} | {BOARD[2]}");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{BOARD[3]} | {BOARD[4]} | {BOARD[5]}");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{BOARD[6]} | {BOARD[7]} | {BOARD[8]}\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Noone has won the game! It's a draw!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static bool checkWin(char turn, int n, int[] usedByTurn, int[,] winningCases, char[] BOARD)
        {   
            for (int i = 0; i < 8; i++)
            {
                int thriple = 0;
                // checking case
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (usedByTurn[j] == winningCases[i, k])
                        {
                            thriple++;
                            if (thriple >= 3)
                            {
                                winner(turn, BOARD);
                                return true;
                            }
                            break;
                        }
                    }
                }
            }
            return false;
        }

        static void winner(char turn, char[] BOARD)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\n\t{BOARD[0]} | {BOARD[1]} | {BOARD[2]}");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{BOARD[3]} | {BOARD[4]} | {BOARD[5]}");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{BOARD[6]} | {BOARD[7]} | {BOARD[8]}\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Congratilutons for the {turn} player for winning the game!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
