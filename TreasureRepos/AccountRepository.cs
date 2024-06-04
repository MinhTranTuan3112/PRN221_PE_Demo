using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureBO;
using TreasureDAOs;

namespace TreasureRepos
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository()
        {
           
        }

        public Account? GetAccount(string username, string password)
        {
            return AccountDAO.Instance.GetAccount(username, password);
        }
    }
}
