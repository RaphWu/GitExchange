using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EmptyProject
{
    public static class ReportDescriptorDumper
    {
        public static string DumpProperties(object obj)
        {
            var sb = new StringBuilder();
            var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);

            DumpObject(
                obj,
                sb,
                indent: 0,
                maxDepth: 100,
                maxCollectionItems: 100,
                visited: visited);

            return sb.ToString();
        }

        private static void DumpObject(
            object obj,
            StringBuilder sb,
            int indent,
            int maxDepth,
            int maxCollectionItems,
            HashSet<object> visited)
        {
            string indentStr = new string('\t', indent);

            if (obj == null)
            {
                sb.AppendLine(indentStr + "null");
                return;
            }

            Type type = obj.GetType();

            sb.AppendLine(indentStr + $"Type: {type.FullName}");

            // Primitive / simple value
            if (IsSimpleType(type))
            {
                sb.AppendLine(indentStr + $"\tValue: {FormatValue(obj)}");
                return;
            }

            // Prevent too deep recursion.
            if (indent >= maxDepth)
            {
                sb.AppendLine(indentStr + "\t<Max depth reached>");
                return;
            }

            // Prevent circular reference.
            if (!type.IsValueType)
            {
                if (!visited.Add(obj))
                {
                    sb.AppendLine(indentStr + "\t<CIRCULAR REFERENCE>");
                    return;
                }
            }

            try
            {
                // IDictionary must be handled before IEnumerable.
                if (obj is IDictionary dictionary)
                {
                    DumpDictionary(
                        dictionary,
                        sb,
                        indent,
                        maxDepth,
                        maxCollectionItems,
                        visited);

                    return;
                }

                // IEnumerable must be handled before normal properties.
                //
                // This is important for HidSharp IndexList and similar types.
                if (obj is IEnumerable enumerable && !(obj is string))
                {
                    DumpEnumerable(
                        enumerable,
                        sb,
                        indent,
                        maxDepth,
                        maxCollectionItems,
                        visited);

                    return;
                }

                PropertyInfo[] properties = type.GetProperties(
                    BindingFlags.Instance |
                    BindingFlags.Public);

                foreach (PropertyInfo property in properties)
                {
                    DumpProperty(
                        obj,
                        property,
                        sb,
                        indent,
                        maxDepth,
                        maxCollectionItems,
                        visited);
                }
            }
            finally
            {
                if (!type.IsValueType)
                {
                    visited.Remove(obj);
                }
            }
        }

        private static void DumpProperty(
            object obj,
            PropertyInfo property,
            StringBuilder sb,
            int indent,
            int maxDepth,
            int maxCollectionItems,
            HashSet<object> visited)
        {
            string indentStr = new string('\t', indent);

            // Ignore indexed properties.
            //
            // Example:
            // Item[int index]
            //
            // They require an argument and cannot be read by GetValue(obj, null).
            if (property.GetIndexParameters().Length > 0)
            {
                sb.AppendLine(
                    indentStr +
                    $"\t{property.Name} ({property.PropertyType.Name}) = " +
                    "<INDEXED PROPERTY>");

                return;
            }

            object value;

            try
            {
                value = property.GetValue(obj, null);
            }
            catch (TargetInvocationException ex)
            {
                Exception inner = ex.InnerException;

                sb.AppendLine(
                    indentStr +
                    $"\t{property.Name} ({property.PropertyType.Name}) = " +
                    $"<THROWN: {inner?.GetType().FullName ?? ex.GetType().FullName}: " +
                    $"{inner?.Message ?? ex.Message}>");

                return;
            }
            catch (Exception ex)
            {
                sb.AppendLine(
                    indentStr +
                    $"\t{property.Name} ({property.PropertyType.Name}) = " +
                    $"<ERROR: {ex.GetType().FullName}: {ex.Message}>");

                return;
            }

            if (value == null)
            {
                sb.AppendLine(
                    indentStr +
                    $"\t{property.Name} ({property.PropertyType.Name}) = null");

                return;
            }

            Type valueType = value.GetType();

            // Simple value.
            if (IsSimpleType(valueType))
            {
                sb.AppendLine(
                    indentStr +
                    $"\t{property.Name} ({property.PropertyType.Name}) = " +
                    $"{FormatValue(value)}");

                return;
            }

            // Dictionary.
            if (value is IDictionary dictionary)
            {
                sb.AppendLine(
                    indentStr +
                    $"\t{property.Name} ({property.PropertyType.Name}) =");

                DumpDictionary(
                    dictionary,
                    sb,
                    indent + 2,
                    maxDepth,
                    maxCollectionItems,
                    visited);

                return;
            }

            // IEnumerable.
            //
            // This includes:
            // - Array
            // - List<T>
            // - Collection<T>
            // - HidSharp IndexList
            // - etc.
            if (value is IEnumerable enumerable && !(value is string))
            {
                sb.AppendLine(
                    indentStr +
                    $"\t{property.Name} ({property.PropertyType.Name}) =");

                DumpEnumerable(
                    enumerable,
                    sb,
                    indent + 2,
                    maxDepth,
                    maxCollectionItems,
                    visited);

                return;
            }

            // Complex object.
            sb.AppendLine(
                indentStr +
                $"\t{property.Name} ({property.PropertyType.Name}) =");

            DumpObject(
                value,
                sb,
                indent + 2,
                maxDepth,
                maxCollectionItems,
                visited);
        }

        private static void DumpEnumerable(
            IEnumerable enumerable,
            StringBuilder sb,
            int indent,
            int maxDepth,
            int maxCollectionItems,
            HashSet<object> visited)
        {
            string indentStr = new string('\t', indent);

            int count = 0;

            // Try to get Count without enumerating first.
            if (enumerable is ICollection collection)
            {
                sb.AppendLine(
                    indentStr +
                    $"Count = {collection.Count}");
            }
            else
            {
                sb.AppendLine(
                    indentStr +
                    "Count = <unknown>");
            }

            sb.AppendLine(indentStr + "[");

            foreach (object item in enumerable)
            {
                if (count >= maxCollectionItems)
                {
                    sb.AppendLine(
                        indentStr +
                        $"\t... <maximum {maxCollectionItems} items reached>");

                    break;
                }

                sb.Append(
                    indentStr +
                    $"\t[{count}] ");

                if (item == null)
                {
                    sb.AppendLine("null");
                }
                else if (IsSimpleType(item.GetType()))
                {
                    sb.AppendLine(FormatValue(item));
                }
                else
                {
                    sb.AppendLine();

                    DumpObject(
                        item,
                        sb,
                        indent + 2,
                        maxDepth,
                        maxCollectionItems,
                        visited);
                }

                count++;
            }

            sb.AppendLine(indentStr + "]");

            if (count == 0)
            {
                sb.AppendLine(indentStr + "\t<empty>");
            }
        }

        private static void DumpDictionary(
            IDictionary dictionary,
            StringBuilder sb,
            int indent,
            int maxDepth,
            int maxCollectionItems,
            HashSet<object> visited)
        {
            string indentStr = new string('\t', indent);

            sb.AppendLine(
                indentStr +
                $"Count = {dictionary.Count}");

            sb.AppendLine(indentStr + "{");

            int count = 0;

            foreach (DictionaryEntry entry in dictionary)
            {
                if (count >= maxCollectionItems)
                {
                    sb.AppendLine(
                        indentStr +
                        $"\t... <maximum {maxCollectionItems} items reached>");

                    break;
                }

                sb.Append(
                    indentStr +
                    $"\t[{FormatValue(entry.Key)}] = ");

                if (entry.Value == null)
                {
                    sb.AppendLine("null");
                }
                else if (IsSimpleType(entry.Value.GetType()))
                {
                    sb.AppendLine(FormatValue(entry.Value));
                }
                else
                {
                    sb.AppendLine();

                    DumpObject(
                        entry.Value,
                        sb,
                        indent + 2,
                        maxDepth,
                        maxCollectionItems,
                        visited);
                }

                count++;
            }

            sb.AppendLine(indentStr + "}");
        }

        private static bool IsSimpleType(Type type)
        {
            if (type == null)
            {
                return true;
            }

            if (type.IsPrimitive)
            {
                return true;
            }

            if (type.IsEnum)
            {
                return true;
            }

            if (type == typeof(string) ||
                type == typeof(decimal) ||
                type == typeof(DateTime) ||
                type == typeof(DateTimeOffset) ||
                type == typeof(TimeSpan) ||
                type == typeof(Guid))
            {
                return true;
            }

            Type nullableType = Nullable.GetUnderlyingType(type);

            if (nullableType != null)
            {
                return IsSimpleType(nullableType);
            }

            return false;
        }

        private static string FormatValue(object value)
        {
            if (value == null)
            {
                return "null";
            }

            Type type = value.GetType();

            if (type.IsEnum)
            {
                return $"{value} ({Convert.ToInt64(value)})";
            }

            if (value is string)
            {
                return $"\"{value}\"";
            }

            if (value is char)
            {
                return $"'{value}'";
            }

            if (value is byte)
            {
                byte b = (byte)value;

                return $"{b} (0x{b:X2})";
            }

            if (value is sbyte)
            {
                sbyte b = (sbyte)value;

                return $"{b} (0x{b:X2})";
            }

            if (value is ushort)
            {
                ushort v = (ushort)value;

                return $"{v} (0x{v:X4})";
            }

            if (value is short)
            {
                short v = (short)value;

                return $"{v} (0x{v:X4})";
            }

            if (value is uint)
            {
                uint v = (uint)value;

                return $"{v} (0x{v:X8})";
            }

            if (value is int)
            {
                int v = (int)value;

                return $"{v} (0x{v:X8})";
            }

            if (value is ulong)
            {
                ulong v = (ulong)value;

                return $"{v} (0x{v:X16})";
            }

            if (value is long)
            {
                long v = (long)value;

                return $"{v} (0x{v:X16})";
            }

            return value.ToString();
        }

        private class ReferenceEqualityComparer : IEqualityComparer<object>
        {
            public static readonly ReferenceEqualityComparer Instance =
                new ReferenceEqualityComparer();

            public new bool Equals(object x, object y)
            {
                return ReferenceEquals(x, y);
            }

            public int GetHashCode(object obj)
            {
                if (obj == null)
                {
                    return 0;
                }

                return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
            }
        }
    }
}
