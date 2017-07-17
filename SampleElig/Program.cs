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
                             new Rule { Id = "1869a4ac-b45b-479f-9b88-0340a781843b",
                                 MemberName = "LoanPurpose", Operator = "Equal", TargetValue = "R", Message = "Invalid Product" },
                             new Rule { Id = "7178cc99-17da-4b58-8b6f-82390ad7b90e",
                                 MemberName = "Product", Operator = "Equal", TargetValue = "CONFIRMING", Message="Invalid Product"}
                                };

            List<LoanEligbility> colle = new List<LoanEligbility> {
                                        new LoanEligbility { LoanPurpose = "R" },
                                        new LoanEligbility { Product = "NONCONFIRMING" }
                                        };

            var rule1 = new Rule { MemberName = "LoanPurpose", Operator = "Equal", TargetValue = "R", Message = "Invalid Product" };
            var someUser1 = new LoanEligbility { LoanPurpose = "R" };



            var pr = someUser.GetType();

            foreach (var con in colle)
            {
                foreach (var proName in typeof(con).GetProperties())
                {


                    if (collr.Any(x => x.MemberName.ToUpper() == proName.Name.ToString().ToUpper()))
                    {

                        var r = collr.Single(x => x.MemberName.ToUpper() == proName.Name.ToString().ToUpper());
                        Func<LoanEligbility, bool> compiledRule6 = MakeExpressionTree.CompileRule<LoanEligbility>(r);
                        var da = compiledRule6(someUser1);
                    }


                }

            }

            Func<LoanEligbility, bool> compiledRule = MakeExpressionTree.CompileRule<LoanEligbility>(rule);
            var isMatch = compiledRule(someUser);

            Func<LoanEligbility, bool> compiledRule1 = MakeExpressionTree.CompileRule<LoanEligbility>(rule);
            var isMatch1 = compiledRule(someUser1);

            
            var andopt = Expression.And(ConvertToExpressionConstant(isMatch), ConvertToExpressionConstant(isMatch1));


            var result = Expression.Lambda<Func<bool>>(andopt).Compile()();
            





            //Func<LoanEligbility, bool> compiledRule = MakeExpressionTree.CompileRule<LoanEligbility>(rule);                    
            //     var isMatch = compiledRule(someUser);
                    // Checking compatilblity 

                 Console.WriteLine(isMatch);

        }

        public static LoanEligbility returnCondi(string protype,List<LoanEligbility> eligCond)
        {
            foreach (var con in eligCond)
            {
                if (typeof(LoanEligbility).GetProperties().GetType())

            }
        }

        public static dynamic ConvertToExpressionConstant(bool boolval)
        {
            if (boolval == true)
                return Expression.Constant(true);
            return Expression.Constant(false);
        }
    }
}
