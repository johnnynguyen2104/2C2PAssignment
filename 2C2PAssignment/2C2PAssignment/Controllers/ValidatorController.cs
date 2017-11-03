using _2C2PAssignment.Business.Business;
using _2C2PAssignment.Business.Dtos;
using _2C2PAssignment.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2C2PAssignment.Controllers
{
    public class ValidatorController : ApiController
    {
        ICardValidationBusiness validateBusiness;

        public ValidatorController(ICardValidationBusiness validate)
        {
            validateBusiness = validate;
        }

        public ValidatorController()
        {
            validateBusiness = new CardValidationBusiness();
        }
        // GET: Validate
        public ValidateResultDto Validate(string cardNumber, ExpiryDateData date)
        {
            return validateBusiness.Validate(cardNumber, date);
        }
    }
}
