using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TreasureBO;
using TreasureDAOs;
using TreasureRepos;

namespace PE_PRN221.Pages.SeaAreas
{
    public class EditModel : PageModel
    {
        private readonly ISeaAreaRepository _seaAreaRepository;
        private readonly ICountryRepository _countryRepository;

        public EditModel(ISeaAreaRepository seaAreaRepository, ICountryRepository countryRepository)
        {
            _seaAreaRepository = seaAreaRepository;
            _countryRepository = countryRepository;
        }

        [BindProperty]
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
            SeaArea = seaarea;
            ViewData["CountryId"] = new SelectList(_countryRepository.GetCountries(), "Id", "Id");
            return Page();
        }

        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _seaAreaRepository.UpdateSeaArea(SeaArea.SeaId, SeaArea);

            return RedirectToPage("./Index");
        }

        private bool SeaAreaExists(int id)
        {
            return (_seaAreaRepository.GetSeaAreaById(id) is not null);
        }
    }
}
