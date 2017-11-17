namespace FitnessWebApi.DAL.Data.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class BiggerThanZeroAttribute : ValidationAttribute
    {
        public BiggerThanZeroAttribute()
        {        }

        public BiggerThanZeroAttribute(string errorMessage) : base(errorMessage)
        {

        }

        public static bool IsBiggerThanZero(decimal number)
        {
            if (number > 0)
            {
                return true;
            }

            return false;
        }
    }
}
