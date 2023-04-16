using System;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;


namespace DDDSample1.Domain.Logins
{
    public class Login : Entity<LoginId>, IAggregateRoot
    {
       
        public Text Name { get; private set; }

        public User User { get; private set; }

        public Data Date { get; private set; }

        public Job_PositionType tipo { get; private set; }
        private Login()
        {

        }

        public Login(string name, string user, Job_PositionType tipo)
        {
            this.Id = new LoginId(Guid.NewGuid());
            this.Name = new Text(name);
            this.User = new User(user);
            DateTime localDate = DateTime.Now;
            Data Date = new Data();
            Date.aleraData(localDate);
            this.Date = Date;
            this.tipo = tipo;

        }


    }
}