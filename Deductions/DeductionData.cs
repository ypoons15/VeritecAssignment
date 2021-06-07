using System;
using System.Collections.Generic;
using System.Text;

namespace VeritecAssignment.Deductions
{
    public class DeductionData : IDeductionData
    {
        public string DeductionName { get; set; }
        public decimal DeductionAmount { get; set; }
    }
}
