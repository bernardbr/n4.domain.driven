// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataProvider.cs" company="N4Works">
//     N4Works.com
// </copyright>
// <summary>
// The data provider interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.DataProvider
{
    using System.Collections.Generic;

    using N4.Domain.Driven.Model;

    /// <summary>
    /// The data provider interface.
    /// </summary>
    /// <typeparam name="TDomainModel">
    /// The domain model type.
    /// </typeparam>
    /// <typeparam name="TIdentifier">
    /// The identifier type.
    /// </typeparam>
    public interface IDataProvider<TDomainModel, in TIdentifier>
        where TDomainModel : IDomainModel<TDomainModel, TIdentifier>, new()
    {
        /// <summary>
        /// The get all models.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{TDomainModel}"/>.
        /// </returns>
        IEnumerable<TDomainModel> GetAll();

        /// <summary>
        /// The get domain model by id.
        /// </summary>
        /// <param name="identifier">
        /// The identifier.
        /// </param>
        /// <returns>
        /// The <see cref="TDomainModel"/>.
        /// </returns>
        TDomainModel GetById(TIdentifier identifier);

        /// <summary>
        /// Inserts the domain model.
        /// </summary>
        /// <param name="domainModel">
        /// The domain model.
        /// </param>
        /// <returns>
        /// The <see cref="TDomainModel"/>.
        /// </returns>
        TDomainModel Insert(TDomainModel domainModel);

        /// <summary>
        /// Updates the domain model.
        /// </summary>
        /// <param name="domainModel">
        /// The domain model.
        /// </param>
        /// <returns>
        /// The <see cref="TDomainModel"/>.
        /// </returns>
        TDomainModel Update(TDomainModel domainModel);
    }
}