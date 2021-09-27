using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        //BoardLayout 0-9, 0 is never used tho.
        static char[] BordLayout = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //Default player 1 starts
        static int PlayerTurn; //This holds the turn of whos turn it it.

        //flag used in CheckWin(), if its 1 then someone has won, if its -1 then its a Draw, if its 0 game continues.
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); //Clear the board (The Console)
                Console.WriteLine("Player 1 is 'X' and Player 2 is 'O'");
                Console.WriteLine("\n");
                if (player % 2 == 0) //Checking whos turn it is
                {
                    Console.WriteLine("Player 2's Turn \n Select a number that has not already been taken\n");
                }
                else
                {
                    Console.WriteLine("Player 1's Turn \nSelect a number that has not already been taken\n");
                }
                Board(); //Write out the Board
                Console.WriteLine("\nSelect a number");
                PlayerTurn = int.Parse(Console.ReadLine()); //User input

                //Checking if a spot is already taken.
                if (BordLayout[PlayerTurn] != 'X' && BordLayout[PlayerTurn] != 'O')
                {
                    if (player % 2 == 0) //put a mark (X or O) depending whos turn it is
                    {
                        BordLayout[PlayerTurn] = 'O';
                        player++;
                    }
                    else
                    {
                        BordLayout[PlayerTurn] = 'X';
                        player++;
                    }
                }
                else
                {
                    //If position of choice is already marked, this message will write out and reload the board.
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", PlayerTurn, BordLayout[PlayerTurn]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait while the board is reloading...");
                    Thread.Sleep(2000);

                }
                flag = CheckWin(); //check if someone has won or continue game

            } while (flag != 1 && flag != -1);//Game will continue to run if flag is 0.

            Console.Clear(); //Clearing the board again (The Console)
            Board(); //Write out the Board

            if (flag == 1) //if Flag value is 1 then someone has won
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else //if flag value is -1 then it write out Draw
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }

        private static void Board()
        {
            //Simple Board
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", BordLayout[1], BordLayout[2], BordLayout[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", BordLayout[4], BordLayout[5], BordLayout[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", BordLayout[7], BordLayout[8], BordLayout[9]);

            Console.WriteLine("     |     |      ");
        }

        //Checking that any player has won or not
        private static int CheckWin()
        {
            //Winning Condition For First Row Down
            if (BordLayout[1] == BordLayout[2] && BordLayout[2] == BordLayout[3])
                return 1;
            else
            //Winning Condition For Second Row Down
            if (BordLayout[4] == BordLayout[5] && BordLayout[5] == BordLayout[6])
                return 1;
            else
            //Winning Condition For Third Row Down
            if (BordLayout[7] == BordLayout[8] && BordLayout[8] == BordLayout[9])
                return 1;
            else
            //Winning Condition For First Row Right
            if (BordLayout[1] == BordLayout[4] && BordLayout[4] == BordLayout[7])
                return 1;
            else
            //Winning Condition For Second Row Right
            if (BordLayout[2] == BordLayout[5] && BordLayout[5] == BordLayout[8])
                return 1;
            else
            //Winning Condition For Second Row Right
            if (BordLayout[3] == BordLayout[6] && BordLayout[6] == BordLayout[9])
                return 1;
            else
            //Winning Condition For Diagonal Down Right
            if (BordLayout[1] == BordLayout[5] && BordLayout[5] == BordLayout[9])
                return 1;
            else
            //Winning Condition For Diagonal Down Left
            if (BordLayout[3] == BordLayout[5] && BordLayout[5] == BordLayout[7])
                return 1;
            else
            //if all cells or values are filled with X or O then its a draw
            if (BordLayout[1] != '1' && BordLayout[2] != '2' && BordLayout[3] != '3' && BordLayout[4] != '4' && BordLayout[5] != '5' && BordLayout[6] != '6' && BordLayout[7] != '7' && BordLayout[8] != '8' && BordLayout[9] != '9')
                return -1;
            else
                return 0;
        }

    }
}
