namespace DDDSample1.Domain.Administrators
{
    public class CreateAdministratorDto
    {
        public string password { get;  set; }
        public string user { get; set; }
    
        public CreateAdministratorDto(string password,string user)
        {
            this.password=password;
            this.user=user;
        }
    }
}