using System.Globalization;

namespace EmployeesEditor.Common;

internal static class Extensions
{
    public static void SetProperties<T>(this T entity, Dictionary<string, string> parameters)
    {
        var entityType = typeof(T);

        foreach (var parameter in parameters)
        {
            var propertyInfo = entityType.GetProperty(parameter.Key)
                ?? throw new ArgumentException($"Property {parameter.Key} is not found in target entity.");

            var typedValue = Convert.ChangeType(parameter.Value, propertyInfo.PropertyType, new CultureInfo("en-US"));
            propertyInfo.SetValue(entity, typedValue);
        }
    }
}