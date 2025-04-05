namespace CarDealership.Models
{
    class Wheels
    {
        public int Size { get; set; }
        public string TireType { get; set; }

        public Wheels(int size, string tireType)
        {
            Size = size;
            TireType = tireType;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Wheels: {Size} inch, {TireType}");
        }
    }
}
