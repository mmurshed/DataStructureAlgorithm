using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithm.NUnit
{
	[TestFixture()]
    public class SpiralMatrixTest
    {
		[TestCaseSource(nameof(TestCases))]
        public void Test(int[,] matrix, int[] expected)
        {
            // Arrange
			var itw = new Algorithm.MicrosoftProblems.SpiralMatrix();

            // Act
			var result = itw.SpiralOrder(matrix);

            // Assert
			CollectionAssert.AreEqual(expected, result);
        }

		static object[] TestCases =
        {
			new object[]
            {
                new int[,]
                {
                    { 0, 1, 2}
                },
                new int[] { 0, 1, 2}
            },
			new object[]
            {
                new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 }
                },
                new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }
            },
			new object[]
            {
                new int[,]
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 }
                },
                new int[] { 0, 1, 2, 3, 7, 11, 10, 9, 8, 4, 5, 6 }
            },
			new object[]
            {
                new int[,]
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
					{ 12, 13, 14, 15 }
                },
                new int[] { 0, 1, 2, 3, 7, 11, 15, 14, 13, 12, 8, 4, 5, 6, 10, 9 }
            },        
			new object[]
            {
                new int[,]
                {
                    { 0, 1, 2},
                    { 4, 5, 6 },
                    { 8, 9, 10 },
                    { 12, 13, 14 }
                },
                new int[] { 0, 1, 2, 6, 10, 14, 13, 12, 8, 4, 5, 9 }
            },
			new object[]
            {
                new int[,]
				{
					{0},
					{1},
					{2}
                },
                new int[] { 0, 1, 2}
            },        
            new object[]
            {
                new int[,]
                {
                    {0}
                },
                new int[] {0}
            },
			new object[]
            {
                new int[,]
                {
                    {}
                },
                new int[] {}
            }
		};
    }
}
