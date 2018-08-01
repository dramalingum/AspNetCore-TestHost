using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHostRepos
{
    public class CarsRepo : ICarsRepo
    {
        public string[] GetCars()
        {
            return new string[] {"Lamborghini Diablo", "Ferrari Countach"};
        }
    }
}
