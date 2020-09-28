using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using INIParser.Exeption;

namespace INIParser.Parser
{
    public static class IniParser
    {
        private static readonly Regex SectionPattern = new Regex("^[[]{1}[a-zA-Z_0-9]+[]]{1}$");
        private static readonly Regex ParametrPattern = new Regex(@"^[a-zA-Z_0-9]+ = .+$");
        private static string Section { get; set; } = "";
        private static string PreviusSection { get; set; } = "";
        private static string NowSection { get; set; } = "";
        private static Dictionary<string, string> CurrentSection { get; set; } = new Dictionary<string, string>();
        private static string[] Lines { get; set; }
        public static ParsedIniFile Parse(string filePath)
        {
            var builder = new IniFileBuilder();
            
            try
            {
                Lines = File.ReadAllLines(filePath);
            }
            catch
            {
                throw new FileParseExeption();
            }

            foreach (var line in Lines)
            {
                var clearLine = ClearLine(line);
                
                
                if (SectionPattern.IsMatch(clearLine) || ParametrPattern.IsMatch(clearLine) || clearLine == "")
                {
                    SectionIsMatch(ref clearLine);

                    ParametrIsMatch(ref clearLine);

                    if (Section != NowSection && PreviusSection != "")
                    {
                        builder.AddSection(PreviusSection, CurrentSection);
                        NowSection = Section;
                        CurrentSection = new Dictionary<string, string>();
                    }
                }
                else
                {
                    throw new FileFormatExeption();
                }
            }

            if (PreviusSection != "") builder.AddSection(Section, CurrentSection);

            return builder.Build();
        }

        private static string ClearLine(string line)
        {
            var index = line.IndexOf(';');
            if (index >= 0) line = line.Remove(index, line.Length - index);
            line = line.Trim();

            return line;
        }

        private static void SectionIsMatch(ref string clearLine)
        {
            if (SectionPattern.IsMatch(clearLine))
            {
                PreviusSection = Section;
                Section = clearLine.Trim('[', ']');
            }
        }

        private static void ParametrIsMatch(ref string clearLine)
        {
            if (ParametrPattern.IsMatch(clearLine))
            {
                var param = clearLine.Split(' ');
                var key = param[0];
                var value = param[2];
                CurrentSection.Add(key, value);
            }
        }
    }
}