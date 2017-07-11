using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreElig;

namespace SampleElig
{
    class Program
    {       
        static void Main(string[] args)
        {
            var rule = new Rule {MemberName = "Product", Operator = "Equal", TargetValue = "CONFIRMING", Message="Invalid Product"};
                 var someUser = new LoanEligbility { Product = "CONFIRMING" };
                Func<LoanEligbility, bool> compiledRule = MakeExpressionTree.CompileRule<LoanEligbility>(rule);                    
                 var isMatch = compiledRule(someUser);

                 Console.WriteLine(isMatch);

        }
    }
}
