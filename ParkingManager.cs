using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace Parking
{
    internal class ParkingManager
    {
        internal const byte HourDefaultValue = 25;
        //List of vehicles
        public static List<Vehicle> ExistedVehicleList = new List<Vehicle>();
        public static List<Vehicle> AllVehicleList = new List<Vehicle>();

        //Id generator method
        protected internal static ulong IdGenerator() => (ulong)(AllVehicleList.Count + 1);

        //Add vehicle method
        protected internal static void AddVehicle(Vehicle.VehicleType vehicleType)
        {
            byte EntranceHour = byte.TryParse(Console.ReadLine(), out byte carEntranceHour) ? carEntranceHour : HourDefaultValue;
            if (EntranceHour > 23)
            {
                ScreenMessages.PrintErrorMessage();
            }
            Vehicle vehicle;
            if (vehicleType == Vehicle.VehicleType.Car)
            {
                Car NewCar = new Car(IdGenerator());
                NewCar.EntryHour = EntranceHour;
                vehicle = NewCar;
            }
            else
            {
                Bike NewBike = new Bike(IdGenerator());
                NewBike.EntryHour = EntranceHour;
                vehicle = NewBike;
            }
            ExistedVehicleList.Add(vehicle);
            AllVehicleList.Add(vehicle);
            Console.WriteLine($"New {vehicleType} saved by ID of {vehicle.ID}.\nPress any key to continue.");
        }

        //Remove vehicle methods
        protected internal static void RemoveVehicle()
        {
            ulong Id = ulong.TryParse(Console.ReadLine(), out ulong id) ? id : 0;

            if (Id == 0)
            {
                ScreenMessages.PrintErrorMessage();
                return;
            }
            Vehicle vehicle = ExistedVehicleList.Find(x => x.ID == Id);
            if (vehicle != null)
            {
                if (vehicle.Type == Vehicle.VehicleType.Car) RemoveVehicle<Car>((Car)vehicle);
                if (vehicle.Type == Vehicle.VehicleType.Bike) RemoveVehicle<Bike>((Bike)vehicle);
                return;
            }
            ScreenMessages.PrintErrorMessage();
        }
        private static void RemoveVehicle<TVehicle>(TVehicle vehicle)
            where TVehicle : Vehicle, IParkable
        {
            Console.Write("Enter exit Hour: ");
            byte ExitHour = byte.TryParse(Console.ReadLine(), out byte exitHour) ? exitHour : HourDefaultValue;
            if (ExitHour > vehicle.EntryHour && ExitHour < 25)
            {
                //Exit and entrance hour can be check by DateTime.Now.Hour
                vehicle.ExitHour = ExitHour;
            }
            else
            {
                ScreenMessages.PrintErrorMessage();
                return;
            }
            Console.Clear();
            Console.WriteLine(vehicle.ToString());
            Console.Write("Are you sure to remove? (y/n)");
            char SureEntry = Console.ReadKey().KeyChar;
            Console.Write("\n");
            switch (SureEntry)
            {
                case 'y':
                    ExistedVehicleList.Remove(vehicle);
                    Console.Write("Vehicle removed.\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                case 'n':
                    Console.Write("Ok, press any key to continue.");
                    Console.ReadKey();
                    break;
                default:
                    ScreenMessages.PrintErrorMessage();
                    break;
            }
        }
        public static StringBuilder ExportTxt = new StringBuilder("");

        //Total vehicle printer methods
        protected internal static void PrintTotalVehicles()
        {
            ScreenMessages.PrintTotalVehicleTexts();
            ExportTxt.Clear();
            ExportTxt.Append(" ID       Type      Entrance Hour     Exit Hour         Price         Leaved\n");
            ExportTxt.Append("****     ******     *************     *********     *************     ******\n");
            foreach (Vehicle vehicle in AllVehicleList)
            {
                if (vehicle.Type == Vehicle.VehicleType.Car) ExportTxt.Append(ProduceTotalVehicleText<Car>((Car)vehicle));
                if (vehicle.Type == Vehicle.VehicleType.Bike) ExportTxt.Append(ProduceTotalVehicleText<Bike>((Bike)vehicle));
            }
            Console.WriteLine(ExportTxt);
            Console.Write("\n\n");
            Console.WriteLine("Press 1 to export result in txt file.");
            Console.WriteLine("Press other key to continue.");
            char ExportMenuKey = Console.ReadKey().KeyChar;
            if (ExportMenuKey == '1') Export(ExportTxt.ToString());
        }
        protected internal static string ProduceTotalVehicleText<TVehicle>(TVehicle vehicle)
            where TVehicle:Vehicle,IParkable
        {
            string result = "";
            result += $"{vehicle.ID}".PadLeft(4, ' ');
            result += $"{vehicle.Type}".PadLeft(11, ' ');
            result += $"{vehicle.EntryHour}".PadLeft(18, ' ');
            result += $"{(vehicle.ExitHour == 0 ? "---" : vehicle.ExitHour.ToString())}".PadLeft(14, ' ');
            result += $"{(vehicle.ExitHour == 0 ? "---" : vehicle.GetCost().ToString("#,#"))}".PadLeft(18, ' ');
            result += $"{(vehicle.ExitHour == 0 ? "No" : "Yes")}".PadLeft(11, ' ');
            result += "\n";
            return result;
        }

        //Total income methods
        protected internal static void PrintTotalIncome()
        {
            double Sum = 0;
            foreach (Vehicle vehicle in AllVehicleList)
            {
                if (vehicle.Type == Vehicle.VehicleType.Car) Sum += TotalIncomeCalculator<Car>((Car)vehicle);
                if (vehicle.Type == Vehicle.VehicleType.Bike) Sum += TotalIncomeCalculator<Bike>((Bike)vehicle);
            }
            ScreenMessages.PrintTotalIncomeTexts(Sum);
            Console.ReadKey();
        }
        protected internal static double TotalIncomeCalculator<TVehicle>(TVehicle vehicle)
            where TVehicle : Vehicle,IParkable
        {
            double Sum = 0;
            if (vehicle.ExitHour != 0)
            {
                Sum += vehicle.GetCost();
            }
            else
            {
                /*This will make a wrong answer when entrance hour amount is more than current hour amount
                e.g., (CurrentHour - EntranceHour) * HourPrice < 0 => this is why the answer is wrong*/
                vehicle.ExitHour = (byte)DateTime.Now.Hour;
                Sum += vehicle.GetCost();
                vehicle.ExitHour = 0;
            }
            return Sum;
        }
        protected internal static void Export(string text)
        {
            Console.Clear();
            Console.WriteLine("Please enter path: ");
            string path = Console.ReadLine();
            File.WriteAllText(path, text);
        }
    }
}