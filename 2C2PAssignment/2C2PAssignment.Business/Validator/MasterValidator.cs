using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2C2PAssignment.Business.Dtos;

namespace _2C2PAssignment.Business.Validator
{
    public class MasterValidator : ValidatorBase
    {
        public override ValidateResultDto Validate(string cardNumber, ExpriedDateData experiedDate)
        {
            var result = base.Validate(cardNumber, experiedDate);

            if (result.Type == null)
            {
                if (!IsPrimeNumber(experiedDate.Year) && cardNumber[0] != '5')
                {
                    result = new ValidateResultDto() { Type = CardType.Unknown };
                }
                else
                {
                    result = new ValidateResultDto() {Type = CardType.Master };
                }
            }

            return result;
        }

        private bool IsPrimeNumber(int number)
        {
            int count = 0;
            for (int i = 1; i <= number; i++)
                if (number % i == 0)
                    count++;

            if (count == 2)
                return true;
            else
                return false;
        }
    }
}
