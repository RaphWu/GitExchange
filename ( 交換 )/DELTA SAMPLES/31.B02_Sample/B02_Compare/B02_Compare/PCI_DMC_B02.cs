using System;
using System.Text;
using System.Runtime.InteropServices;

namespace PCI_DMC_B02
{
    public class CPCI_DMC_B02
    {
        //2015/10/27
   	//PCI_DMC_B02
	[DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_qep_set_mode")]
        public static extern short CS_DMC_B02_qep_set_mode(ushort nCardNo, byte nQepIndex, byte nMode);

	[DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_qep_set_inverse")]
        public static extern short CS_DMC_B02_qep_set_inverse(ushort nCardNo, byte nQepIndex, bool bEnable);

	[DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_qep_get_reload_counter")]
        public static extern short CS_DMC_B02_qep_get_reload_counter(ushort nCardNo, byte nQepIndex, ref int nCounter);

	[DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_qep_set_reload_counter")]
        public static extern short CS_DMC_B02_qep_set_reload_counter(ushort nCardNo, byte nQepIndex, int nCounter);

	[DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_qep_get_counter")]
        public static extern short CS_DMC_B02_qep_get_counter(ushort nCardNo, byte nQepIndex, ref int nCounter);

	[DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_gpio_software_control_status")]
        public static extern short CS_DMC_B02_gpio_software_control_status(ushort nCardNo, ref ushort nStatus);

	[DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_gpio_software_control_setting")]
        public static extern short CS_DMC_B02_gpio_software_control_setting(ushort nCardNo, ushort nSetting);

	[DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ipcmp_initial")]
        public static extern short CS_DMC_B02_ipcmp_initial(ushort nCardNo, byte nIpcmpIndex, byte nQepIndex, byte nGpioPin, bool bInverse);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ipcmp_oneshot_time")]
        public static extern short CS_DMC_B02_ipcmp_oneshot_time(ushort nCardNo, byte nIpcmpIndex, ushort nPulseWidth);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ipcmp_software_trigger")]
        public static extern short CS_DMC_B02_ipcmp_software_trigger(ushort nCardNo, byte nIpcmpIndex);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ipcmp_compare_position")]
        public static extern short CS_DMC_B02_ipcmp_compare_position(ushort nCardNo, byte nIpcmpIndex, int nStartPosition, ushort nInterval, uint nCount, byte nDir);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ipcmp_compare_trigger_count")]
        public static extern short CS_DMC_B02_ipcmp_compare_trigger_count(ushort nCardNo, byte nIpcmpIndex, ref uint nCount);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ipcmp_compare_trigger_count_clear")]
        public static extern short CS_DMC_B02_ipcmp_compare_trigger_count_clear(ushort nCardNo, byte nIpcmpIndex);


        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_initial")]
        public static extern short CS_DMC_B02_tpcmp_initial(ushort nCardNo, byte nFifoIndex, byte nQepIndex, byte nGpioPin, bool bInverse, bool bInterrupt);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_oneshot_time")]
        public static extern short CS_DMC_B02_tpcmp_oneshot_time(ushort nCardNo, byte nFifoIndex, ushort nPulseWidth);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_software_trigger")]
        public static extern short CS_DMC_B02_tpcmp_software_trigger(ushort nCardNo, byte nFifoIndex);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_software_trigger_level")]
        public static extern short CS_DMC_B02_tpcmp_software_trigger_level(ushort nCardNo, byte nFifoIndex, bool bActive);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_compare_position_table_reset")]
        public static extern short CS_DMC_B02_tpcmp_compare_position_table_reset(ushort nCardNo, byte nFifoIndex);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_compare_position_table")]
        public static extern short CS_DMC_B02_tpcmp_compare_position_table(ushort nCardNo, byte nFifoIndex, ref int nPositionTable, uint nTableSize);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_compare_position_table_level")]
        public static extern short CS_DMC_B02_tpcmp_compare_position_table_level(ushort nCardNo, byte nFifoIndex, ref int nPositionTable, ref byte nLevelTable, uint nTableSize);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_compare_trigger_count")]
        public static extern short CS_DMC_B02_tpcmp_compare_trigger_count(ushort nCardNo, byte nFifoIndex, ref uint nCount);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_tpcmp_compare_trigger_count_clear")]
        public static extern short CS_DMC_B02_tpcmp_compare_trigger_count_clear(ushort nCardNo, byte nFifoIndex);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ext_io_get_input_value")]
        public static extern short CS_DMC_B02_ext_io_get_input_value(ushort nCardNo, ref byte nState);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ext_io_get_output_value")]
        public static extern short CS_DMC_B02_ext_io_get_output_value(ushort nCardNo, ref byte nState);

        [DllImport("PCI_DMC.dll", EntryPoint ="_DMC_B02_ext_io_set_output_value")]
        public static extern short CS_DMC_B02_ext_io_set_output_value(ushort nCardNo, byte nState);
    }
}
