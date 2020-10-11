using System;
using System.Text;
using BankingApp.Entities;

namespace BankingApp
{
    class Application
    {
        static void Main(string[] args)
        {
            SavingAccount SA = new SavingAccount(5, 1.25);
            ChequingAccount CA = new ChequingAccount(5, 1);
            GlobalSavingsAccount GSA = new GlobalSavingsAccount(5, 1.3);
            SA.currentBalance = SA.startBalance;
            CA.currentBalance = CA.startBalance;
            GSA.currentBalance = GSA.startBalance;
            BankMenu();
            string bankOption;
            do
            {
                bankOption = Console.ReadLine();
                BankOption(bankOption, SA, CA, GSA);
            }
            while (bankOption.ToLower() != "q");


        }

        private static void BankMenu() {
            Console.WriteLine("Bank Menu");

            StringBuilder sb = new StringBuilder();

            sb.Append("Select Option");
            sb.Append("\n");
            sb.Append("A: Savings\n");
            sb.Append("B: Checkings\n");
            sb.Append("C: GlobalSavings\n");
            sb.Append("Q: Exit");
            Console.WriteLine(sb);
        }

        private static void BankOption(string option, SavingAccount SA, ChequingAccount CA, GlobalSavingsAccount GSA)
        {
            switch (option.ToLower())
            {
                case "a":
                    OpenSavingsMenu(SA);
                    break;

                case "b":
                    OpenCheckingMenu(CA);
                    break;

                case "c":
                    OpenGlobalSavingsMenu(GSA);
                    break;

                case "q":
                    return;
                    break;

                default:
                    Console.WriteLine("Previously Entered option did not match, try again");
                    BankMenu();
                    break;
            }
        }


        /// <summary>
        /// SAVINGS 
        /// </summary>

        private static void OpenSavingsMenu(SavingAccount SA)
        {
            Console.WriteLine("Savings Menu");

            StringBuilder SM = new StringBuilder();

            SM.Append("Select Option");
            SM.Append("\n");
            SM.Append("A: Deposit\n");
            SM.Append("B: Withdrawal\n");
            SM.Append("C: Close + Report\n");
            SM.Append("R: Return To Bank Menu");
            Console.WriteLine(SM);
            SavingOption(Console.ReadLine(),SA);
        }

        private static void SavingOption(string option, SavingAccount SA)
        {
            switch (option.ToLower())
            {
                case "a":
                    DepositSavings(SA);
                    break;

                case "b":
                    WithdrawSavings(SA);
                    break;

                case "c":
                    Console.WriteLine(SA.CloseAndReport());
                    SA.startBalance = SA.currentBalance;
                    OpenSavingsMenu(SA);
                    break;

                case "r":
                    BankMenu();
                    break;

                default:
                    Console.WriteLine("Previously Entered option did not match, try again");
                    OpenSavingsMenu(SA);
                    break;
            }
        }

        /// <summary>
        /// CHECKING
        /// </summary>

        private static void OpenCheckingMenu(ChequingAccount CA)
        {
            Console.WriteLine("Checkings Menu");

            StringBuilder CM = new StringBuilder();

            CM.Append("Select Option");
            CM.Append("\n");
            CM.Append("A: Deposit\n");
            CM.Append("B: Withdrawal\n");
            CM.Append("C: Close + Report\n");
            CM.Append("R: Return To Bank Menu");
            Console.WriteLine(CM);
            CheckingOption(Console.ReadLine(), CA);
        }

        private static void CheckingOption(string option, ChequingAccount CA)
        {
            switch (option.ToLower())
            {
                case "a":
                    DepositChecking(CA);
                    break;

                case "b":
                    WithdrawChecking(CA);
                    break;

                case "c":
                    Console.WriteLine(CA.CloseAndReport());
                    CA.startBalance = CA.currentBalance;
                    OpenCheckingMenu(CA);
                    break;

                case "r":
                    BankMenu();
                    break;

                default:
                    Console.WriteLine("Previously Entered option did not match, try again");
                    OpenCheckingMenu(CA);
                    break;
            }
        }

        /// <summary>
        /// GLOBAL SAVINGS
        /// </summary>

        private static void OpenGlobalSavingsMenu(GlobalSavingsAccount GSA)
        {
            Console.WriteLine("Global Savings Menu");

            StringBuilder GM = new StringBuilder();

            GM.Append("Select Option");
            GM.Append("\n");
            GM.Append("A: Deposit\n");
            GM.Append("B: Withdrawal\n");
            GM.Append("C: Close + Report\n");
            GM.Append("D: Report Balance in USD");
            GM.Append("R: Return To Bank Menu");
            Console.WriteLine(GM);
            GlobalOption(Console.ReadLine(), GSA);
        }

        private static void GlobalOption(string option, GlobalSavingsAccount GSA)
        {
            switch (option.ToLower())
            {
                case "a":
                    DepositGlobal(GSA);
                    break;

                case "b":
                    WithdrawGlobal(GSA);
                    break;

                case "c":
                    Console.WriteLine(GSA.CloseAndReport());
                    GSA.startBalance = GSA.currentBalance;
                    OpenGlobalSavingsMenu(GSA);
                    break;

                case "d":
                    Console.WriteLine(GSA.USValue(1.25));
                    OpenGlobalSavingsMenu(GSA);
                    break;

                case "r":
                    BankMenu();
                    break;

                default:
                    Console.WriteLine("Previously Entered option did not match, try again");
                    OpenGlobalSavingsMenu(GSA);
                    break;
            }
        }



        private static void DepositSavings(SavingAccount SA)
        {
            Console.WriteLine("Deposit Menu\n");
            Console.WriteLine("How much do you want to Deposit");
            double amount;
            while (!Double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("The amount entered is not in the correct format, try again");
            }
                
            SA.MakeDeposit(amount);
            Console.WriteLine("Done");
            OpenSavingsMenu(SA);


        }

        private static void DepositChecking(ChequingAccount CA)
        {
            Console.WriteLine("Deposit Menu\n");
            Console.WriteLine("How much do you want to Deposit");
            double amount;
            while (!Double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("The amount entered is not in the correct format, try again");
            }
            CA.MakeDeposit(amount);
            Console.WriteLine("Done");
            OpenCheckingMenu(CA);
        }

        private static void DepositGlobal(GlobalSavingsAccount GSA)
        {
            Console.WriteLine("Deposit Menu\n");
            Console.WriteLine("How much do you want to Deposit");
            double amount;
            while (!Double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("The amount entered is not in the correct format, try again");
            }
            GSA.MakeDeposit(amount);
            Console.WriteLine("Done");
            OpenGlobalSavingsMenu(GSA);
        }

        private static void WithdrawSavings(SavingAccount SA)
        {
            Console.WriteLine("Withdrawal Menu\n");
            Console.WriteLine("How much do you want to Withdraw");
            double amount;
            while (!Double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("The amount entered is not in the correct format, try again");
            }
            SA.MakeWithdraw(amount);
            Console.WriteLine("Done");
            OpenSavingsMenu(SA);
        }

        private static void WithdrawChecking(ChequingAccount CA)
        {
            Console.WriteLine("Withdrawal Menu\n");
            Console.WriteLine("How much do you want to Withdraw");
            double amount;
            while (!Double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("The amount entered is not in the correct format, try again");
            }
            CA.MakeWithdraw(amount);
            Console.WriteLine("Done");
            OpenCheckingMenu(CA);
        }

        private static void WithdrawGlobal(GlobalSavingsAccount GSA)
        {
            Console.WriteLine("Withdrawal Menu\n");
            Console.WriteLine("How much do you want to Withdraw");
            double amount;
            while (!Double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("The amount entered is not in the correct format, try again");
            }
            GSA.MakeWithdraw(amount);
            Console.WriteLine("Done");
            OpenGlobalSavingsMenu(GSA);
        }

    }
}
