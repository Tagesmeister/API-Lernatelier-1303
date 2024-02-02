namespace API_DbTest.Modals
{
    public class Student
    {
        public bool IsLoggedIn { get; set; } = false;
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;


    }
    public class StudentDTO
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }
    }
    
}
