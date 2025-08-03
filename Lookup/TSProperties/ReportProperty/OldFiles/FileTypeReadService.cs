using System;
using System.Collections.Generic;
using System.Linq;

namespace Lookup.TSProperties.ReportProperty
{
    internal class FileTypeService
    {
        private readonly List<QueryType> _queryTypesDb;

        public FileTypeService()
            => _queryTypesDb = GetQueryTypesDb();

        public Type GetType(string endQueryName)
        {
            List<Type> types = _queryTypesDb
                 .Where(t => t.Name.ToLower() == endQueryName.ToLower())
                 .Select(t => t.Type)
                 .ToList();
            if (types.Count > 0)
                return types[0];
            return null;
        }

        private List<QueryType> GetQueryTypesDb()
        {
            string[] typeRows = FileService.Read("1.lst");
            List<QueryType> types = new List<QueryType>();
            foreach (string row in typeRows)
            {
                string[] array = row.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                QueryType propertyType = new QueryType();
                propertyType.Name = array[0].Replace(" ", "").Replace("\t", "");
                propertyType.Type = GetTypeByStringDescription(array[1]);
                types.Add(propertyType);
            }
            return types;
        }

        private Type GetTypeByStringDescription(string type)
        {
            switch (type)
            {
                default:
                case ("CHARACTER"):
                    return typeof(string);
                case ("INTEGER"):
                    return typeof(int);
                case ("FLOAT"):
                    return typeof(double);
            }
        }
    }
}
