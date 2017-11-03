using _2C2PAssignment.Business.Dtos;
using _2C2PAssignment.Business.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PAssignment.Business.Validator
{
    public class ValidatorBase
    {
        public virtual ValidateResultDto Validate(string cardNumber, ExpriedDateData experiedDate)
        {
            ValidateResultDto result;
            DateTime now = SystemDatetime.Now.Invoke();

            if (string.IsNullOrEmpty(cardNumber)
                || cardNumber.Trim().Length != 16
                || experiedDate == null
                || !cardNumber.All(char.IsDigit)
                )
            {
                return new ValidateResultDto() { IsValid = false, Type = CardType.Unknown };
            }

            return result = new ValidateResultDto() { IsValid = (experiedDate.Year > now.Year || ( experiedDate.Year == now.Year && experiedDate.Month >= now.Month)) };
        } 
    }
}
