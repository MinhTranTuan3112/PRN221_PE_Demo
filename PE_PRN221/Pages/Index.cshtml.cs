using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TreasureRepos;

namespace PE_PRN221.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        [BindProperty(Name = "username")]
        public string Username { get; set; } = string.Empty;

        [BindProperty(Name = "password")]
        public string Password { get; set; } = string.Empty;

        public IndexModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            var account = _accountRepository.GetAccount(Username, Password);
            if (account is not null)
            {
                Console.WriteLine($"Username: {Username}, Password = {Password}");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }
    }
}
