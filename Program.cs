using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        //BoardLayout 0-9, 0 is never used tho.
        static char[] TicTacToeBoardLayout = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int TicTacToeplayer = 1; //Default player 1 starts
        static int TicTacToePlayerTurn; //This holds the turn of whos turn it it.

        //flag used in CheckWin(), if its 1 then someone has won, if its -1 then its a Draw, if its 0 game continues.
        static int TicTacToeflag = 0;

        static void Main(string[] args)
        {
            SelectGame();
        }

        private static void TicTacToe()
        {
            do
            {
                Console.Clear(); //Clear the board (The Console)
                Console.WriteLine("Player 1 is 'X' and Player 2 is 'O'");
                Console.WriteLine("\n");
                if (TicTacToeplayer % 2 == 0) //Checking whos turn it is
                {
                    Console.WriteLine("Player 2's Turn \n Select a number that has not already been taken\n");
                }
                else
                {
                    Console.WriteLine("Player 1's Turn \nSelect a number that has not already been taken\n");
                }
                TicTacToeBoard(); //Write out the Board
                Console.WriteLine("\nSelect a number");
                TicTacToePlayerTurn = int.Parse(Console.ReadLine()); //User input

                //Checking if a spot is already taken.
                if (TicTacToeBoardLayout[TicTacToePlayerTurn] != 'X' && TicTacToeBoardLayout[TicTacToePlayerTurn] != 'O')
                {
                    if (TicTacToeplayer % 2 == 0) //put a mark (X or O) depending whos turn it is
                    {
                        TicTacToeBoardLayout[TicTacToePlayerTurn] = 'O';
                        TicTacToeplayer++;
                    }
                    else
                    {
                        TicTacToeBoardLayout[TicTacToePlayerTurn] = 'X';
                        TicTacToeplayer++;
                    }
                }
                else
                {
                    //If position of choice is already marked, this message will write out and reload the board.
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", TicTacToePlayerTurn, TicTacToeBoardLayout[TicTacToePlayerTurn]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait while the board is reloading...");
                    Thread.Sleep(2000);

                }
                TicTacToeflag = TicTacToeCheckWin(); //check if someone has won or continue game

            } while (TicTacToeflag != 1 && TicTacToeflag != -1);//Game will continue to run if flag is 0.

            Console.Clear(); //Clearing the board again (The Console)
            TicTacToeBoard(); //Write out the Board

            if (TicTacToeflag == 1) //if Flag value is 1 then someone has won
            {
                Console.WriteLine("Player {0} has won\n", (TicTacToeplayer % 2) + 1);
            }
            else //if flag value is -1 then it write out Draw
            {
                Console.WriteLine("Draw\n");
            }
            SelectGame();
        }

        private static void TicTacToeBoard()
        {
            //Simple Board
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", TicTacToeBoardLayout[1], TicTacToeBoardLayout[2], TicTacToeBoardLayout[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", TicTacToeBoardLayout[4], TicTacToeBoardLayout[5], TicTacToeBoardLayout[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", TicTacToeBoardLayout[7], TicTacToeBoardLayout[8], TicTacToeBoardLayout[9]);

            Console.WriteLine("     |     |      ");
        }

        //Checking that any player has won or not
        private static int TicTacToeCheckWin()
        {
            //Winning Condition For First Row Down
            if (TicTacToeBoardLayout[1] == TicTacToeBoardLayout[2] && TicTacToeBoardLayout[2] == TicTacToeBoardLayout[3])
            {
                return 1;
            }
            else
            //Winning Condition For Second Row Down
            if (TicTacToeBoardLayout[4] == TicTacToeBoardLayout[5] && TicTacToeBoardLayout[5] == TicTacToeBoardLayout[6])
                return 1;
            else
            //Winning Condition For Third Row Down
            if (TicTacToeBoardLayout[7] == TicTacToeBoardLayout[8] && TicTacToeBoardLayout[8] == TicTacToeBoardLayout[9])
                return 1;
            else
            //Winning Condition For First Row Right
            if (TicTacToeBoardLayout[1] == TicTacToeBoardLayout[4] && TicTacToeBoardLayout[4] == TicTacToeBoardLayout[7])
                return 1;
            else
            //Winning Condition For Second Row Right
            if (TicTacToeBoardLayout[2] == TicTacToeBoardLayout[5] && TicTacToeBoardLayout[5] == TicTacToeBoardLayout[8])
                return 1;
            else
            //Winning Condition For Second Row Right
            if (TicTacToeBoardLayout[3] == TicTacToeBoardLayout[6] && TicTacToeBoardLayout[6] == TicTacToeBoardLayout[9])
                return 1;
            else
            //Winning Condition For Diagonal Down Right
            if (TicTacToeBoardLayout[1] == TicTacToeBoardLayout[5] && TicTacToeBoardLayout[5] == TicTacToeBoardLayout[9])
                return 1;
            else
            //Winning Condition For Diagonal Down Left
            if (TicTacToeBoardLayout[3] == TicTacToeBoardLayout[5] && TicTacToeBoardLayout[5] == TicTacToeBoardLayout[7])
                return 1;
            else
            //if all cells or values are filled with X or O then its a draw
            if (TicTacToeBoardLayout[1] != '1' && TicTacToeBoardLayout[2] != '2' && TicTacToeBoardLayout[3] != '3' && TicTacToeBoardLayout[4] != '4' && TicTacToeBoardLayout[5] != '5' && TicTacToeBoardLayout[6] != '6' && TicTacToeBoardLayout[7] != '7' && TicTacToeBoardLayout[8] != '8' && TicTacToeBoardLayout[9] != '9')
                return -1;
            else
                return 0;
        }

        private static void SelectGame()
        {
            int selectGame;
            Console.WriteLine("Select the game you want to play");
            Console.WriteLine("TicTacToe: Select 1");
            Console.WriteLine("Battleship: Select 2");
            Console.WriteLine("Nim: Select 3");
            selectGame = int.Parse(Console.ReadLine());
            if (selectGame == 1)
            {
                TicTacToeflag = 0;
                TicTacToeBoardLayout[1] = '1';
                TicTacToeBoardLayout[2] = '2';
                TicTacToeBoardLayout[3] = '3';
                TicTacToeBoardLayout[4] = '4';
                TicTacToeBoardLayout[5] = '5';
                TicTacToeBoardLayout[6] = '6';
                TicTacToeBoardLayout[7] = '7';
                TicTacToeBoardLayout[8] = '8';
                TicTacToeBoardLayout[9] = '9';
                TicTacToeplayer = 1;
                TicTacToe();
            }
            else if (selectGame == 2)
            {
                //Battleship();
                Console.WriteLine("You Have Selected Battleship");
                SelectGame();
            }
            else if (selectGame == 3)
            {
                //Nim();
                Console.WriteLine("You have Selected Num");
                SelectGame();
            }
        }

    }
}
