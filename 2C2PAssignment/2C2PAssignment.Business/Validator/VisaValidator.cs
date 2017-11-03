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
        public override ValidateResultDto Validate(string cardNumber, ExpriedDateData experiedDate)
        {
            var result = base.Validate(cardNumber, experiedDate);

            if (result.Type == null)
            {
                if (!IsLeapYear(experiedDate.Year) && cardNumber[0] != '4')
                {
                    result = new ValidateResultDto() { Type = CardType.Unknown };
                }
                else
                {
                    result = new ValidateResultDto() { Type = CardType.Visa };
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
