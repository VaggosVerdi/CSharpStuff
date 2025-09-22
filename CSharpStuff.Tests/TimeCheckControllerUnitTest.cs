using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Dynamic;
using Xunit;
using CSharpStuff.Models;
using CSharpStuff.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CSharpStuff.Tests
{
    public class TimeCheckControllerUnitTest
    {
        private readonly TimeCheckController _timeCheckController;

        public TimeCheckControllerUnitTest()
        {
            _timeCheckController = new TimeCheckController();
        }

        [Fact]
        public void Test_Returning_Overlap()
        {
            var model = new TimeCheckViewModel { FirstRange = "2025-09-21 00:00 - 2025-09-21 12:00", SecondRange = "2025-09-21 06:00 - 2025-09-21 18:00" };

            var res = _timeCheckController.Time(model);

            Assert.Equal("06:00-12:00", model.Result);
        }

        [Fact]
        public void Test_No_Overlap_Diff_Days()
        {
            var model = new TimeCheckViewModel { FirstRange = "2025-09-21 00:00 - 2025-09-21 12:00", SecondRange = "2025-09-20 06:00 - 2025-09-20 18:00" };

            var res = _timeCheckController.Time(model);

            Assert.Equal("No overlap (different days)", model.Result);
        }

        [Fact]
        public void Test_No_Overlap()
        {
            var model = new TimeCheckViewModel { FirstRange = "2025-09-21 00:00 - 2025-09-21 12:00", SecondRange = "2025-09-21 13:00 - 2025-09-21 23:00" };

            var res = _timeCheckController.Time(model);

            Assert.Equal("No overlap", model.Result);
        }
    }
}
