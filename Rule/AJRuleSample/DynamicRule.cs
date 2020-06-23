using NRules;
using NRules.RuleModel;
using NRules.RuleModel.Builders;
using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AJRuleSample
{
    public class CustomRuleRepository : IRuleRepository
    {
        private readonly IRuleSet _ruleSet = new RuleSet("MyRuleSet");

        public IEnumerable<IRuleSet> GetRuleSets()
        {
            return new[] { _ruleSet };
        }

        public void LoadRules()
        {
            //Assuming there is only one rule in this example
            var rule = BuildRule();
            _ruleSet.Add(new[] { rule });
        }

        private IRuleDefinition BuildRule()
        {
            //Create rule builder
            var builder = new RuleBuilder();
            builder.Name("TestRule");

            //Build conditions
            PatternBuilder customerPattern = builder.LeftHandSide().Pattern(typeof(Customer), "customer");
            Expression<Func<Customer, bool>> customerCondition =
                customer => customer.Name == "John Do";
            customerPattern.Condition(customerCondition);
            
            PatternBuilder orderPattern = builder.LeftHandSide().Pattern(typeof(Order), "order");
            Expression<Func<Order, Customer, bool>> orderCondition1 =
                (order, customer) => order.Customer == customer;
            Expression<Func<Order, bool>> orderCondition2 =
                order => order.Amount > 100.00m;
            orderPattern.Condition(orderCondition1);
            orderPattern.Condition(orderCondition2);

            //Build actions
            Expression<Action<IContext, Customer, Order>> action =
                (ctx, customer, order) => Console.WriteLine("Customer {0} has an order in amount of ${1}", customer.Name, order.Amount);
            builder.RightHandSide().Action(action);

            //Build rule model
            return builder.Build();
        }

        public IQueryable<TSource> PropertyEqualsValue<TSource>(IQueryable<TSource> query,string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(TSource));
            var body = Expression.Equal(
                Expression.Property(param, propertyName),
                Expression.Constant(value)
            );
            var expr = Expression.Call(
                typeof(Queryable),
                "Where",
                new[] { typeof(TSource) },
                query.Expression,
                Expression.Lambda<Func<TSource, bool>>(body, param)
            );
            return query.Provider.CreateQuery<TSource>(expr);
        }

        public IQueryable PropertyEqualsValue(IQueryable query, Type type, string propertyName, object value)
        {
            var param = Expression.Parameter(type);
            var body = Expression.Equal(
                Expression.Property(param, propertyName),
                Expression.Constant(value)
            );
            var expr = Expression.Call(
                typeof(Queryable),
                "Where",
                new[] { type },
                query.Expression,
                Expression.Lambda(body, param)
            );
            return query.Provider.CreateQuery(expr);
        }
    }

    class DynamicRule
    {
        static void Main(string[] args)
        {
            //Create Repository
            var repository = new CustomRuleRepository();
            //Load rules
            repository.LoadRules();
            //Compile rules
            ISessionFactory factory = repository.Compile();
            //Create session for rule
            ISession session = factory.CreateSession();

            var customer = new Customer("John Do");
            session.Insert(customer);
            session.Insert(new Order(customer, 90.00m));
            session.Insert(new Order(customer, 110.00m));

            session.Fire();

            Console.ReadKey();
        }
    }

    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    public class Order
    {
        public Order(Customer customer, decimal amount)
        {
            Customer = customer;
            Amount = amount;
        }

        public Customer Customer { get; private set; }
        public decimal Amount { get; private set; }
    }
}
