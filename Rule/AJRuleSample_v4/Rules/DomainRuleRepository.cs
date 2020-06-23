using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRules.RuleModel;
using NRules.RuleModel.Builders;
using AJRuleSample_v4.Model;
using System.Linq.Expressions;

namespace AJRuleSample_v4.Rules
{
    public class DomainRuleRepository : IRuleRepository
    {
        private readonly IRuleSet _ruleSet = new RuleSet("DefaultRuleSet");

        public IEnumerable<IRuleSet> GetRuleSets()
        {
            return new[] { _ruleSet };
        }

        public void LoadRules()
        {
            _ruleSet.Add(new[]
            {
                SrCitizenEligibility(),
                ChildConessionEligibility(),
                ValidateSrCitizenFlag(),
            });
        }

        private IRuleDefinition SrCitizenEligibility()
        {
            var builder = new NRules.RuleModel.Builders.RuleBuilder();
            builder.Name("Senior Citizen Elgibility Rule");

            PatternBuilder passengerPattern = builder.LeftHandSide().Pattern(typeof(Passenger), "passenger");
            ParameterExpression passengerParameter = passengerPattern.Declaration.ToParameterExpression();
            var passengerCondition = Expression.Lambda(
                Expression.GreaterThanOrEqual(
                    Expression.Property(passengerParameter, "Age"),
                    Expression.Constant(60)),
                passengerParameter);
            passengerPattern.Condition(passengerCondition);

            //Expression<Action<IContext, Passenger>> action =
            //    (ctx, customer, order) => Console.WriteLine("Customer {0} has an order in amount of ${1}", customer.Name, order.Amount);
            //Added
            Expression<Action<IContext, Passenger>> action =
                (ctx, passenger) => ctx.Insert($"Passenger : {passenger.Name} is eligible for senior citizen concession.");
            builder.RightHandSide().Action(action);

            return builder.Build();
        }

        private IRuleDefinition ChildConessionEligibility()
        {
            var builder = new NRules.RuleModel.Builders.RuleBuilder();
            builder.Name("Child Concession Elgibility Rule");

            PatternBuilder passengerPattern = builder.LeftHandSide().Pattern(typeof(Passenger), "passenger");
            ParameterExpression passengerParameter = passengerPattern.Declaration.ToParameterExpression();
            var passengerCondition = Expression.Lambda(
                Expression.LessThan(
                    Expression.Property(passengerParameter, "Age"),
                    Expression.Constant(6)),
                passengerParameter);
            passengerPattern.Condition(passengerCondition);

            //Expression<Action<IContext, Passenger>> action =
            //    (ctx, customer, order) => Console.WriteLine("Customer {0} has an order in amount of ${1}", customer.Name, order.Amount);
            //Added
            Expression<Action<IContext, Passenger>> action =
                (ctx, passenger) => ctx.Insert($"Passenger : {passenger.Name} is eligible for child concession.");
            builder.RightHandSide().Action(action);

            return builder.Build();
        }

        private IRuleDefinition ValidateSrCitizenFlag()
        {
            var builder = new NRules.RuleModel.Builders.RuleBuilder();
            builder.Name("Validate IsConsession flag Rule");

            PatternBuilder passengerPattern = builder.LeftHandSide().Pattern(typeof(Passenger), "passenger");
            Expression<Func<Passenger, bool>> passengerCondition = (passenger) => passenger.IsSeniorCitizen && passenger.Age < 60;
            passengerPattern.Condition(passengerCondition);

            Expression<Action<IContext, Passenger>> action =
                (ctx, passenger) => ctx.Insert($"Passenger : {passenger.Name}  is not eligible for senior citizen concession, since his age is under 60.");
            builder.RightHandSide().Action(action);

            return builder.Build();
        }
    }
}
