using CarDealership.Models;
using System.Data.SqlClient;
using CarDealership.StaticVariables;
using CarDealership.SortStrategy;

namespace CarDealership.LocalDatabase
{
    class DatabaseConnection
    {
        const string connectionString = DatabaseStrings.DatabaseConnection;
        static public void DisplayCars(ISortStrategy sortStrategy = null) 
        {
            try
            {
                List<Car> cars = GetCarsFromDatabase();

                if (cars != null)
                {
                    if (sortStrategy != null) 
                    {
                        cars = sortStrategy.Sort(cars); 
                    }

                    foreach (Car car in cars)
                    {
                        car.DisplayDetails(Dealership.selectedCurrency);
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare: {ex.Message}");
            }
        }
        static public void AddCar()
        {
            try
            {
                Console.Write("Brand: ");
                string brand = Console.ReadLine();
                Console.Write("Model: ");
                string model = Console.ReadLine();
                Console.Write("An: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Pret: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Putere motor: ");
                int enginePower = int.Parse(Console.ReadLine());
                Console.Write("Capacitate motor: ");
                double engineCapacity = double.Parse(Console.ReadLine());
                Console.Write("Tip combustibil: ");
                string engineFuelType = Console.ReadLine();
                Console.Write("Tip transmisie: ");
                string transmissionType = Console.ReadLine();
                Console.Write("Numar trepte: ");
                int transmissionGears = int.Parse(Console.ReadLine());
                Console.Write("Dimensiune roti: ");
                int wheelSize = int.Parse(Console.ReadLine());
                Console.Write("Tip anvelope: ");
                string tireType = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //Obtinem id-urile pentru motoare, transmisii si roti
                    int engineId = InsertEngine(connection, enginePower, engineCapacity, engineFuelType);
                    int transmissionId = InsertTransmission(connection, transmissionType, transmissionGears);
                    int wheelId = InsertWheels(connection, wheelSize, tireType);

                    string query = DatabaseStrings.AddCarQuery;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Brand", brand);
                        command.Parameters.AddWithValue("@Model", model);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@EngineId", engineId);
                        command.Parameters.AddWithValue("@TransmissionId", transmissionId);
                        command.Parameters.AddWithValue("@WheelId", wheelId);

                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Masina adaugata cu succes.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare: {ex.Message}");
            }
        }

        static int InsertEngine(SqlConnection connection, int power, double capacity, string fuelType)
        {
            string query = DatabaseStrings.InsertEngineQuery;
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Power", power);
                command.Parameters.AddWithValue("@Capacity", capacity);
                command.Parameters.AddWithValue("@FuelType", fuelType);
                return (int)command.ExecuteScalar();
            }
        }

        static int InsertTransmission(SqlConnection connection, string type, int gears)
        {
            string query = DatabaseStrings.InsertTransmissionQuery;
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@NumberOfGears", gears);
                return (int)command.ExecuteScalar();
            }
        }

        static int InsertWheels(SqlConnection connection, int size, string tireType)
        {
            string query = DatabaseStrings.InsertWheelsQuery;
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Size", size);
                command.Parameters.AddWithValue("@TireType", tireType);
                return (int)command.ExecuteScalar();
            }
        }

        static public void DeleteCar()
        {
            try
            {
                Console.Write("Introduceti CarId-ul masinii de sters: ");
                int carId = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = DatabaseStrings.DeleteCarQuery;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarId", carId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Masina stearsa cu succes.");
                        }
                        else
                        {
                            Console.WriteLine("Masina nu a fost gasita.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare: {ex.Message}");
            }
        }
        static List<Car> GetCarsFromDatabase()
        {
            List<Car> cars = new List<Car>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = DatabaseStrings.GetCarsQuery;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Car car = new Car(
                                    Convert.ToInt32(reader["CarId"]), 
                                    reader["Brand"].ToString(),
                                    reader["Model"].ToString(),
                                    Convert.ToInt32(reader["Year"]),
                                    Convert.ToDouble(reader["Price"]),
                                    new Engine(Convert.ToInt32(reader["Power"]), Convert.ToDouble(reader["Capacity"]), reader["FuelType"].ToString()),
                                    new Transmission(reader["Type"].ToString(), Convert.ToInt32(reader["NumberOfGears"])),
                                    new Wheels(Convert.ToInt32(reader["Size"]), reader["TireType"].ToString())
                                );

                                cars.Add(car);
                            }
                        }
                    }
                }
                return cars;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare bază de date: {ex.Message}");
                return null;
            }
        }
    }
}
