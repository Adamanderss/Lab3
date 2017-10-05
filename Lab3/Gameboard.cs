using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Gameboard
    {
        public static string[,] board = new string[3, 3];
        public static string symbolValue;
        public static double winnings;
        public static bool lineWin;
        static Random random = new Random();

        public static string SymbolChance()
        {
            int randomNumber = random.Next(0, 101); //Ett randomiserat nummer mellan 1-100 skapas

            if (randomNumber > 0 && randomNumber < 31)
                    symbolValue = "9 ";
                else if (randomNumber > 30 && randomNumber < 55)
                    symbolValue = "10";
                else if (randomNumber > 55 && randomNumber < 75)
                    symbolValue = "J ";
                else if (randomNumber > 75 && randomNumber < 90)
                    symbolValue = "Q ";
                else if (randomNumber > 90 && randomNumber < 98)
                    symbolValue = "K ";
                else if (randomNumber > 98 && randomNumber < 101)
                    symbolValue = "D ";

            return symbolValue; //En spelsymbol returneras baserat på det randomiserade numret
        }
        public static void PrintBoard()
        {
            for (int i = 0; i < 3; ++i)
            {
                SymbolChance();
                for (int j = 0; j < 3; ++j)
                {
                    board[i, j] = symbolValue; //Arrayens element får var sin spelsymbol genom looparna
                    SymbolChance(); //Symbolerna tilldelas i SymbolChance
                }
            }
            Console.WriteLine("Du har satsat " + Wallet.bet + " SEK.");

            Console.WriteLine(
                "\n" + "|" + board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2] + "|" +
                "\n" + "|" + board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2] + "|" +
                "\n" + "|" + board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2] + "|" + "\n");
        }
        public static bool SlotResult(string e) //Parametern e ges i Outcome ett värde av respektive spelsymbol
        {
            lineWin = false;

            if (board[0, 0] == e && board[0, 1] == e && board[0, 2] == e)
                lineWin = true;
            else if (board[1, 0] == e && board[1, 1] == e && board[1, 2] == e)
                lineWin = true;
            else if (board[2, 0] == e && board[2, 1] == e && board[2, 2] == e)
                lineWin = true;
            else if (board[0, 0] == e && board[1, 1] == e && board[2, 2] == e)
                lineWin = true;
            else if (board[2, 0] == e && board[1, 1] == e && board[0, 2] == e)
                lineWin = true;

            return lineWin;
        }
        public static void WinStatement(double x) //Parametern x används i Outcome för att räkna ut varje vinstsumma
        {
            winnings = Wallet.bet * x;
            Person.budget = Person.budget + winnings;
            Console.WriteLine("Grattis! Du har vunnit " + winnings + " SEK." +
                "\nDu har " + Person.budget + " SEK kvar.\n");

        }
        public static double Outcome() //Hittar om det blev någon vinst, och vad den summan isåfall blir
        {
            if (SlotResult("9 ") == true)
                WinStatement(1.2);
            else if (SlotResult("10") == true)
                WinStatement(2);
            else if (SlotResult("J ") == true)
                WinStatement(2.5);
            else if (SlotResult("Q ") == true)
                WinStatement(5);
            else if (SlotResult("K ") == true)
                WinStatement(10);
            else if (SlotResult("D ") == true)
                WinStatement(50);
            else
                Console.WriteLine("Bättre lycka nästa gång!" +
                    "\nDu har " + Person.budget + " SEK kvar.\n");

            return winnings;
        }
    }
}
