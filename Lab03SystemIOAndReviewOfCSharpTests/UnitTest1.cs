using System;
using Xunit;
using static Lab03SystemIOAndReviewOfCSharp.Program;

namespace Lab03SystemIOAndReviewOfCSharpTests
{
    public class UnitTest1
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
}
