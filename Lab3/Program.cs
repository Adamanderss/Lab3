using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        public static bool programRun = true;
        public static bool menuRun = true;

        static void Main(string[] args)
        {
            while (programRun)
            {
                Console.WriteLine("Välkommen till Enarmade banditen!");
                Person.AskName(); //Frågar efter användarens namn
                Person.AskBudget(); //Frågar efter hur mycket som är i användarens plånbok vid start
                Menu(); //Skriver ut meny
            }
        }
        public static void Menu()
        {
            int menu;
            string strMenu;
            bool menuSave;
            
            while (menuRun)
            {
                Console.WriteLine(
                    "Tryck 1 för att placera din insats." +
                    "\nTryck 2 för att se din insats och budget." +
                    "\nTryck 3 för att spela." +
                    "\nTryck 4 för att avsluta.\n");
                strMenu = Console.ReadLine();
                menuSave = Int32.TryParse(strMenu, out menu);

                if (menuSave == false)
                    Console.WriteLine("Försök igen med en siffra.\n");
                switch (menu)
                {
                    case 1: //Insatsen anges, men dras först av när användaren väljer att spela
                        Wallet.AskBet();
                        Console.WriteLine("Du har angett " + Wallet.bet + " SEK som din spelinsats.\n");
                        break;

                    case 2: //Visar nuvarande budget och spelinsats
                        Console.WriteLine(
                            "Din totala budget: " + Person.budget +
                            "\nNuvarande spelinsats: " + Wallet.bet + "\n");
                        break;

                    case 3: //Om användaren har tillräckligt med kredit kvar så körs spelet
                        if (Person.budget >= Wallet.bet)
                        {
                            if (Wallet.bet == 0)
                            { 
                                Console.WriteLine("Ange en insats innan du spelar.\n");
                                break;
                            }                              
                            Person.budget = Person.budget - Wallet.bet; //bet dras av från budget
                            Gameboard.PrintBoard(); //Spelplanen visas
                            Gameboard.Outcome(); //Resultatet visas
                            Person.AskRepeat(); //Om krediten är slut så frågas användaren om han/hon vill spela igen
                        }
                        else if (Person.budget < Wallet.bet)
                            Console.WriteLine("Din insats är för hög, försök igen med en mindre insats.\n");
                        break;
                        
                    case 4: //Programmet avslutas
                        Console.WriteLine("Tack för att du spelade Enarmade banditen!");
                        Console.ReadLine();
                        menuRun = false;
                        programRun = false;
                        break;
                }
            }          
        }
    }
}
