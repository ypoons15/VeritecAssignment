using System;
using System.Collections.Generic;
using System.Text;

namespace VeritecAssignment.Deductions
{
    public interface IDeductions
    {
        public decimal TotalDeductions { get; }

        public List<DeductionData> DeductionList { get; }

        public void SetTaxableIncome(decimal taxableIncome);
    }
}
