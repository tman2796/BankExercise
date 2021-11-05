using System;
using System.Linq;

namespace AutoVinBankCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bankOfAmerica = new("Bank of America");

            InvestmentAccount testInvestAccount = new("TestInvestIndividual", true);

            bankOfAmerica.InvestmentAccounts.Add(testInvestAccount);

            var testIndividualInvestAccount = bankOfAmerica.InvestmentAccounts.Where(w => w.Owner == "TestInvestIndividual").FirstOrDefault();

            Console.WriteLine(testIndividualInvestAccount.Owner);

            Console.WriteLine(testIndividualInvestAccount.IndividualAccountBalance);

            testInvestAccount.Deposit(testIndividualInvestAccount.isIndividual, 8254);

            Console.WriteLine(testIndividualInvestAccount.IndividualAccountBalance);

            testIndividualInvestAccount.CheckingAccount.Deposit(1500);

            testIndividualInvestAccount.Transfer(testIndividualInvestAccount, testIndividualInvestAccount.CheckingAccount, 600, "Checking");


            Console.WriteLine($"{testIndividualInvestAccount.Owner} \n");
            Console.WriteLine($"{testIndividualInvestAccount.IndividualAccountBalance} \n");



            InvestmentAccount testInvest = new("TestInvestCorporate", false);

            bankOfAmerica.InvestmentAccounts.Add(testInvest);

            var testCorporateInvestAccount = bankOfAmerica.InvestmentAccounts.Where(w => w.Owner == "TestInvestCorporate").FirstOrDefault();

            Console.WriteLine($"Corporate account balance is: {testCorporateInvestAccount.CorporateAccountBalance}");

            testCorporateInvestAccount.Deposit(testCorporateInvestAccount.isIndividual,5000);

            testCorporateInvestAccount.Transfer(testCorporateInvestAccount, testCorporateInvestAccount.CheckingAccount, 450, "Checking");

            testCorporateInvestAccount.Withdrawal(testCorporateInvestAccount.isIndividual, 780);

            Console.WriteLine($"{testCorporateInvestAccount.Owner} \n");
            Console.WriteLine($"{testCorporateInvestAccount.CorporateAccountBalance} \n");

            CheckingAccount testChecking = new CheckingAccount("TestChecking");
            bankOfAmerica.CheckingAccounts.Add(testChecking);

            var testCheckingAccount = bankOfAmerica.CheckingAccounts.Where(w => w.Owner == "TestChecking").FirstOrDefault();

            Console.WriteLine($"Checking account balance is: {testCheckingAccount.CheckingAccountBalance}");

            testCheckingAccount.Deposit(1954);
            testCheckingAccount.Withdrawal(54);
            testCheckingAccount.Transfer(testCheckingAccount.InvestmentAccount, testCheckingAccount, 150, "Investment");
            Console.WriteLine($"Checking account owner: {testCheckingAccount.Owner} \n");
            Console.WriteLine($"Checking account balance is now: {testCheckingAccount.CheckingAccountBalance} \n");
            Console.WriteLine($"Corporate investment account balance is now: {testCheckingAccount.InvestmentAccount.CorporateAccountBalance} \n");
        }
    }
}
