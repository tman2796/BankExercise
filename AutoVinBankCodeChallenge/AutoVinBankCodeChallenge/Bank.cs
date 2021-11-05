using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVinBankCodeChallenge
{
    class Bank
    {
        public List<Account> AllAccounts { get; set; } = new List<Account>();
        public string Name { get; set; }
        public List<InvestmentAccount> InvestmentAccounts { get; set; } = new List<InvestmentAccount>();
        public List<CheckingAccount> CheckingAccounts { get; set; } = new List<CheckingAccount>();
        public Bank(string name)
        {
            Name = name;
        }
    }
}
