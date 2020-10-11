using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BankingApp.Entities
{
    public static class Extensions
    {
       public static string toNAMoneyFormat(this double val, bool RoundUp)
        {
            double newVal;
            if(RoundUp)
            {
               newVal = Math.Floor(val * 100) / 100;
            }
            else
            {
                newVal = Math.Ceiling(val * 100) / 100;
            }

            string money = newVal.ToString("C",new CultureInfo("en-US"));

            string NAFormat = String.Format("{0:C2}", money);

            return NAFormat;
        }

        public static string getPercentageChange(this Account acc)
        {
            double percentageVal = (acc.startBalance / acc.currentBalance) * 100;
            double newpercentage = Math.Round(percentageVal, 2);
            string percentage = newpercentage.ToString() + " %";
            return percentage;
        }
    }
}
