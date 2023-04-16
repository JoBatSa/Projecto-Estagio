using System;
using System.Text.Json.Serialization;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.WorkAuthorizations
{
 
        public class WorkAuthorizationId:EntityId
         {
     [JsonConstructor]
        public WorkAuthorizationId(Guid value) : base(value) {
        }

          public WorkAuthorizationId(String value) : base(value) {
        }
        
        override
        protected Object createFromString(String text) {
            return new Guid(text);
        }

        override
        public String AsString() {
            Guid obj = (Guid) base.ObjValue;
            return obj.ToString();
        }

        public Guid AsGuid() {
            return (Guid) base.ObjValue;
        }

    }
}