using System;
using OnScreenSizeMarkup.Maui.Helpers;
using Xunit;

namespace OnScreenSizeMarkup.Maui.Tests;


public class ProportionalSizeConverterTests
{
    [Fact]
    public void TestMultiplyWithInt()
    {
        int result = (int)ProportionalSizeConverter.Multiply(typeof(int), 5, 2.0);
        Assert.Equal(10, result);
    }

    [Fact]
    public void TestMultiplyWithDouble()
    {
        double result = (double)ProportionalSizeConverter.Multiply(typeof(double), 16.0, 2);
        Assert.Equal(32.0, result);
    }

    [Fact]
    public void TestMultiplyWithFloat()
    {
        float result = (float)ProportionalSizeConverter.Multiply(typeof(float), 5.5f, 2.0);
        Assert.Equal(11.0f, result);
    }

    [Fact]
    public void TestMultiplyWithLong()
    {
        long result = (long)ProportionalSizeConverter.Multiply(typeof(long), 5L, 2.0);
        Assert.Equal(10L, result);
    }

    [Fact]
    public void TestMultiplyWithShort()
    {
        short result = (short)ProportionalSizeConverter.Multiply(typeof(short), 5, 2.0);
        Assert.Equal(10, result);
    }

    [Fact]
    public void TestMultiplyWithDecimal()
    {
        decimal result = (decimal)ProportionalSizeConverter.Multiply(typeof(decimal), 5.5m, 2.0);
        Assert.Equal(11.0m, result);
    }

    [Fact]
    public void TestMultiplyWithUnsupportedType()
    {
        Assert.Throws<NotSupportedException>(() => ProportionalSizeConverter.Multiply(typeof(string), "5", 2.0));
    }
}