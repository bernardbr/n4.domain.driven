// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectStringCommandBuilder.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The select string command builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.DataProvider.Builders
{
    using N4.Domain.Driven.DataProvider.Builders.SqlServer;

    /// <summary>
    /// The select string command builder.
    /// </summary>
    public static class SelectStringCommandBuilder
    {
        /// <summary>
        /// Gets the <see cref="ISelectStringCommandBuilder"/> instance.
        /// </summary>
        /// <returns>
        /// The <see cref="ISelectStringCommandBuilder"/>.
        /// </returns>
        public static ISelectStringCommandBuilder Get()
        {
            // TODO: Read config here and instantiate a specific class for DB.
            return new SqlServerSelectStringCommandBuilder();
        }
    }
}