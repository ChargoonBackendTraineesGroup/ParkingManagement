namespace Parking
{
    internal class Bike : Vehicle, IParkable
    {
        internal Bike(ulong _ID)
        {
            ID = _ID;
            Type = VehicleType.Bike;
            EntrancePrice = 30000;
            HourPrice = 10000;
        }
        protected internal override ulong ID { get; }
        protected internal override VehicleType Type { get; }
        public byte EntryHour { get; set; }
        public byte ExitHour { get; set; }
        public double EntrancePrice { get; }
        public double HourPrice { get; }
        public double GetCost() => EntrancePrice + ((ExitHour - EntryHour) * HourPrice);
        public override string ToString() => ScreenMessages.PrintBill(Vehicle.VehicleType.Bike, EntryHour, ExitHour, GetCost());
    }
}
