using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;

namespace MasterData.Domain.ValueObjects
{

    [ComplexType]
    public class Image : ValueObject
    {

        public byte[] Bytes { get; private set; }

        private Image() { } // EFCore needs for proper working

        public Image(byte[] bytes)
        {

            if (bytes == null) throw new BusinessRuleValidationException("Image cant't be null!");

            this.Bytes = bytes;
        }

      
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Bytes;
        }

    }
}