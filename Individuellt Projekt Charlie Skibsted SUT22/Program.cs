using System;

namespace Individuellt_Projekt_Charlie_Skibsted_SUT22
{
    class Program
    {
        //Publika variablar som vi kan komma från alla metoder
        static string[,] users;
        static decimal[,] accountBalance;
        static string[,] accountTitles;


        static void Main(string[] args)
        {
            users = new string[5, 2]; //Instansierar och tilldelar 2d array, userId och passWord
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

            accountBalance = new decimal[5, 2];  //Instansierar och tilldelar 2d array för kontosaldon
            accountBalance[0, 0] = 5000;
            accountBalance[0, 1] = 10000;
            accountBalance[1, 0] = 7000;
            accountBalance[1, 1] = 100;
            accountBalance[2, 0] = 400;
            accountBalance[2, 1] = 30000;
            accountBalance[3, 0] = 55000;
            accountBalance[3, 1] = 870000;
            accountBalance[4, 0] = 1000;
            accountBalance[4, 1] = 20000;

            accountTitles = new string[5, 2]; //Instansierar och tilldelar 2d array för kontontitlar
            accountTitles[0, 0] = "Privatkonto";
            accountTitles[0, 1] = "Sparkonto";
            accountTitles[1, 0] = "Privatkonto";
            accountTitles[1, 1] = "Studiekonto";
            accountTitles[2, 0] = "Privatkonto";
            accountTitles[2, 1] = "Pensionskonto";
            accountTitles[3, 0] = "Privatkonto";
            accountTitles[3, 1] = "Övrigt konto";
            accountTitles[4, 0] = "Privatkonto";
            accountTitles[4, 1] = "Långsparkonto";

            Console.WriteLine("Välkommen till Varbergs Sparbank");
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
                        PrintBalance(userId);
                        break;
                    case 2:
                        TransferMoney(userId);
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
        static decimal[,] TransferMoney(int accountNumber)
        {

            PrintBalance(accountNumber); //Printa ut kundens saldo

            Console.WriteLine("Välj det konto du vill överföra ifrån: ");
            int fromAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Välj det konto du vill överföra till: ");
            int toAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Välj summa du vill föra över: ");
            decimal transferSum = decimal.Parse(Console.ReadLine());

            if (fromAccount == 1 && toAccount == 2)
            {
                accountBalance[accountNumber, 0] = accountBalance[accountNumber, 0] - transferSum;
                accountBalance[accountNumber, 1] = accountBalance[accountNumber, 1] + transferSum;
            }
            else if (fromAccount == 2 && toAccount == 1)
            {
                accountBalance[accountNumber, 0] = accountBalance[accountNumber, 0] + transferSum;
                accountBalance[accountNumber, 1] = accountBalance[accountNumber, 1] - transferSum;
            }

            Console.WriteLine("Dina nya saldon är: ");
            Console.WriteLine(accountBalance[accountNumber, 0]);
            Console.WriteLine(accountBalance[accountNumber, 1]);

            return accountBalance;

        }
        static void PrintBalance(int accountNumber) //Skriv ut konto saldon
        {
            Console.WriteLine($"1. {accountTitles[accountNumber, 0]} : {accountBalance[accountNumber, 0]} kronor");
            Console.WriteLine($"2. {accountTitles[accountNumber, 1]} : {accountBalance[accountNumber, 1]} kronor");
        }




    }
}
