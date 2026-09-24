using System.Collections.Generic;
using System.Text;
using HidSharp.Reports;

namespace EmptyProject
{
    public static class HidReportDumper
    {
        /// <summary>
        /// 將 HidSharp ReportDescriptor / DeviceItem
        /// 以結構化方式輸出。
        /// </summary>
        public static string DumpProperties(object obj)
        {
            var sb = new StringBuilder();

            if (obj == null)
            {
                return string.Empty;
            }

            if (obj is ReportDescriptor descriptor)
            {
                DumpReportDescriptor(descriptor, sb);
                return sb.ToString();
            }

            if (obj is DeviceItem deviceItem)
            {
                DumpDeviceItem(deviceItem, sb, 0, 0);
                return sb.ToString();
            }

            if (obj is IEnumerable<DeviceItem> deviceItems)
            {
                int index = 0;

                foreach (DeviceItem item in deviceItems)
                {
                    if (index > 0)
                    {
                        sb.AppendLine();
                    }

                    DumpDeviceItem(
                        item,
                        sb,
                        0,
                        index);

                    index++;
                }

                return sb.ToString();
            }

            sb.AppendLine(obj.GetType().FullName);

            return sb.ToString();
        }

        private static void DumpReportDescriptor(
            ReportDescriptor descriptor,
            StringBuilder sb)
        {
            if (descriptor == null)
            {
                return;
            }

            int index = 0;

            foreach (DeviceItem deviceItem in descriptor.DeviceItems)
            {
                if (index > 0)
                {
                    sb.AppendLine();
                }

                DumpDeviceItem(
                    deviceItem,
                    sb,
                    0,
                    index);

                index++;
            }
        }

        private static void DumpDeviceItem(
            DeviceItem deviceItem,
            StringBuilder sb,
            int indent,
            int index)
        {
            if (deviceItem == null)
            {
                return;
            }

            AppendLine(
                sb,
                indent,
                $"DeviceItem #{index}");

            AppendProperty(
                sb,
                indent + 1,
                "UsagePage",
                GetUsagePage(deviceItem));

            AppendProperty(
                sb,
                indent + 1,
                "Usage",
                FormatUsages(deviceItem.Usages));

            sb.AppendLine();

            DumpReports(
                deviceItem.InputReports,
                "InputReport",
                sb,
                indent + 1);

            DumpReports(
                deviceItem.OutputReports,
                "OutputReport",
                sb,
                indent + 1);

            DumpReports(
                deviceItem.FeatureReports,
                "FeatureReport",
                sb,
                indent + 1);
        }

        private static void DumpReports(
            IEnumerable<Report> reports,
            string reportName,
            StringBuilder sb,
            int indent)
        {
            if (reports == null)
            {
                return;
            }

            foreach (Report report in reports)
            {
                if (report == null)
                {
                    continue;
                }

                AppendLine(
                    sb,
                    indent,
                    reportName);

                DumpReport(
                    report,
                    sb,
                    indent + 1);

                sb.AppendLine();
            }

            RemoveLastEmptyLine(sb);
        }

        private static void DumpReport(
            Report report,
            StringBuilder sb,
            int indent)
        {
            AppendProperty(
                sb,
                indent,
                "ReportId",
                report.ReportID);

            AppendProperty(
                sb,
                indent,
                "Length",
                report.Length);

            sb.AppendLine();

            int bitOffset = 0;
            int index = 0;

            foreach (DataItem dataItem in report.DataItems)
            {
                if (dataItem == null)
                {
                    continue;
                }

                AppendLine(
                    sb,
                    indent,
                    $"DataItem #{index}");

                DumpDataItem(
                    dataItem,
                    sb,
                    indent + 1,
                    bitOffset);

                sb.AppendLine();

                bitOffset += dataItem.TotalBits;
                index++;
            }

            RemoveLastEmptyLine(sb);
        }

        private static void DumpDataItem(
            DataItem dataItem,
            StringBuilder sb,
            int indent,
            int bitOffset)
        {
            AppendProperty(
                sb,
                indent,
                "Usage",
                FormatUsages(dataItem.Usages));

            AppendProperty(
                sb,
                indent,
                "BitOffset",
                bitOffset);

            AppendProperty(
                sb,
                indent,
                "BitLength",
                dataItem.ElementBits);

            AppendProperty(
                sb,
                indent,
                "ElementCount",
                dataItem.ElementCount);

            AppendProperty(
                sb,
                indent,
                "TotalBits",
                dataItem.TotalBits);

            AppendProperty(
                sb,
                indent,
                "LogicalMin",
                dataItem.LogicalMinimum);

            AppendProperty(
                sb,
                indent,
                "LogicalMax",
                dataItem.LogicalMaximum);

            AppendProperty(
                sb,
                indent,
                "PhysicalMin",
                dataItem.PhysicalMinimum);

            AppendProperty(
                sb,
                indent,
                "PhysicalMax",
                dataItem.PhysicalMaximum);

            AppendProperty(
                sb,
                indent,
                "Flags",
                dataItem.Flags);

            AppendProperty(
                sb,
                indent,
                "IsVariable",
                dataItem.IsVariable);

            AppendProperty(
                sb,
                indent,
                "IsArray",
                dataItem.IsArray);

            AppendProperty(
                sb,
                indent,
                "IsConstant",
                dataItem.IsConstant);

            AppendProperty(
                sb,
                indent,
                "IsRelative",
                dataItem.IsRelative);
        }

        private static string GetUsagePage(
            DeviceItem deviceItem)
        {
            if (deviceItem == null ||
                deviceItem.Usages == null)
            {
                return string.Empty;
            }

            return deviceItem.Usages.ToString();
        }

        private static string FormatUsages(
            object usages)
        {
            if (usages == null)
            {
                return string.Empty;
            }

            // HidSharp 的 Usages 是 Indexes 類型。
            // 優先使用 GetAllValues() 取得實際 Usage 值。
            try
            {
                var indexes = usages as Indexes;

                if (indexes != null)
                {
                    var values = indexes.GetAllValues();

                    var result = new List<string>();

                    foreach (uint value in values)
                    {
                        result.Add(FormatUsageValue(value));
                    }

                    return string.Join(", ", result);
                }
            }
            catch
            {
                // 保留 ToString() 作為最後 fallback。
            }

            return usages.ToString();
        }

        private static string FormatUsageValue(
            uint usage)
        {
            ushort usagePage =
                (ushort)(usage >> 16);

            ushort usageId =
                (ushort)(usage & 0xFFFF);

            string usageName =
                GetUsageName(
                    usagePage,
                    usageId);

            if (!string.IsNullOrEmpty(usageName))
            {
                return usageName;
            }

            return string.Format(
                "0x{0:X4}:0x{1:X4}",
                usagePage,
                usageId);
        }

        private static string GetUsageName(
            ushort usagePage,
            ushort usageId)
        {
            // 先處理常見 Keyboard Usage。
            if (usagePage == 0x01)
            {
                switch (usageId)
                {
                    case 0x01:
                        return "Pointer";

                    case 0x02:
                        return "Mouse";

                    case 0x04:
                        return "Joystick";

                    case 0x05:
                        return "Game Pad";

                    case 0x06:
                        return "Keyboard";

                    case 0x07:
                        return "Keypad";
                }
            }

            if (usagePage == 0x07)
            {
                switch (usageId)
                {
                    case 0x04:
                        return "Keyboard a and A";

                    case 0x05:
                        return "Keyboard b and B";

                    case 0x06:
                        return "Keyboard c and C";

                    case 0x1E:
                        return "Keyboard 1 and !";

                    case 0x1F:
                        return "Keyboard 2 and @";

                    case 0x20:
                        return "Keyboard 3 and #";

                    case 0x21:
                        return "Keyboard 4 and $";

                    case 0x22:
                        return "Keyboard 5 and %";

                    case 0x23:
                        return "Keyboard 6 and ^";

                    case 0x24:
                        return "Keyboard 7 and &";

                    case 0x25:
                        return "Keyboard 8 and *";

                    case 0x26:
                        return "Keyboard 9 and (";

                    case 0x27:
                        return "Keyboard 0 and )";

                    case 0x28:
                        return "Keyboard Return";

                    case 0x29:
                        return "Keyboard ESC";

                    case 0x2C:
                        return "Keyboard Spacebar";

                    case 0x2D:
                        return "Keyboard - and _";

                    case 0x2E:
                        return "Keyboard = and +";

                    case 0x2F:
                        return "Keyboard [ and {";

                    case 0x30:
                        return "Keyboard ] and }";

                    case 0x31:
                        return "Keyboard \\ and |";

                    case 0x33:
                        return "Keyboard ; and :";

                    case 0x34:
                        return "Keyboard ' and \"";

                    case 0x35:
                        return "Keyboard ` and ~";

                    case 0x36:
                        return "Keyboard , and <";

                    case 0x37:
                        return "Keyboard . and >";

                    case 0x38:
                        return "Keyboard / and ?";
                }
            }

            return string.Empty;
        }

        private static void AppendProperty(
            StringBuilder sb,
            int indent,
            string name,
            object value)
        {
            if (value == null)
            {
                return;
            }

            string text =
                FormatValue(value);

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            AppendLine(
                sb,
                indent,
                $"{name,-13} : {text}");
        }

        private static string FormatValue(
            object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (value is bool boolean)
            {
                return boolean ? "True" : "False";
            }

            if (value is string text)
            {
                return text;
            }

            return value.ToString();
        }

        private static void AppendLine(
            StringBuilder sb,
            int indent,
            string text)
        {
            sb.Append(' ', indent * 4);
            sb.AppendLine(text);
        }

        private static void RemoveLastEmptyLine(
            StringBuilder sb)
        {
            while (sb.Length > 0)
            {
                if (sb[sb.Length - 1] == '\n')
                {
                    sb.Length--;

                    if (sb.Length > 0 &&
                        sb[sb.Length - 1] == '\r')
                    {
                        sb.Length--;
                    }

                    break;
                }

                if (!char.IsWhiteSpace(
                        sb[sb.Length - 1]))
                {
                    break;
                }

                sb.Length--;
            }
        }
    }
}
