Author: Nerisa Santos

Coding Decisions:

The code is divided into 3 Classes (BusinessObjects, Deductions and SalaryPackages).
BusinessObjects contain the constants, enums and the currency formatting.  This will make future changes are easier to maintain.
SalaryPackages contain the calculation of SuperAnnuationContribution, TaxableIncome, NetIncome and PayPocketAmount. The output
SalaryDetails object that breakdown the salaray package details and deductions is also modeled in this class. 
Deductions contain the calculations of Medical Levy, Budget Repair Levy and Income Tax.

The applications also cater invalid user entry by prompting the user with an error that the input entered is invalid.  It will let the user enter
a valid value without restarting the application. 

