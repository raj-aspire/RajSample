using AJRuleSample.Model;
using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJRuleSample.Rules
{
    public class TicketConsessionRule1 : Rule
    {
        public override void Define()
        {
            Passenger passenger = null;

            When()
                .Match<Passenger>(() => passenger, p => p.Age >= 60);

            Then()
                //.Do(ctx => passenger.ShowValidation($"Passenger : {passenger.Name} is eligible for senior citizen concession."));
                .Do(ctx => ctx.Insert($"Passenger : {passenger.Name} is eligible for senior citizen concession."));
        }
    }
}
