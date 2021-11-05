using System;
using System.Linq;

namespace AutoVinBankCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Initializing
            Bank bankOfAmerica = new Bank("Bank of America");

            var testInvestAccount = new InvestmentAccount("TestInvestIndividual",true, false);

            bankOfAmerica.InvestmentAccounts.Add(testInvestAccount);

            var testIndividualInvestAccount = bankOfAmerica.InvestmentAccounts.Where(w => w.Owner == "TestInvestIndividual").FirstOrDefault();

            Console.WriteLine(testIndividualInvestAccount.Owner);
            Console.WriteLine(testIndividualInvestAccount.IndividualAccountBalance);

            testInvestAccount.Deposit(testIndividualInvestAccount.isIndividual, 8254);

            Console.WriteLine(testIndividualInvestAccount.IndividualAccountBalance);

            testIndividualInvestAccount.CheckingAccount.Deposit(1500);


            testIndividualInvestAccount.Transfer(testIndividualInvestAccount, testIndividualInvestAccount.CheckingAccount, 600, "Checking");








            InvestmentAccount testInvest = new InvestmentAccount("TestInvestCorporate", false, true);

            bankOfAmerica.InvestmentAccounts.Add(testInvest);
            var testCorporateInvestAccount = bankOfAmerica.InvestmentAccounts.Where(w => w.Owner == "TestInvestCorporate").FirstOrDefault();

            Console.WriteLine($"Corporate account balance is: {testCorporateInvestAccount.CorporateAccountBalance}");

            testCorporateInvestAccount.Deposit(testCorporateInvestAccount.isIndividual,5000);

            testCorporateInvestAccount.Transfer(testCorporateInvestAccount, testCorporateInvestAccount.CheckingAccount, 450, "Checking");

        }
    }
}
