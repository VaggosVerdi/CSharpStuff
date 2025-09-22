using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Dynamic;
using Xunit;
using CSharpStuff.Models;
using CSharpStuff.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace CSharpStuff.Tests
{
    public class FrequentItemUnitTest
    {
        private readonly HomeController _homeController;

        public FrequentItemUnitTest()
        {
            var nullLogger = NullLogger<HomeController>.Instance;
            _homeController = new HomeController(nullLogger);
        }

        [Fact]
        public void Test_Frequent_Items()
        {
            string[] data = { "Apple", "Banana", "Cherry", "Apple", "Date", "Banana", "Elderberry" };

            var res = _homeController.FindMostFrequentItem(data);

            Assert.Equal(2, res.Count);

            Assert.Contains("Apple", res.Names);

            Assert.Contains("Banana", res.Names);
        }

        [Fact]
        public void Test_Frequent_Item()
        {
            string[] data = { "Test", "This", "Test", "That", "Test", "Everything" };

            var res = _homeController.FindMostFrequentItem(data);

            Assert.Single(res.Names);

            Assert.Equal(3, res.Count);

            Assert.Contains("Test", res.Names);
        }

        [Fact]
        public void Test_Frequent_Index()
        {
            var res = _homeController.Index() as ViewResult;

            Assert.NotNull(res);

            Assert.NotNull(res.ViewData["Name"]);

            Assert.NotNull(res.ViewData["Count"]);

            string names = res.ViewData["Name"].ToString();
            int count = (int)res.ViewData["Count"];

            Assert.Contains("Apple", names);

            Assert.Contains("Banana", names);

            Assert.Equal(2, count);
        }
    }
}
