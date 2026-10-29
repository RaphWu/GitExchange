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
        bool gIsServoOn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0;

            for (i = 0; i < 4; i++)
            {
                SlaveTable[i] = 0;
            }

            btnFindSlave.Enabled = false;
            txtSlaveNum.Text = "0";
            CmbCardNo.Items.Clear();

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
            ushort status = 0;
            rc = CPCI_DMC.CS_DMC_01_read_security_status(gCardNo, ref status);
            if (status == 4)
                stsSecurity.Text = "Read Only";
            else if (status == 6)
                stsSecurity.Text = "Write/Read";
            else
                stsSecurity.Text = "";
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";

            for (i = 0; i < 4; i++)     
                SlaveTable[i] = 0;
            
            rc =CPCI_DMC.CS_DMC_01_start_ring(gCardNo, 0);                       //Start communication
            rc =CPCI_DMC.CS_DMC_01_get_device_table(gCardNo, ref DeviceInfo);    //Get Slave Node ID
            rc =CPCI_DMC.CS_DMC_01_get_node_table(gCardNo, ref SlaveTable[0]);

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
                    }
                    lMask <<= 1;
                }
                    txtSlaveNum.Text = gNodeNum.ToString();
                    timer1.Enabled = true;
            }
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            uint[] Password = new uint[2];
            ushort state = 0;
            if((txtPW0.Text!="")&&(txtPW1.Text!=""))
            {
                Password[0] = uint.Parse(txtPW0.Text, System.Globalization.NumberStyles.HexNumber);
                Password[1] = uint.Parse(txtPW1.Text, System.Globalization.NumberStyles.HexNumber);
                rc = CPCI_DMC.CS_DMC_01_check_userpassword(gCardNo, ref Password[0], ref state);

                if (state == 1)
                    stsLogin.Text = "Pass!";
                else
                    stsLogin.Text = "Failed!";
            }
        }

        private void cmdChangePW_Click(object sender, EventArgs e)
        {
            uint[] Password = new uint[2];
            if ((String.Compare(txtChangePW0.Text, txtRepeatPW0.Text) == 0) && (String.Compare(txtChangePW1.Text, txtRepeatPW1.Text) == 0))
            {
                if ((txtChangePW0.Text != "") && (txtChangePW1.Text != ""))
                {
                    Password[0] = uint.Parse(txtChangePW0.Text, System.Globalization.NumberStyles.HexNumber);
                    Password[1] = uint.Parse(txtChangePW1.Text, System.Globalization.NumberStyles.HexNumber);
                    rc = CPCI_DMC.CS_DMC_01_write_userpassword(gCardNo, ref Password[0]);
                    if (rc == 0)
                        stsChangePW.Text = "Done.";
                    else
                        stsChangePW.Text = "Change Failed.";
                }
            }
            else
            {
                stsChangePW.Text = "Please rewrite it.";
            }
        }

        private void cmdReadSN_Click(object sender, EventArgs e)
        {
            uint[] SN = new uint[2];
            rc = CPCI_DMC.CS_DMC_01_read_serialno(gCardNo, ref SN[0]);
            txtSN0.Text = Convert.ToString(SN[0], 16);
            txtSN1.Text = Convert.ToString(SN[1], 16);
        }

        private void cmdMakeKey_Click(object sender, EventArgs e)
        {
            uint[] UserKey=new uint[2];
            uint[] SN = new uint[2];
            uint[] VerifyKey=new uint[4];
            if ((txtSN0.Text != "") && (txtSN1.Text != ""))
            {
                if (txtUserKey0.Text != "")
                    UserKey[0] = uint.Parse(txtUserKey0.Text, System.Globalization.NumberStyles.HexNumber);
                else
                    UserKey[0] = 0;
                if (txtUserKey1.Text != "")
                    UserKey[1] = uint.Parse(txtUserKey1.Text, System.Globalization.NumberStyles.HexNumber);
                else
                    UserKey[1] = 0;
                SN[0] = uint.Parse(txtSN0.Text, System.Globalization.NumberStyles.HexNumber);
                SN[1] = uint.Parse(txtSN1.Text, System.Globalization.NumberStyles.HexNumber);
                rc = CPCI_DMC.CS_misc_security(UserKey[0], UserKey[1], SN[0], SN[1], ref VerifyKey[0], ref VerifyKey[1], ref VerifyKey[2], ref VerifyKey[3]);
                txtVerifyKey0.Text = Convert.ToString(VerifyKey[0], 16);
                txtVerifyKey1.Text = Convert.ToString(VerifyKey[1], 16);
                txtVerifyKey2.Text = Convert.ToString(VerifyKey[2], 16);
                txtVerifyKey3.Text = Convert.ToString(VerifyKey[3], 16);
            }

        }

        private void cmdWriteKey_Click(object sender, EventArgs e)
        {
            uint[] VerifyKey = new uint[4];
            if (txtVerifyKey0.Text != "")
                VerifyKey[0] = uint.Parse(txtVerifyKey0.Text, System.Globalization.NumberStyles.HexNumber);
            else
                VerifyKey[0] = 0;
            if (txtVerifyKey1.Text != "")
                VerifyKey[1] = uint.Parse(txtVerifyKey1.Text, System.Globalization.NumberStyles.HexNumber);
            else
                VerifyKey[1] = 0;
            if (txtVerifyKey2.Text != "")
                VerifyKey[2] = uint.Parse(txtVerifyKey2.Text, System.Globalization.NumberStyles.HexNumber);
            else
                VerifyKey[2] = 0;
            if (txtVerifyKey3.Text != "")
                VerifyKey[3] = uint.Parse(txtVerifyKey3.Text, System.Globalization.NumberStyles.HexNumber);
            else
                VerifyKey[3] = 0;
            rc = CPCI_DMC.CS_DMC_01_write_verifykey(gCardNo, ref VerifyKey[0]);
            if(rc==0)
                stsWriteKey.Text="Write Done.";
            else
                stsWriteKey.Text = "Write Failed.";
        }

        private void cmdSyncKey_Click(object sender, EventArgs e)
        {
            txtInputKey0.Text = txtVerifyKey0.Text;
            txtInputKey1.Text = txtVerifyKey1.Text;
            txtInputKey2.Text = txtVerifyKey2.Text;
            txtInputKey3.Text = txtVerifyKey3.Text;
        }

        private void cmdCheckKey_Click(object sender, EventArgs e)
        {
            uint[] CheckKey = new uint[4];
            ushort state = 0;
            if(txtInputKey0.Text!="")
                CheckKey[0] = uint.Parse(txtInputKey0.Text, System.Globalization.NumberStyles.HexNumber);
            else
                CheckKey[0]=0;
            if(txtInputKey1.Text!="")
                CheckKey[1] = uint.Parse(txtInputKey1.Text, System.Globalization.NumberStyles.HexNumber);
            else
                CheckKey[1]=0;
            if(txtInputKey2.Text!="")
                CheckKey[2] = uint.Parse(txtInputKey2.Text, System.Globalization.NumberStyles.HexNumber);
            else
                CheckKey[2]=0;
            if(txtInputKey3.Text!="")
                CheckKey[3] = uint.Parse(txtInputKey3.Text, System.Globalization.NumberStyles.HexNumber);
            else
                CheckKey[3]=0;
            rc = CPCI_DMC.CS_DMC_01_check_verifykey(gCardNo, ref CheckKey[0], ref state);
            if (state == 1)
                stsCheckKey.Text = "Check Done.";
            else
                stsCheckKey.Text = "Check Failed.";
        }

        private void cmdRead_Click(object sender, EventArgs e)
        {
            ushort page = 0;
            uint i=0;
            TextBox[] txtR = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16 };

            ushort[] data = new ushort[16];
            page = ushort.Parse(txtPage.Text);
            rc = CPCI_DMC.CS_DMC_01_read_security(gCardNo,page, ref data[0]);
            for(i=0;i<16;i++)
                txtR[i].Text=Convert.ToString(data[i],16);
        }

        private void cmdSync_Click(object sender, EventArgs e)
        {
            TextBox[] txtR = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16 };
            TextBox[] txtW = new TextBox[] { textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32 };
            uint i = 0;
            for (i = 0; i < 16; i++)
                txtW[i].Text = txtR[i].Text;
        }

        private void cmdWrite_Click(object sender, EventArgs e)
        {
            TextBox[] txtW = new TextBox[] { textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32 };
            uint i = 0;
            ushort[] data=new ushort[16];
            ushort page=0;
            page = ushort.Parse(txtPage.Text);
            for (i = 0; i < 16; i++)
            {
                if (txtW[i].Text != "")
                    data[i] = ushort.Parse(txtW[i].Text, System.Globalization.NumberStyles.HexNumber);
                else
                    data[i] = 0;
            }
            rc=CPCI_DMC.CS_DMC_01_write_security(gCardNo,page,ref data[0]);
            chkWriteEnable.Checked = false;
            cmdWrite.Enabled = false;
        }

        private void chkWriteEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWriteEnable.Checked)
            {
                cmdWrite.Enabled = true;
                rc = CPCI_DMC.CS_DMC_01_write_security_status(gCardNo, 1);
            }
            else
            {
                cmdWrite.Enabled = false;
                rc = CPCI_DMC.CS_DMC_01_write_security_status(gCardNo, 0);
            }
        }
    }
}