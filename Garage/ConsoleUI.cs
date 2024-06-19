



namespace Garage
{
    internal class ConsoleUI
    {

        internal static void Clear()
        {
            Console.Clear();
        }
        internal static object GetKey() => Console.ReadKey(intercept: true).Key;

        internal static void ConfirmExit(string exitable = "application")
        {
            WriteLine($"Are you sure you want to exit the {exitable}?"
                + "\n1. Yes."
                + "\n0. No.");
        }

        internal static void PrintMainMenu()
        {
            WriteLine("Main Menu"
                + "\n1. Create a new garage."
                + "\n2. Delete a garage."
                + "\n3. Select a garage."
                + "\n0. Exit the application.");
        }

        private static void PrintGarageMenuTitle(string garageName)
        {
            Console.WriteLine($"Garage '{garageName}'s Menu");
        }

        internal static void PrintGarageMenu(string garageName)
        {
            PrintGarageMenuTitle(garageName);
            WriteLine(
                    "1. List all parked vehicles."
                + "\n2. List the amount of each vehicle type currently in the garage."
                + "\n3. Add a vehicle to the garage."
                + "\n4. Remove a vehicle from the garage."
                + "\n5. Search a specific vehicle by registration number."
                + "\n6. Search vehicles by one or more characteristics."
                + "\n0. Return to main menu.");
        }

        internal static void PrintGetVehicleTypeMenu(string garageName)
        {
            PrintGarageMenuTitle(garageName);
            WriteLine("Choose a vehicle type:"
                + "\n1. Airplane."
                + "\n2. Boat."
                + "\n3. Bus."
                + "\n4. Car."
                + "\n5. Motorcycle.");
        }

        internal static void PrintRemoveVehicleMenu(string garageName)
        {
            PrintGarageMenuTitle(garageName);
            WriteLine("Remove"
                + "\n1. ... the last parked vehicle."
                + "\n2. ... a specific vehicle.");
        }

        internal static void WriteLine(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }

        internal static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            Console.ResetColor();
        }
        
        internal static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLine(message);
            Console.ResetColor();
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
                    ErrorMessage("You must enter a valid input");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return input;
        }

        internal static int AskForInt(string prompt)
        {
            do
            {
                var input = AskForString(prompt);

                if (!int.TryParse(input, out int result))
                    ErrorMessage("You must enter a valid integer.");
                else
                    return result;

            } while (true);
        }
        
        internal static int AskForPositiveInt(string prompt)
        {
            int input;
            do
            {
                input = ConsoleUI.AskForInt(prompt);

                if (input < 0) ConsoleUI.ErrorMessage("Please enter a positive integer.");
            } while (input < 0);

            return input;
        }

        internal static int AskForPositiveNonZeroInt(string prompt)
        {
            int input;
            do
            {
                input = ConsoleUI.AskForInt(prompt);

                if (input <= 0) ConsoleUI.ErrorMessage("Please enter a positive integer.");
            } while (input <= 0);

            return input;
        }
    }
}