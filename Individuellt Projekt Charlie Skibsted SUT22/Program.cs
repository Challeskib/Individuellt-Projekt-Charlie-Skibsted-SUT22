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

            accountBalance = new decimal[5, 5];  //Instansierar och tilldelar 2d array för kontosaldon
            accountBalance[0, 0] = 5000;
            accountBalance[0, 1] = 10000;
            accountBalance[0, 2] = 10000;
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

            RunInternetBank();

        }


        static void RunInternetBank() // Metod som kör switch meny för banken
        {
            int userId = GetLoggedInUser(); //Logga in och lagra kundnummer i accountNumber

            while (userId < 5) // loop till switchen som körs sålänge vi har kundnummer mellan 0-4
            {
                Console.WriteLine("1. Se dina konton och saldo ");
                Console.WriteLine("2. Överföring mellan konton ");
                Console.WriteLine("3. Ta ut pengar ");
                Console.WriteLine("4. Sätt in pengar ");
                Console.WriteLine("5. Logga ut ");

                int switchNum = int.Parse(Console.ReadLine());

                switch (switchNum) //Switch menu
                {
                    case 1:
                        PrintAllBalances(userId);
                        ClickEnterToReturnToMenu();
                        break;
                    case 2:
                        TransferMoney(userId);
                        ClickEnterToReturnToMenu();
                        break;
                    case 3:
                        WithDrawMoney(userId);
                        ClickEnterToReturnToMenu();
                        break;
                    case 4:
                        InsertMoney(userId);
                        ClickEnterToReturnToMenu();
                        break;
                    case 5:
                        userId = GetLoggedInUser();
                        ClickEnterToReturnToMenu();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                }
            }
        }
        static int GetLoggedInUser()
        {
            Console.WriteLine("Välkommen till Varbergs Sparbank");

            int userId = 5;

            bool errorMessage = false;

            for (int i = 0; i < 3; i++) //Loop som ger tre försök till inlogg
            {
                Console.WriteLine("Skriv ditt användarnamn: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Skriv din fyrasiffriga pinkod: ");
                string userPass = Console.ReadLine();

                for (int j = 0; j < 5; j++) //Loop som jämför userName&&userPass med elementen i arrayen.
                {
                    if (users[j, 0] == userName && users[j, 1] == userPass) //Om elementen i Array stämmer överens med input
                    {
                        userId = j; //userId får samma värde som J så att vi kan följa vilken användare som är inloggad

                        //i och j får nya värden så vi hoppar ur looparna
                        i = 3;
                        j = 11;
                    }
                    else
                    {
                        errorMessage = true;
                    }

                }

                if (errorMessage && i < 2) //felmeddelande som bara kommer de 2 första iterationerna i yttre loop.
                {
                    Console.WriteLine("Du har slagit fel användarnamn eller pinkod, försök igen!");
                }
            }
            if (userId == 5) //felmeddelande som kommer efter 3 felaktiga inloggningsförsök
            {
                Console.WriteLine("Tyvärr, du har slagit fel användarnamn eller lösenord tre gånger." +
                    "vänligen starta om programmet");
            }

            return userId;
        }

        static bool CheckPin(int userId) //Metod för att endast kolla pin kod
        {



            bool pinCorrect = false;


            for (int i = 0; i < 3; i++) //3 försök att skriva rätt pin
            {
                Console.WriteLine("Skriv din fyrasiffriga pinkod: ");
                string userPass = Console.ReadLine();

                if (users[userId, 1] == userPass) //Om elementen i Array stämmer överens med input så gör vi return
                {
                    pinCorrect = true;
                    return pinCorrect;
                }

                Console.WriteLine("Fel kod, pröva igen: ");
            }


            pinCorrect = false; //om vi kommer utanför for-loopen så har vi skrivit fel 3 gånger
            return pinCorrect;


        }

        static decimal[,] TransferMoney(int userId) //Metod för att föra över pengar mellan konton
        {

            PrintAllBalances(userId); //Printa ut kundens saldo med

            //Skapar variablar utanför kodblock
            int fromAccount = 0;
            int toAccount = 0;
            decimal transferSum = 0;

            //initierar bools och tilldelar till false till TryParsemetod
            bool parseSuccess = false;


            while (parseSuccess == false)
            {
                Console.WriteLine("Välj det konto du vill överföra ifrån: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out fromAccount);

                if (parseSuccess == false)
                {
                    Console.WriteLine("Du måste skriva en siffra, försök igen! ");
                }
            }

            parseSuccess = false;

            while (parseSuccess == false)
            {
                Console.WriteLine("Välj det konto du vill överföra till: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out toAccount);

                if (parseSuccess == false)
                {
                    Console.WriteLine("Du måste skriva en siffra, försök igen! ");
                }
            }

            parseSuccess = false;

            while (parseSuccess == false)
            {
                Console.WriteLine("Välj summa du vill föra över: ");
                parseSuccess = decimal.TryParse(Console.ReadLine(), out transferSum);

                if (parseSuccess == false)
                {
                    Console.WriteLine("Du måste skriva en siffra, försök igen! ");
                }
            }



            if (fromAccount == 1 && toAccount == 2)
            {
                accountBalance[userId, 0] = accountBalance[userId, 0] - transferSum;
                accountBalance[userId, 1] = accountBalance[userId, 1] + transferSum;
            }
            else if (fromAccount == 2 && toAccount == 1)
            {
                accountBalance[userId, 0] = accountBalance[userId, 0] + transferSum;
                accountBalance[userId, 1] = accountBalance[userId, 1] - transferSum;
            }

            Console.WriteLine("Dina nya saldon är: ");
            PrintAllBalances(userId);

            return accountBalance;

        }
        static decimal[,] WithDrawMoney(int userId) //Metod för att ta ut pengar
        {


            PrintAllBalances(userId);

            Console.WriteLine("Från vilket konto vill du ta ut pengar ifrån?");
            int fromAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Hur mycket pengar vill du ta ut?");
            int withdrawAmount = int.Parse(Console.ReadLine());

            bool pinCodeCorrect = CheckPin(userId);

            if (pinCodeCorrect == false)
            {
                return accountBalance;
            }

            fromAccount = fromAccount - 1;

            accountBalance[userId, fromAccount] = accountBalance[userId, fromAccount] - withdrawAmount;

            Console.WriteLine($"Du har tagit ut {withdrawAmount} kronor");

            Console.WriteLine("Återstående mängd: ");
            PrintBalance(userId, fromAccount);

            return accountBalance;

        }

        static decimal[,] InsertMoney(int userId) //Metod för att ta ut pengar
        {


            PrintAllBalances(userId);

            Console.WriteLine("Från vilket konto vill du sätta in pengar till ?");
            int fromAccount = int.Parse(Console.ReadLine());


            Console.WriteLine("Hur mycket pengar vill du sätta in? ");
            int insertAmount = int.Parse(Console.ReadLine());

            fromAccount = fromAccount - 1;

            accountBalance[userId, fromAccount] = accountBalance[userId, fromAccount] + insertAmount;

            Console.WriteLine($"Du har satt in {insertAmount} kronor ");

            Console.WriteLine(" Mängd: ");
            PrintBalance(userId, fromAccount);

            return accountBalance;

        }


        static void PrintAllBalances(int userId) //Skriv ut konto saldon
        {
            Console.WriteLine($"1. {accountTitles[userId, 0]} : {accountBalance[userId, 0]} kronor");
            Console.WriteLine($"2. {accountTitles[userId, 1]} : {accountBalance[userId, 1]} kronor");
        }
        static void PrintBalance(int userId, int fromAccount) //Skriv ut personkonto saldo
        {

            Console.WriteLine($"{accountTitles[userId, fromAccount]} : {accountBalance[userId, fromAccount]} kronor");


        }

        static void ClickEnterToReturnToMenu() //WriteLine metod för att ha mindre kod i huvudmenu
        {
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadLine();

        }


    }
}
