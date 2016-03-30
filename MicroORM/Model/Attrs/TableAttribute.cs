// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TableAttribute.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The table attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Model.Attrs
{
    using System;

    /// <summary>
    /// The table attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableAttribute"/> class.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }

        /// <summary>
        /// Gets the table name.
        /// </summary>
        public string TableName { get; private set; }
    }
}