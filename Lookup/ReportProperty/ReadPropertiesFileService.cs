using System;
using System.Collections.Generic;
using System.Linq;

namespace Lookup.ReportProperty
{
    internal class ReadPropertiesFileService
    {
        public List<PossiblePropertyQuery> Read()
        {
            string[] queryRows = FileService.Read("1.lst");

            List<PossiblePropertyQuery> fileData = GetPropertyQueriesDb(queryRows);

            return fileData;
        }

        private List<PossiblePropertyQuery> GetPropertyQueriesDb(string[] rows)
        {
            var fileData = new List<PossiblePropertyQuery>();
            var propertyTypeReadService = new FileTypeService();
            foreach (string row in rows)
            {
                string[] data = row.Split(new string[] { " = " },
                    StringSplitOptions.RemoveEmptyEntries);
                string endQueryName = GetLastPart(data[1]);

                Type type = propertyTypeReadService.GetType(endQueryName);

                if (type != null)
                    fileData.Add(GetPropertyDataForDefinedType(data, type));

                if (type == null)
                    fileData.AddRange(GetPropertiesForNonDefinedType(data));
            }

            return fileData;
        }

        private List<PossiblePropertyQuery> GetPropertiesForNonDefinedType(string[] data)
        {
            var fileData = new List<PossiblePropertyQuery>();
            var propertyData1 = new PossiblePropertyQuery()
            {
                Name = data[0],
                Type = typeof(double),
                QueryString = data[1],
            };
            fileData.Add(propertyData1);

            var propertyData2 = new PossiblePropertyQuery()
            {
                Name = data[0],
                Type = typeof(string),
                QueryString = data[1],
            };
            fileData.Add(propertyData2);

            var propertyData3 = new PossiblePropertyQuery()
            {
                Name = data[0],
                Type = typeof(int),
                QueryString = data[1],
            };
            fileData.Add(propertyData3);

            return fileData;
        }

        private PossiblePropertyQuery GetPropertyDataForDefinedType(string[] data, Type type)
            => new PossiblePropertyQuery()
            {
                Name = data[0],
                QueryString = data[1],
                Type = type,
            };

        private string GetLastPart(string value)
        {
            string[] strings = value.Split('.');
            string lastPart = strings.LastOrDefault();
            string[] lastPartStrings = lastPart.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return strings.FirstOrDefault();
        }
    }
}
