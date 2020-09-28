using System;

namespace INIParser.Exeption
{
    public class TypesExeption : ParseExeption
    {
        public TypesExeption()
        {
        }

        public TypesExeption(string message) : base(message)
        {
        }

        public TypesExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}