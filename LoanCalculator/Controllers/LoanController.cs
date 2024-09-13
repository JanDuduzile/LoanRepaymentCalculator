using Microsoft.AspNetCore.Mvc;
using LoanCalculator.Models;

namespace LoanCalculator.Controllers
{
    public class LoanController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(Loan model)
        {
            if (ModelState.IsValid)
            {
                model.CalculateMonthlyPayment();
                return View("Result", model);
            }
            return View("Index", model);
        }

        
        public IActionResult Result()
        {
            return View();
        }
    }
}
