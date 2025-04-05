using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.StaticVariables
{
    class DatabaseStrings
    {
        public const string DatabaseConnection = "Server=localhost;Database=CarDealership;Integrated Security=True;"; 
        public const string AddCarQuery = "INSERT INTO Cars (Brand, Model, Year, Price, EngineId, TransmissionId, WheelId) VALUES (@Brand, @Model, @Year, @Price, @EngineId, @TransmissionId, @WheelId)";
        public const string InsertEngineQuery = "INSERT INTO Engines (Power, Capacity, FuelType) OUTPUT INSERTED.EngineId VALUES (@Power, @Capacity, @FuelType)";
        public const string InsertTransmissionQuery = "INSERT INTO Transmissions (Type, NumberOfGears) OUTPUT INSERTED.TransmissionId VALUES (@Type, @NumberOfGears)";
        public const string InsertWheelsQuery = "INSERT INTO Wheels (Size, TireType) OUTPUT INSERTED.WheelId VALUES (@Size, @TireType)";
        public const string DeleteCarQuery = "DELETE FROM Cars WHERE CarId = @CarId";
        public const string GetCarsQuery = "SELECT c.*, e.*, t.*, w.* FROM Cars c JOIN Engines e ON c.EngineId = e.EngineId JOIN Transmissions t ON c.TransmissionId = t.TransmissionId JOIN Wheels w ON c.WheelId = w.WheelId";
    }
}
