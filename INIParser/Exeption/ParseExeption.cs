using System;

namespace INIParser.Exeption
{
    public class ParseExeption : Exception
    {
        public ParseExeption() : base("Parse exception.")
        {
        }

        public ParseExeption(string message) : base(message)
        {
        }

        public ParseExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}