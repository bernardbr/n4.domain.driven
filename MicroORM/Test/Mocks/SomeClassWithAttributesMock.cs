// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SomeClassWithAttributesMock.cs" company="N4Works">
//     N4Works.com
// </copyright>
// <summary>
// The mock of some class with attributes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Test.Mocks
{
    using System.Data;

    using N4.Domain.Driven.Model.Attrs;

    /// <summary>
    /// The mock of some class with attributes.
    /// </summary>
    [Table("Some_Class_Table_Name")]
    public class SomeClassWithAttributesMock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SomeClassWithAttributesMock"/> class.
        /// </summary>
        public SomeClassWithAttributesMock()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Gets or sets the another value.
        /// </summary>
        [Field("Another_Value")]
        public string AnotherValue { get; set; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        [Key]
        [Field("Some_Class_Table_Name_Id", DbType.Int32)]
        public int Id { get; private set; }
    }
}