using Moq;
using SmsOffice.Client.Extensions;
using SmsOffice.Client.Interfaces;
using SmsOffice.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmsOffice.Client.Tests
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData("995533221122")]
        [InlineData("+995533221122")]
        [InlineData("533221122")]
        public void Should_Start_With_NineNineFive(string phoneNumber)
        {
            Assert.StartsWith("995", phoneNumber.ToNormalizedPhoneNumber());
        }

        [Theory]
        [InlineData("995533221122")]
        [InlineData("+995533221122")]
        [InlineData("533221122")]
        public void Should_Equal_To_Exact_Number(string phoneNumber)
        {
            Assert.Equal("995533221122", phoneNumber.ToNormalizedPhoneNumber());
        }

        [Theory]
        [InlineData("995533221122")]
        [InlineData("+995533221122")]
        [InlineData("533221122")]
        public void Should_Be_Twelve_Symbols_Long(string phoneNumber)
        {
            var normalizedResult = phoneNumber.ToNormalizedPhoneNumber();
            Assert.Equal(12, normalizedResult.Length);
        }
    }
}
