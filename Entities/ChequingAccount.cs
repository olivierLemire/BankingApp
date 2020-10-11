using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Entities
{
    class ChequingAccount : Account
    {
        public ChequingAccount(double startB, double annualR) : base(startB, annualR)
        {
            startBalance = startB;
            annualRate = annualR;
        }
        public override void MakeWithdraw(double withdrawAmount)
        {
            if((currentBalance - withdrawAmount) < 0)
            {
                currentBalance = currentBalance - 15;
                Console.WriteLine("Not enough money in the balance, 15$ were charged");
            }
            else {
                base.MakeWithdraw(withdrawAmount);
            }
        }

        public override string CloseAndReport()
        {
            monthlyCharge = (5 + (0.1 * numWithdrawals));
            return base.CloseAndReport();
        }
    }
}
