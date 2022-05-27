using HRApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAllCountry();
    }
}
