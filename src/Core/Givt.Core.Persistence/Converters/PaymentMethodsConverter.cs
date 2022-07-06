using Givt.Core.Domain.Enums;
using Givt.Platform.Payments.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Givt.Core.Persistence.Converters
{
    internal class PaymentMethodsConverter
    {
        public static ValueConverter<ICollection<PaymentMethod>, UInt64> GetConverter()
        {
            return new ValueConverter<ICollection<PaymentMethod>, UInt64>(
                list => GetBitmappedPaymentMethods(list),
                bitmap => GetListPaymentMethods(bitmap)
            );
        }

        public static ValueComparer<ICollection<PaymentMethod>> GetComparer()
        {
            return new ValueComparer<ICollection<PaymentMethod>>(
                (c1, c2) => c1.OrderBy(pm => pm).SequenceEqual(c2.OrderBy(pm => pm)),
                c => c.OrderBy(pm => pm).Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.OrderBy(pm => pm).ToList());
        }

        private static UInt64 GetBitmappedPaymentMethods(ICollection<PaymentMethod> list)
        {
            UInt64 result = 0;
            foreach (var paymentMethod in list)
                result |= (UInt64)0x1 << (byte)paymentMethod;

            return result;
        }

        private static ICollection<PaymentMethod> GetListPaymentMethods(UInt64 bitmap)
        {
            var result = new List<PaymentMethod>();
            UInt64 mask = 0x1;
            for (int i = 0; i < sizeof(UInt64) * 8; i++)
            {
                if ((bitmap & mask) != 0) { result.Add((PaymentMethod)i); }
                mask <<= 1;
            }
            return result;
        }

    }
}
