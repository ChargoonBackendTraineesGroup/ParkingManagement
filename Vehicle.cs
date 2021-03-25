namespace Parking
{
    public abstract class Vehicle
    {
        protected internal enum VehicleType
        {
            Car,
            Bike
        }
        protected internal abstract ulong ID { get; }
        protected internal abstract VehicleType Type { get; }
    }

}