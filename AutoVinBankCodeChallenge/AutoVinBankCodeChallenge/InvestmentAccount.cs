using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVinBankCodeChallenge
{
    class InvestmentAccount : Account
    {
        public bool isIndividual{ get; set; }
        public double IndividualAccountBalance { get; set; }
        public double CorporateAccountBalance { get; set; }

        public InvestmentAccount()
        {

        }
        public InvestmentAccount(string owner)
        {
            Owner = owner;
        }

        public InvestmentAccount(string owner, bool individual, bool corporate)
        {
            Owner = owner;
            isIndividual = individual;
            IndividualAccountBalance = 0.0;
            CorporateAccountBalance = 0.0;
            CheckingAccount = new CheckingAccount(owner);
        }

        public void Deposit(bool isIndividualAccount, double depositAmount)
        {
            if (isIndividualAccount)
            {
                IndividualAccountBalance += depositAmount;
                Console.WriteLine($"Deposited {depositAmount} successfully into individual investment account - new balance is {IndividualAccountBalance}");
            }
            if (!isIndividualAccount)
            {
                CorporateAccountBalance += depositAmount;
                Console.WriteLine($"Deposited {depositAmount} successfully into Corporate investment account - new balance is {CorporateAccountBalance}");
            }

        }

        public void Withdrawal(bool isIndividualAccount,double withdrawalAmount)
        {
            try
            {
                if (!isIndividualAccount)
                {
                    if (withdrawalAmount < CorporateAccountBalance)
                    {
                        CorporateAccountBalance -= withdrawalAmount;
                        Console.WriteLine($"Successfully withdrew {withdrawalAmount} and new Corporate investment account balance is {CorporateAccountBalance}");
                    }
                }
                if (withdrawalAmount < 500 && isIndividual)
                {
                    if (isIndividualAccount && withdrawalAmount <= IndividualAccountBalance)
                    {
                        IndividualAccountBalance -= withdrawalAmount; 
                        Console.WriteLine($"Successfully withdrew {withdrawalAmount} and new Individual investment account balance is {IndividualAccountBalance}");
                    }
                    else
                    {
                        Console.WriteLine("Not enough money to withdrawal");
                    }
                }
                else
                {
                    Console.WriteLine("Max withdrawal amount is $500 on individual investment accounts");
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Error occurred: {ex}");
            }
        }
    }
}
