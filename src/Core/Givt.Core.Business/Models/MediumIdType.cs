using Givt.Platform.Common.Exceptions;
using Microsoft.Linq.Translations;
using Newtonsoft.Json;
using System.Text;

namespace Givt.Core.Business.Models;

[JsonConverter(typeof(MediumIdTypeSerializer))]
public struct MediumIdType : IComparable<MediumIdType>
{
    private readonly string _value;
    public MediumIdType(string value)
    {
        // Valid medium length = 20 chars (+ dot + 12 chars)
        var dot = value.IndexOf('.');
        var len = value.Length;
        if (dot >= 0)
        {
            if (dot != 20)
                throw new InvalidMediumException(nameof(Namespace), value);
            if (len - dot != 12 + 1)
                throw new InvalidMediumException(nameof(Instance), value);
        }
        else if (len != 20)
            throw new InvalidMediumException(nameof(Namespace), value);

        _value = value;
    }

    public static MediumIdType FromString(string s)
    {
        try
        {
            return new MediumIdType(s);            
        }
        catch (InvalidMediumException)
        {
            byte[] data = Convert.FromBase64String(s);
            string decodedString = Encoding.UTF8.GetString(data);
            return new MediumIdType(decodedString);
        }
    }

    private static readonly CompiledExpression<MediumIdType, string> NameSpaceExpression =
        DefaultTranslationOf<MediumIdType>.Property(m => m.Namespace)
        .Is(m => ((string)m).Substring(0, 20));

    private static readonly CompiledExpression<MediumIdType, string> InstanceExpression =
        DefaultTranslationOf<MediumIdType>.Property(m => m.Instance)
        .Is(m => ((string)m).Length > 20 ? ((string)m).Substring(21, 12) : null);
    
    public bool Equals(MediumIdType other)
    {
        return _value == other._value;
    }

    public override bool Equals(object obj)
    {
        return obj is MediumIdType other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (_value != null ? _value.GetHashCode() : 0);
    }

    public static bool operator ==(MediumIdType a, MediumIdType b)
    {
        return a.Equals(b);
    } 
    public static bool operator !=(MediumIdType a, MediumIdType b)
    {
        return !(a == b);
    }

    public static implicit operator MediumIdType(string value)
    {
        return new MediumIdType(value.ToLower());
    }

    public static implicit operator string(MediumIdType type)
    {
        return type._value.ToLower();
    }

    public override string ToString()
    {
        return _value;
    }

    public int CompareTo(MediumIdType other)
    {
        return string.Compare(_value, other._value, StringComparison.Ordinal);
    }

    public string Namespace => NameSpaceExpression.Evaluate(this);

    public string Instance => InstanceExpression.Evaluate(this);
}