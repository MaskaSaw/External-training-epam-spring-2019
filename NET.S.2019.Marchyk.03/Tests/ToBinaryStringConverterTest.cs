﻿using System;
using Algorithms;
using NUnit.Framework;

namespace Algorithms.Tests
{
    public class DoubleExtensionsTests
    {
        [TestCase(-255.255, ExpectedResult =
            "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult =
            "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult =
            "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(-2.99952605668139866386179688505E-309,
            ExpectedResult = "1000000000000010001010000010101000000001100001100010000100100011")]
        [TestCase(9.99999999999999854480847716331E4,
            ExpectedResult = "0100000011111000011010011111111111111111111111111111111111111111")]
        [TestCase(-3.76559515811228894122401564611E-155,
            ExpectedResult = "1001111111100000001010000000001000000000000001100010000100100011")]
        [TestCase(double.MinValue, ExpectedResult =
            "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult =
            "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult =
            "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NegativeInfinity, ExpectedResult =
            "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult =
            "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult =
            "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult =
            "0000000000000000000000000000000000000000000000000000000000000000")]
        public string ToBinaryStringTests(double number)
        {
            return number.ConvertToBinaryString();
        }
    }
}
