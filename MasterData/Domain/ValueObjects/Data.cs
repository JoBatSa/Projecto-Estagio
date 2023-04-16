using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DDDSample1.Domain.Shared;



using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;


namespace MasterData.Domain.ValueObjects

{

    [ComplexType]
    public class Data : ValueObject
    {
        public Data(DateTime data)
        {
            this.data = data;

        }
        public DateTime data { get; private set; }


        public Data() { }

        public Data(string data)
        {
            this.data = ConfData(data);

        }

      
        private DateTime ConfData(string data)
        {
            string[] splitData = data.Split("-");


            if (splitData.Length == 3)
            {
                DateTime tempData = new DateTime(Int32.Parse(splitData[0]), Int32.Parse(splitData[1]), Int32.Parse(splitData[2]));
                return tempData;
            }
            throw new BusinessRuleValidationException("Invalid Date Format");



        }
        public string toString()
        {
            return this.data.ToString();
        }
        public int getAno()
        {
            return this.data.Year;
        }
        public int getDia()
        {
            return this.data.Day;
        }

        public DateTime getDateTime()
        {
            return this.data;
        }
        public void aleraData(DateTime dt)
        {
          this.data=dt;
        }

         protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return data;
        }
    }
}