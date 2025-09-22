using Microsoft.AspNetCore.Mvc;
using CSharpStuff.Models;

namespace CSharpStuff.Controllers
{
    public class RectangleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public JsonResult RectangleAPC(RectangleViewModel model) {
            var rect = new RectangleViewModel { Length = model.Length, Width = model.Width };
            
            double result = 0;

            if (model.BtnType == "area") { 
                result = rect.Area();
            } else if (model.BtnType == "perimeter") { 
                result = rect.Perimeter();
            }

            model.Result = result;

            return Json(model);
        }
    }
}
