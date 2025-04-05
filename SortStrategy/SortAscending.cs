using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.SortStrategy
{
    class SortAscending : ISortStrategy
    {
        public List<Car> Sort(List<Car> cars)
        {
            cars.Sort((car1, car2) => car1.Price.CompareTo(car2.Price));
            return cars;
        }
    }
}
