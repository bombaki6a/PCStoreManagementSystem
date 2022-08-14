namespace PCStoreManagementSystem.Extensions;

/// <summary>
/// EnumBinding, helps with binding enums to ItemsSource of Pickers.
/// </summary>
[ContentProperty(nameof(EnumType))]
public class EnumBinding : IMarkupExtension
{
    public Type EnumType { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        if (EnumType == null || !EnumType.IsEnum)
        {
            throw new Exception("Provide type is not of type enum!");
        }
        else
        {
            return Enum.GetValues(EnumType);
        }
    }
}
