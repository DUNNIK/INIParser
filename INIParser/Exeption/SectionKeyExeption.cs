using System;

namespace INIParser.Exeption
{
    public class SectionKeyExeption : ParseExeption
    {
        public SectionKeyExeption()
        {
        }

        public SectionKeyExeption(string message) : base(message)
        {
        }

        public SectionKeyExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}