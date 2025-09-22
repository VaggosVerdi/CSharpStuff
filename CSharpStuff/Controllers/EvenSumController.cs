using Microsoft.AspNetCore.Mvc;
using CSharpStuff.Models;

namespace CSharpStuff.Controllers
{
    public class EvenSumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult EvenSumCalc(EvenSumViewModel model)
        {
            int sum = 0;
            
            int[] numbers = { model.Num1, model.Num2, model.Num3 };

            foreach (var numb in numbers)
            {
                if (numb % 2 == 0)
                    sum += numb;
            }

            model.Sum = sum;

            return Json(model);
        }
    }
}
