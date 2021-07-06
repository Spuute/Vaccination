namespace backend.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public bool HealthCareEmployee { get; set; }
        public bool MedicalCondition { get; set; }
        public Vaccination Vaccination { get; set; }
    }
}