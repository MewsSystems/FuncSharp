using System.Collections.Generic;
using System.Linq;

namespace FuncSharp;

public static class DigitExtensions
{
    public static Option<Digit> AsDigit(this char value)
    {
        return Digit.Create(value);
    }

    public static IEnumerable<Digit> FilterDigits(this string value)
    {
        if (value is null)
        {
            return Enumerable.Empty<Digit>();
        }
        return value.Select(Digit.Create).Flatten();
    }
}