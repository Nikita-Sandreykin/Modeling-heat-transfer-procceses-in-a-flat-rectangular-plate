using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace UMF
{
    delegate int Def(int a, int b);
    public partial class Form1 : Form
    {
        private double a;

        Def func;

        private double k;

        private double c;

        private double T;

        private double Lx;

        private double Ly;

        private int N1;

        private int N2;

        private int checkNF(double e)

        {
            return 1 + (int)(80 * Lx / (Math.PI * Math.PI * e));
        }

        private int checkNG(double e)

        {
            double ex = Math.Exp(e * Math.PI / 12);
            return 1 + (int)((1 + ex) / (ex - 1));
        }

        public Form1()

        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            k = Convert.ToDouble(textBox1.Text);
            c = Convert.ToDouble(textBox2.Text);
            T = Convert.ToDouble(textBox3.Text);
            Lx = Convert.ToDouble(textBox4.Text);
            Ly = Convert.ToDouble(textBox5.Text);
            double eps = Convert.ToDouble(textBox6.Text);
            a = k / c;
            Graph graph = new Graph();
            GraphPane pane = graph.zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            N1 = checkNF(eps);
            N2 = checkNG(eps);
            F f = new F(N1, Lx, a);
            G g = new G(N2, Ly, a);
            // Создадим список точек

            PointPairList list = new PointPairList();
            for (double i = 0; i < Ly; i += 0.001)
            {
                list.Add(i, f.f(2, T) * g.g(i, T) + 7.5);
            }
            LineItem myCurve = pane.AddCurve("X = 2", list, Color.Blue, SymbolType.None);
            pane.XAxis.Title.Text = "Y, m";
            pane.YAxis.Title.Text = "T, ℃";
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;
            graph.zedGraphControl1.AxisChange();
            graph.zedGraphControl1.Invalidate();
            graph.Show();
        }
    }
}
