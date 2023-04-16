using System;
using DDDSample1.Domain.Shared;
using Newtonsoft.Json;

namespace DDDSample1.Domain.Logins
{
    public class  LoginId : EntityId
    {
        [JsonConstructor]
        public  LoginId(Guid value) : base(value)
        {
        }

        public  LoginId(String value) : base(value)
        {
        }

        override
        protected  Object createFromString(String text){
            return new Guid(text);
        }

        override
        public String AsString(){
            Guid obj = (Guid) base.ObjValue;
            return obj.ToString();
        }
    
        public Guid AsGuid(){
            return (Guid) base.ObjValue;
        }
    }
}