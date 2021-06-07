using System;
using System.Collections.Generic;
using System.Text;
using VeritecAssignment.BusinessObjects;
using VeritecAssignment.Deductions;

namespace VeritecAssignment.SalaryPackages
{
    public class SalaryPackage : ISalaryPackage
    {
        private EPaymentFrequency paymentFrequency;
        private decimal grossPackage;
        private IDeductions Deductions { get; }
        private decimal superAnnuationContribution => Math.Round((grossPackage / (1 + BusinessConstants.SuperContributionPercentage)) * BusinessConstants.SuperContributionPercentage, 2);

        private decimal taxableIncome => Math.Round(grossPackage - superAnnuationContribution, 2);

        private decimal netIncome => grossPackage - superAnnuationContribution - Deductions.TotalDeductions;

        private decimal payPacketAmount => Math.Round(netIncome / noOfPayIntervalsPerYear, 2);
        private List<DeductionData> DeductionList => Deductions.DeductionList;

        private decimal noOfPayIntervalsPerYear
        {
            get
            {
                switch (paymentFrequency)
                {
                    case EPaymentFrequency.Weekly:
                        return BusinessConstants.NoOfWeeksInAYear;
                    case EPaymentFrequency.Fortnightly:
                        return BusinessConstants.NoOfFortnightsInAYear;
                    case EPaymentFrequency.Monthly:
                        return BusinessConstants.NoOfMonthsInAYear;
                    default:
                        return BusinessConstants.NoOfMonthsInAYear;
                }
            }
        }
        public SalaryPackage(IDeductions deductions)
        {
            Deductions = deductions;
        }
        public SalaryDetails GetSalaryPackage(decimal salaryinput, EPaymentFrequency payFrequency)
        {
            grossPackage = Math.Ceiling(salaryinput);
            paymentFrequency = payFrequency;
            Deductions.SetTaxableIncome(taxableIncome);

            return new SalaryDetails(grossPackage, superAnnuationContribution, taxableIncome, DeductionList, netIncome, payPacketAmount);
        }
    }
}
