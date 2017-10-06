using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Wallet
    {
        public static double bet;

        public static void AskBet() //Frågar efter insats
        {
            bool betSave;
            bool betRun = true;
            string strBet;

            while (betRun)
            {
                Console.WriteLine(
                    "Hur mycket vill du satsa? " +
                    "\nDin budget är: " + Person.budget + " SEK.");
                strBet = Console.ReadLine();
                betSave = Double.TryParse(strBet, out bet);

                if (betSave == false)
                    Console.WriteLine("Försök igen med en siffra.");            
                else
                {
                    if (bet <= Person.budget)
                        betRun = false;
                    
                    else if (bet > Person.budget)
                    {
                        Console.WriteLine("Din insats är för hög, ange en mindre insats och försök igen.");
                        continue;
                    }
                }
            }          
        }
    }
}
