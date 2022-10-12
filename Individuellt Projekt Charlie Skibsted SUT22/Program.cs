using System;

namespace Individuellt_Projekt_Charlie_Skibsted_SUT22
{
    class Program
    {
        static string[,] users;


        static void Main(string[] args)
        {
            users = new string[5, 2];
            users[0, 0] = "Anders";
            users[0, 1] = "1234";
            users[1, 0] = "Bengt";
            users[1, 1] = "2345";
            users[2, 0] = "David";
            users[2, 1] = "3456";
            users[3, 0] = "Emil";
            users[3, 1] = "4567";
            users[4, 0] = "Fredrik";
            users[4, 1] = "5678";

            RunInternetBank();

        }


        static void RunInternetBank() // Metod som kör switch meny för banken
        {
            int userId = GetLoggedInUser(); //Logga in och lagra kundnummer i accountNumber


            while (userId < 5) //switch loop som körs sålänge vi har kundnummer mellan 0-4
            {
                Console.WriteLine("1. Se dina konton och saldo ");
                Console.WriteLine("2. Överföring mellan konton ");
                Console.WriteLine("3. Ta ut pengar ");
                Console.WriteLine("4. Logga ut ");

                int switchNum = int.Parse(Console.ReadLine());

                switch (switchNum)
                {
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        break;
                    case 4:
                        userId = GetLoggedInUser();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                }
            }
        }
        static int GetLoggedInUser()
        {
            int accountNumber = 5;

            for (int i = 0; i < 3; i++) //Loop som ger tre försök till inlogg
            {
                Console.WriteLine("Skriv ditt användarnamn: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Skriv din fyrasiffriga pinkod: ");
                string userPass = Console.ReadLine();

                for (int j = 0; j < 5; j++) //Loop som jämför userName&&userPass med elementen i arrayen.
                {
                    if (users[j, 0] == userName && users[j, 1] == userPass) //Sök efter användaren
                    {
                        accountNumber = j;
                        i = 3;
                        j = 11;
                    }
                }
            }
            return accountNumber;
        }

    }
}
