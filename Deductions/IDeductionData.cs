using System;
using System.Collections.Generic;
using System.Text;

namespace VeritecAssignment.Deductions
{
    interface IDeductionData
    {
        string DeductionName { get; set; }
        decimal DeductionAmount { get; set; }
    }
}

