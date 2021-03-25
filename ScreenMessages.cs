using System;

namespace Parking
{
    abstract class ScreenMessages
    {
        internal static void PrintMainMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Soltaaaan Parking".PadLeft(38, ' '));
            Console.WriteLine("Main Menu".PadLeft(34, ' '));
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Press 1 to add new vehicle.");
            Console.WriteLine("Press 2 to remove vehicle.");
            Console.WriteLine("Press 3 to see features list.");
            Console.WriteLine("Press q to close application.");
            Console.Write("Press valid key to continue: ");
        }
        internal static void PrintAddMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine("Add Vehicle Menu".PadLeft(38, ' '));
            Console.WriteLine("************************************************************");
            Console.WriteLine("Press 1 to add new car.");
            Console.WriteLine("Press 2 to add new bike.");
            Console.Write("Press valid key to continue: ");
        }
        internal static void PrintAddVehicleMenuText(string type)
        {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine($"Add {type} Menu".PadLeft(36, ' '));
            Console.WriteLine("************************************************************");
            Console.Write("Enterance hour: ");
        }
        internal static void PrintAddVehicleResultText(string result)
        {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine("Saved New Vehicle Result".PadLeft(42, ' '));
            Console.WriteLine("************************************************************");
            Console.Write(result);
        }
        internal static void PrintRemoveMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Remove Vehicle Menu".PadLeft(38, ' '));
            Console.WriteLine("***********************************************************");
            Console.Write("Enter vehicle ID: ");
        }
        internal static void PrintFeaturesMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Features Menu".PadLeft(35, ' '));
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Press 1 to see total income of calculated settlement of vehicles.");
            Console.WriteLine("Press 2 to see total vehicle list.");
            Console.Write("Press valid key to continue: ");
        }
        internal static void PrintTotalIncomeTexts(double Sum)
        {
            Console.Clear();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Total Income Menu".PadLeft(37, ' '));
            Console.WriteLine("***********************************************************");
            Console.WriteLine($"Total income is {Sum.ToString("#,#")} Rls.");
            Console.Write("Press any key to continue.");
        }
        public static void PrintErrorMessage()
        {
            Console.Clear();
            Console.Write("Invalid entry, please try again.\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void PrintTotalVehicleTexts()
        {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine("Total Vehicle List".PadLeft(39, ' '));
            Console.WriteLine("************************************************************");
        }
        public static string PrintBill(Vehicle.VehicleType type, byte entryHour, byte exitHour, double getCost)
        {
            return $"***********************************************************\n{"Bill".PadLeft(32, ' ')}\n***********************************************************\nType: Bike\nEntry Hour: {entryHour}\nExit Hour: {exitHour}\nTotal Price: {getCost.ToString("#,#")} Rls";
        }
    }
}