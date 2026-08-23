using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
public partial class Form1 : Form
{
    private readonly Timer _timer = new Timer();

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs ea)
    {
        _timer.Interval = 1000;
        _timer.Tick += ((s, e) =>
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        });
        _timer.Start();
    }
}
}
