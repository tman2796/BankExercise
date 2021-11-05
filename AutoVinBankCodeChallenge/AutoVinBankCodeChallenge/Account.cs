using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVinBankCodeChallenge
{
    abstract class Account
    {
        public string Owner { get; set; }
        public bool isChecking { get; set; }
        public CheckingAccount CheckingAccount { get; set; }
        public InvestmentAccount InvestmentAccount { get; set; }

        public Account()
        {
        }

        public Account(string owner)
        {
            Owner = owner;
        }

        public void Transfer(InvestmentAccount investAccount, CheckingAccount checkingAccount, double transferAmount, string transferToAccount)
        {
            if (transferToAccount.Trim() == "Checking")
            {
                if (investAccount.isIndividual && investAccount.IndividualAccountBalance >= transferAmount)
                {
                    checkingAccount.CheckingAccountBalance += transferAmount;
                    investAccount.IndividualAccountBalance -= transferAmount;
                    Console.WriteLine($"Successfully transferred {transferAmount} from individual investment account to checking. New Checking balance is " +
                        $"{checkingAccount.CheckingAccountBalance} and new balance for individual investment account is {investAccount.IndividualAccountBalance}\n");
                }
                else if(investAccount.CorporateAccountBalance >= transferAmount)
                {
                    checkingAccount.CheckingAccountBalance += transferAmount;
                    investAccount.CorporateAccountBalance -= transferAmount;
                    Console.WriteLine($"Successfully transferred {transferAmount} from corporate investment account to checking. New Checking balance is " +
                        $"{checkingAccount.CheckingAccountBalance} and new balance for corporate investment account is {investAccount.CorporateAccountBalance} \n");
                }
            }
            if (transferToAccount.Trim() == "Investment")
            {
                if (investAccount.isIndividual && checkingAccount.CheckingAccountBalance >= transferAmount)
                {
                    checkingAccount.CheckingAccountBalance -= transferAmount;
                    investAccount.IndividualAccountBalance += transferAmount;
                    Console.WriteLine($"Successfully transferred {transferAmount} from checking account to Individual investment account. " +
                        $"New individual investment account balance is {investAccount.IndividualAccountBalance} and new checking balance is {checkingAccount.CheckingAccountBalance} \n");
                }
                else if(checkingAccount.CheckingAccountBalance >= transferAmount)
                {
                    checkingAccount.CheckingAccountBalance -= transferAmount;
                    investAccount.CorporateAccountBalance += transferAmount;
                    Console.WriteLine($"Successfully transferred {transferAmount} from checking account to Individual investment account. " +
                        $"New individual investment account balance is {investAccount.CorporateAccountBalance} and new checking balance is {checkingAccount.CheckingAccountBalance} \n");
                }
            }
        }
    }
}
