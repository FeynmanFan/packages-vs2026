namespace ourcompany.businesslibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Xml.Serialization;
    using CsvHelper;
    using System.Globalization;
    using YamlDotNet.Serialization;
    using YamlDotNet.Serialization.NamingConventions;

    public class FileManifold
    {
        private readonly string _filePath;

        public FileManifold(string filePath)
        {
            _filePath = filePath;
        }

        // Main method - easy to use!
        public object ReadFile()
        {
            string extension = Path.GetExtension(_filePath).ToLower();

            Console.WriteLine($"Reading file: {_filePath}");

            return extension switch
            {
                ".json" => ReadJson(),
                ".xml" => ReadXml(),
                ".csv" => ReadCsv(),
                ".yaml" or ".yml" => ReadYaml(),
                _ => throw new Exception($"Sorry, I don't support {extension} files yet.")
            };
        }

        // ====================== JSON ======================
        private List<Person> ReadJson()
        {
            string text = File.ReadAllText(_filePath);
            var people = JsonSerializer.Deserialize<List<Person>>(text);
            Console.WriteLine("✅ Successfully read JSON file");
            return people ?? [];
        }

        // ====================== XML ======================
        private List<Person> ReadXml()
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            using var reader = new StreamReader(_filePath);

            var people = (List<Person>?)serializer.Deserialize(reader);
            Console.WriteLine("✅ Successfully read XML file");
            return people ?? [];
        }

        // ====================== CSV ======================
        private List<Person> ReadCsv()
        {
            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var people = csv.GetRecords<Person>().ToList();
            Console.WriteLine($"✅ Successfully read CSV file ({people.Count} records)");
            return people;
        }

        // ====================== YAML ======================
        private List<Person> ReadYaml()
        {
            string text = File.ReadAllText(_filePath);

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var people = deserializer.Deserialize<List<Person>>(text);
            Console.WriteLine("✅ Successfully read YAML file");
            return people ?? [];
        }
    }
}
