using Microsoft.AspNetCore.Mvc;
using CSharpStuff.Controllers;
using CSharpStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStuff.Tests
{
    public class LongestSubstringControllerUnitTest
    {
        private readonly LongestSubstringController _longestController;

        public LongestSubstringControllerUnitTest()
        {
            _longestController = new LongestSubstringController();
        }

        [Fact]
        public void Test_Less_Than_Two_Strings()
        {
            var model = new LongestSubstringViewModel { Strings = new List<string> { "one" } };

            var res = _longestController.Index(model) as ViewResult;

            Assert.Equal("Enter at least two strings..!", model.Result);
        }

        [Fact]
        public void Test_Strings()
        {
            var model = new LongestSubstringViewModel { Strings = new List<string> { "animal", "animation", "and" } };

            var res = _longestController.Index(model) as ViewResult;

            Assert.Equal("an", model.Result);
        }

        [Fact]
        public void Test_No_Common_String()
        {
            var model = new LongestSubstringViewModel { Strings = new List<string> { null, null } };

            var res = _longestController.Index(model) as ViewResult;

            Assert.Equal("Couldn't find a common substring...", model.Result);
        }
    }
}
