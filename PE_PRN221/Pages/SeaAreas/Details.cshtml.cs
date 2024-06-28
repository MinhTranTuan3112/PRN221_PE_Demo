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
    public class DetailsModel : PageModel
    {
        private readonly ISeaAreaRepository _seaAreaRepository;

        public DetailsModel(ISeaAreaRepository seaAreaRepository)
        {
            _seaAreaRepository = seaAreaRepository;
        }

        public SeaArea SeaArea { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seaarea = _seaAreaRepository.GetSeaAreaById(Convert.ToInt32(id));
            if (seaarea == null)
            {
                return NotFound();
            }
            else
            {
                SeaArea = seaarea;
            }
            return Page();
        }
    }
}
