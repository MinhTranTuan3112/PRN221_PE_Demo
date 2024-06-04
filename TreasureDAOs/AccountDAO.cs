using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureBO;

namespace TreasureDAOs
{
    public class AccountDAO
    {
        private readonly TreasureOceanDb2024Context _context;

        private static AccountDAO? instance = null;


        public AccountDAO()
        {
            _context = new TreasureOceanDb2024Context();
        }


        public static AccountDAO Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new AccountDAO(); 
                }

                return instance;
            }
        }

        public Account? GetAccount(string username, string password)
        {
            return _context.Accounts.FirstOrDefault(a => a.UserName == username && a.Password == password);
        }


    }
}
