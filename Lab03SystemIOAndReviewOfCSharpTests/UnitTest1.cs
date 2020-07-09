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
}
