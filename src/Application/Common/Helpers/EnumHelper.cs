namespace Application.Common.Helpers;

public static class EnumHelper
{
    public static TEnum? ConvertToEnum<TEnum>(string value)
        where TEnum : struct, Enum
    {
        if (Enum.TryParse<TEnum>(value, true, out var result))
        {
            return result;
        }
        return null;
    }
}