using System;
    /*
     * 
     tic-tac-toe game.(Player1 vs Player2)
     Take the row and column number for both the players
     Keep putting the X's and O's on the given positions
     If a row or column or diagonal checks out, we have a winner.
     Keep the corner cases in mind which mostly include faulty inputs from the user
     *
     */

namespace tic_tac_toe
{
    class Program
    {

        static char[,] board = new char[3, 3];
        static bool flag = true;

        static void Initialize() // creating an empty board
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void Show_Board() // printing the board
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("|\t" + board[i, 0] + "|\t" +  board[i, 1] + "|\t" +  board[i, 2] + "|");
                Console.WriteLine("|--------|-------|-------|");
            }
            

            Console.WriteLine();

        } 
        
        static bool RowCheck() // checks if any of the rows have all the same elements.
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
                    return true;
            }
            return false;

        }
        
        static bool ColumnCheck() // checks if any of the columns have all the same elements.
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
                    return true;
            }
            return false;

        }
        
        static bool DiagonalCheck() // checks if any of the diagonals have all the same elements.
        {

            if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ') ||
                (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' '))
                return true;
            return false;
        }

        static bool Game_Over() // if any of the above is true .... then GAME OVER.
        {
            return RowCheck() || ColumnCheck() || DiagonalCheck();
            
        }

        static void Play_Game(string player1, string player2)// LET THE GAME BEGIN
        {
            Initialize();

            Show_Board();

            string whose_turn = player1;
            int r = 0, c = 0, moves = 0;

            while (flag = !Game_Over() && moves != 9)
            {

                /*
                 * turn = player1
                 */
                if (whose_turn == player1)
                {
                    Console.WriteLine($"{player1}'s turn.\n");
                    while (whose_turn != player2)
                    {

                        Console.WriteLine("Please give the row and coloumn number to enter 'X'\n");
                        try
                        {
                            Console.Write("Enter Row No. : ");
                            r = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Enter Column No. ");
                            c = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Enter valid numbers please!!!\n");
                            continue;
                        }

                        /*
                         * Row number and Column number smaller than the size of Grid.
                         */
                        if (r <= 3 && c <= 3)
                        {

                            /*
                             * However if the row number and column number is smaller than 0...which is actually not possible ..lol..
                             */

                            if (r <= 0 || c <= 0)
                            {
                                Console.WriteLine("Please enter a valid number." + "\n" +
                                                " It should be atleast 1.\n");
                            }
                            /*
                             *  if the row and column number is actually in the range of the size of grid
                             */

                            else if (board[r - 1, c - 1] == ' ')
                            {
                                board[r - 1, c - 1] = 'X';
                                whose_turn = player2;
                                moves++; /*
                                          * since the size of the grid is taken as 3 so the total number of moves can be atmost 9
                                          * if the game goes the distance i.e, the number of moves goes upto 9, then we need to 
                                          *stop.So, we need to keep a count of how many moves has been played in total.
                                          *
                                          */

                                Console.Clear();
                                
                                Show_Board();
                            }

                            else // One  just cannot override the place in a grid, which is already taken.
                            {
                                Console.WriteLine("Please choose a empty space\n");

                            }
                        }
                        else // What if someone enters row and column as 30,33. My grid is only of the size (3,3).
                        {
                            Console.WriteLine("Please enter valid numbers.\n" +
                                "It should not be greater than the size of the grid.\n " +
                                "The size of the grid is taken as 3.\n");

                        }


                    }
                }


                /*
                 * turn = player 2 
                 */

                /**
                  the logic stays the same as above .Only player1 becomes player 2...thats it.
                 **/

                else
                {
                    Console.WriteLine($"{player2}'s turn.\n");
                    while (whose_turn != player1)
                    {

                        Console.WriteLine("Please give the row and coloumn number to enter 'O'\n");
                        try
                        {
                            Console.Write("Enter Row No. : ");
                            r = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            
                            Console.Write("Enter Column No. : ");
                            c = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Enter numbers please!!!\n");
                            continue;
                        }

                        if (r <= 3 && c <= 3)
                        {
                            if (r <= 0 || c <= 0)
                            {
                                Console.WriteLine("Please enter a valid number." + "\n" +
                                                " It should be atleast 1.\n");
                            }

                            else if (board[r - 1, c - 1] == ' ')
                            {
                                board[r - 1, c - 1] = 'O';
                                whose_turn = player1;
                                moves++;

                                Console.Clear();
                                Show_Board();

                            }

                            else
                            {
                                Console.WriteLine("Please choose a empty space\n");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid numbers.\n" +
                                "It should not be greater than the size of the grid.\n " +
                                "The size of the grid is taken as 3.\n");

                        }

                    }
                }


            }
            
            Console.WriteLine("GAME OVER!!!\n");

            if (!flag && moves == 9)
                Console.WriteLine("MATCH DRAW !!! BOTH PLAYED OPTIMALLY!!\n");
            else if (moves % 2 == 0) Console.WriteLine($"WINNER - {player2}");
            else Console.WriteLine($"WINNER - {player1}");

        }
            static void Main(string[] args)
            {
                string player1, player2;
                Console.Write("ENTER NAME OF 1st PLAYER : " );
                player1 = Console.ReadLine();

                Console.WriteLine();

                Console.Write("ENTER NAME OF 2nd PLAYER : ");
                player2 = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine($"{player1} gets 'X'\n{player2} gets 'O'. ");
                int col = Console.CursorLeft;
                int row = Console.CursorTop;

            Play_Game(player1,
                          player2);
                

            }
        
    }
}
