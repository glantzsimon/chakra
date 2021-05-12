using K9.WebApplication.Enums;
using K9.WebApplication.Models;
using System;
using System.Linq;
using K9.SharedLibrary.Models;
using K9.WebApplication.Services;
using Moq;
using Xunit;

namespace K9.WebApplication.Tests.Unit.Services
{
    public class ChakraCodesServiceTests
    {
        [Theory]
        [InlineData(1979, 6, 16, EChakraCode.Warrior, EChakraCode.Seer, EChakraCode.Teacher, EChakraCode.Mystic, EChakraCode.Healer, EChakraCode.Pioneer, EChakraCode.Seer)]
        [InlineData(1984, 6, 21, EChakraCode.Healer, EChakraCode.Seer, EChakraCode.Warrior, EChakraCode.Healer, EChakraCode.Communicator, EChakraCode.Seer, EChakraCode.Seer)]
        public void CalculateTest(int year, int month, int day, EChakraCode dominant, EChakraCode subdominant, EChakraCode guide, EChakraCode gift, EChakraCode birthYear, EChakraCode currentYear, EChakraCode birthDharmaCode)
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
            Assert.Equal(birthYear, result.BirthYear.ChakraCode);
            Assert.Equal(currentYear, result.CurrentYear.ChakraCode);
            Assert.Equal(birthDharmaCode, result.DharmaCodes.First(e => e.Age == 0).ChakraCode);

            Assert.False(result.Dominant.IsActive);
            Assert.False(result.SubDominant.IsActive);
            Assert.True(result.Guide.IsActive);
            Assert.False(result.Gift.IsActive);
        }

    }
}
