using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVinBankCodeChallenge
{
    class CheckingAccount: Account
    {
        public double CheckingAccountBalance { get; set; }
        public CheckingAccount()
        {
        }
        public CheckingAccount(string owner)
        {
            Owner = owner;
            isChecking = true;
            CheckingAccountBalance = 0.0;
            InvestmentAccount = new InvestmentAccount(owner);
        }

        public void Deposit(double depositAmount)
        {
            CheckingAccountBalance += depositAmount;
            Console.WriteLine($"Successfully deposited {depositAmount} into checking account. New balance is {CheckingAccountBalance} \n");
        }
        public void Withdrawal(double withdrawalAmount)
        {
            if (withdrawalAmount <= CheckingAccountBalance)
            {
                CheckingAccountBalance -= withdrawalAmount;
                Console.WriteLine($"Withdrew {withdrawalAmount} and new balance is {CheckingAccountBalance} \n");
            }
            else
            {
                Console.WriteLine("Not enough money to take out");
            }
        }

    }
}
