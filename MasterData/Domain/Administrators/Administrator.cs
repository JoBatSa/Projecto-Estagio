
using System;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;
using DDDSample1.Domain.Administrators;

namespace DDDSample1.Domain.Administrators
{
    public class Administrator : Entity<AdministratorId>, IAggregateRoot
    {
        public Job_PositionType AdminP { get; private set; }
    
        public User user { get; private set; }

        public Password password { get; private set; }
        private Administrator()
        {

        }

        public Administrator(string user)
        {
            this.Id = new AdministratorId(Guid.NewGuid());

            this.user = new User(user);
            this.password = new Password("Administrador");
            this.AdminP = new Job_PositionType(1000);     
       }


    }
}