using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScottPlot;
using static CalculationMethods_L1_WPF.CalcMeth;
using Color = System.Drawing.Color;

namespace CalculationMethods_L1_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyPlot.Plot.AddVerticalLine(x: 0, color: Color.Black, width: 1);
            MyPlot.Plot.AddHorizontalLine(y: 0, color: Color.Black, width: 1);
        }

        private void DrawFunction()
        {
            var x = new List<double>();
            for (var i = -500.0; i < 500.0; i += 0.1)
            {
                x.Add(i / 100);
            }
            var y = x.Select(F).ToList();
            for (var i = 1; i < x.Count; i++)
            {
                MyPlot.Plot.AddLine(x[i - 1], y[i - 1], x[i], y[i], Color.Lime);
            }
        }
        private void ButtonStart_OnClick(object sender, RoutedEventArgs e)
        {
            MyPlot.Plot.Clear();
            var a = Double.Parse(InputA.Text.Replace('.', ','));
            var b = Double.Parse(InputB.Text.Replace('.', ','));
            var tolerance = Double.Parse(InputT.Text.Replace('.', ','));
            
            DrawFunction();
            MyPlot.Plot.AddVerticalLine(BisectionMethod(a, b, tolerance), Color.Red);
            MyPlot.Plot.AddVerticalLine(NewtonMethod(a, b, tolerance), Color.Blue);
            MyPlot.Plot.AddVerticalLine(CombinedMethod(a, b, tolerance), Color.Fuchsia);
            MyPlot.Plot.AddVerticalLine(ChordMethod(a, b, tolerance), Color.Green);
            
            MyPlot.Plot.AddVerticalLine(x: 0, color: Color.Black, width: 1);
            MyPlot.Plot.AddHorizontalLine(y: 0, color: Color.Black, width: 1);
            
            MyPlot.Refresh();
        }
    }
}