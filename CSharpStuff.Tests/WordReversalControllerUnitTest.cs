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
    public class WordReversalControllerUnitTest
    {
        private readonly WordReversalController _wordReversalController;

        public WordReversalControllerUnitTest()
        {
            _wordReversalController = new WordReversalController();
        }

        [Fact]
        public void Test_Word_Reversal()
        {
            var model = new WordReversalViewModel { Text = "Hello World" };

            var res = _wordReversalController.WordReverse(model);

            Assert.Equal("World Hello", model.Reversed);
        }

        [Fact]
        public void Test_Empty_Word_Reversal()
        {
            var model = new WordReversalViewModel { Text = "" };

            var res = _wordReversalController.WordReverse(model);

            Assert.Equal("", model.Reversed);
        }
    }
}
