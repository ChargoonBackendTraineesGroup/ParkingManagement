namespace Parking
{
    public interface IParkable
    {
        byte EntryHour { get; set; }
        byte ExitHour { get; set; }
        double EntrancePrice { get; }
        double HourPrice { get; }
        double GetCost();
    }
}