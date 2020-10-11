using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Entities
{
    public abstract class Account : IAccount
    {
        public double startBalance { get; set;  }
        public double currentBalance { get; set; }

        public double totalDeposits = 0.0;

        public int numDeposits = 0;

        public double totalWithdrawals = 0.0;

        public int numWithdrawals = 0;
        public double annualRate { get; set; }
        public double monthlyCharge { get; set; }
        public enum accountStatus
        {
            Active,
            Inactive
        }

        public virtual void MakeDeposit(double depositAmount)
        {
            currentBalance = currentBalance + depositAmount;
            totalDeposits = totalDeposits + depositAmount;
            numDeposits++;
        }

        public virtual void MakeWithdraw(double withdrawAmount)
        {
            currentBalance = currentBalance - withdrawAmount;
            totalWithdrawals = totalWithdrawals + totalWithdrawals;
            numWithdrawals++;
        }

        public double CalculateInterest()
        {
            double monthlyInterestRate = annualRate / 12;
            double monthlyInterest = currentBalance * monthlyInterestRate;
            return monthlyInterest;
        }

        public virtual string CloseAndReport()
        {
            currentBalance = currentBalance - monthlyCharge;
            double finalBalance = CalculateInterest();
            int finalNumDeposits = numDeposits;
            int finalNumWithdrawals = numWithdrawals;
            double finalDeposits = totalDeposits;
            double finalWithdrawals = totalWithdrawals;
            numDeposits = 0;
            numWithdrawals = 0;
            monthlyCharge = 0;
            totalWithdrawals = 0;
            totalDeposits = 0;
            return "Previous balance : " + startBalance.toNAMoneyFormat(false) +
                   "\nNew Balance : " + finalBalance.toNAMoneyFormat(false) +
                   "\nDeposits : " + finalDeposits.toNAMoneyFormat(false) + " in " + finalNumDeposits + " Deposits"+
                   "\nWithdrawals : " + finalWithdrawals.toNAMoneyFormat(false) + " in " + finalNumWithdrawals + " WithDrawals" +
                   "\nPercentage of change in Balance : " + this.getPercentageChange() +
                   "\nApplied Interest : " + CalculateInterest().toNAMoneyFormat(false);
        }

        public Account(double startB, double annualR)
        {
            this.startBalance = startB;
            this.annualRate = annualR;
        }
    }
}
