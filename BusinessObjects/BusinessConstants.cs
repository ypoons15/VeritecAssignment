using System;
using System.Collections.Generic;
using System.Text;

namespace VeritecAssignment.BusinessObjects
{
    public static class BusinessConstants
    {
        public static string PaymentFrequency(EPaymentFrequency frequency)
        {
            switch (frequency)
            {
                case EPaymentFrequency.Weekly:
                    return "per week";
                case EPaymentFrequency.Fortnightly:
                    return "per fortnight";
                case EPaymentFrequency.Monthly:
                    return "per month";
            }

            return string.Empty;
        }

        public const decimal NoOfWeeksInAYear = 52.0m;
        public const decimal NoOfFortnightsInAYear = 26.0m;
        public const decimal NoOfMonthsInAYear = 12.0m;
        public const decimal SuperContributionPercentage = 0.095m;
        public const string  CurrencyFormat = "$#,##0.00;-$#,##0.00;$0";
        public const string  GrossPackageCurrencyFormat = "$#,##0";

    }
}
