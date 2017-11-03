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
    public class ValidatorBaseTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void Validate_GivenCardNumberNullOrEmptyWithValidExpiriedDate_Should_ReturnInvalidAndUnknownCard(string cardNumber)
        {
            //Arr
            ValidatorBase val = new ValidatorBase();

            //Act
            var result = val.Validate(cardNumber, new ExpiryDateData() { Month = 1, Year = 2019 });

            //Assert
            Assert.True(result != null);
            Assert.True((!result.IsValid));
            Assert.True(result.Type == CardType.Unknown);
        }

        [Test]
        [TestCase(null)]
        [TestCase("123456789012345")]
        [TestCase("12345678901234567")]
        [TestCase("123456789012345123456789012345")]
        public void Validate_GivenCardNumberMoreOrLessThan16WithValidExpiriedDate_Should_ReturnInvalidAndUnknownCard(string cardNumber)
        {
            //Arr
            ValidatorBase val = new ValidatorBase();

            //Act
            var result = val.Validate(cardNumber, new ExpiryDateData() { Month = 1, Year = 2019 });

            //Assert
            Assert.True(result != null);
            Assert.True((!result.IsValid));
            Assert.True(result.Type == CardType.Unknown);
        }

        [Test]
        [TestCase(null)]
        [TestCase("1234f6789012345")]
        [TestCase("1234567890a23456")]
        [TestCase("123456b890123451")]
        [TestCase("c23456b890123451")]
        [TestCase("123456b89012345a")]
        public void Validate_GivenCardNumberContainsNotDigitNumberWithValidExpiriedDate_Should_ReturnInvalidAndUnknownCard(string cardNumber)
        {
            //Arr
            ValidatorBase val = new ValidatorBase();

            //Act
            var result = val.Validate(cardNumber, new ExpiryDateData() { Month = 1, Year = 2019 });

            //Assert
            Assert.True(result != null);
            Assert.True((!result.IsValid));
            Assert.True(result.Type == CardType.Unknown);
        }

        [Test]
        public void Validate_GivenValidCardNumberWithNullExpiriedDate_Should_ReturnInvalidAndUnknownCard()
        {
            //Arr
            ValidatorBase val = new ValidatorBase();

            //Act
            var result = val.Validate("123446789012345", null);

            //Assert
            Assert.True(result != null);
            Assert.True((!result.IsValid));
            Assert.True(result.Type == CardType.Unknown);
        }

        [Test]
        [TestCase(11, 2016)]
        [TestCase(10, 2017)]
        [TestCase(9, 2017)]
        [TestCase(8, 2017)]
        [TestCase(7, 2017)]
        public void Validate_GivenValidCardNumberWithExpiriedDate_Should_ReturnIsValidFalse(int month, int year)
        {
            //Arr
            ValidatorBase val = new ValidatorBase();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);

            //Act
            var result = val.Validate("1234567890123456", new ExpiryDateData() { Month = month, Year = year});

            //Assert
            Assert.True(result != null);
            Assert.True((!result.IsValid));
            Assert.True(result.Type == null);
        }

        [Test]
        [TestCase(11, 2018)]
        [TestCase(11, 2017)]
        [TestCase(12, 2017)]
        [TestCase(1, 2018)]
        [TestCase(2, 2018)]
        public void Validate_GivenValidCardNumberWithValidExpiryDate_Should_ReturnIsValidTrue(int month, int year)
        {
            //Arr
            ValidatorBase val = new ValidatorBase();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);

            //Act
            var result = val.Validate("1234567890123456", new ExpiryDateData() { Month = month, Year = year });

            //Assert
            Assert.True(result != null);
            Assert.True((result.IsValid));
            Assert.True(result.Type == null);
        }
    }
}
