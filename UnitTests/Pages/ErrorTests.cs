using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using HWUT.Pages;
using Microsoft.AspNetCore.Http;

namespace UnitTests.Pages
{
    [TestClass]
    public class ErrorTests
    {
        [TestMethod]
        public void Error_OnGet_Valid_TraceIdentifier_Value_Should_Return_IsValid()
        {
            // Arrange
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(m => m.TraceIdentifier).Returns("value");
            
            var logger = Mock.Of<ILogger<ErrorModel>>();
            var pageModel = new ErrorModel(logger);

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        [TestMethod]
        public void Error_OnGet_Valid_TraceIdentifier_Null_Should_Return_IsValid()
        {
            // Arrange
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(m => m.TraceIdentifier).Returns((string)null);

            var logger = Mock.Of<ILogger<ErrorModel>>();
            var pageModel = new ErrorModel(logger);

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
    }
}