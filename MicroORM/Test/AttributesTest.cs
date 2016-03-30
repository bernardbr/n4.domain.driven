// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributesTest.cs" company="N4Works">
//     N4Works.com
// </copyright>
// <summary>
// The attributes test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Test
{
    using System.Data;
    using System.Linq;
    using System.Reflection;

    using N4.Domain.Driven.Model.Attrs;
    using N4.Domain.Driven.Test.Mocks;

    using NUnit.Framework;

    /// <summary>
    /// The attributes test.
    /// </summary>
    [TestFixture]
    public class AttributesTest
    {
        /// <summary>
        /// The should be read attributes from some class.
        /// </summary>
        [Test]
        public void ShouldBeReadAttributesFromSomeClass()
        {
            var someClass = new SomeClassWithAttributesMock();
            var info = someClass.GetType();
            var someClassAttrs = info.GetCustomAttributes<TableAttribute>(true).ToList();

            Assert.AreEqual(1, someClassAttrs.Count());

            foreach (var attr in someClassAttrs)
            {
                Assert.IsInstanceOf<TableAttribute>(attr);
                Assert.AreEqual("Some_Class_Table_Name", attr.TableName);
            }

            var properties = info.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            Assert.AreEqual(2, properties.Count());

            var propertiesWithAttrs = properties.Where(p => p.GetCustomAttributes<FieldAttribute>(false).Any()).ToList();
            Assert.AreEqual(2, propertiesWithAttrs.Count());

            var keyProperty = propertiesWithAttrs.First(p => p.GetCustomAttribute<KeyAttribute>() != null);
            Assert.IsNotNull(keyProperty);
            Assert.AreEqual("Some_Class_Table_Name_Id", keyProperty.GetCustomAttribute<FieldAttribute>(false).FieldName);
            Assert.AreEqual(DbType.Int32, keyProperty.GetCustomAttribute<FieldAttribute>(false).FieldType);

            var anotherProperty = propertiesWithAttrs.First(p => p.GetCustomAttribute<KeyAttribute>() == null);
            Assert.IsNotNull(anotherProperty);
            Assert.AreEqual("Another_Value", anotherProperty.GetCustomAttribute<FieldAttribute>(false).FieldName);
            Assert.AreEqual(DbType.String, anotherProperty.GetCustomAttribute<FieldAttribute>(false).FieldType);

            /**
             * TODO : Como alterar uma propriedade readonly
             * Adicionar o using Mono.Reflection;
             * -----
             * var idProperty = typeof(SomeClassWithAttributesMock).GetProperty("Id");
             * var idField = idProperty.GetBackingField();
             * idField.SetValue(someClass, 10);
             *
             * Assert.AreEqual(10, someClass.Id);
             **/
        }
    }
}