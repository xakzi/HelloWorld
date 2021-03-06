///Emanoel Kouriat
///2021-09-27
///emanoel.kouriat@student.forsbergsskolan.se

using System;
using System.Linq;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        #region Variables
        #region TicTacToe Variables
        //BoardLayout 0-9, 0 is never used tho.
        static char[] TicTacToeBoardLayout = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int TicTacToeplayer = 1; //Default player 1 starts
        static int TicTacToePlayerTurn; //This holds the turn of whos turn it is.

        //flag used in CheckWin(), if its 1 then someone has won, if its -1 then its a Draw, if its 0 game continues.
        static int TicTacToeflag = 0;
        #endregion

        #region Nim Variables
        static int NimGamePlayer = 1; //Default player 1 starts
        static int NimGamePlayerTurn = 0; //This holds the turn of whos turn it is.
        static int NimGameFlag = 0; //Used to check if someone has won
        static int NimGameTokens = 12;
        #endregion
        #endregion

        static void Main(string[] args)
        {
            #region Main, Select Game Switch
            SelectGame(); //Start with user selecting what game to play
            #endregion
        }

        #region TicTacToe Game

        //The game mechanics
        private static void TicTacToe()
        {
            #region The Game
            TicTacToeReset();
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

                if (TicTacToePlayerTurn < 1 || TicTacToePlayerTurn > 9)
                {
                    Console.WriteLine("Please choose a number that is available on the board");
                    Console.WriteLine("\nPlease wait while the board is reloading...");
                    Thread.Sleep(2000);
                   
                }else
                {
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
                        Console.WriteLine("\nPlease wait while the board is reloading...");
                        Thread.Sleep(2000);

                    }
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
#endregion
        }

        //Simple Board Layout
        private static void TicTacToeBoard()
        {
            #region Tic Tac Toe Board Print
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", TicTacToeBoardLayout[1], TicTacToeBoardLayout[2], TicTacToeBoardLayout[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", TicTacToeBoardLayout[4], TicTacToeBoardLayout[5], TicTacToeBoardLayout[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", TicTacToeBoardLayout[7], TicTacToeBoardLayout[8], TicTacToeBoardLayout[9]);

            Console.WriteLine("     |     |      ");
            #endregion
        }
        
        //Checking if there is a winner during gameplay
        private static int TicTacToeCheckWin()
        {
            #region TicTacToe Check if there is a winner
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
            #endregion
        }

        //Reset the game values
        private static void TicTacToeReset()
        {
            #region TicTacToeReset()
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
            #endregion
        }
        
        #endregion //TicTacToeGame

        #region Battleship Game
        //Lol Made you look, game is not yet here :)
        #endregion

        #region Nim Game

        //the game mechanics
        private static void NimGame()
        {
            #region The Game
            NimGameReset();
            do
            {
                Console.Clear();
                Console.WriteLine("Whoever takes the last tokens wins.\n\n" +
                    "There are " + NimGameTokens + " tokens.\n");
                
                if (NimGamePlayer % 2 == 0)
                {
                    if (NimGameTokens < NimGamePlayerTurn)
                    {
                        Console.WriteLine("Nice Try!! Select an amount that is not more than Tokens left\n");
                    }
                    else
                    {
                        if (NimGamePlayerTurn != 0)
                        {
                            if (NimGamePlayerTurn < 1 || NimGamePlayerTurn > 3)
                                Console.WriteLine("Please take 1, 2 or 3 only!\n");
                            else
                                Console.WriteLine("Player 1 Took " + NimGamePlayerTurn + " Tokens\n");
                        }
                    }
                    Console.WriteLine("Player 2's Turn\nSelect a number between 1 and 3\n");
                }
                else
                {
                    if (NimGameTokens < NimGamePlayerTurn)
                    {
                        Console.WriteLine("Nice Try! Select an amount that is not more than Tokens left\n");
                    }
                    else
                    {
                        if (NimGamePlayerTurn != 0)
                        {
                            if (NimGamePlayerTurn < 1 || NimGamePlayerTurn > 3)
                                Console.WriteLine("Please take 1, 2 or 3 only!\n");
                            else
                                Console.WriteLine("Player 2 Took " + NimGamePlayerTurn + " Tokens\n");
                        }
                    }
                    Console.WriteLine("Player 1's Turn\nSelect a number between 1 and 3\n");
                }
                NimGamePlayerTurn = int.Parse(Console.ReadLine());

                if (NimGamePlayerTurn < 1 || NimGamePlayerTurn > 3 || NimGameTokens < NimGamePlayerTurn)
                {
                    //Console.WriteLine("Please take 1, 2 or 3 only!");
                    //This wont show because of the reset in the beginning
                }
                else
                {
                    NimGamePlayer++;
                    NimGameTokens -= NimGamePlayerTurn;
                }
                NimGameFlag = NimGameCheckWin();
            
            } while (NimGameFlag != 1);
            
            Console.Clear(); //Clearing the Console to show only the winner!
            if (NimGameFlag == 1)
                Console.WriteLine("Player {0} has won \n", (NimGamePlayer % 2) + 1);
            SelectGame();
        #endregion
        }

        //Checking who is the winner
        private static int NimGameCheckWin()
        {
            #region Nim Game Check Win
            if (NimGameTokens == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            #endregion
        }
        
        //Reset the game values
        private static void NimGameReset()
        {
            #region Nim Game Reset()
            //Some resets before game starts again.
            NimGameTokens = 12;
            NimGameFlag = 0;
            NimGamePlayer = 1;
            NimGamePlayerTurn = 0;
            #endregion
        }

        #endregion

        
        private static void SelectGame()
        {
            #region SelectGame Void
            Console.WriteLine("Select the game you want to play");
            Console.WriteLine("TicTacToe: Select 1");
            Console.WriteLine("Battleship: Select 2");
            Console.WriteLine("Nim: Select 3");

            string selectGameInput = Console.ReadLine(); //Get user Input (ex 1, 2 or 3)
            int selectGame;
            Int32.TryParse(selectGameInput, out selectGame); //Check if user Input is an interger
            
            if (Enumerable.Range(1, 3).Contains(selectGame))
            {
                switch (selectGame) //Simple switch
                {
                    case 1: //Start Tic Tac Toe
                        TicTacToe();
                        break;
                    case 2: //Start Battleship
                        //Battleship();
                        Console.WriteLine("You Have Selected Battleship");
                        SelectGame();
                        break;
                    case 3: //Start Nim Game
                        NimGame();
                        break;
                    default: //If other Input a number lower than 1 or higher than 3 it will force user to reselect
                        Console.Clear();
                        Console.WriteLine("Please select one of the following\n");
                        SelectGame();
                        break;
                }
            }else
            {
                //If other Input than numbers was given it force user to reselect
                Console.Clear();
                Console.WriteLine("Please select one of the following\n");
                SelectGame();
            }
            #endregion
        }


    }
}
