using System.Data;

namespace CabinPi.Web.Services
{
    public static class ExtensionMethods
    {
        public static int? GetNullableInt32(this IDataReader reader, string columnName)
        {
            int columnIndex = reader.GetOrdinal(columnName);
            return reader.IsDBNull(columnIndex) ? null : reader.GetInt32(columnIndex);
        }

        public static T? Get<T>(this IDataReader reader, string columnName)
        {
            int columnIndex = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(columnIndex))
            {
                return default;
            }
            var type = Type.GetTypeCode(Nullable.GetUnderlyingType(typeof(T)));
            //switch (Type.GetTypeCode(typeof(T)))
            switch (type)
            {

                case TypeCode.Boolean:
                    return (T)(object)reader.GetBoolean(columnIndex);
                case TypeCode.Byte:
                    return (T)(object)reader.GetByte(columnIndex);
                case TypeCode.DateTime:
                    return (T)(object)reader.GetDateTime(columnIndex);
                case TypeCode.Decimal:
                    return (T)(object)reader.GetDecimal(columnIndex);
                case TypeCode.Double:
                    return (T)(object)reader.GetDouble(columnIndex);
                case TypeCode.Int16:
                    return (T)(object)reader.GetInt16(columnIndex);
                case TypeCode.Int32:
                    return (T)(object)reader.GetInt32(columnIndex);
                case TypeCode.Int64:
                    return (T)(object)reader.GetInt64(columnIndex);
                case TypeCode.Single:
                    return (T)(object)reader.GetFloat(columnIndex);
                case TypeCode.String:
                    return (T)(object)reader.GetString(columnIndex);
                default:
                    throw new NotSupportedException($"Type {typeof(T).Name} is not supported.");
            }
        }
    }
}
