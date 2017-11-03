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
    public class MasterValidatorsTest
    {
        [Test]
        [TestCase("123456789012345")]//not 16 digit numbers
        [TestCase("a234567890123456")] // contains other char
        [TestCase(" ")]
        [TestCase(null)]
        public void Validate_GivenDataFailedBasicValidation_Should_ReturnUnknownCardType(string cardNumber)
        {
            //Arr
            MasterValidator visa = new MasterValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = visa.Validate(cardNumber, new Business.Dtos.ExpiryDateData() { Month = 11, Year = 2017 });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid);
            Assert.True(result.Type == Business.Dtos.CardType.Unknown);
        }

        [Test]
        [TestCase("1234567890123456")]
        [TestCase("2234567890123456")]
        [TestCase("3234567890123456")]
        [TestCase("0234567890123456")]
        public void Validate_GivenCardNumberDontStartWithFiveWithValidDate_Should_ReturnUnknownCardTypeWithValidExpiryDate(string cardNumber)
        {
            //Arr
            MasterValidator master = new MasterValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = master.Validate(cardNumber, new Business.Dtos.ExpiryDateData() { Month = 11, Year = 2017 });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid);
            Assert.True(result.Type == null);
        }

        [Test]
        [TestCase("5234567890123456")]
        public void Validate_GivenCardNumberStartWithFiveButInvalidDate_Should_ReturnMasterCartTypeWithInvalid(string cardNumber)
        {
            //Arr
            MasterValidator master = new MasterValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = master.Validate(cardNumber, new Business.Dtos.ExpiryDateData() { Month = 11, Year = 2011 });
            //Assert
            Assert.True(result != null);
            Assert.True(!result.IsValid);
            Assert.True(result.Type == Business.Dtos.CardType.Master);
        }


        [Test]
        [TestCase("5234567890123456", 2018)]
        [TestCase("5234567890123456", 2019)]
        [TestCase("5234567890123456", 2020)]
        [TestCase("5234567890123456", 2021)]
        public void Validate_GivenCardNumberStartWithFiveButNotPrimeYearButValid_Should_ReturnNullCardTypeWithInvalid(string cardNumber, int year)
        {
            //Arr
            MasterValidator master = new MasterValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = master.Validate(cardNumber, new Business.Dtos.ExpiryDateData() { Month = 11, Year = year });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid);
            Assert.True(result.Type == null);
        }

        [Test]
        [TestCase("5234567890123456", 2027)]
        [TestCase("5234567890123456", 2017)]
        [TestCase("5234567890123456", 2029)]
        public void Validate_GivenCardNumberStartWithFourAndValidLeapYear_Should_ReturnVisaCartTypeWithInvalid(string cardNumber, int year)
        {
            //Arr
            MasterValidator master = new MasterValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = master.Validate(cardNumber, new Business.Dtos.ExpiryDateData() { Month = 11, Year = year });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid);
            Assert.True(result.Type == Business.Dtos.CardType.Master);
        }
    }
}
