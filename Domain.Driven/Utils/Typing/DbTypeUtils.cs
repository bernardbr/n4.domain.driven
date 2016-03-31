// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbTypeUtils.cs" company="N4Works">
//     N4Works.com
// </copyright>
// <summary>
// The db type utils.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Utils.Typing
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// The db type utils.
    /// </summary>
    public static class DbTypeUtils
    {
        /// <summary>
        /// The list of DbType mapping.
        /// </summary>
        private static readonly Dictionary<Type, DbType> typeMap;

        /// <summary>
        /// Initializes static members of the <see cref="DbTypeUtils"/> class.
        /// </summary>
        static DbTypeUtils()
        {
            typeMap = new Dictionary<Type, DbType>();
            typeMap[typeof(byte)] = DbType.Byte;
            typeMap[typeof(sbyte)] = DbType.SByte;
            typeMap[typeof(short)] = DbType.Int16;
            typeMap[typeof(ushort)] = DbType.UInt16;
            typeMap[typeof(int)] = DbType.Int32;
            typeMap[typeof(uint)] = DbType.UInt32;
            typeMap[typeof(long)] = DbType.Int64;
            typeMap[typeof(ulong)] = DbType.UInt64;
            typeMap[typeof(float)] = DbType.Single;
            typeMap[typeof(double)] = DbType.Double;
            typeMap[typeof(decimal)] = DbType.Decimal;
            typeMap[typeof(bool)] = DbType.Boolean;
            typeMap[typeof(string)] = DbType.String;
            typeMap[typeof(char)] = DbType.StringFixedLength;
            typeMap[typeof(Guid)] = DbType.Guid;
            typeMap[typeof(DateTime)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
            typeMap[typeof(TimeSpan)] = DbType.Time;
            typeMap[typeof(byte[])] = DbType.Binary;
            typeMap[typeof(byte?)] = DbType.Byte;
            typeMap[typeof(sbyte?)] = DbType.SByte;
            typeMap[typeof(short?)] = DbType.Int16;
            typeMap[typeof(ushort?)] = DbType.UInt16;
            typeMap[typeof(int?)] = DbType.Int32;
            typeMap[typeof(uint?)] = DbType.UInt32;
            typeMap[typeof(long?)] = DbType.Int64;
            typeMap[typeof(ulong?)] = DbType.UInt64;
            typeMap[typeof(float?)] = DbType.Single;
            typeMap[typeof(double?)] = DbType.Double;
            typeMap[typeof(decimal?)] = DbType.Decimal;
            typeMap[typeof(bool?)] = DbType.Boolean;
            typeMap[typeof(char?)] = DbType.StringFixedLength;
            typeMap[typeof(Guid?)] = DbType.Guid;
            typeMap[typeof(DateTime?)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;
            typeMap[typeof(TimeSpan?)] = DbType.Time;
            typeMap[typeof(object)] = DbType.Object;
        }

        /// <summary>
        /// Get a <see cref="DbType"/> from <see cref="Type"/>.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="DbType"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// If the type is not supported for mapping.
        /// </exception>
        internal static DbType GetFromType(Type type)
        {
            DbType dataType;
            var nullUnderlyingType = Nullable.GetUnderlyingType(type);
            if (nullUnderlyingType != null)
            {
                type = nullUnderlyingType;
            }

            if (type.IsEnum)
            {
                type = Enum.GetUnderlyingType(type);
            }

            if (typeMap.TryGetValue(type, out dataType))
            {
                return dataType;
            }

            throw new NotSupportedException("If the type is not supported for mapping.");
        }
    }
}