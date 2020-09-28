using System;

namespace INIParser.Exeption
{
    public class FileFormatExeption : ParseExeption
    {
        public FileFormatExeption()
        {
        }

        public FileFormatExeption(string message) : base(message)
        {
        }

        public FileFormatExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}