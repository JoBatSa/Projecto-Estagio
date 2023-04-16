using System;

using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;



namespace MasterData.Domain.ValueObjects
{

   public enum Job_PositionTypeList {
        Intern = 0,
        Controler = 1,
        Auditor = 2,
        TeamLeader = 3,
        Supervisor = 4,
        Manager = 5,

        Customer =100,

        Administrator = 1000
        
          }

    [ComplexType]
    public class Job_PositionType : ValueObject {

        public int job_Position { get; private set; }

        private Job_PositionType(){} // EFCore needs for proper working

        public Job_PositionType(int _job_Position) {
            if (!Enum.IsDefined(typeof(Job_PositionTypeList), _job_Position))
                throw new BusinessRuleValidationException("The job position type is invalid!");

            this.job_Position = _job_Position;
        }

       protected override IEnumerable<object> GetEqualityComponents() {
            // Using a yield return statement to return each element one at a time
            yield return job_Position;
        }
        
    }
}