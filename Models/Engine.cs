
namespace CarDealership.Models
{
    class Engine
    {
        public int Power { get; set; }
        public double Capacity { get; set; }
        public string FuelType { get; set; }

        public Engine(int power, double capacity, string fuelType)
        {
            Power = power;
            Capacity = capacity;
            FuelType = fuelType;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Engine: {Power} HP, {Capacity}L, {FuelType}");
        }
    }
}
