using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Dynamic;
using Xunit;
using CSharpStuff.Models;
using CSharpStuff.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CSharpStuff.Tests;

public class RectangleControllerUnitTest
{
    private readonly RectangleController _rectangleController;

    public RectangleControllerUnitTest()
    {
        _rectangleController = new RectangleController();
    }

    public void Dispose() { }

    [Fact]
    public void Test_Rectangle_Area()
    {
        var model = new RectangleViewModel { Length = 5.0, Width = 3.0, BtnType = "area" };

        var res = _rectangleController.RectangleAPC(model);

        Assert.Equal(15, model.Result);
    }

    [Fact]
    public void Test_Rectangle_Width()
    {
        var model = new RectangleViewModel { Length = 5.0, Width = 3.0, BtnType = "perimeter" };

        var res = _rectangleController.RectangleAPC(model);

        Assert.Equal(16, model.Result);
    }
}