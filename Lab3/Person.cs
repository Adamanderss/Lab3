using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Person
    {
        public static double budget;

        public static string AskName()
        {
            string name;
            Console.Write("Skriv ditt namn: ");
            name = Console.ReadLine();
            return name;
        }
        public static double AskBudget()
        {
            string strBudget;
            bool budgetSave;
            bool budgetRun = true;
            
            while (budgetRun)
            {
                Console.Write("Skriv din budget i SEK: ");
                strBudget = Console.ReadLine();
                budgetSave = Double.TryParse(strBudget, out budget);
                Console.WriteLine("\nDin budget är " + budget + " SEK.\n");

                if (budgetSave == false)
                    Console.WriteLine("Försök igen med ett nummer.");
                else
                    budgetRun = false;
            }
            return budget;
        }
        public static void AskRepeat()
        {
            string runCheck;

            if (budget <= 0)
            {
                Console.WriteLine("Dina pengar är slut. Vill du spela igen?" +
                "\nY: Ja \nN: Nej");
                runCheck = Console.ReadLine();
                if (runCheck == "Y")
                {
                    budget = 0;
                    Wallet.bet = 0;
                    Console.WriteLine("Välkommen till Enarmade banditen!\n");
                    AskName(); 
                    AskBudget();
                    Program.Menu();
                }
                else if (runCheck == "N")
                {
                    Console.WriteLine("Tack för att du spelade Enarmade banditen!");
                    Console.ReadLine();
                    Program.programRun = false;
                    Program.menuRun = false;
                }
            }
        }        
    }
}
