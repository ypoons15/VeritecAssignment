using System;
using System.Collections.Generic;
using System.Text;

namespace VeritecAssignment.Deductions
{
    public class DeductionsDetails : IDeductions
    {
        private decimal taxableIncome { get; set; } = 0.0m;
        private decimal sumOfDeductions { get; set; } = 0.0m;
        public decimal TotalDeductions => sumOfDeductions;
        private List<DeductionData> deductions { get; set; } = new List<DeductionData>();

        public List<DeductionData> DeductionList => deductions;

        public decimal TaxableIncome => Math.Floor(taxableIncome);

        public void SetTaxableIncome(decimal taxableIncomeAmount)
        {
            taxableIncome = taxableIncomeAmount;
            CalculateDeductions();
        }

        public decimal MedicareLevyAmount
        {
            get
            {
                if (TaxableIncome >= 21336 && TaxableIncome < 26668)
                {
                    return Math.Ceiling((TaxableIncome - 21335m) * 0.1m);
                }

                if (TaxableIncome >= 26669)
                {
                    return Math.Ceiling(TaxableIncome * 0.02m);
                }

                return 0;
            }
        }
        public decimal BudgetRepariLevyAmount
        {
            get
            {
                if (TaxableIncome >= 180001m)
                {
                    return (TaxableIncome - 180000m) * 0.02m;
                }

                return 0;
            }
        }
        public decimal TaxableIncomeAmount
        {
            get
            {
                if (TaxableIncome >= 18201m && TaxableIncome <= 37000m)
                {
                    return (TaxableIncome - 18200m) * 0.19m;
                }

                if (TaxableIncome >= 37001m && TaxableIncome <= 87000m)
                {
                    return ((TaxableIncome - 37000m) * 0.325m) + 3572m;
                }

                if (TaxableIncome >= 87001m && TaxableIncome <= 180000m)
                {
                    return ((TaxableIncome - 87000m) * 0.37m) + 19822m;
                }

                if (TaxableIncome >= 180001m)
                {
                    return ((TaxableIncome - 180000m) * 0.47m) + 54232m;
                }

                return 0;
            }
        }
        private void CalculateDeductions()
        {
            sumOfDeductions = 0.00m;

            //Calculate medical levy
             sumOfDeductions += MedicareLevyAmount;
            deductions.Add(new DeductionData()
            {
                DeductionName = "Medical Levy",
                DeductionAmount = MedicareLevyAmount
            });

            //Calculate Budget Repair Levy
            sumOfDeductions += BudgetRepariLevyAmount;
            deductions.Add(new DeductionData()
            {
                DeductionName = "Budget Repair Levy",
                DeductionAmount = BudgetRepariLevyAmount
            });

            //Calculate Income Tax
            sumOfDeductions += TaxableIncomeAmount;
            deductions.Add(new DeductionData()
            {
                DeductionName = "Income Tax",
                DeductionAmount = TaxableIncomeAmount
            });

        }
    }
}
