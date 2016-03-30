// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringBuilderExtension.cs" company="N4Works">
//   N4Works.com
// </copyright>
// <summary>
//   The string builder extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace N4.Domain.Driven.Utils.Extensions
{
    using System.Text;

    /// <summary>
    /// The string builder extension.
    /// </summary>
    public static class StringBuilderExtension
    {
        /// <summary>
        /// Append a line with separator when the StringBuilder has one or more lines appended.
        /// </summary>
        /// <param name="stringBuilder">
        /// The string builder.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// A instance of <see cref="StringBuilder"/> appended with the text and separator.
        /// </returns>
        public static StringBuilder AppendLineWithSeparator(this StringBuilder stringBuilder, string text, string separator)
        {
            return stringBuilder.AppendLineWithSeparator(text, separator, 0);
        }

        /// <summary>
        /// Append a line with separator when the StringBuilder has one or more lines appended.
        /// </summary>
        /// <param name="stringBuilder">
        /// The string builder.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <param name="indentSize">
        /// The indent Size.
        /// </param>
        /// <returns>
        /// A instance of <see cref="StringBuilder"/> appended with the text and separator.
        /// </returns>
        public static StringBuilder AppendLineWithSeparator(this StringBuilder stringBuilder, string text, string separator, int indentSize)
        {
            var textToAppend = string.Format("{0}{1}{2}", new string(' ', indentSize), stringBuilder.LineCount() > 0 ? separator : string.Empty, text);
            return stringBuilder.AppendLine(textToAppend);
        }

        /// <summary>
        /// Retrieve the line count on StringBuilder.
        /// </summary>
        /// <param name="stringBuilder">
        /// The string builder.
        /// </param>
        /// <returns>
        /// A number of lines.
        /// </returns>
        public static int LineCount(this StringBuilder stringBuilder)
        {
            var length = stringBuilder.ToString().Split('\n').Length;

            if (string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                length--;
            }

            return length;
        }
    }
}