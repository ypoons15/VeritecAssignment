using System;
using System.Collections.Generic;
using System.Text;
using VeritecAssignment.Deductions;

namespace VeritecAssignment.SalaryPackages
{
    public class SalaryDetails
    {
        public SalaryDetails(decimal grossPackage, decimal superAnnuationContribution, decimal taxableIncome, List<DeductionData> deductions, decimal netIncome, decimal payPacketAmount)
        {
            GrossPackage = grossPackage;
            SuperAnnuationContribution = superAnnuationContribution;
            TaxableIncome = taxableIncome;
            Deductions = deductions;
            NetIncome = netIncome;
            PayPacketAmount = payPacketAmount;
        }

        public decimal GrossPackage { get; }

        public decimal SuperAnnuationContribution { get; }

        public decimal TaxableIncome { get; }

        public List<DeductionData> Deductions { get; }

        public decimal NetIncome { get; }

        public decimal PayPacketAmount { get; }
    }
}
