using System;
using System.Collections.Generic;
using backend.Model;

namespace backend.Logic
{
    public class CalculateAge
    {
        public static Dictionary<Person, int> Age(List<Person> people) {

            
            Dictionary<Person, int> vaccinationOrder = new Dictionary<Person, int>();
            foreach(Person p in people) {
                var dateOfBirth = int.Parse(p.SocialSecurityNumber.Split('-')[0]);
                var age = DateTime.Now.Year - dateOfBirth;
                vaccinationOrder.Add(p, age);
            }

            return vaccinationOrder;
        }
    }
}