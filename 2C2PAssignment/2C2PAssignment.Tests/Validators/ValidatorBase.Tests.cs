using _2C2PAssignment.Business.Dtos;
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
        public void Validate_GivenCardNumberNullOrEmptyWithValidExperiedDate_Should_ReturnInvalidAndUnknownCard(string cardNumber)
        {
            //Arr
            ValidatorBase val = new ValidatorBase();

            //Act
            var result = val.Validate(cardNumber, new ExpriedDateData() { Month = 1, Year = 2019 });

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
        public void Validate_GivenCardNumberMoreOrLessThan16WithValidExperiedDate_Should_ReturnInvalidAndUnknownCard(string cardNumber)
        {
            //Arr
            ValidatorBase val = new ValidatorBase();

            //Act
            var result = val.Validate(cardNumber, new ExpriedDateData() { Month = 1, Year = 2019 });

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
        public void Validate_GivenCardNumberContainsNotDigitNumberWithValidExperiedDate_Should_ReturnInvalidAndUnknownCard(string cardNumber)
        {
            //Arr
            ValidatorBase val = new ValidatorBase();

            //Act
            var result = val.Validate(cardNumber, new ExpriedDateData() { Month = 1, Year = 2019 });

            //Assert
            Assert.True(result != null);
            Assert.True((!result.IsValid));
            Assert.True(result.Type == CardType.Unknown);
        }

        [Test]
        public void Validate_GivenValidCardNumberWithNullExperiedDate_Should_ReturnInvalidAndUnknownCard()
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


    }
}
