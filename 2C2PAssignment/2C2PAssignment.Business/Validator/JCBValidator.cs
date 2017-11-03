using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2C2PAssignment.Business.Dtos;

namespace _2C2PAssignment.Business.Validator
{
    public class JCBValidator : ValidatorBase
    {
        public override ValidateResultDto Validate(string cardNumber, ExpiryDateData expiriedDate)
        {
            var result = base.Validate(cardNumber, expiriedDate);

            if (result.Type == null)
            {
                if (cardNumber[0] == '3')
                {
                    result = new ValidateResultDto() { IsValid = true, Type = CardType.JCB };
                }
            }

            return result;
        }
    }
}
