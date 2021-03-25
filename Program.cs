using System;

namespace Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            char MainMenuKey;
            while(true)
            {
                //Main menu texts
                ScreenMessages.PrintMainMenuTexts();
                MainMenuKey = Console.ReadKey().KeyChar;
                switch (MainMenuKey)
                {
                    case '1':
                        //Add new vehice menu texts
                        ScreenMessages.PrintAddMenuTexts();
                        char AddMenuKey = Console.ReadKey().KeyChar;
                        switch (AddMenuKey)
                        {
                            case '1':
                                ScreenMessages.PrintAddVehicleMenuText("Car");
                                ParkingManager.AddVehicle(Vehicle.VehicleType.Car);
                                break;
                            case '2':
                                ScreenMessages.PrintAddVehicleMenuText("Bike");
                                ParkingManager.AddVehicle(Vehicle.VehicleType.Bike);
                                break;
                            default:
                                ScreenMessages.PrintErrorMessage();
                                break;
                        }
                        break;
                    case '2':
                        //Remove vehicle menu texts
                        ScreenMessages.PrintRemoveMenuTexts();
                        ParkingManager.RemoveVehicle();
                        break;
                    case '3':
                        //Feature vehicle menu texts
                        ScreenMessages.PrintFeaturesMenuTexts();
                        char FeatureKey =Console.ReadKey().KeyChar;
                        switch (FeatureKey)
                        {
                            case '1':
                                ParkingManager.PrintTotalIncome();
                                break;
                            case '2':
                                ParkingManager.PrintTotalVehicles();
                                break;
                            default:
                                ScreenMessages.PrintErrorMessage();
                                break;
                        }
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                    default:
                        ScreenMessages.PrintErrorMessage();
                        break;
                }
            }
        }
    }
}