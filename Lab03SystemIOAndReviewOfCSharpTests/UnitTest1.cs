using System;
using Xunit;
using static Lab03SystemIOAndReviewOfCSharp.Program;

namespace Lab03SystemIOAndReviewOfCSharpTests
{
    public class UnitTestsForChallenge1
    {
        [Fact]
        public void CanReturnZeroWhenLengthIsLessThanThree()
        {
            // Arrange
            string input = "cat";
            // Act
            int outputFromMethod = MultiplyInputNumber(input);
            // Assert
            Assert.Equal(0, outputFromMethod);
        }

        [Fact]
        public void CanReturnProductWhenLengthGreaterThanOrEqualToThree()
        {
            // Arrange
            string numbers = "2 3 4";
            // Act
            int outputFromMethod = MultiplyInputNumber(numbers);
            // Assert
            Assert.Equal(24, outputFromMethod);
        }

        [Theory]
        [InlineData("4 8 15 16", 480)]
        [InlineData("1 1 1", 1)]
        [InlineData("cat dog 5", 5)]
        [InlineData("Razzle Leo", 0)]
        [InlineData("22 11", 0)]
        [InlineData("-10 -22 1", 220)]
        public void CanReturnProperProduct(string numbers, int product)
        {
            // Arrange & Act
            int outputFromMethod = MultiplyInputNumber(numbers);
            // Assert
            Assert.Equal(product, outputFromMethod);
        }       

    }

    public class UnitTestsForChallenge2
    {
        [Fact]
        public void CanReturnTheAverage()
        {
            // Arrange
            int[] testArray = { 1, 2, 3, 4 };
            // Act
            decimal calledMethod = GetAverage(testArray);
            // Assert
            Assert.Equal(2.5m, calledMethod);
        }

        [Theory]
        [InlineData(new int[] {5, 6, 9, 2}, 5.5)]
        [InlineData(new int[] { 18, 11, 1 }, 10)]
        [InlineData(new int[] { 9, 24, 33, 91, 7 }, 32.8)]
        [InlineData(new int[] { 0, 0, 0, 0 }, 0)]
        public void CanReturnValidAverages(int[] numbers, decimal expectedAverage)
        {
            //Arrange & Act
            decimal outputFromMethod = GetAverage(numbers);
            //Assert
            Assert.Equal(expectedAverage, outputFromMethod);
        }

    }

    public class UnitTestsForChallenge4
    {
        [Fact]
        public void CanReturnExample()
        {
            // Arrange
            int[] testArray = new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };
            // Act
            int methodOutput = MostDuplicates(testArray);
            // Assert
            Assert.Equal(1, methodOutput);
        }

        [Theory]
        [InlineData(new int[] { 5, 5, 5, 4, 4, 1 }, 5)]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, 1)]
        [InlineData(new int[] { 3, 3, 2, 2 }, 3)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 1)]
        public void CanReturnExpectedResults(int[] inputArray, int expectedOutput)
        {
            //Arrange
            //Act
            int methodCall = MostDuplicates(inputArray);
            //Assert
            Assert.Equal(expectedOutput, methodCall);
        }
    }

    public class UnitTestsForChallenge5
    {
        [Fact]
        public void ProvidedExampleWorks()
        {
            //Arrange
            int[] inputArray = new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 };
            //Act
            int outputFromMethod = FindMaximumValue(inputArray);
            //Assert
            Assert.Equal(555, outputFromMethod);
        }

        [Theory]
        [InlineData(new int[] { 1, -1, 55, -33, -100 }, 55)]
        [InlineData(new int[] { 5, 5, 5, 5 }, 5)]
        public void AllRequiredTests(int[] inputArray, int expectedOutcome)
        {
            // Arrange
            // Act
            int methodCall = FindMaximumValue(inputArray);
            // Assert
            Assert.Equal(expectedOutcome, methodCall);
        }
    }

    public class UnitTestsForChallenge9
    {
        [Fact]
        public void DoesItReturnAStringArray()
        {
            // Arrange
            string example = "This is a sentance about important things";
            //Act
            string[] outputFromMethod = WordLengthGetter(example);
            //Assert
            Assert.Equal(new string[] { "the", "Brown", "Fox" }, outputFromMethod);
        }
    }
}
