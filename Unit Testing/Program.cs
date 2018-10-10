using System;

namespace Unit_Testing
{
    public class Program
    {

        // ATM "Global" variable
        decimal balance = 1000m;

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
            Console.WriteLine("Please make a selection: ");
            
            bool prompt = true;
            while (prompt)
            {
                Console.WriteLine(UIChoices());
                Console.ReadLine();
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
                return 0;
            }
        }
        /// <summary>  
        ///  Convenience method containing our ATM Choices for our UI prompt.
        /// </summary>  
        public static string UIChoices()
        {
            return "1) View Balance\n" +
                "2) Withdraw Money\n" +
                "3) Add Money\n" +
                "4) Exit\n";
        }
    }
}
