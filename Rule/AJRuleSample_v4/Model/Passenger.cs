﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJRuleSample_v4.Model
{
    public class Passenger
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public bool IsSeniorCitizen { get; set; }

        public Passenger(string name, Gender gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
        }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
