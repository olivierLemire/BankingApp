using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Entities
{
    class GlobalSavingsAccount : SavingAccount,IExchangeable
    {

        public GlobalSavingsAccount(double startB, double annualR) : base(startB, annualR)
        {
            startBalance = startB;
            annualRate = annualR;
        }

        public string USValue(double rate)
        {
            double USValue;
            USValue = currentBalance * rate;
            return "USD converted : "+USValue.toNAMoneyFormat(true);
        }
    }
}
