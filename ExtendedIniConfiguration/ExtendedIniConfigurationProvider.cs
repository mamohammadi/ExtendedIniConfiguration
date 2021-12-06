
using Microsoft.Extensions.Configuration.Ini;
using System.IO;
using System.Linq;

namespace ExtendedIniConfiguration
{
    public class ExtendedIniConfigurationProvider : IniConfigurationProvider
    {
        public ExtendedIniConfigurationProvider(IniConfigurationSource source) : base(source) { }

        public void Save(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                var sections = Data.GroupBy(item => item.Key.Split(':')[0]);
                foreach (var section in sections)
                {
                    writer.WriteLine($"[{section.Key}]");
                    foreach (var field in section)
                    {
                        writer.WriteLine($"{field.Key.Split(":")[1]}={field.Value}");
                    }
                    writer.WriteLine();
                }
            }
        }

    }
}
