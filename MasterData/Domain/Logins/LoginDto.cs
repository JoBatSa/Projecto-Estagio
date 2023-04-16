using System;

namespace DDDSample1.Domain.Logins
{

    public class  LoginDto
    {
        public Guid Id { get; set; }
        
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public int Tipo{ get; set; }
    }
}