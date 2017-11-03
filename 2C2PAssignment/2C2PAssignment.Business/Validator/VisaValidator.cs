using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2C2PAssignment.Business.Dtos;

namespace _2C2PAssignment.Business.Validator
{
    public class VisaValidator : ValidatorBase
    {
        public override ValidateResultDto Validate(string cardNumber, ExpiryDateData expiriedDate)
        {
            var result = base.Validate(cardNumber, expiriedDate);

            if (result.Type == null)
            {
                if (IsLeapYear(expiriedDate.Year) && cardNumber[0] == '4')
                {
                    result.Type = CardType.Visa;
                }
            }

            return result;
        }

        private bool IsLeapYear(int year)
        {
            if ((year % 400) == 0)
                return true;
            else if ((year % 100) == 0)
                return false;
            else if ((year % 4) == 0)
                return true;
            else
                return false;
        }
    }
}
