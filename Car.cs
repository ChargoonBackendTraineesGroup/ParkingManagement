namespace Parking
{
    internal class Car : Vehicle, IParkable
    {
        internal Car(ulong _ID)
        {
            ID = _ID;
            Type = VehicleType.Car;
            EntrancePrice = 50000;
            HourPrice = 20000;
        }
        protected internal override ulong ID { get; }
        protected internal override VehicleType Type { get; }
        public byte EntryHour { get; set; }
        public byte ExitHour { get; set; }
        public double EntrancePrice { get; }
        public double HourPrice { get; }
        public double GetCost() => EntrancePrice + ((ExitHour - EntryHour) * HourPrice);
        public override string ToString() => ScreenMessages.PrintBill(Vehicle.VehicleType.Car, EntryHour, ExitHour, GetCost());
    }
}
