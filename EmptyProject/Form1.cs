using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using HidSharp;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace EmptyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var device in DeviceList.Local.GetHidDevices())
            {
                sb.AppendLine($"====================================");
                sb.AppendLine($"Manufacturer     : {device.GetManufacturer()}");
                sb.AppendLine($"Product          : {device.GetProductName()}");
                sb.AppendLine($"VID              : 0x{device.VendorID:X4}");
                sb.AppendLine($"PID              : 0x{device.ProductID:X4}");
                sb.AppendLine($"Serial           : {GetSerialNumberOrEmpty(device)}");
                sb.AppendLine($"Release Number   : {device.ReleaseNumber}");
                sb.AppendLine($"Path             : {device.DevicePath}");
                sb.AppendLine($"Input Length     : {device.GetMaxInputReportLength()}");
                sb.AppendLine($"Output Length    : {device.GetMaxOutputReportLength()}");
                sb.AppendLine($"Report Descriptor:");
                sb.AppendLine($"{HidReportDumper.DumpProperties(device.GetReportDescriptor())}");
            }

            string result = sb.ToString();
            textBox1.Text = result;

            // 儲存 sb 的結果為 DeviceList.txt 到「我的文件」資料夾
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DeviceList.txt");
                File.WriteAllText(filePath, result, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Cannot save DeviceList.txt: {ex.Message}",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private static string GetSerialNumberOrEmpty(HidDevice device)
        {
            try
            {
                return device.GetSerialNumber() ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        //// Modified DumpProperties: supports recursive dumping of IEnumerable properties (excluding string),
        //// with depth limit and circular reference detection.
        //public static string DumpProperties(object obj)
        //{
        //    var sb = new StringBuilder();
        //    var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);
        //    DumpProperties(obj, sb, 0, 5, visited);
        //    return sb.ToString();
        //}

        //private static void DumpProperties(object obj, StringBuilder sb, int indent, int maxDepth, HashSet<object> visited)
        //{
        //    string indentStr = new string('\t', indent);
        //    if (obj == null)
        //    {
        //        sb.AppendLine(indentStr + "null");
        //        return;
        //    }

        //    Type type = obj.GetType();
        //    sb.AppendLine(indentStr + $"Type: {type.FullName}");

        //    // Prevent too deep recursion
        //    if (indent >= maxDepth)
        //    {
        //        sb.AppendLine(indentStr + "\t<Max depth reached>");
        //        return;
        //    }

        //    // For primitive or string types, just print the value
        //    if (type.IsPrimitive || obj is string || obj is decimal)
        //    {
        //        sb.AppendLine(indentStr + "\t" + obj.ToString());
        //        return;
        //    }

        //    // Avoid circular references for reference types
        //    if (!type.IsValueType)
        //    {
        //        if (visited.Contains(obj))
        //        {
        //            sb.AppendLine(indentStr + "\t<CIRCULAR REFERENCE>");
        //            return;
        //        }

        //        visited.Add(obj);
        //    }

        //    foreach (var property in type.GetProperties())
        //    {
        //        try
        //        {
        //            object value = property.GetValue(obj, null);

        //            // If value is null just print
        //            if (value == null)
        //            {
        //                sb.AppendLine(indentStr + $"\t{property.Name} ({property.PropertyType.Name}) = null");
        //                continue;
        //            }

        //            // If the property type (or value) is IEnumerable (but not string), enumerate contents
        //            if (value is IEnumerable enumerable && !(value is string))
        //            {
        //                sb.AppendLine(indentStr + $"\t{property.Name} ({property.PropertyType.Name}) = [");

        //                int idx = 0;
        //                foreach (var item in enumerable)
        //                {
        //                    sb.Append(indentStr + $"\t\t[{idx}] ");
        //                    // For simple types, just show ToString; otherwise recurse
        //                    if (item == null)
        //                    {
        //                        sb.AppendLine("null");
        //                    }
        //                    else
        //                    {
        //                        Type itemType = item.GetType();
        //                        if (itemType.IsPrimitive || item is string || item is decimal)
        //                        {
        //                            sb.AppendLine(item.ToString());
        //                        }
        //                        else
        //                        {
        //                            sb.AppendLine();
        //                            DumpProperties(item, sb, indent + 3, maxDepth, visited);
        //                        }
        //                    }
        //                    idx++;
        //                }

        //                sb.AppendLine(indentStr + "\t]");
        //            }
        //            else
        //            {
        //                sb.AppendLine(indentStr + $"\t{property.Name} ({property.PropertyType.Name}) = {value}");

        //                // If the property is a complex object (not primitive/string), recurse into it
        //                if (!(value is string) && !property.PropertyType.IsPrimitive && !property.PropertyType.IsValueType && !(value is decimal))
        //                {
        //                    DumpProperties(value, sb, indent + 2, maxDepth, visited);
        //                }
        //            }
        //        }
        //        catch (TargetInvocationException ex)
        //        {
        //            sb.AppendLine(
        //                indentStr + $"\t{property.Name} ({property.PropertyType.Name}) = " +
        //                $"<THROWN: {ex.InnerException?.GetType().Name}: " +
        //                $"{ex.InnerException?.Message}>");
        //        }
        //        catch (Exception ex)
        //        {
        //            sb.AppendLine(
        //                indentStr + $"\t{property.Name} ({property.PropertyType.Name}) = " +
        //                $"<ERROR: {ex.GetType().Name}: {ex.Message}>");
        //        }
        //    }

        //    // If reference type, remove from visited so other branches can still inspect it separately
        //    if (!type.IsValueType)
        //    {
        //        visited.Remove(obj);
        //    }
        //}

        //// Reference equality comparer for tracking visited objects
        //private class ReferenceEqualityComparer : IEqualityComparer<object>
        //{
        //    public static readonly ReferenceEqualityComparer Instance = new ReferenceEqualityComparer();
        //    public new bool Equals(object x, object y)
        //    {
        //        return ReferenceEquals(x, y);
        //    }

        //    public int GetHashCode(object obj)
        //    {
        //        if (obj == null) return 0;
        //        return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
        //    }
        //}
    }
}
