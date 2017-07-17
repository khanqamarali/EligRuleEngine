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
        public string Id { get; set; }
        public string MemberName { get; set; }
        public string Operator { get; set; }
        public string TargetValue { get; set; }
        public string Message { get; set; }
    }

    public class LoanEligbility
    {
        public string Id { get; set; }
        public string Product { get; set; }
        public string State { get; set; }
        public string LoanPurpose { get; set; }
        public string Amort { get; set; }
        public double FICO { get; set; }

    }
}
