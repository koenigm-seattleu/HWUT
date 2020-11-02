using System.Linq;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using HWUT.Pages;
using HWUT.Services;

namespace UnitTests.Pages
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void IndexMethod_Valid_Should_Return_Products()
        {
            // Arrange

            var dataPath = @"..\\..\\..\\..\\HWUT\\wwwroot";

            var hostEnvironment = new Mock<IWebHostEnvironment>();
            hostEnvironment
                .Setup(m => m.WebRootPath)
                .Returns(dataPath);

            hostEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");

            var logger = Mock.Of<ILogger<IndexModel>>();
            var productService = new JsonFileProductService(hostEnvironment.Object);
            var pageModel = new IndexModel(logger,productService);

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(6, pageModel.Products.ToList().Count);
        }
    }
}