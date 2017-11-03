using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PAssignment.Business.Dtos
{
    public class ValidateResultDto
    {
        public CardType? Type { get; set; }

        public bool? IsValid { get; set; }
    }
}
