using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureBO;
using TreasureDAOs;
using TreasureRepos;

namespace PE_PRN221.Pages.SeaAreas
{
    public class IndexModel : PageModel
    {
        private readonly ISeaAreaRepository _seaAreaRepository;

        public IndexModel(ISeaAreaRepository seaAreaRepository)
        {
            _seaAreaRepository = seaAreaRepository;
        }

        public IList<SeaArea> SeaArea { get;set; } = default!;

        public void OnGet()
        {
            SeaArea = _seaAreaRepository.GetSeaAreas();
        }
    }
}
