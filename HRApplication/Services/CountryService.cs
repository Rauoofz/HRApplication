using HRApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public class CountryService:ICountryService
    {
        private readonly Data.AppContext context;

        public CountryService(Data.AppContext _context)
        {
            context = _context;
        }

        public IEnumerable<Country> GetAllCountry()
        {
           return context.countries.ToList();
        }

    }
}
