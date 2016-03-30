// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldAttribute.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The field attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Model.Attrs
{
    using System;
    using System.Data;

    /// <summary>
    /// The field attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldAttribute"/> class.
        /// </summary>
        /// <param name="fieldName">
        /// The field name.
        /// </param>
        public FieldAttribute(string fieldName)
            : this(fieldName, DbType.String)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldAttribute"/> class.
        /// </summary>
        /// <param name="fieldName">
        /// The field name.
        /// </param>
        /// <param name="fieldType">
        /// The field type.
        /// </param>
        public FieldAttribute(string fieldName, DbType fieldType)
        {
            this.FieldName = fieldName;
            this.FieldType = fieldType;
        }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// Gets the field type.
        /// </summary>
        public DbType FieldType { get; private set; }
    }
}