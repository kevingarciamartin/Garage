




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

        internal static void PrintMenu()
        {
            WriteLine("Main Menu"
                + "\n1. List all parked vehicles."
                + "\n2. List the amount of each vehicle type currently in the garage."
                + "\n3. Add a vehicle to the garage."
                + "\n4. Remove a vehicle from the garage."
                + "\n5. Search a specific vehicle by registration number."
                + "\n6. Search vehicles by one or more characteristics."
                + "\n0. Exit the application.");
        }

        internal static void WriteLine(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
        
    }
}