using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PAssignment.Business.Helper
{
    public class SystemDatetime
    {
        public static Func<DateTime> Now { get; set; } = () => DateTime.Now;

    }
}
