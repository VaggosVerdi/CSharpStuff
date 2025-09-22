using Microsoft.AspNetCore.Mvc;
using CSharpStuff.Models;

namespace CSharpStuff.Controllers
{
    public class WordReversalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult WordReverse(WordReversalViewModel model)
        {
            var words = model.Text?.Split(' ');
            
            string reverse = "";

            for (int i = words!.Length - 1; i >= 0; i--)
            {
                reverse += words[i];
                if (i != 0) {
                    reverse += " ";
                }
            }

            model.Reversed = reverse;

            return Json(model);
        }
    }
}
