namespace DDDSample1.Domain.Logins
{
    public class CreateLoginDto
    {
        public string password { get;  set; }
        public string user { get; set; }
    



        public CreateLoginDto(string password,string user)
        {
            this.password=password;
            this.user=user;
          
      
        }
    }
}