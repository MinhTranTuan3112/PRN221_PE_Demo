using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureBO;

namespace TreasureDAOs
{
    public class SeaAreaDAO
    {
        private readonly TreasureOceanDb2024Context _context;

        private static SeaAreaDAO? _instance = null;

        public SeaAreaDAO()
        {

            _context = new TreasureOceanDb2024Context();

        }

        public static SeaAreaDAO Instance { 
            get
            {
                if (_instance is null)
                {
                    _instance = new SeaAreaDAO();
                }

                return _instance;
            }
        }

        public SeaArea? GetSeaAreaById(int id)
        {
            return _context.SeaAreas.SingleOrDefault(s => s.SeaId == id);
        }

        public List<SeaArea> GetSeaAreas()
        {
            return _context.SeaAreas
                .Include(s => s.Country)
                .ToList();
        }

        public void AddSeaArea(SeaArea seaArea)
        {
            if (_context.SeaAreas.Any(s => s.SeaId == seaArea.SeaId))
            {
                return;
            }

            _context.Add(seaArea);
            _context.SaveChanges();
        }

        public void DeleteSeaArea(int seaAreaId)
        {
            var seaArea = _context.SeaAreas.FirstOrDefault(s => s.SeaId == seaAreaId);

            if (seaArea is null)
            {
                return;
            }

            _context.Remove(seaArea);
            _context.SaveChanges();
        }

        public void UpdateSeaArea(int seaAreaId, SeaArea seaArea)
        {
            var seaAreaDb = _context.SeaAreas.SingleOrDefault(s => s.SeaId == seaAreaId);

            if (seaAreaDb is null)
            {
                return;
            }

            seaAreaDb.SeaName = seaArea.SeaName;
            seaAreaDb.Treasure = seaArea.Treasure;
            seaAreaDb.Probability = seaArea.Probability;
            seaAreaDb.Fee = seaArea.Fee;
            seaAreaDb.StartDate = seaArea.StartDate;
            seaAreaDb.ExpiryDate = seaArea.ExpiryDate;
            seaAreaDb.CountryId = seaArea.CountryId;
            _context.SaveChanges();

        }
    }
}
