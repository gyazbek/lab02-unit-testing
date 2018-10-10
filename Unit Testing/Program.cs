using System;

namespace Unit_Testing
{
    public class Program
    {

        // ATM "Global" variable
        public static decimal balance = 1000m;

        public static void Main(string[] args)
        {
            UI();
        }

        /// <summary>  
        ///  This method prompts the user for the standard ATM operations.
        /// </summary>  
        public static void UI()
        {
            Console.WriteLine("       ,'``.._   ,'``.\r\n      :,--._:)\\,:,._,.:       HYPNO TOAD\r\n      :`--,''   :`...';\\      FUTURE BANK!\r\n       `,'       `---'  `.\r\n       /                 :\r\n      /                   \\\r\n    ,'                     :\\.___,-.\r\n   `...,---'``````-..._    |:       \\\r\n     (                 )   ;:    )   \\  _,-.\r\n      `.              (   //          `'    \\\r\n       :               `.//  )      )     , ;\r\n     ,-|`.            _,'/       )    ) ,' ,'\r\n    (  :`.`-..____..=:.-':     .     _,' ,'\r\n     `,'\\ ``--....-)='    `._,  \\  ,') _ '``._\r\n  _.-/ _ `.       (_)      /     )' ; / \\ \\`-.'\r\n `--(   `-:`.     `' ___..'  _,-'   |/   `.)\r\n     `-. `.`.``-----``--,  .'\r\n       |/`.\\`'        ,',');\r\n           `         (/  (/");
            
            int choice = 0;
            while (choice != 4)
            {
                Console.WriteLine(UIChoices());
                try
                {
                    choice = ProcessChoice(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Your balance is ${0}\n", balance);
                            break;
                        case 2:
                            Console.WriteLine("How much would you like to withdraw?");
                            try
                            { 
                                decimal money = ProcessMoney(Console.ReadLine());
                                if (WithdrawMoney(money))
                                {
                                    Console.WriteLine("\nTransaction Completed");
                                    UIViewBalance();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid transaction, insufficient funds.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid format, please type in a number.");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Amount cannot be negative.");
                            }
                            
                            break;

                        case 3:
                            Console.WriteLine("How much would you like to deposit?");
                            try
                            {
                                decimal money = ProcessMoney(Console.ReadLine());
                                if (DepositMoney(money)) {
                                    Console.WriteLine("\nTransaction Completed");
                                    UIViewBalance();                             }
                                else
                                {
                                    Console.WriteLine("Cannot deposit zero, please try again.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid format, please type in a number.");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Amount cannot be negative.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("I'm finally richer than those snooty ATM machines!");
                            Console.WriteLine("Wait... I AM AN ATM MACHINE! Good bye.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid selection");
                }
                finally
                {
                    if (choice != 4)
                    {
                        choice = 0;
                    }
                }
            }
        }

        /// <summary>  
        ///  This is a UI helper method to print balance.
        ///  </summary>  
        public static void UIViewBalance()
        {
            Console.WriteLine("Your balance is now ${0}\n", balance);
        }

        /// <summary>  
        ///  This Method deposits money into the account
        ///  </summary>  
        /// <param name="money">decimal</param>
        /// <returns>Returns bool for success/failure.</returns>
        public static bool DepositMoney(decimal money)
        {
            if (money <= 0)
            {
                return false;
            }
            else
            {
                balance += money;
            }
            return true;
        }

        /// <summary>  
        ///  This Method withdraws money if funds are sufficient
        /// </summary>  
        /// <param name="money">decimal</param>
        /// <returns>Returns bool for success/failure.</returns>
        public static bool WithdrawMoney(decimal money)
        {
            if (money < 0 || (balance - money) < 0)
            {
                return false;
            }
            else
            {
                balance -= money;
            }
            return true;
        }

        /// <summary>  
        ///  This Method parses the choice and validates it
        /// </summary>  
        /// <param name="choice">String</param>
        /// <returns>Returns choice.</returns>
        /// <exception cref="System.Exception">Thrown when input is not a valid choice</exception>
        public static int ProcessChoice(string choice)
        {
            try
            {
                int num = int.Parse(choice);
                // check if the number itself is a valid choice
                if (num < 1 || num > 4)
                {
                    throw new Exception("Invalid choice");
                }
                return num;
            }catch (FormatException)
            {
                throw;
            }
        }


        /// <summary>  
        ///  This Method parses the choice and validates it
        /// </summary>  
        /// <param name="money">String</param>
        /// <returns>Returns decimal.</returns>
        /// <exception cref="System.Exception">Thrown when input is not a valid</exception>
        public static decimal ProcessMoney(string money)
        {
            try
            {
                decimal num = decimal.Parse(money);
                // check if the number itself is a valid choice
                if (num < 0)
                {
                    throw new Exception("Negative money not allowed.");
                }
                return num;
            }
            catch (FormatException)
            {
                throw;
            }
        }


        /// <summary>  
        ///  Convenience method containing our ATM Choices for our UI prompt.
        /// </summary>  
        public static string UIChoices()
        {
            return "Please make a selection:\n\n" +
                "1) View Balance\n" +
                "2) Withdraw Money\n" +
                "3) Add Money\n" +
                "4) Exit\n";
        }
    }
}
