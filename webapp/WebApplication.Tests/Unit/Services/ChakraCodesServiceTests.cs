using K9.WebApplication.Enums;
using K9.WebApplication.Models;
using System;
using K9.SharedLibrary.Models;
using K9.WebApplication.Services;
using Moq;
using Xunit;

namespace K9.WebApplication.Tests.Unit.Services
{
    public class ChakraCodesServiceTests
    {
        [Theory]
        [InlineData(1979, 6, 16, EChakraCode.Warrior, EChakraCode.Seer)]
        [InlineData(1984, 6, 21, EChakraCode.Healer, EChakraCode.Seer)]
        public void CalculateDominant(int year, int month, int day, EChakraCode dominant, EChakraCode subdominant)
        {
            var model = new ChakraCodesModel(new PersonModel
            {
                DateOfBirth = new DateTime(year, month, day)
            });

            var mockAuthentication = new Mock<IAuthentication>();
            mockAuthentication.SetupGet(e => e.CurrentUserId).Returns(2);
            mockAuthentication.SetupGet(e => e.IsAuthenticated).Returns(true);

            var chakraCodeService = new ChakraCodesService();

            var result = chakraCodeService.CalculateChakraCodes(model);
            
            Assert.Equal(dominant, result.Dominant.ChakraCode);
        }
        
    }
}
