using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using HWUT.Pages;

namespace UnitTests.Pages
{
    [TestClass]
    public class PrivacyTests
    {
        [TestMethod]
        public void Privacy_OnGet_Valid_Should_Return_IsValid()
        {
            // Arrange
            var logger = Mock.Of<ILogger<PrivacyModel>>();
            var pageModel = new PrivacyModel(logger);

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
    }
}