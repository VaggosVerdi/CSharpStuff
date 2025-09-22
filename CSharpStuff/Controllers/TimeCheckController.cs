using Microsoft.AspNetCore.Mvc;
using CSharpStuff.Models;
using System.Globalization;

namespace CSharpStuff.Controllers
{
    public class TimeCheckController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Time(TimeCheckViewModel model)
        {
            var result = FindTimeRangeOverlap(model.FirstRange, model.SecondRange);

            model.Result = result;

            return Json(model);
        }

        public string FindTimeRangeOverlap(string firstRange, string secondRange) { 
            var (firstStart, firstEnd) = ParseRange(firstRange);
            var (secondStart, secondEnd) = ParseRange(secondRange);

            if (firstStart.Date != secondStart.Date)
            {
                return "No overlap (different days)";
            }

            var overlapStart = firstStart > secondStart ? firstStart : secondStart;
            var overlapEnd = firstEnd < secondEnd ? firstEnd : secondEnd;

            if (overlapStart < overlapEnd) {
                return $"{overlapStart:HH:mm}-{overlapEnd:HH:mm}";
            } else
            {
                return "No overlap";
            }
        }

        private (DateTime start, DateTime end) ParseRange(string input) {
            var parts = input.Split(" - ");
            var start = DateTime.ParseExact(parts[0], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            return (start, end);
        }
    }
}
