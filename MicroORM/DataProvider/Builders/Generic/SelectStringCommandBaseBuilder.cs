// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectStringCommandBaseBuilder.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The base builder for select.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.DataProvider.Builders.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using N4.Domain.Driven.Model.Attrs;
    using N4.Domain.Driven.Utils.CodeContract;
    using N4.Domain.Driven.Utils.Extensions;

    /// <summary>
    /// The base builder for select.
    /// </summary>
    internal abstract class SelectStringCommandBaseBuilder : ISelectStringCommandBuilder
    {
        /// <summary>
        /// The separator.
        /// </summary>
        private const string FIELD_SEPARATOR = ",";

        /// <summary>
        /// The from.
        /// </summary>
        private const string FROM = "FROM";

        /// <summary>
        /// The indent size.
        /// </summary>
        private const int INDENT_SIZE = 4;

        /// <summary>
        /// The select.
        /// </summary>
        private const string SELECT = "SELECT";

        /*
        /// <summary>
        /// The where.
        /// </summary>
        private const string WHERE = "WHERE";
        */

        /// <summary>
        /// Build a select string command for type.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The select string command.
        /// </returns>
        public string Build(Type type)
        {
            var tableAttribute = type.GetCustomAttribute<TableAttribute>(true);
            Contract.Requires<Exception>(tableAttribute != null, "The object type must have a table attribute.");

            var properties =
                type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .Where(p => p.GetCustomAttributes<FieldAttribute>(false).Any())
                    .ToList();
            Contract.Requires<Exception>(properties.Any(), "The object type must have a least one property with field attribute.");

            var fieldsForSelect = GetSelectStringFields(properties);

            // ReSharper disable once PossibleNullReferenceException
            return string.Format("{0}{1}{2}{3}{4}{5}{6}", SELECT, Environment.NewLine, fieldsForSelect, FROM, Environment.NewLine, new string(' ', INDENT_SIZE), tableAttribute.TableName);
        }

        /// <summary>
        /// Gets the select string fields.
        /// </summary>
        /// <param name="properties">
        /// The properties.
        /// </param>
        /// <returns>
        /// The <see cref="StringBuilder"/> with a select string fields.
        /// </returns>
        private static StringBuilder GetSelectStringFields(List<PropertyInfo> properties)
        {
            var keyFields = properties.Where(property => property.GetCustomAttribute<KeyAttribute>() != null).ToList();
            Contract.Requires<Exception>(keyFields.Any(), "The object type must have a least one proprety with key attribute.");

            var otherFields = properties.Except(keyFields).ToList();

            var fieldsForSelect = new StringBuilder();
            foreach (var keyField in keyFields)
            {
                fieldsForSelect.AppendLineWithSeparator(keyField.GetCustomAttribute<FieldAttribute>().FieldName.Trim(), FIELD_SEPARATOR, INDENT_SIZE);
            }

            foreach (var otherField in otherFields)
            {
                fieldsForSelect.AppendLineWithSeparator(otherField.GetCustomAttribute<FieldAttribute>().FieldName.Trim(), FIELD_SEPARATOR, INDENT_SIZE);
            }

            return fieldsForSelect;
        }
    }
}