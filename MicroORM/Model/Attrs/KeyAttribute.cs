// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyAttribute.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The key attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Model.Attrs
{
    using System;

    /// <summary>
    /// The key attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class KeyAttribute : Attribute
    {
    }
}