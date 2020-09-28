using System;

namespace INIParser.Exeption
{
    public class FileParseExeption : ParseExeption
    {
        public FileParseExeption()
        {
        }

        public FileParseExeption(string message) : base(message)
        {
        }

        public FileParseExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}