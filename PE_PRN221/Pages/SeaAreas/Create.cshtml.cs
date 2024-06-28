using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureBO;
using TreasureDAOs;
using TreasureRepos;

namespace PE_PRN221.Pages.SeaAreas
{
    public class CreateModel : PageModel
    {
        private readonly ISeaAreaRepository _seaAreaRepository;
        private readonly ICountryRepository _countryRepository;

        public CreateModel(ISeaAreaRepository seaAreaRepository, ICountryRepository countryRepository)
        {
            _seaAreaRepository = seaAreaRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["CountryId"] = new SelectList(_countryRepository.GetCountries(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public SeaArea SeaArea { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _seaAreaRepository.AddSeaArea(SeaArea);

            return RedirectToPage("./Index");
        }
    }
}
