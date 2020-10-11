using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Entities
{
    interface IAccount
    {
        void MakeWithdraw(double amount);
        void MakeDeposit(double amount);
        double CalculateInterest();
        string CloseAndReport();

    }
}
