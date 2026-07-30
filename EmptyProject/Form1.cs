using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmptyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



stateMachine.Configure(State.Active)
    .OnEntry(() =>
    {
        Console.WriteLine("Activating data refresh");
        RefreshData();
        SetupRefreshTimer();
    })
    .PermitReentry(Trigger.Refresh)
    .OnExit(() =>
    {
        Console.WriteLine("Deactivating data refresh");
        StopRefreshTimer();
    });

// 定时触发刷新
void SetupRefreshTimer()
{
    var timer = new Timer(5000);
    timer.Elapsed += (sender, e) => stateMachine.Fire(Trigger.Refresh);
    timer.Start();
}
void RefreshData()
{
    // 实际的数据刷新逻辑
    Console.WriteLine("Refreshing data...");
}
        }
    }


    public enum State
    {
        Inactive,
        Active,
        Paused
    }
    public enum Trigger
    {
        Activate,
        Deactivate,
        Pause,
        Resume,
        Refresh
    }
}
