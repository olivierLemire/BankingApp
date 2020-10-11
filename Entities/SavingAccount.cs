using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Entities
{
    class SavingAccount : Account
    {
        public SavingAccount(double startB, double annualR) : base(startB, annualR)
        {
            startBalance = startB;
            annualRate = annualR;
        }

        public override void MakeWithdraw(double withdrawAmount)
        {
            int status = DefineStatus("withdraw",withdrawAmount);
            if(status == (int)accountStatus.Inactive)
            {
                Console.WriteLine("Your current balance is under 25$, please deposit before withdrawing");
            }
            else 
            {
                base.MakeWithdraw(withdrawAmount);
            }
            
        }

        public override void MakeDeposit(double depositAmount)
        {
            int status = DefineStatus("deposit",depositAmount);
            if (status == (int)accountStatus.Inactive)
            {
                Console.WriteLine("Your current balance is under 25$, please deposit enough to pass this minimum");
            }
            else
            {
                base.MakeDeposit(depositAmount);
            }
        }

        public override string CloseAndReport()
        {
            if(numWithdrawals > 4)
            {
                monthlyCharge = numWithdrawals - 4;
            }
            return base.CloseAndReport();
        }

        public int DefineStatus(string type, double money)
        {
            int status = 0;
            if (type == "withdraw") {
                if (currentBalance < 25)
                {
                    status = 1;
                }
            }
            else if(type == "deposit")
            {
                if ((currentBalance + money) > 25)
                {
                    status = 0;
                }
                else
                {
                    status = 1;
                }
            }
            return status;
        }
    }
}
