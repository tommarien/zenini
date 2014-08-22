using System;

namespace Zenini
{
    public static class SectionExtensions
    {
        public static bool? GetValueAsBool(this ISection section, string key)
        {
            string property = section.GetValue(key);

            if (property == null) return null;

            if (property == "1" || property.Equals("true", StringComparison.OrdinalIgnoreCase))
                return true;

            if (property == "0" || property.Equals("false", StringComparison.OrdinalIgnoreCase))
                return false;

            throw new FormatException("String was not recognized as a valid Boolean.");
        }
    }
}