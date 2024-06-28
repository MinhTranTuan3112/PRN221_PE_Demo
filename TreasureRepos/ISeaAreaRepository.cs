using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureBO;

namespace TreasureRepos
{
    public interface ISeaAreaRepository
    {
        List<SeaArea> GetSeaAreas();
        void AddSeaArea(SeaArea seaArea);
        void DeleteSeaArea(int seaAreaId);
        void UpdateSeaArea(int seaAreaId, SeaArea seaArea);
        SeaArea? GetSeaAreaById(int id);
    }
}
