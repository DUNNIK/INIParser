using System.Collections.Generic;

namespace INIParser.Parser
{
    public class IniFileBuilder
    {
        private readonly Dictionary<string, Dictionary<string, string>> _data;

        public IniFileBuilder()
        {
            _data = new Dictionary<string, Dictionary<string, string>>();
        }

        public void AddSection(string sectionName, Dictionary<string, string> keys)
        {
            _data.Add(sectionName, keys);
        }

        public ParsedIniFile Build()
        {
            return new ParsedIniFile(_data);
        }
    }
}