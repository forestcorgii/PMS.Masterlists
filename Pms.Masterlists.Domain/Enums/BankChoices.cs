﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.Domain.Enums
{
    /// <summary>
    /// CHK - Check
    /// LBP - Land Bank of the Philippines
    /// CHB - China Bank
    /// MTAC - Metro Bank Tacloban
    /// MPALO - Metro Bank Palo
    /// </summary>
    public enum BankChoices
    {
        CHK = 000,
        LBP = 100,
        CBC = 101,
        CBC1 = 111,
        MTAC = 102,
        MPALO = 103,
        UCPB = 105,
        UNKNOWN = 126,
    }
}
