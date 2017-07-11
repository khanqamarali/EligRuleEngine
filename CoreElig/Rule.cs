using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreElig
{
    public class Rule
    {
        public string MemberName { get; set; }
        public string Operator { get; set; }
        public string TargetValue { get; set; }
        public string Message { get; set; }
    }

    public class LoanEligbility
    {
        public string Product { get; set; }       
    }
}
