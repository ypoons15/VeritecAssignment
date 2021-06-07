using System;
using System.Collections.Generic;
using System.Text;
using VeritecAssignment.BusinessObjects;

namespace VeritecAssignment.SalaryPackages
{
    public interface ISalaryPackage
    {
        public SalaryDetails GetSalaryPackage(decimal salaryinput, EPaymentFrequency paymentFrequency);
    }
}
