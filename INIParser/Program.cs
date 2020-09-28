using System;
using System.Text.RegularExpressions;
using INIParser.Exeption;
using INIParser.Parser;

namespace INIParser
{
    internal static class Program
    {
        private static ParsedIniFile _inifile;

        private static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.Error.WriteLine(
                    "Wrong number of parameters!" +
                    "\nUsage: INIParser.exe temp.ini");
                return;
            }

            try
            {
                _inifile = IniParser.Parse(args[0]);
            }
            catch (FileParseExeption)
            {
                Console.Error.WriteLine("File subsystem error!");
                return;
            }
            catch (FileFormatExeption)
            {
                Console.Error.WriteLine("File format error!");
                return;
            }

            Console.Write("Section:");
            var section = Console.ReadLine();
            Console.Write("Key:");
            var key = Console.ReadLine();
            Console.Write("Type:");
            var type = Console.ReadLine();

            WhatType(ref type, out var types);

            try
            {
                switch (types)
                {
                    case Types.Double:
                        Console.WriteLine($"Your parameter of type double: {_inifile.GetDouble(section, key)}");
                        break;
                    case Types.Int:
                        Console.WriteLine($"Your parameter of type integer: {_inifile.GetInt(section, key)}");
                        break;
                    case Types.String:
                        Console.WriteLine($"Your parameter of type string: {_inifile.GetString(section, key)}");
                        break;
                    default:
                        throw new TypesExeption("Invalid parameter type!");
                }
            }
            catch (TypesExeption)
            {
                Console.Error.WriteLine("Conversion to this type is not possible!");
            }
            catch (SectionKeyExeption)
            {
                Console.Error.WriteLine("The specified pair SECTION PARAMETER is not in the configuration file!");
            }
            catch (ParseExeption)
            {
                Console.Error.WriteLine("Wrong parametr for parse!");
            }
        }

        private static void WhatType(ref string type, out Types types)
        {
            var getDoublePattern = new Regex("double", RegexOptions.IgnoreCase);
            var getIntPattern = new Regex("int|integer", RegexOptions.IgnoreCase);
            var getStringPattern = new Regex("string", RegexOptions.IgnoreCase);

            if (getDoublePattern.IsMatch(type!))
                types = Types.Double;
            else if (getIntPattern.IsMatch(type!))
                types = Types.Int;
            else if (getStringPattern.IsMatch(type!))
                types = Types.String;
            else
                types = Types.None;
        }

        private enum Types
        {
            Double,
            Int,
            String,
            None
        }
    }
}