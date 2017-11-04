using _2C2PAssignment.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2C2PAssignment.Business.Dtos;
using _2C2PAssignment.Business.Validator;

namespace _2C2PAssignment.Business.Business
{
    public class CardValidationBusiness : ICardValidationBusiness
    {
        public ValidateResultDto Validate(string cardNumber, ExpiryDateData date)
        {
            ValidateResultDto result = null;
            List<ValidatorBase> validators = new List<ValidatorBase>()
            {
                new JCBValidator(),
                new VisaValidator(),
                new MasterValidator()
            };

            foreach (var item in validators)
            {
                if ((result = item.Validate(cardNumber, date)).Type != null)
                {
                    return result;
                }
            }


            result.Type = CardType.Unknown;
            return result;
        }
    }
}
