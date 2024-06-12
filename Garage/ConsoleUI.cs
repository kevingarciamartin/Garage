







namespace Garage
{
    internal class ConsoleUI
    {

        internal static void Clear()
        {
            Console.Clear();
        }

        internal static void ConfirmExit()
        {
            WriteLine("Are you sure you want to exit the application?"
                + "\n1. Yes."
                + "\n0. No.");
        }

        internal static object GetKey() => Console.ReadKey(intercept: true).Key;

        internal static void PrintMainMenu()
        {
            WriteLine("Main Menu"
                + "\n1. Create a garage."
                + "\n0. Exit the application.");
        }

        internal static void PrintMenu()
        {
            WriteLine("Menu"
                + "\n1. List all parked vehicles."
                + "\n2. List the amount of each vehicle type currently in the garage."
                + "\n3. Add a vehicle to the garage."
                + "\n4. Remove a vehicle from the garage."
                + "\n5. Search a specific vehicle by registration number."
                + "\n6. Search vehicles by one or more characteristics."
                + "\n0. Return to main menu.");
        }

        internal static void WriteLine(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }

        internal static string AskForString(string prompt)
        {
            bool success = false;
            string input;

            do
            {
                Console.Write($"{prompt} ");
                input = Console.ReadLine() ?? string.Empty;
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteLine("You must enter a valid input");
                }
                else
                    success = true;

            } while (!success);

            return input;
        }

        internal static int AskForInt(string prompt)
        {
            do
            {
                var input = AskForString(prompt);

                if (!int.TryParse(input, out int result))
                    WriteLine("You must enter a valid integer.");
                else
                    return result;

            } while (true);
        }
        
    }
}