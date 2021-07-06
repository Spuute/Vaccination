namespace backend.DTO
{
    public class AddPersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public bool HealthCareEmployee { get; set; }
        public bool MedicalCondition { get; set; }

    }
}