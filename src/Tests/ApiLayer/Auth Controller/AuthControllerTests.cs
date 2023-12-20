using ApplicationLayer.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLayer.Commands.Users;
using ApplicationLayer.Requests.Users;
using Shared.Services.Commands.Abstract;
using Shared.Services.Queries.Abstract;
using Moq;
using ApiLayer.ExceptionHandling;
using Api.Controllers;
using StockKeeping.BL.Tests;
using DomainLayer.Enums.UserEnum;
using System.Diagnostics;



namespace Tests.ApiLayer.Auth_Controller
{
    [TestClass]
    public sealed class AuthControllerTests : TestBase<UserController>
    {
        private Mock<ICommandHandler<UserRegistration>> UserReg => AutoMocker.GetMock<ICommandHandler<UserRegistration>>();
        private Mock<IQueryHandler<UserLogin, string>> Userlogin => AutoMocker.GetMock<IQueryHandler<UserLogin, string>>();
        private Mock<IExceptionHandler> ExceptionHandler => AutoMocker.GetMock<IExceptionHandler>();

        [TestMethod]
        public async Task Auth_Register_PerformanceTest()
        {
            // Arrange
            var sut = CreateSut(); // Assuming this method creates your UserController instance
            var regCommand = new UserRegistration("kieren", "adkins", "kierenadkins2008@hotmail.com", "Password!", new DateOnly(2023, 12, 20), Roles.VisaApplicant, null);

            UserReg.Setup(x => x.HandleAsync(regCommand, It.IsAny<CancellationToken>()));

            // Act
            var stopwatch = Stopwatch.StartNew();
            var result = await sut.RegisterMember(regCommand);
            stopwatch.Stop();

            // Assert
            UserReg.Verify(x => x.HandleAsync(regCommand, It.IsAny<CancellationToken>()), Times.Once);

            // Check if the execution time is less than a certain threshold (adjust as needed)
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000, $"Execution time exceeded the threshold: {stopwatch.ElapsedMilliseconds}ms");
        }

    }
}
