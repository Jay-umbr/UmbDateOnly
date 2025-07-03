using Newtonsoft.Json;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace DateOnly;

public class DateOnlyValueConverter : IPropertyValueConverter
{
    public bool IsConverter(IPublishedPropertyType propertyType) => propertyType.EditorAlias == "UmbDateOnly";
    
    public object? ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object? source,
        bool preview)
    {
        if (source == null) throw new NullReferenceException(source?.ToString());
        DateOnlyModel converted = JsonConvert.DeserializeObject<DateOnlyModel>(source.ToString()!)!;
        return converted;
    }
    
    public object? ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType,
        PropertyCacheLevel referenceCacheLevel, object? inter, bool preview)
    {
        if (inter == null)
        {
            return null;
        };

        if (inter is DateOnlyModel dto)
        {
            inter = new System.DateOnly(dto.Year, dto.Month, dto.Day);
            return inter;
        }

        return null;
    }

    public PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType) => PropertyCacheLevel.Element;

    public Type GetPropertyValueType(IPublishedPropertyType propertyType) => typeof(System.DateOnly);
    
    public object? ConvertIntermediateToXPath(IPublishedElement owner, IPublishedPropertyType propertyType,
        PropertyCacheLevel referenceCacheLevel, object? inter, bool preview) => throw new NotImplementedException();

    public bool? IsValue(object? value, PropertyValueLevel level) => value is System.DateOnly;
}