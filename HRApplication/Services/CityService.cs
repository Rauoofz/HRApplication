using HRApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public class CityService:ICityService
    {
        private readonly Data.AppContext context;

        public CityService(Data.AppContext _context)
        {
            context = _context;
        }


        public IEnumerable<City> GetCities()
        {
            try
            {
                return context.cities.ToList();

            }catch(Exception ex)
            {
                return null;
            }
        }

    }
}
