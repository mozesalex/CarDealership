using CarDealership.LocalDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    class Dealership
    {
        public static string selectedCurrency = "EUR";
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1. Selecteaza moneda (EUR/RON/USD)");
                Console.WriteLine("2. Afiseaza masini");
                Console.WriteLine("3. Adauga masina");
                Console.WriteLine("4. Sterge masina");
                Console.WriteLine("5. Iesire\n");

                Console.Write("Alege o optiune: ");
                string option = Console.ReadLine();
                Console.WriteLine();
                switch (option)
                {
                    case "1":
                        SelectCurrency();
                        break;
                    case "2":
                        DatabaseConnection.DisplayCars();
                        break;
                    case "3":
                        DatabaseConnection.AddCar();
                        break;
                    case "4":
                        DatabaseConnection.DeleteCar();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void SelectCurrency()
        {
            Console.Write("Introduceti moneda (EUR, RON, USD): ");
            string currency = Console.ReadLine().ToUpper();

            if (currency == "EUR" || currency == "RON" || currency == "USD")
            {
                selectedCurrency = currency;
                Console.WriteLine($"Moneda selectata: {selectedCurrency}");
            }
            else
            {
                Console.WriteLine("Moneda invalida.");
            }
        }
    }
}
