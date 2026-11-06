using System;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace EmptyWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var maryValues = new double[] { 2, 5, 4 };
            var anaValues = new double[] { 3, 1, 6 };
            var labels = new string[] { "Category 1", "Category 2", "Category 3" };

            var series = new ISeries[]
            {
            new ColumnSeries<double> { Name = "Mary", Values = maryValues },
            new ColumnSeries<double> { Name = "Ana", Values = anaValues }
            };

            var xAxis = new Axis
            {
                Labels = labels,
                LabelsRotation = 0,
                SeparatorsPaint = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(new SKColor(200, 200, 200)),
                SeparatorsAtCenter = false,
                TicksPaint = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(new SKColor(35, 35, 35)),
                TicksAtCenter = true,
                MinStep = 1,
                ForceStepToMin = true
            };

            var cartesianChart = new CartesianChart
            {
                Series = series,
                XAxes = new Axis[] { xAxis },
                //LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                //Location = new System.Drawing.Point(0, 0),
                Dock = DockStyle.Fill,
                //Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };

            panel1.Controls.Clear();
            panel1.Controls.Add(cartesianChart);
        }
    }
}
