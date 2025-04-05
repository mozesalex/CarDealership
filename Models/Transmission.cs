namespace CarDealership.Models
{
    class Transmission
    {
        public string Type { get; set; }
        public int NumberOfGears { get; set; }

        public Transmission(string type, int numberOfGears)
        {
            Type = type;
            NumberOfGears = numberOfGears;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Transmission: {Type}, {NumberOfGears} gears");
        }
    }
}
