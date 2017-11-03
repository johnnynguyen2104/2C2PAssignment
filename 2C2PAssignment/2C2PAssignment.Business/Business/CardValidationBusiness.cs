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
        public ValidateResultDto Validate(string cardNumber, ExpriedDateData date)
        {
            ValidateResultDto result;

            if ((result = new JCBValidator().Validate(cardNumber, date)).Type != CardType.Unknown)
            {
                return result;
            }
            else if ((result = new VisaValidator().Validate(cardNumber, date)).Type != CardType.Unknown)
            {
                return result;
            }
            else if ((result = new VisaValidator().Validate(cardNumber, date)).Type != CardType.Unknown)
            {
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
