using CSharpStuff.Controllers;
using CSharpStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStuff.Tests
{
    public class EvenSumControllerUnitTest
    {
        private readonly EvenSumController _evenSumController;

        public EvenSumControllerUnitTest()
        {
            _evenSumController = new EvenSumController();
        }

        [Fact]
        public void Test_Even_Sum()
        {
            var model = new EvenSumViewModel { Num1 = 0, Num2 = 2, Num3 = 4 };

            var res = _evenSumController.EvenSumCalc(model);

            Assert.Equal(6, model.Sum);
        }

        [Fact]
        public void Test_Odd_Sum()
        {
            var model = new EvenSumViewModel { Num1 = 1, Num2 = 3, Num3 = 5 };

            var res = _evenSumController.EvenSumCalc(model);

            Assert.Equal(0, model.Sum);
        }
    }
}
