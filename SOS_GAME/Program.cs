using System;

namespace SOS_GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] numbers = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            Game(numbers, 3, 3);
            
        }
        static void PrintArray(string[,] arr, int column, int row)
        {
            int counter = 1;
            Console.Write("     |     |     \n");

            foreach (string item in arr)
            {

                Console.Write("  " + item + "  ");
                if (counter % column != 0)
                    Console.Write("|");
                else if(counter != column*row)
                {
                    Console.WriteLine("\n_____|_____|_____");
                    Console.Write("     |     |     \n");
                }
                counter++;
            }
            Console.WriteLine("\n     |     |     \n");
        }
        static int EnterChoice(int Player)
        {
            bool isUserEnteredBetween0and9 = false;
            int choice;
            string input;
            bool isUserEnteredWord = true;
            do
            {
                Console.Write("Player {0}: Choose your field! ", Player);
                input = Console.ReadLine();
                isUserEnteredWord = int.TryParse(input, out choice);
                isUserEnteredBetween0and9 = (choice > 0 && choice < 9) ? true : false;
                if(isUserEnteredWord || !isUserEnteredBetween0and9)
                    Console.WriteLine("Enter number between 0 and 9 please.");
            } while (!isUserEnteredWord && !isUserEnteredBetween0and9);
            return choice;
        }
        static void Game(string[,] numbers, int column, int row)
        {
            int cnt = 0, P1, P2;
            bool P1_Won=false, P2_Won=false;
            while (cnt < 9 && !P1_Won && !P2_Won)
            {
                PrintArray(numbers, column, row);
                if (cnt % 2 == 0)
                {
                    P1 = EnterChoice(1) - 1;
                    int P1_row = P1 / 3;
                    int P1_col = P1 - P1_row * 3;
                    numbers[P1_row, P1_col] = "0";
                    P1_Won = CheckWinner(numbers, "0", 3, 3);
                }
                else
                {
                    P2 = EnterChoice(2) - 1;
                    int P2_row = P2 / 3;
                    int P2_col = P2 - P2_row * 3;
                    numbers[P2_row, P2_col] = "X";
                    P2_Won = CheckWinner(numbers, "X", 3, 3);
                }
                Console.Clear();
                cnt++;
            }
            PrintArray(numbers, 3, 3);
            if(P1_Won == true)
                Console.WriteLine("Player 1 is Winner.");
            else if(P2_Won == true)
                Console.WriteLine("Player 2 is Winner.");
            else
                Console.WriteLine("No winner for this game.");
        }
        static bool CheckWinner(string[,] numbers, string c, int column, int row)
        {
            bool P_Won = false;
            if(numbers[0,0]==c && numbers[0,1] == c && numbers[0,2] == c)
            {
                P_Won = true;
            }
            if (numbers[1, 0] == c && numbers[1, 1] == c && numbers[1, 2] == c)
            {
                P_Won = true;
            }
            if (numbers[2, 0] == c && numbers[2, 1] == c && numbers[2, 2] == c)
            {
                P_Won = true;
            }
            if (numbers[0, 0] == c && numbers[1, 1] == c && numbers[2, 2] == c)
            {
                P_Won = true;
            }
            if (numbers[0, 2] == c && numbers[1, 1] == c && numbers[2, 0] == c)
            {
                P_Won = true;
            }
            if (numbers[0, 0] == c && numbers[1, 0] == c && numbers[2, 0] == c)
            {
                P_Won = true;
            }
            if (numbers[0, 1] == c && numbers[1, 1] == c && numbers[2, 1] == c)
            {
                P_Won = true;
            }
            if (numbers[0, 2] == c && numbers[1, 2] == c && numbers[2, 2] == c)
            {
                P_Won = true;
            }
            return P_Won;
        }
    }
}
