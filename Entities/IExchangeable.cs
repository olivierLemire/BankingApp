using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Entities
{
    interface IExchangeable
    {
        string USValue(double rate);
    }
}
