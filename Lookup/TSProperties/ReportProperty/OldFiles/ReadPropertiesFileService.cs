using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Lookup.TSProperties.ReportProperty
{
    internal class ReadPropertiesFileService
    {
        public IEnumerable<PossiblePropertyQuery> Read()
        {

            IEnumerable<string> queryRows = FileService.Read();

            IEnumerable<PossiblePropertyQuery> fileData = GetPropertyQueriesDb(queryRows);

            return fileData;
        }

        private IEnumerable<PossiblePropertyQuery> GetPropertyQueriesDb(IEnumerable<string> rows)
        {
            var fileData = new List<PossiblePropertyQuery>();
            foreach (string row in rows)
            {
                string handeledRow = row.Replace("\"", "");
                string[] data = row.Split(new string[] { " ", ";", "," },
                    StringSplitOptions.RemoveEmptyEntries);

                Type type = null;
                if (data.Length >= 2)
                {
                    type = GetTypeByStringDescription(data[1]);

                    if (type != null)
                        fileData.Add(GetPropertyDataForDefinedType(data, type));

                    if (type == null)
                        fileData.AddRange(GetPropertiesForNonDefinedType(data));
                }
            }

            IEnumerable<PossiblePropertyQuery> result = fileData.GroupBy(d => new { d.Name, d.Type })
                .Select(d => new PossiblePropertyQuery { Name = d.Key.Name, Type = d.Key.Type, QueryString = d.Key.Name }).ToList();

            return result;
        }

        private List<PossiblePropertyQuery> GetPropertiesForNonDefinedType(string[] data)
        {
            var fileData = new List<PossiblePropertyQuery>();
            var propertyData1 = new PossiblePropertyQuery()
            {
                Name = data[0],
                Type = typeof(double),
                QueryString = data[0],
            };
            fileData.Add(propertyData1);

            var propertyData2 = new PossiblePropertyQuery()
            {
                Name = data[0],
                Type = typeof(string),
                QueryString = data[0],
            };
            fileData.Add(propertyData2);

            var propertyData3 = new PossiblePropertyQuery()
            {
                Name = data[0],
                Type = typeof(int),
                QueryString = data[0],
            };
            fileData.Add(propertyData3);

            return fileData;
        }

        private PossiblePropertyQuery GetPropertyDataForDefinedType(string[] data, Type type)
            => new PossiblePropertyQuery()
            {
                Name = data[0],
                QueryString = data[0],
                Type = type,
            };

        private string GetLastPart(string value)
        {
            string[] strings = value.Split('.');
            string lastPart = strings.LastOrDefault();
            string[] lastPartStrings = lastPart.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return strings.FirstOrDefault();
        }

        private Type GetTypeByStringDescription(string type)
        {
            switch (type.ToLower())
            {
                case ("character"):
                case ("string"):
                    return typeof(string);
                case ("integer"):
                case ("int32"):
                    return typeof(int);
                case ("double"):
                case ("float"):
                    return typeof(double);
                default:
                    return null;
            }
        }
    }
}
