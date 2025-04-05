using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.SortStrategy
{
    interface ISortStrategy
    {
        List<Car> Sort(List<Car> cars);
    }
}
