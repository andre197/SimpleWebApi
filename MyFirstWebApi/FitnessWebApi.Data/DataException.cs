namespace FitnessWebApi.DAL
{
    using System;

    public class DataException : Exception
    {
        public DataException()
            : base()
        { }

        public DataException(string message)
            : base(message)
        { }
    }
}
