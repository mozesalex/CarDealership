using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.SortStrategy
{
    class SortDescending : ISortStrategy
    {
        public List<Car> Sort(List<Car> cars)
        {
            cars.Sort((car1, car2) => car2.Price.CompareTo(car1.Price));
            return cars;
        }
    }
}
