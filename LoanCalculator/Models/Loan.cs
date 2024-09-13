using System;
using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Models
{
    public class Loan
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive loan amount.")]
        public double LoanAmount { get; set; }

        [Required]
        [Range(0.01, 100.0, ErrorMessage = "Please enter a positive interest rate.")]
        public double InterestRate = 0.25;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive loan term.")]
        public int LoanTerm { get; set; }

        public double MonthlyPayment { get; set; }

        public void CalculateMonthlyPayment()
        {
            double monthlyRate = InterestRate;
            int totalPayments = LoanTerm * 12;

            if (monthlyRate > 0)
            {
                MonthlyPayment = LoanAmount * (monthlyRate * Math.Pow(1 + monthlyRate, totalPayments)) / (Math.Pow(1 + monthlyRate, totalPayments) - 1);
            }
            else
            {
                MonthlyPayment = LoanAmount / totalPayments;
            }
        }
    }
}
