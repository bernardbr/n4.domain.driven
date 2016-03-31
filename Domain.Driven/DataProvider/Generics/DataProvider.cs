// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="N4Works">
//     N4Works.com
// </copyright>
// <summary>
// The generic data provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.DataProvider.Generics
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    using N4.Domain.Driven.Model;

    /// <summary>
    /// The generic data provider.
    /// </summary>
    /// <typeparam name="TDomainModel">
    /// The domain model type.
    /// </typeparam>
    /// <typeparam name="TIdentifier">
    /// The identifier type.
    /// </typeparam>
    public abstract class DataProvider<TDomainModel, TIdentifier>
        : IDataProvider<TDomainModel, TIdentifier>
        where TDomainModel : IDomainModel<TDomainModel, TIdentifier>, new()
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProvider{TDomainModel,TIdentifier}"/> class.
        /// </summary>
        protected DataProvider()
        {
            var factory = new DatabaseProviderFactory();
            this.database = factory.CreateDefault();
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        protected Database Database
        {
            get
            {
                return this.database;
            }
        }

        /// <summary>
        /// The get all models.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{TDomainModel}"/>.
        /// </returns>
        public virtual IEnumerable<TDomainModel> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get domain model by id.
        /// </summary>
        /// <param name="identifier">
        /// The identifier.
        /// </param>
        /// <returns>
        /// The <see cref="TDomainModel"/>.
        /// </returns>
        public virtual TDomainModel GetById(TIdentifier identifier)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the domain model.
        /// </summary>
        /// <param name="domainModel">
        /// The domain model.
        /// </param>
        /// <returns>
        /// The <see cref="TDomainModel"/>.
        /// </returns>
        public virtual TDomainModel Insert(TDomainModel domainModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the domain model.
        /// </summary>
        /// <param name="domainModel">
        /// The domain model.
        /// </param>
        /// <returns>
        /// The <see cref="TDomainModel"/>.
        /// </returns>
        public virtual TDomainModel Update(TDomainModel domainModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fill the domain model.
        /// </summary>
        /// <param name="dataReader">
        /// The data reader.
        /// </param>
        /// <returns>
        /// The <see cref="TDomainModel"/>.
        /// </returns>
        protected abstract TDomainModel FillDomainModel(IDataReader dataReader);

        /// <summary>
        /// Fill the domain model.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="domainModel">
        /// The domain Model.
        /// </param>
        protected abstract void FillParameters(DbCommand command, TDomainModel domainModel);
    }
}