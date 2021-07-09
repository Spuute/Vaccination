using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using backend.DTO;
using backend.Model;
using backend.Logic;

namespace backend.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    public class VaccinationController : ControllerBase
    {
        private readonly VaccinationContext _context;

        public VaccinationController(VaccinationContext context)
        {
            _context = context;
        }
        [HttpGet("people")]
        public IActionResult GetAll()
        {
            var people = _context.Persons
            .Select(x => new ShowPeopleDTO()
            {
                FullName = $"{x.LastName} {x.FirstName}",
                SocialSecurityNumber = x.SocialSecurityNumber
            });

            return Ok(people);
        }

        //FIXME: Enbart testsyfte. 
        [HttpGet("orderby")]
        public IActionResult OrderBy()
        {
            var nonVaccinatedHealthCareEmployees = _context.Persons
            .Where(c => c.Vaccination.FirstDose == false && c.Vaccination.SecondDose == false && c.HealthCareEmployee == true)
            .ToList();
            var oldestFirst = nonVaccinatedHealthCareEmployees.OrderBy(x => x.SocialSecurityNumber.Substring(0, 8)).ToList();

            return Ok(oldestFirst);
        }

        [HttpGet("test1")]
        public IActionResult Test1() {
            var apa = _context.AvailableDoses.Where(x => x.Id == 1);
            apa.
            return Ok(apa);
        }

        //FIXME: Enbart testsyfte.
        [HttpGet("test")]
        public IActionResult Test()
        {
            // Ändrat från int till var
            var avaliableDoses = (int)_context.AvailableDoses.Select(x => x.Doses).FirstOrDefault();
            // var nonVaccinatedHealthCareEmployees = _context.Persons
            // .Where(c => c.Vaccination.FirstDose == false && c.Vaccination.SecondDose == false && c.HealthCareEmployee == true).ToList(); // Tagit bort en .Where som redan finns i första.

            // var nonVaccinatedPeopleWithMedicalCondition = _context.Persons
            // .Where(x => x.Vaccination.FirstDose == false && x.Vaccination.SecondDose == false && x.MedicalCondition == true).ToList();

            // Lista med personer som har fått första dosen.
            // var firstDose = _context.Persons.Include(x => x.Vaccination).Where(x => x.Vaccination.FirstDose == true && x.Vaccination.SecondDose == false).ToList();

            //TODO: Kolla först om alla inom vård och omsorg har fått en första dos, annars fortsätt på dom som ej har fått sin första, därefter en andra dos. 
            // if (avaliableDoses > _context.Persons.Include(x => x.Vaccination.FirstDose).Count())
            // {
            //     var vaccinate = _context.Persons.Include(x => x.Vaccination).Where(x => x.Vaccination.FirstDose == false).OrderBy(x => x.SocialSecurityNumber.Substring(0, 8)).ToList();
            //     // vaccinate.
            // }

            // var vaccinate = _context.Persons.Include(x => x.Vaccination).Where(x => x.Vaccination.FirstDose == false).ToList();

            var nuda = _context.Persons.Where(x => x.HealthCareEmployee == true).OrderBy(x => x.SocialSecurityNumber.Substring(0, 8)).ToList();
                    // var test = _context.AvailableDoses.FirstOrDefault(x => x.Doses);

            foreach (var person in nuda)
            {
                if (avaliableDoses > 0)
                {
                    var personToVaccinate = _context.Persons.Include(x => x.Vaccination).Where(x => x.Id == person.Id).FirstOrDefault();
                    personToVaccinate.Vaccination.FirstDose = true;
                    avaliableDoses --;
                    var test = _context.AvailableDoses.Select(x => x.Doses).FirstOrDefault();
                    test -= 1;
                    _context.SaveChanges();
                }
            }



            // if (avaliableDoses > nonVaccinatedHealthCareEmployees.Count)
            // {
            //     var oldestFirst = nonVaccinatedHealthCareEmployees.OrderBy(x => x.SocialSecurityNumber.Substring(0, 8)).ToList();
            //     return Ok(oldestFirst);
            // }

            // if (avaliableDoses < nonVaccinatedHealthCareEmployees.Count)
            // {
            //     for (int i = avaliableDoses; i < nonVaccinatedHealthCareEmployees.Count; i++)
            //     {
            //         var oldestFirst = nonVaccinatedHealthCareEmployees.OrderBy(x => x.SocialSecurityNumber.Substring(0, 8)).Take(avaliableDoses).ToList();
            //         foreach (var person in oldestFirst)
            //         {
            //             var personToVaccinate = _context.Persons.Include(x => x.Vaccination).Where(x => x.Id == person.Id).FirstOrDefault();
            //             personToVaccinate.Vaccination.FirstDose = true;
            //             _context.SaveChanges();
            //         }
            //         return Ok(oldestFirst);
            //     };
            // }

            return Ok();
        }

        [HttpGet("vaccinated/phase-one")]
        public IActionResult PhaseOneVaccination()
        {
            throw new NotImplementedException();
        }

        [HttpPost("people")]
        public IActionResult AddPerson([FromBody] AddPersonDTO person)
        {
            var thisPerson = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                SocialSecurityNumber = person.SocialSecurityNumber,
                HealthCareEmployee = person.HealthCareEmployee,
                MedicalCondition = person.MedicalCondition
            };

            _context.Persons.Add(thisPerson);
            _context.SaveChanges();
            int personId = _context.Persons.Where(x => x.SocialSecurityNumber == person.SocialSecurityNumber)
                .Select(x => x.Id).First();

            Vaccination vac = new Vaccination
            {
                FirstDose = false,
                SecondDose = false,
                Manufacturer = null,
                PersonId = personId
            };
            _context.Vaccinations.Add(vac);

            _context.SaveChanges();
            return Ok($"{person.FirstName} tillagd i databasen");
        }

        // [HttpGet]
        // public IActionResult UpcomingVaccinations() {
        //     int doses = _context.AvailableDoses.Count();

        //     var healthCarePeople = _context.Persons.Where(x => x.HealthCareEmployee == true).ToList();
        //     var medicalConditionPeople = _context.Persons.Where(x => x.MedicalCondition == true).ToList();
        //     var peopleToVaccinate = new List<Person>();
        //     throw new NotImplementedException();
        // }
    }
}