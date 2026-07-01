using ourcompany.businesslibrary;

namespace ourcompany.client
{
    internal class Program
    {
        static void Main()
        {
            const string FILEPATH = "C:\\code\\packages-vs2026\\ourcompany.client\\";

            // JSON
            var jsonManifold = new FileManifold(FILEPATH + "data/people.json");
            var jsonData = jsonManifold.ReadFile() as List<Person>;

            // XML
            var xmlManifold = new FileManifold(FILEPATH + "data/people.xml");
            var xmlData = xmlManifold.ReadFile() as List<Person>;

            // CSV
            var csvManifold = new FileManifold(FILEPATH + "data/people.csv");
            var csvData = csvManifold.ReadFile() as List<Person>;

            // YAML (new!)
            var yamlManifold = new FileManifold(FILEPATH + "data/people.yaml");
            var yamlData = yamlManifold.ReadFile() as List<Person>;

            Console.WriteLine($"Loaded {yamlData?.Count ?? 0} people from YAML");
        }
    }
}
