using System;
using System.Text.Json.Serialization;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Reports
{
    public class ReportId: EntityId
    {

 [JsonConstructor]
        public ReportId(Guid value) : base(value) {
        }

          public ReportId(String value) : base(value) {
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