// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contract.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The code contract validation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Utils.CodeContract
{
    using System;

    /// <summary>
    /// The code contract validation.
    /// </summary>
    public static class Contract
    {
        /// <summary>
        /// Specify de requires of portion of code.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <param name="exceptionParameters">
        /// The exception parameters.
        /// </param>
        /// <typeparam name="TException">
        /// The exception type.
        /// </typeparam>
        public static void Requires<TException>(bool condition, params object[] exceptionParameters) where TException : Exception
        {
            if (condition)
            {
                return;
            }

            var exception = (TException)Activator.CreateInstance(typeof(TException), exceptionParameters);
            throw exception;
        }
    }
}