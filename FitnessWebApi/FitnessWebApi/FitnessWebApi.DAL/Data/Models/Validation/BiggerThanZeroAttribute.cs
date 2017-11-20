namespace FitnessWebApi.DAL.Data.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class BiggerThanZeroAttribute : ValidationAttribute
    {
        private static string errorMessage;

        public BiggerThanZeroAttribute()
        { }

        public BiggerThanZeroAttribute(string errMessage) : base(errMessage)
        { }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (decimal.TryParse(value.ToString(), out decimal number))
            {
                if (number > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
