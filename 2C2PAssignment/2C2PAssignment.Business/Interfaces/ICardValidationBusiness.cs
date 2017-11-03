using _2C2PAssignment.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PAssignment.Business.Interfaces
{
    public interface ICardValidationBusiness
    {
        ValidateResultDto Validate(string cardNumber, ExpiryDateData date);
    }
}
