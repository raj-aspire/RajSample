using AJRuleSample.Model;
using AJRuleSample.Rules;
using NRules;
using NRules.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJRuleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the rules
            var repository = new RuleRepository();
            
            repository.Load(x => x.From(typeof(Program).Assembly));

            //Compile the rule
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            //Load model
            var passenger1 = new Passenger("Rajkumar", Gender.Male, 39) { IsSeniorCitizen = true };
            var passenger2 = new Passenger("Selvakumar", Gender.Male, 61);
            var passenger3 = new Passenger("Nancy", Gender.Female, 62);
            var passenger4 = new Passenger("Jenifer", Gender.Female, 4);

            // To insert the fact into rule engine memory
            session.Insert(passenger1);
            session.Insert(passenger2);
            session.Insert(passenger3);
            session.Insert(passenger4);

            //Start rule validation
            Console.WriteLine("Running rules:");
            session.Fire();
            var errorList = session.Query<string>().ToList();

            if (errorList.Count > 0)
                Console.WriteLine("==============");

            foreach (var item in errorList)
            {
                Console.WriteLine(item);
            }

            Console.Read();//To show the validation message in console
        }
    }
}
