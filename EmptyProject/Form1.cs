using System;
using System.Text;
using System.Windows.Forms;
using HidSharp;

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
            foreach (HidDevice device in DeviceList.Local.GetHidDevices())
            {
                listBox1.Items.Add($"====================================");
                listBox1.Items.Add($"Product     : {device.GetProductName()}");
                listBox1.Items.Add($"Manufacturer: {device.GetManufacturer()}");
                listBox1.Items.Add($"VID         : 0x{device.VendorID:X4}");
                listBox1.Items.Add($"PID         : 0x{device.ProductID:X4}");
                listBox1.Items.Add($"Serial      : {device.GetSerialNumber()}");
                listBox1.Items.Add($"Path        : {device.DevicePath}");
                listBox1.Items.Add($"Input Length: {device.GetMaxInputReportLength()}");
                listBox1.Items.Add($"Output Length: {device.GetMaxOutputReportLength()}");
            }
        }
    }
}
