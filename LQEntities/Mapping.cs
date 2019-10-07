using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INOM.Entities
{
    public class Mapping
    {
        [Key]
        public int MappingID { get; set; }
        public string ExternalSystem { get; set; }
        public string LocalField { get; set; }
        public string LocalValue { get; set; }
        public string ExternalField { get; set; }
        public string ExternalValue { get; set; }
        public string ExternalObject { get; set; }
        public static List<Mapping> GetFieldValue(string ExternalSystem)
        {
            using (var db = new DBContext())
            {
                List<Mapping> mapping = db.Mappings
                                .Where(a => a.ExternalSystem == ExternalSystem)
                                .ToList();
                return mapping;
            }
        }
        public static string GetFieldValue(List<Mapping> mappings, string ExternalField, string LocalValue)
        {
            string externalValue = (from map in mappings where map.ExternalField == ExternalField && map.LocalValue == LocalValue select map.ExternalValue).FirstOrDefault();
            return externalValue ?? LocalValue;
        }
        public static string GetFieldValue(List<Mapping> mappings, string ExternalField)
        {
            string externalValue = (from map in mappings where map.ExternalField == ExternalField select map.ExternalValue).FirstOrDefault();
            return externalValue;
        }
        public static string GetLocalValue(List<Mapping> mappings, string LocalField, string ExternalValue)
        {
            string localValue = (from map in mappings where map.LocalField == LocalField && map.ExternalValue == ExternalValue select map.LocalValue).FirstOrDefault();
            return localValue;
        }
    }
}
