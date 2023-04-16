using System;
using System.Text.Json.Serialization;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.WorkOrders
{
    public class WorkOrderId:EntityId
    {
     [JsonConstructor]
        public WorkOrderId(Guid value) : base(value) {
        }

          public WorkOrderId(String value) : base(value) {
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