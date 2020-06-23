using NRules;
using NRules.RuleModel;
using NRules.RuleModel.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AJRuleSample.Dynamic2
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
            var rule = BuildRule1();
            _ruleSet.Add(new[] { rule });
        }

        private IRuleDefinition BuildRule1()
        {
            //Create rule builder
            var builder = new RuleBuilder();
            builder.Name("Product should exist in stock");

            //Build conditions
            PatternBuilder productPattern = builder.LeftHandSide().Pattern(typeof(Product), "product");
            Expression<Func<Product, bool>> productCondition =
                product => product.InStock < 1;
            productPattern.Condition(productCondition);

            //PatternBuilder orderPattern = builder.LeftHandSide().Pattern(typeof(Order), "order");
            //Expression<Func<Order, Product, bool>> orderCondition1 =
            //    (order, product) => order.Details == product;
            //orderPattern.Condition(orderCondition1);

            //Build actions
            //Expression<Action<IContext, Product, Order>> action =
            //    (ctx, product, order) => Console.WriteLine("No stock available for product {0}", product.Name);
            //builder.RightHandSide().Action(action);
            Expression<Action<IContext, Product>> action =
                (ctx, product) => Console.WriteLine("No stock available for product {0}", product.Name);
            builder.RightHandSide().Action(action);

            //Build rule model
            return builder.Build();
        }
    }

    class DynamicRule2
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
            var product1 = new Product("Pencil", 0, 1);
            var product2 = new Product("Pen", 5, 1);
            session.Insert(customer);
            session.Insert(product1);
            session.Insert(product2);
            session.Insert(new Order(customer) {  Details = new List<Product> { product1, product2 } });

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

    public class Product
    {
        public Product(string name, int stock, int reorder)
        {
            Name = name;
            InStock = stock;
            ReOrderLevel = reorder;
        }
        public string Name { get; set; }
        public int InStock { get; set; }
        public int ReOrderLevel { get; set; }
    }

    public class Order
    {
        public Order(Customer customer)
        {
            Customer = customer;
        }
        public Customer Customer { get; set; }
        public List<Product> Details { get; set; }
    }
}
