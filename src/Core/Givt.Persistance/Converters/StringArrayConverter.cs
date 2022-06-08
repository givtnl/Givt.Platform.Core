using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Givt.Persistance.Converters;

internal class StringArrayConverter
{
    public static ValueConverter<string[], string> GetConverter()
    {
        return new ValueConverter<string[], string>(
            v => String.Join('\n', v),
            v => v.Split('\n', StringSplitOptions.None));
    }

    public static ValueComparer<string[]> GetComparer()
    {
        return new ValueComparer<string[]>(true);
    }
}
