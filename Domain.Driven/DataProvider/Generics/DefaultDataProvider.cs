// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultDataProvider.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The default data provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.DataProvider.Generics
{
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Reflection;

    using Mono.Reflection;

    using N4.Domain.Driven.Model;
    using N4.Domain.Driven.Model.Attrs;
    using N4.Domain.Driven.Utils.Extensions;
    using N4.Domain.Driven.Utils.Typing;

    /// <summary>
    /// The default data provider.
    /// </summary>
    /// <typeparam name="TDomainModel">
    /// The domain model type.
    /// </typeparam>
    /// <typeparam name="TIdentifier">
    /// The identifier type.
    /// </typeparam>
    internal sealed class DefaultDataProvider<TDomainModel, TIdentifier> : DataProvider<TDomainModel, TIdentifier>
        where TDomainModel : IDomainModel<TDomainModel, TIdentifier>, new()
    {
        /// <summary>
        /// The binding flags.
        /// </summary>
        private const BindingFlags BINDING_FLAGS = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        /// <summary>
        /// Fill the domain model.
        /// </summary>
        /// <param name="dataReader">
        /// The data reader.
        /// </param>
        /// <returns>
        /// The <see cref="TDomainModel"/>.
        /// </returns>
        protected override TDomainModel FillDomainModel(IDataReader dataReader)
        {
            var domainModel = new TDomainModel();

            var type = typeof(TDomainModel);
            var properties = type.GetProperties(BINDING_FLAGS).Where(p => p.GetCustomAttributes<FieldAttribute>(false).Any()).ToList();

            foreach (var property in properties)
            {
                var backingField = property.GetBackingField();
                backingField.SetValue(domainModel, dataReader.GetFieldValue(property.GetType(), property.GetCustomAttribute<FieldAttribute>().FieldName));
            }

            return domainModel;
        }

        /// <summary>
        /// Fill the domain model.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="domainModel">
        /// The domain Model.
        /// </param>
        protected override void FillParameters(DbCommand command, TDomainModel domainModel)
        {
            var type = domainModel.GetType();
            var properties = type.GetProperties(BINDING_FLAGS).Where(p => p.GetCustomAttributes<FieldAttribute>(false).Any()).ToList();

            foreach (var property in properties)
            {
                // TODO: I need read the prefix from configuration.
                this.Database.AddInParameter(
                    command,
                    string.Format("@{0}", property.GetCustomAttribute<FieldAttribute>().FieldName),
                    DbTypeUtils.GetFromType(property.GetType()));
            }
        }
    }
}