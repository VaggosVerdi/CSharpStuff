using Microsoft.AspNetCore.Mvc;
using CSharpStuff.Models;

namespace CSharpStuff.Controllers
{
    public class LongestSubstringController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new LongestSubstringViewModel();
            return View("~/Views/Home/CommonString.cshtml" ,model);
        }
        [HttpPost]
        public IActionResult Index(LongestSubstringViewModel model)
        {
            if (model == null)
            {
                model = new LongestSubstringViewModel();
            }

            if (model.Strings == null || model.Strings.Count < 2)
            {
                model.Result = "Enter at least two strings..!";
                return View("~/Views/Home/CommonString.cshtml", model);
            }

            var result = FindTheLongestCommonString(model.Strings);

            model.Result = string.IsNullOrEmpty(result) ? "Couldn't find a common substring..." : result;
            
            return View("~/Views/Home/CommonString.cshtml", model);
        }

        private string FindTheLongestCommonString(List<string> strings)
        {
            string refer = strings[0];
            int len = 0;
            string longest = string.Empty;

            if (string.IsNullOrEmpty(refer))
            {
                return string.Empty;
            }

            for (int i = 0; i < refer.Length; i++) {
                for (int y = 1; y <= refer.Length - i; y++)
                {
                    string sbs = refer.Substring(i, y);

                    if (strings.All(z => z.Contains(sbs)))
                    {
                        if (sbs.Length > len)
                        {
                            len = sbs.Length;
                            longest = sbs;
                        }
                    }
                }
            }

            return longest;
        }
    }
}
