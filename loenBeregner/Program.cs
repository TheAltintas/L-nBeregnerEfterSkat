using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loenBeregner
{
    using System;

    class Program
    {
        static void Main()
        {
            // Default hourly wage
            decimal hourlyWage = 139m;
            decimal AMPercentage = 0.08m;
            decimal taxDeduction = 4352m;
            decimal taxRate = 0.38m;
            decimal SU = 1824m;

            while (true)
            {

                // Get user input for hours worked
                Console.Write("Indtast antal timer: ");
                int hoursWorked = int.Parse(Console.ReadLine());

                // Optionally get a different hourly wage
                Console.Write("Vil du ændre timelønnen fra standard 139kr? (ja/nej): ");
                string changeWage = Console.ReadLine().ToLower();

                if (changeWage == "ja")
                {
                    Console.Write("Indtast ny timeløn: ");
                    hourlyWage = decimal.Parse(Console.ReadLine());
                }

                // Optionally get a different SU
                Console.Write("Vil du ændre SU satsen fra standard 1824kr?  (ja/nej): ");
                string changeSU = Console.ReadLine().ToLower();

                if (changeSU == "ja")
                {
                    Console.Write("Indtast ny SU sats: ");
                    SU = decimal.Parse(Console.ReadLine());
                }

                // Optionally get a different Tax deduction
                Console.Write("Vil du ændre i dit personfradrag? (ja/nej): ");
                string changeTaxDeduction = Console.ReadLine().ToLower();
                
                if(changeTaxDeduction == "ja")
                {
                    Console.Write("Indtast nyt Personfradrag: ");
                    taxDeduction = decimal.Parse(Console.ReadLine());
                }

                // Calculate gross income
                decimal grossIncome = Math.Round(hoursWorked * hourlyWage, 2);
                Console.WriteLine($"Bruttoløn: {grossIncome} kr");

                // Calculate AM contribution
                decimal AMContribution = Math.Round(AMPercentage * grossIncome, 2);
                Console.WriteLine($"AM-bidrag: {AMContribution} kr");

                // Calculate income after AM contribution
                decimal incomeAfterAM = Math.Round(grossIncome - AMContribution, 2);
                Console.WriteLine($"Løn efter AM-bidrag: {incomeAfterAM} kr");

                // Calculate taxable income
                decimal taxableIncome = Math.Round(incomeAfterAM - taxDeduction, 2);
                Console.WriteLine($"Skattepligtig indkomst: {taxableIncome} kr");

                // Calculate tax
                decimal tax = Math.Round(taxRate * taxableIncome, 2);
                Console.WriteLine($"Skat: {tax} kr");

                // Calculate net income after tax
                decimal netIncomeAfterTax = Math.Round(incomeAfterAM - tax, 2);
                Console.WriteLine($"Nettoindkomst efter skat: {netIncomeAfterTax} kr");

                // Calculate feriepenge
                decimal feriepenge = Math.Round(0.12m * netIncomeAfterTax, 2);
                Console.WriteLine($"Feriepenge: {feriepenge} kr");

                // Total udbetaling
                decimal totalUdbetaling = Math.Round(netIncomeAfterTax + SU, 2);
                Console.WriteLine($"Total udbetaling: {totalUdbetaling} kr");

                // Display the result
                Console.WriteLine($"\nEndelig beregning:");
                Console.WriteLine($"Nettoindkomst efter skat: {netIncomeAfterTax} kr");
                Console.WriteLine($"SU: {SU} kr");
                Console.WriteLine($"Total udbetaling: {totalUdbetaling} kr");
                Console.WriteLine($"Feriepenge: {feriepenge} kr");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

}
