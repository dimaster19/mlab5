using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mlab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double a = -2; double b = 2;

            //n = 10
            MyStruct eulor10 = new MyStruct();
            eulor10 = Eulor(a, b, 10);
            MyStruct runge10 = new MyStruct();
            runge10 = RungeCutta(a, b, 10);

            for (int i = 0; i < eulor10.V.Length; i++) {
                chart1.Series["Euler"].Points.AddXY( eulor10.T[i], eulor10.V[i]);
                chart1.Series["Runge-Kutta"].Points.AddXY(runge10.T[i], runge10.V[i]);
            }

            //n = 50
            MyStruct eulor50 = new MyStruct();
            eulor50 = Eulor(a, b, 50);
            MyStruct runge50 = new MyStruct();
            runge50 = RungeCutta(a, b, 50);

            for (int i = 0; i < eulor50.V.Length; i++)
            {
                chart2.Series["Euler"].Points.AddXY(eulor50.T[i], eulor50.V[i]);
                chart2.Series["Runge-Kutta"].Points.AddXY(runge50.T[i], runge50.V[i]);
            }

            //n = 500
            MyStruct eulor500 = new MyStruct();
            eulor500 = Eulor(a, b, 500);
            MyStruct runge500 = new MyStruct();
            runge500 = RungeCutta(a, b, 500);

            for (int i = 0; i < eulor500.V.Length; i++)
            {
                chart3.Series["Euler"].Points.AddXY(eulor500.T[i], eulor500.V[i]);
                chart3.Series["Runge-Kutta"].Points.AddXY(runge500.T[i], runge500.V[i]);
            }
        }

        class MyStruct
        {
            public double[] T;
            public double[] V;
        }

        public double f (double t, double v)
        {
            return 2*v;
        }
        MyStruct Eulor(double a, double b, int n)
        {
            double h = (b - a) / n;
            double[] T = new double[n];
            double[] V = new double[n];
            T[0] = a; V[0] = 10;
            for (int i = 1; i <= n - 1; i++)
            {
                T[i] = a + i * h;
                V[i] = V[i - 1] + h * f(T[i - 1], V[i - 1]);
            }
            MyStruct result = new MyStruct();
            result.V = V;
            result.T = T;
            return result;
        }
        MyStruct RungeCutta(double a, double b, int n)
        {
            double h = (b - a) / n;
            double[] T = new double[n];
            double[] V = new double[n];
            double[] V1 = new double[n];
            double[] V2 = new double[n];
            double[] V3 = new double[n];
            double[] V4 = new double[n];
            T[0] = a; V[0] = 10;
            for (int i = 1; i <= n - 1; i++)
            {
                T[i] = a + i * h;
                V1[i] = h * f(T[i - 1], V[i - 1]);
                V2[i] = h * f(T[i - 1] + h / 2.0, V[i - 1] + V1[i] / 2.0);
                V3[i] = h * f(T[i - 1] + h / 2, V[i - 1] + V2[i] / 2);
                V4[i] = h * f(T[i - 1] + h, V[i - 1] + V3[i]);
                V[i] = V[i - 1] + (V1[i] + 2 * V2[i] + 2 * V3[i] + V4[i]) / 6;
            }
            MyStruct result = new MyStruct();
            result.V = V;
            result.T = T;
            return result;
        }
        
    }


}
