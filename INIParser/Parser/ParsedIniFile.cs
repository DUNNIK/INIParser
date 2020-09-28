using System;
using System.Collections.Generic;
using INIParser.Exeption;

namespace INIParser.Parser
{
    public class ParsedIniFile
    {
        private readonly Dictionary<string, Dictionary<string, string>> _data;

        public ParsedIniFile(Dictionary<string, Dictionary<string, string>> data)
        {
            _data = data;
        }


        public int GetInt(string section, string key)
        {
            string param;
            try
            {
                param = _data[section][key];
            }
            catch (Exception)
            {
                throw new SectionKeyExeption();
            }

            var result = int.TryParse(param, out var value);
            if (!result)
            {
                var str = _data[section][key].Replace(".", ",");
                result = int.TryParse(str, out value);
            }

            if (!result) throw new ParseExeption();
            return value;
        }

        public double GetDouble(string section, string key)
        {
            string param;
            try
            {
                param = _data[section][key];
            }
            catch (Exception)
            {
                throw new SectionKeyExeption();
            }

            var result = double.TryParse(param, out var value);
            if (!result)
            {
                var str = _data[section][key].Replace(".", ",");
                result = double.TryParse(str, out value);
            }

            if (!result) throw new ParseExeption();
            return value;
        }

        public string GetString(string section, string key)
        {
            return _data[section][key];
        }
    }
}