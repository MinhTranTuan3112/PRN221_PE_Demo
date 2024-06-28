using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureBO;
using TreasureDAOs;

namespace TreasureRepos
{
    public class CountryRepository : ICountryRepository
    {
        public List<Country> GetCountries()
        {
            return CountryDAO.Instance.GetCountries();
        }
    }
}
