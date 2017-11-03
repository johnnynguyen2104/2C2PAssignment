using _2C2PAssignment.Business.Dtos;
using _2C2PAssignment.Business.Helper;
using _2C2PAssignment.Business.Validator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PAssignment.Tests.Validators
{
    [TestFixture]
    public class JCBValidatorsTest
    {
        [Test]
        [TestCase("123456789012345")]//not 16 digit numbers
        [TestCase("a234567890123456")] // contains other char
        [TestCase(" ")]
        [TestCase(null)]
        public void Validate_GivenDataFailedBasicValidation_Should_ReturnUnknownCardType(string cardNumber)
        {
            //Arr
            JCBValidator visa = new JCBValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = visa.Validate(cardNumber, new ExpiryDateData() { Month = 11, Year = 2017 });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid);
            Assert.True(result.Type == CardType.Unknown);
        }

        [Test]
        [TestCase("123456789012345")]//not 16 digit numbers
        [TestCase("a234567890123456")] // contains other char
        [TestCase(" ")]
        [TestCase(null)]
        public void Validate_GivenDataFailedBasicValidationWithInvalidExpiryDate_Should_ReturnUnknownCardType(string cardNumber)
        {
            //Arr
            JCBValidator visa = new JCBValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = visa.Validate(cardNumber, new ExpiryDateData() { Month = 11, Year = 2016 });
            //Assert
            Assert.True(result != null);
            Assert.True(!result.IsValid);
            Assert.True(result.Type == CardType.Unknown);
        }

        [Test]
        [TestCase("3234567890123456", 11, 2016)]
        [TestCase("3234567890123456", 11, 2017)]
        [TestCase("3234567890123456", 11, 2018)]
        [TestCase("3234567890123456", 11, 2019)]
        public void Validate_GivenCardNumberStartWith3WithValidAndInvalidExpiryDate_Should_ReturnJCBCard_AlwaysValidDate(string cardNumber, int month, int year)
        {
            //Arr
            JCBValidator visa = new JCBValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = visa.Validate(cardNumber, new ExpiryDateData() { Month = month, Year = year });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid);
            Assert.True(result.Type == CardType.JCB);
        }

        [Test]
        [TestCase("1234567890123456", 11, 2016, false)]
        [TestCase("2234567890123456", 11, 2017, true)]
        [TestCase("5234567890123456", 11, 2018, true)]
        [TestCase("4234567890123456", 11, 2019, true)]
        public void Validate_GivenCardNumberDontStartWith3WithValidAndInvalidExpiryDate_Should_ReturnJCBCard_AlwaysValidDate(string cardNumber, int month, int year, bool expectedValid)
        {
            //Arr
            JCBValidator visa = new JCBValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = visa.Validate(cardNumber, new ExpiryDateData() { Month = month, Year = year });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid == expectedValid);
            Assert.True(result.Type == null);
        }
    }
}
