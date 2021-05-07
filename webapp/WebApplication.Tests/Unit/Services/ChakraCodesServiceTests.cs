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
        [InlineData(1979, 6, 16, EChakraCode.Warrior, EChakraCode.Seer, EChakraCode.Teacher, EChakraCode.Mystic)]
        [InlineData(1984, 6, 21, EChakraCode.Healer, EChakraCode.Seer, EChakraCode.Warrior,EChakraCode.Healer)]
        public void CalculateTest(int year, int month, int day, EChakraCode dominant, EChakraCode subdominant, EChakraCode guide, EChakraCode gift)
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
            Assert.Equal(subdominant, result.SubDominant.ChakraCode);
            Assert.Equal(guide, result.Guide.ChakraCode);
            Assert.Equal(gift, result.Gift.ChakraCode);
            
            Assert.False(result.Dominant.IsActive);
            Assert.False(result.SubDominant.IsActive);
            Assert.True(result.Guide.IsActive);
            Assert.False(result.Gift.IsActive);
        }
        
    }
}
