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

            List<Rule> collr = new List<Rule> {
                             new Rule { MemberName = "LoanPurpose", Operator = "Equal", TargetValue = "R", Message = "Invalid Product" },
                             new Rule {MemberName = "Product", Operator = "Equal", TargetValue = "CONFIRMING", Message="Invalid Product"}
                                };

            List<LoanEligbility> colle = new List<LoanEligbility> {
                                        new LoanEligbility { LoanPurpose = "R" },
                                        new LoanEligbility { Product = "CONFIRMING" }
                                        };

            var rule1 = new Rule { MemberName = "LoanPurpose", Operator = "Equal", TargetValue = "R", Message = "Invalid Product" };
            var someUser1 = new LoanEligbility { LoanPurpose = "R" };



            var pr = someUser.GetType();

            foreach(var proName in typeof(LoanEligbility).GetProperties())
            {          
                var find = collr.First(x => x.MemberName.ToUpper() == proName.Name.ToString().ToUpper());
                Func<LoanEligbility, bool> compiledRule4 = MakeExpressionTree.CompileRule<LoanEligbility>(find);
                var isMatch4 = compiledRule4(someUser);
            }

            Func<LoanEligbility, bool> compiledRule = MakeExpressionTree.CompileRule<LoanEligbility>(rule);
            var isMatch = compiledRule(someUser);

            Func<LoanEligbility, bool> compiledRule1 = MakeExpressionTree.CompileRule<LoanEligbility>(rule);
            var isMatch1 = compiledRule(someUser1);

            
            var andopt = Expression.And(getdata(isMatch), getdata(isMatch1));


            var result = Expression.Lambda<Func<bool>>(andopt).Compile()();
            





            //Func<LoanEligbility, bool> compiledRule = MakeExpressionTree.CompileRule<LoanEligbility>(rule);                    
            //     var isMatch = compiledRule(someUser);
                    // Checking compatilblity 

                 Console.WriteLine(isMatch);

        }

        public static dynamic getdata(bool boolval)
        {
            if (boolval == true)
                return Expression.Constant(true);
            return Expression.Constant(false);
        }
    }
}
