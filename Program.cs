using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VeritecAssignment.BusinessObjects;
using VeritecAssignment.Deductions;
using VeritecAssignment.SalaryPackages;

namespace VeritecAssignment
{
    class Program
    {
        private static decimal _salaryPackageAmount = 0.0m;
        private static EPaymentFrequency _paymentFrequency = EPaymentFrequency.Weekly;
        private static IServiceProvider _serviceProvider;
        private static SalaryDetails _salaryDetails;

        static void Main(string[] args)
        {
            // Create service collection
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            _serviceProvider = serviceCollection.BuildServiceProvider();

            try
            {
                GetAndValidateUserInputs();
                GetSalaryPackage();
                DisplaySalaryPackage();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Write("Press any key to end...");
                Console.ReadKey();
            }
        }

             
        private static void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<ISalaryPackage, SalaryPackage>();
            services.AddScoped<IDeductions, DeductionsDetails>();
        }

        private static bool GetAndValidateUserInputs()
        {
            bool result = false;
            // loop till we get valid salary input
            while (!result)
            {
                Console.Write("Enter your salary package amount: ");
                string salaryInput = Console.ReadLine();
                if (IsDecimal(salaryInput))
                {
                    result = true;
                }
            }
            //initialise result for payment frequency validation
            result = false;
            // loop till we get valid  pay frequency
            while (!result)
            {
                Console.Write("Enter your pay frequency (W for weekly, F for fortnighly, M for monthly): ");
                string paymentFrequencyInput = Console.ReadLine();

                if (IsValidPaymentFrequency(paymentFrequencyInput.ToUpper()))
                {
                    result = true;
                }
            }

            return result;
           
        }
        private static void DisplaySalaryPackage()
        {
           
            Console.WriteLine();
            Console.WriteLine("Calculating salary details...");
            Console.WriteLine();
            Console.WriteLine($"Gross package: {_salaryDetails.GrossPackage.ToString(BusinessConstants.GrossPackageCurrencyFormat)}");
            Console.WriteLine($"Superannuation: {_salaryDetails.SuperAnnuationContribution.ToString(BusinessConstants.CurrencyFormat)}");
            Console.WriteLine();
            Console.WriteLine($"Taxable Income: {_salaryDetails.TaxableIncome.ToString(BusinessConstants.CurrencyFormat)}");
            Console.WriteLine();
            Console.WriteLine("Deductions:");
            foreach (DeductionData dd in _salaryDetails.Deductions)
            {
                Console.WriteLine($"{dd.DeductionName}: {dd.DeductionAmount.ToString(BusinessConstants.CurrencyFormat)}");
            }

            Console.WriteLine();
            Console.WriteLine($"Net income: {_salaryDetails.NetIncome.ToString(BusinessConstants.CurrencyFormat)}");
            Console.WriteLine($"Pay Packet: {_salaryDetails.PayPacketAmount.ToString(BusinessConstants.CurrencyFormat)} {BusinessConstants.PaymentFrequency(_paymentFrequency)}");
            Console.WriteLine();
        }
        private static void GetSalaryPackage()
        {

            ISalaryPackage salaryPackage = _serviceProvider.GetService<ISalaryPackage>();
            _salaryDetails = salaryPackage.GetSalaryPackage(_salaryPackageAmount, _paymentFrequency);
        }

        #region Validations
        private static bool IsDecimal(string input)
        {
            
            if (!decimal.TryParse(input, out _salaryPackageAmount))
            {
                Console.WriteLine($"The input value {input} is not a valid number. Please enter valid number with no commas and $ signs.");
                return false;
            }
            return true;
        }
        private static bool IsValidPaymentFrequency(string input)
        {
            switch (input)
            {
                case "W":
                    _paymentFrequency = EPaymentFrequency.Weekly;
                    return true;
                case "F":
                    _paymentFrequency = EPaymentFrequency.Fortnightly;
                    return true;
                case "M":
                    _paymentFrequency = EPaymentFrequency.Monthly;
                    return true;
                default:
                    Console.WriteLine($"Cannot find payment frequency matching input: '{input}'. Please select (W for weekly, F for fortnighly, M for monthly.");
                    return false;
            }
        }
        #endregion

    }
}
