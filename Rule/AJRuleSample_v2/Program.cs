using NRules;
using NRules.RuleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace AJRuleSample_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var text = @"
                rule TestRule
                when
                    var pas1 = Passenger(x => x.Age >= 60);
    
                then
                    Context.Insert(""Passenger Age is greater than 60"");
                ";
            //Load the rules
            var repository = new RuleRepository();

            repository.LoadText(text);

            //Compile the rule
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            //Load model
            var passenger1 = new Passenger("Rajkumar", Gender.Male, 39) { IsSeniorCitizen = true };
            var passenger2 = new Passenger("Selvakumar", Gender.Male, 61);
            var passenger3 = new Passenger("Nancy", Gender.Female, 62);

            // To insert the fact into rule engine memory
            session.Insert(passenger1);
            session.Insert(passenger2);
            session.Insert(passenger3);

            //Start rule validation
            session.Fire();
            var errorList = session.Query<string>().ToList();

            foreach (var item in errorList)
            {
                Console.WriteLine(item);
            }

            Console.Read();//To show the validation message in console
            */
            var repository = new RuleRepository();
            repository.AddNamespace("System");
            repository.AddReference(typeof(Passenger).Assembly);

            List<string> ruleFiles = new List<string> { "rk.rul", "rk2.rul", "rk3.rul" };

            //repository.Load(@"rk.rul");
            repository.Load(ruleFiles);

            var factory = repository.Compile();
            var session = factory.CreateSession();

            var passenger1 = new Passenger("Rajkumar", Gender.Male, 39) { IsSeniorCitizen = true };
            var passenger2 = new Passenger("Selvakumar", Gender.Male, 61);
            var passenger3 = new Passenger("Nancy", Gender.Female, 62);
            var passenger4 = new Passenger("Jenifer", Gender.Female, 4);

            session.Insert(passenger1);
            session.Insert(passenger2);
            session.Insert(passenger3);
            session.Insert(passenger4);

            Console.WriteLine("Running rules:");
            session.Fire();
            var errorList = session.Query<string>().ToList();

            if (errorList.Count > 0)
                Console.WriteLine("==================");

            foreach (var item in errorList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
