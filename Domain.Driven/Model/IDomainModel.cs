// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDomainModel.cs" company="N4Works">
//     N4Works.com
// </copyright>
// <summary>
// The domain model interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Model
{
    using System;

    using N4.Domain.Driven.Model.Attrs;

    /// <summary>
    /// The domain model interface.
    /// </summary>
    /// <typeparam name="TDomainModel">
    /// The domain type model.
    /// </typeparam>
    /// <typeparam name="TIdentifier">
    /// The type of identifier.
    /// </typeparam>
    public interface IDomainModel<TDomainModel, out TIdentifier>
        : IEquatable<TDomainModel>
        where TDomainModel : new()
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        [Field("Id")]
        TIdentifier Identifier { get; }
    }
}