using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureBO;

namespace TreasureDAOs
{
    public class CountryDAO
    {
        private readonly TreasureOceanDb2024Context _context;
        private static CountryDAO? _instance = null;

        public CountryDAO()
        {
            _context = new TreasureOceanDb2024Context();
        }

        public static CountryDAO Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new CountryDAO();
                }

                return _instance;
            }
        }

        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }
    }
}
