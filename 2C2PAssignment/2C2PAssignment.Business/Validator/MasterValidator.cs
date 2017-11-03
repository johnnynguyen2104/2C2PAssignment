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
        public override ValidateResultDto Validate(string cardNumber, ExpiryDateData expiriedDate)
        {
            var result = base.Validate(cardNumber, expiriedDate);

            if (result.Type == null)
            {
                if (!IsPrimeNumber(expiriedDate.Year) || cardNumber[0] != '5')
                {
                    result.Type = CardType.Unknown;
                }
                else
                {
                    result.Type = CardType.Master;
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
