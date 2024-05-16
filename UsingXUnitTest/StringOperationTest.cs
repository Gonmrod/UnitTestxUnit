using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingXUnit;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace UsingXUnitTest
{
    public class StringOperationTest
    {
        [Fact(Skip = "Esta prueba no es válida en este momento. Ticket-001")]
        public void ConcatenateString()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.ConcatenateStrings("Hello", "World!");

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello World!", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            //Arrenge
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.IsPalindrome("ama");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            //Arrenge
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.IsPalindrome("Gon");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveWhiteSpace()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.RemoveWhiteSpace("Gonzalo Rodriguez");

            //Assert
            Assert.DoesNotContain(" ", result);
        }

        [Fact]
        public void QuantityInWords()
        {
            //Arranage
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.QuantityInWords("Gonzalo", 2);

            //Assert
            Assert.StartsWith("dos", result);
            Assert.Contains("Gonzalo", result);
            Assert.Equal("dos Gonzalos", result);
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            //Arrenge
            var strOperations = new StringOperations();

            //Assert
            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.GetStringLength("Rodriguez");

            //Assert
            Assert.Equal(9, result);
        }

        [Fact]
        public void TruncateString_Exception()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Assert
            Assert.ThrowsAny<ArgumentOutOfRangeException>(()=> strOperations.TruncateString("Martin", 0));
        }

        [Fact]
        public void TruncateString()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.TruncateString("Martin", 3);

            //Assert
            Assert.Equal("Mar", result);
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("M", 1000)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.FromRomanToNumber(romanNumber);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Casa", "asaC")]
        [InlineData("teoria", "airoet")]
        public void ReverseString(string str, string expected)
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.ReverseString(str);

            //Assert
            Assert.Equal($"{expected}", result);
        }

        [Fact]
        public void CountOcurrences()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);

            //Act
            var result = strOperations.CountOccurrences("Hola RRHH", 'R');

            //Asser
            Assert.Equal(2, result);
        }

        [Fact]
        public void ReadFile()
        {
            //Arrange
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString("file.txt")).Returns("Reading file");

            //Act
            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            //Assert
            Assert.Equal("Reading file", result);

        }

        [Fact]
        public void ReadFile_ParameterIsAny()
        {
            //Arrange
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");

            //Act
            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            //Assert
            Assert.Equal("Reading file", result);

        }
    }
}
