// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlServerSelectBuilderTest.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The sql server select builder test class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Test
{
    using System;

    using N4.Domain.Driven.DataProvider.Builders;
    using N4.Domain.Driven.Test.Mocks;

    using NUnit.Framework;

    /// <summary>
    /// The SQLServer select builder test class.
    /// </summary>
    [TestFixture]
    public class SqlServerSelectBuilderTest
    {
        /// <summary>
        /// Should be return select string command.
        /// </summary>
        [Test]
        public void ShouldBeReturnSelectStringCommand()
        {
            var expected = string.Format(
                    "{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                    "SELECT",
                    Environment.NewLine,
                    "    Some_Class_Table_Name_Id",
                    Environment.NewLine,
                    "    ,Another_Value",
                    Environment.NewLine,
                    "FROM",
                    Environment.NewLine,
                    "    Some_Class_Table_Name");

            var select = SelectStringCommandBuilder.Get().Build(typeof(SomeClassWithAttributesMock));
            Assert.IsNotEmpty(select);
            Assert.AreEqual(expected, select);
        }
    }
}
