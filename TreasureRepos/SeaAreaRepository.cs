using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureBO;
using TreasureDAOs;

namespace TreasureRepos
{
    public class SeaAreaRepository : ISeaAreaRepository
    {
        public void AddSeaArea(SeaArea seaArea)
        {
            SeaAreaDAO.Instance.AddSeaArea(seaArea);
        }

        public void DeleteSeaArea(int seaAreaId)
        {
            SeaAreaDAO.Instance.DeleteSeaArea(seaAreaId);
        }

        public SeaArea? GetSeaAreaById(int id)
        {
            return SeaAreaDAO.Instance.GetSeaAreaById(id);
        }

        public List<SeaArea> GetSeaAreas()
        {
            return SeaAreaDAO.Instance.GetSeaAreas();
        }

        public void UpdateSeaArea(int seaAreaId, SeaArea seaArea)
        {
            SeaAreaDAO.Instance.UpdateSeaArea(seaAreaId, seaArea);
        }
    }
}
