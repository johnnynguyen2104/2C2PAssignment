using _2C2PAssignment.Business.Business;
using _2C2PAssignment.Business.Dtos;
using _2C2PAssignment.Business.Helper;
using _2C2PAssignment.Business.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PAssignment.Tests.Business
{
    [TestFixture]
    public class CardValidationTest
    {
        ICardValidationBusiness business = new CardValidationBusiness();

        [Test]
        [TestCase("123456789012345", 11, 2016, false, CardType.Unknown)]//not 16 digit numbers
        [TestCase("a234567890123456", 11, 2016, false, CardType.Unknown)] // contains other char
        [TestCase(" ", 11, 2016, false, CardType.Unknown)]
        [TestCase(null, 11, 2016, false, CardType.Unknown)]
        [TestCase("123456789012345", 11, 2017, true, CardType.Unknown)]//not 16 digit numbers
        [TestCase("a234567890123456", 11, 2018, true, CardType.Unknown)] // contains other char
        [TestCase(" ", 11, 2019, true, CardType.Unknown)]
        [TestCase(null, 11, 2020, true, CardType.Unknown)]
        [TestCase("1234567890123456", 11, 2017, true, CardType.Unknown)]
        [TestCase("1234567890123456", 11, 2016, false, CardType.Unknown)]
        [TestCase("3234567890123456", 11, 2017, true, CardType.JCB)]
        [TestCase("3234567890123456", 11, 2016, true, CardType.JCB)]
        [TestCase("4234567890123456", 11, 2017, true, CardType.Unknown)]
        [TestCase("4234567890123456", 11, 2016, false, CardType.Visa)]
        [TestCase("4234567890123456", 11, 2020, true, CardType.Visa)]
        [TestCase("4234567890123456", 11, 2016, false, CardType.Visa)]
        [TestCase("5234567890123456", 11, 2017, true, CardType.Master)]
        [TestCase("5234567890123456", 11, 2011, false, CardType.Master)]
        [TestCase("5234567890123456", 11, 2012, false, CardType.Unknown)]
        public void Validate_GivenDataAndExpectation_ReturnDataToMeetExpectation(
            string cardName, 
            int month, 
            int year, 
            bool valid, 
            CardType? cardTypeExpectation)
        {
            //Arr
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);

            //Act
            var result = business.Validate(cardName, new ExpiryDateData() { Month = month, Year = year });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid == valid);
            Assert.True(result.Type == cardTypeExpectation);
        }

    }
}
