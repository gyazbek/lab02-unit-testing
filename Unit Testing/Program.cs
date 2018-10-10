using System;

namespace Unit_Testing
{
    public class Program
    {

        // ATM "Global" variable
        static decimal balance = 1000m;

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
            
            bool prompt = true;
            while (prompt)
            {
                Console.WriteLine(UIChoices());
                try
                {
                    int choice = ProcessChoice(Console.ReadLine());
                    switch (choice)
                    {

                        case 1:
                            Console.WriteLine("Your balance is ${0}\n", balance);
                            break;
                        case 4:
                            prompt = false;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid inputformat");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid selection");
                }
            }
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
