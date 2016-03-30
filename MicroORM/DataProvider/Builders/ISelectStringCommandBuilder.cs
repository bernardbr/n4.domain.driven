// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISelectStringCommandBuilder.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The select string command builder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.DataProvider.Builders
{
    using System;

    /// <summary>
    /// The select string command builder interface.
    /// </summary>
    public interface ISelectStringCommandBuilder
    {
        /// <summary>
        /// Build a select string command for type.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The select string command.
        /// </returns>
        string Build(Type type);
    }
}