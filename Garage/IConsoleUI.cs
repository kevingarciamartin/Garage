namespace Garage
{
    internal interface IConsoleUI
    {
        ConsoleKey GetKey();
        void ConfirmExit(string exitable);
        void PrintMainMenu();
        void PrintGarageMenuTitle(string garageName);
        void PrintGarageMenu(string garageName);
        void PrintGetVehicleTypeMenu(string garageName);
        void PrintRemoveVehicleMenu(string garageName);
        void WriteLine(string message);
        void ErrorMessage(Action action);
        void SuccessMessage(Action action);
        string AskForString(string prompt);
        int AskForInt(string prompt);
        int AskForPositiveInt(string prompt);
        int AskForPositiveNonZeroInt(string prompt);
    }
}