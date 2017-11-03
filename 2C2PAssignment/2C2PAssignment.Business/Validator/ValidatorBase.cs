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
        public virtual ValidateResultDto Validate(string cardNumber, ExpiryDateData expiriedDate)
        {
            DateTime now = SystemDatetime.Now.Invoke();

            ValidateResultDto result = new ValidateResultDto()
            {
                IsValid = ( expiriedDate != null && (expiriedDate.Year > now.Year || (expiriedDate.Year == now.Year && expiriedDate.Month >= now.Month)))
            };
         
            if (string.IsNullOrEmpty(cardNumber)
                || cardNumber.Trim().Length != 16
                || expiriedDate == null
                || !cardNumber.All(char.IsDigit)
                )
            {
                result.Type = CardType.Unknown;
            }

            return result;
        } 
    }
}
