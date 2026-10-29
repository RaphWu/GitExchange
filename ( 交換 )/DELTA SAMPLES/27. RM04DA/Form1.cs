using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PCI_DMC;
using PCI_DMC_ERR;

namespace DMC_NET
{
    public partial class Form1 : Form
    {
        short existcard = 0, rc;
        ushort gCardNo = 0, DeviceInfo = 0, nodeid = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        int[] ModeMin=new int[8];
        int[] ModeMax=new int[8];
        ushort ChannelDA = 0;
        ushort DAmode = 0;
        bool STchMode = false;
        bool FsActive = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FsActive = false;
            STchMode = false;
            ModeMin[0] = 0;
            ModeMin[1] = 0;
            ModeMin[2] = -5;
            ModeMin[3] = -10;
            ModeMin[5] = 4;
            ModeMin[6] = 0;
            ModeMin[7] = 0;

            ModeMax[0] = 5;
            ModeMax[1] = 10;
            ModeMax[2] = 10;
            ModeMax[3] = 20;
            ModeMax[5] = 16;
            ModeMax[6] = 20;
            ModeMax[7] = 24;
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0;
            FsActive = false;
            STchMode = false;

            for (i = 0; i < 4; i++)
            {
                SlaveTable[i] = 0;
            }

            btnFindSlave.Enabled = false;
            txtSlaveNum.Text = "0";
            CmbCardNo.Items.Clear();
            cmbNodeID.Items.Clear();

            rc = CPCI_DMC.CS_DMC_01_open(ref existcard);

            if (existcard <= 0)
                MessageBox.Show("No DMC-NET card can be found!");
            else
            {

                for (i = 0; i < existcard; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_get_CardNo_seq(i, ref card_no);
                    gCardNoList[i] = card_no;

                    CmbCardNo.Items.Insert(i, card_no);

                }

                btnFindSlave.Enabled = true;        //2011.08.05
                CmbCardNo.SelectedIndex = 0;
                gCardNo = gCardNoList[0];

                for (i = 0; i < existcard; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_pci_initial(gCardNoList[i]);
                    if (rc != 0)
                        MessageBox.Show("Can't boot PCI_DMC Master Card!");

                    rc = CPCI_DMC.CS_DMC_01_initial_bus(gCardNoList[i]);
                    if (rc != 0)
                    {
                        MessageBox.Show("Initial Failed!");
                    }
                    else
                    {
                        rc = CPCI_DMC.CS_DMC_01_start_ring(gCardNo, 0);                      //Start communication                      
                        rc = CPCI_DMC.CS_DMC_01_get_device_table(gCardNo, ref DeviceInfo);   //Get Slave Node ID 
                        rc = CPCI_DMC.CS_DMC_01_get_node_table(gCardNo, ref SlaveTable[0]);
                    }
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

           CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ushort value = 0,Tempdata=0,rt=0,RCode=0,AppValue=0;
            double Ovalue = 0;
            short offset = 0;
            nodeid = ushort.Parse(cmbNodeID.Text);
            ChannelDA=(ushort)cmbChannel.SelectedIndex;
            rc = CPCI_DMC.CS_DMC_01_rm_04da_get_output_value(gCardNo, nodeid, 0, ChannelDA, ref value);

            Tempdata = value;
            if (Tempdata < 0)
                Tempdata = (ushort)(Tempdata + 65536);
            rc = CPCI_DMC.CS_DMC_01_rm_04da_get_output_offset_value(gCardNo, nodeid, 0, ChannelDA, ref offset);
            rc = CPCI_DMC.CS_DMC_01_rm_04da_get_return_code(gCardNo, nodeid, 0, ChannelDA, ref rt);
            if (rt >= 0)
                RCode = rt;
            else
                RCode = (ushort)(65536 - System.Math.Abs(rt));

            if (System.Math.Abs(rt) > 63)
            {
                RCode = (ushort)(RCode - (RCode % 64) / 64);
                txtERR.Text = "0x" + Convert.ToString(RCode, 16);
            }
            else
                txtERR.Text = "0x" + Convert.ToString(rt, 16);

            if (DAmode < 0)
                DAmode = 0;

            if (chkOverRange.Checked)
            {
                Ovalue = (double)(ModeMin[DAmode] * 1.1 + (Tempdata * ModeMax[DAmode] * 1.1 / (double)65535));
                txtRead.Text = Ovalue.ToString();
            }
            else
            {
                Ovalue = (double)(ModeMin[DAmode] * 1 + Tempdata * ModeMax[DAmode] * 1 / (double)65535);
                txtRead.Text = Convert.ToString(System.Math.Round(Ovalue,4));
            }

            AppValue = (ushort)barV.Value;
            if (chkOverRange.Checked)
            {
                Ovalue = (double)(ModeMin[DAmode] * 1.1 + (offset + AppValue) * ModeMax[DAmode] * 1.1 / (double)65535);
                txtAppro.Text = Ovalue.ToString();
            }
            else
            {
                Ovalue = (double)(ModeMin[DAmode] * 1 + (offset + AppValue) * ModeMax[DAmode] * 1 / (double)65535);
                txtAppro.Text=Convert.ToString(System.Math.Round(Ovalue,4));
            }
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);
        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,p=0;
            uint DeviceType=0, IdentityObject=0;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            cmbNodeID.Items.Clear();

            for (i = 0; i < 1; i++) NodeID[i] = 0;

            if (SlaveTable[0] == 0)
                MessageBox.Show("CardNo: " + gCardNo.ToString() + " No slave found!");      
            else
            {
                for (i = 0; i < 32; i++)
                {
                    if ((SlaveTable[0] & lMask) != 0)
                    {
                        NodeID[gNodeNum] = (ushort)(i + 1);
                        gNodeNum++;
                        rc = CPCI_DMC.CS_DMC_01_get_devicetype(gCardNo, (ushort)(i + 1), (ushort)0, ref DeviceType, ref IdentityObject);
                        if (rc != 0)
                        {
                            MessageBox.Show("get_devicetype failed - code=" + rc);
                        }
                        else
                        {
                            switch (DeviceType)
                            {
                                case 0x8180191:				//RM04AD
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                {
                    MessageBox.Show("RM04DA required!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    cmbChannel.SelectedIndex = 0;
                    cmbMode.SelectedIndex = 0;
                    chkOverRange.Checked = false;
                    chkERR.Checked = false;
                    STchMode = true;
                }
            }
        }

        private void cmdChannel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ushort rt= 0;
            ushort value = 0;
            short offset = 0;
            int Outvalue=0;
            uint tempValue=0;

            ChannelDA = (ushort)cmbChannel.SelectedIndex;
            nodeid=ushort.Parse(cmbNodeID.Text);
            rc = CPCI_DMC.CS_DMC_01_rm_04da_get_return_code(gCardNo, nodeid, 0, ChannelDA, ref rt);
            if (rt < 0)
                rt = (ushort)(rt + 32768);
            if ((rt&0x20)==1)
                chkERR.Checked = true;
            if ((rt & 0x10) == 1)
                chkOverRange.Checked = true;

            if ((rt & 0x7) == 1)
                cmbMode.SelectedIndex = 7;
            else if ((rt & 0x6) == 1)
                cmbMode.SelectedIndex = 6;
            else if ((rt & 0x5) == 1)
                cmbMode.SelectedIndex = 5;
            else if ((rt & 0x3) == 1)
                cmbMode.SelectedIndex = 3;
            else if ((rt & 0x2) == 1)
                cmbMode.SelectedIndex = 2;
            else if ((rt & 0x1) == 1)
                cmbMode.SelectedIndex = 1;
            else
                cmbMode.SelectedIndex = 0;

            rc = CPCI_DMC.CS_DMC_01_rm_04da_get_output_value(gCardNo, nodeid, 0, ChannelDA, ref value);
            rc = CPCI_DMC.CS_DMC_01_rm_04da_get_output_offset_value(gCardNo, nodeid, 0, ChannelDA, ref offset);
            if (value < 0)
                Outvalue = Outvalue + 65536;
            else
                Outvalue = value;

            Outvalue = Outvalue - offset;

            barV.Value = (int)Outvalue;
            DAmode = (ushort)cmbMode.SelectedIndex;

            if (chkOverRange.Checked)
            {
                tempValue = (uint)(ModeMin[DAmode] * 1.1 + Outvalue * ModeMax[DAmode] * 1.1 / 65535);
                txtAppro.Text = tempValue.ToString();
            }
            else
            {
                tempValue = (uint)(ModeMin[DAmode] * 1 + Outvalue * ModeMax[DAmode] * 1 / 65535);
                txtAppro.Text = tempValue.ToString();
            }
            if (Outvalue > 32767)
                value = (ushort)(Outvalue - 65536);
            else
                value = (ushort)(Outvalue);
            rc = CPCI_DMC.CS_DMC_01_rm_04da_set_output_value(gCardNo, nodeid, 0, ChannelDA, value);
            txtOffset.Text = offset.ToString();

            switch (ChannelDA)
            {
                case 0:
                    frm04DA.Text = "RM04DA Channel 0 Status";
                    break;
                case 1:
                    frm04DA.Text = "RM04DA Channel 1 Status";
                    break;
                case 2:
                    frm04DA.Text = "RM04DA Channel 2 Status";
                    break;
                case 3:
                    frm04DA.Text = "RM04DA Channel 3 Status";
                    break;
            }
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ushort rt=0;
            short offset = 0;

            nodeid=ushort.Parse(cmbNodeID.Text);

            DAmode = (ushort)cmbMode.SelectedIndex;

            if (DAmode > 4)
            {
                txtUnitAppro.Text = "mA";
                txtUnitRead.Text = "mA";
                chkOverRange.Enabled = false;
            }
            else if (DAmode < 4)
            {
                txtUnitAppro.Text = "V";
                txtUnitRead.Text = "V";
                chkOverRange.Enabled = true;
            }
            else if (DAmode == 4)
            {
                txtUnitAppro.Text = "";
                txtUnitRead.Text = "";
                chkOverRange.Enabled = false;
            }
            rc = CPCI_DMC.CS_DMC_01_rm_04da_get_return_code(gCardNo, nodeid, 0, ChannelDA, ref rt);
            if ((DAmode != (rt % 8)) && (DAmode != 4))
            {
                ChannelDA = (ushort)cmbChannel.SelectedIndex;
                rc = CPCI_DMC.CS_DMC_01_rm_04da_set_output_offset_value(gCardNo, nodeid, 0, ChannelDA, 0);
                txtOffset.Text = "0";
            }

            rc = CPCI_DMC.CS_DMC_01_rm_04da_get_output_offset_value(gCardNo, nodeid, 0, ChannelDA,ref offset);
            System.Threading.Thread.Sleep(100);
            rc = CPCI_DMC.CS_DMC_01_rm_04da_set_output_enable(gCardNo, nodeid, 0, ChannelDA, 0);
            System.Threading.Thread.Sleep(100);
            rc = CPCI_DMC.CS_DMC_01_rm_04da_set_output_range(gCardNo, nodeid, 0, ChannelDA, DAmode);
            System.Threading.Thread.Sleep(100);

            if (STchMode == true)
            {
                rc = CPCI_DMC.CS_DMC_01_rm_04da_set_output_enable(gCardNo, nodeid, 0, ChannelDA, 1);
                if ((cmbMode.SelectedIndex == 2) || (cmbMode.SelectedIndex == 3))
                {
                    barV.Value = 32767;
                    rc = CPCI_DMC.CS_DMC_01_rm_04da_set_output_value(gCardNo, nodeid, 0, ChannelDA, 32767);
                }
                else
                {
                    barV.Value = 0;
                    rc = CPCI_DMC.CS_DMC_01_rm_04da_set_output_value(gCardNo, nodeid, 0, ChannelDA, 0);
                }                
            }
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            ChannelDA = (ushort)cmbChannel.SelectedIndex;
            ushort Temp = 0;
            ushort AValue=0;

            Temp = (ushort)barV.Value;
            if (Temp > 32767)
                AValue = (ushort)(Temp - 65535);
            else
                AValue = Temp;

            if (FsActive == false)
            {
                rc = CPCI_DMC.CS_DMC_01_set_rm_output_active(gCardNo, nodeid, 0, 1);
                FsActive = true;
            }
            rc = CPCI_DMC.CS_DMC_01_rm_04da_set_output_value(gCardNo, nodeid, 0, ChannelDA, AValue);
        }

        private void chkOverRange_CheckedChanged(object sender, EventArgs e)
        {
            nodeid=ushort.Parse(cmbNodeID.Text);
            ChannelDA=(ushort)cmbChannel.SelectedIndex;

            if (chkOverRange.Checked)
                CPCI_DMC.CS_DMC_01_rm_04da_set_output_overrange(gCardNo, nodeid, 0, ChannelDA, 1);
            else
                CPCI_DMC.CS_DMC_01_rm_04da_set_output_overrange(gCardNo, nodeid, 0, ChannelDA, 0);
        }

        private void chkERR_CheckedChanged(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            ChannelDA = (ushort)cmbChannel.SelectedIndex;

            if (chkERR.Checked)
                CPCI_DMC.CS_DMC_01_rm_04da_set_output_error_handle(gCardNo, nodeid, 0, ChannelDA, 1);
            else
                CPCI_DMC.CS_DMC_01_rm_04da_set_output_error_handle(gCardNo, nodeid, 0, ChannelDA, 0);
        }

        private void cmdSetOffset_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            ChannelDA = (ushort)cmbChannel.SelectedIndex;
            short offset = short.Parse(txtOffset.Text);

            CPCI_DMC.CS_DMC_01_rm_04da_set_output_offset_value(gCardNo, nodeid, 0, ChannelDA, offset);
        }

        private void cmdClearERR_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            ChannelDA = (ushort)cmbChannel.SelectedIndex;

            CPCI_DMC.CS_DMC_01_rm_04da_set_output_error_clear(gCardNo, nodeid, 0, ChannelDA, 1);
        }
    }
}
