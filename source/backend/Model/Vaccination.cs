using System.Collections.Generic;

namespace backend.Model
{
    public class Vaccination
    {
        public int Id { get; set; }
        public bool FirstDose { get; set; }
        public bool SecondDose { get; set; }
        public string Manufacturer { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}