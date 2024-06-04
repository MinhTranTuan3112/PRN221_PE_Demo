using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureBO;

namespace TreasureRepos
{
    public interface IAccountRepository
    {
        Account? GetAccount(string username, string password);
    }
}
