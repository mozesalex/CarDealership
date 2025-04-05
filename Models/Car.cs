using CarDealership.StaticStrings;

namespace CarDealership.Models
{
    class Car
    {
        public int CarId { get; set; } 
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public Engine Engine { get; set; }
        public Transmission Transmission { get; set; }
        public Wheels Wheels { get; set; }

        public Car(int carId, string brand, string model, int year, double price, Engine engine, Transmission transmission, Wheels wheels)
        {
            CarId = carId; 
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            Engine = engine;
            Transmission = transmission;
            Wheels = wheels;
        }

        public void DisplayDetails(string currency)
        {
            double convertedPrice = Price;
            string currencySymbol = "EUR";

            if (currency == "RON")
            {
                convertedPrice *= Currency.EurotoRon;
                currencySymbol = "RON";
            }
            else if (currency == "USD")
            {
                convertedPrice *= Currency.EuroToDollar;
                currencySymbol = "USD";
            }

            WriteLine();
            Console.WriteLine($"CarID: {CarId}, {Brand} {Model} - An: {Year}, Pret: {convertedPrice:F2} {currencySymbol}");
            WriteLine();
            Engine.DisplayDetails();
            WriteLine();
            Transmission.DisplayDetails();
            WriteLine();
            Wheels.DisplayDetails();
            WriteLine();
        }
        void WriteLine()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }
    }
}
