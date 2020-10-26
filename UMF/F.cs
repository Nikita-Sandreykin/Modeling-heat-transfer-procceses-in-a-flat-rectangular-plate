using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMF
{
    class F
    {
        private int n;

        private double Lx;

        private double a;

        public F(int n, double Lx, double a)

        {

            this.n = n;

            this.Lx = Lx;

            this.a = a;

        }

        public double f(double x, double t)

        {

            double summ = 0;

            for (int i = 1; i < n; i++)

            {

                summ += A(i) * Math.Exp(-(Math.PI * i * a / Lx) * (Math.PI * i * a / Lx) * t) * Math.Cos(Math.PI * i * x / Lx);

            }

            return summ;

        }

        private double A(int n)

        {

            if ((n - 2) % 4 == 0) return -40 * Lx / (Math.PI * n * Math.PI * n);

            else return 0;

        }

    }
}
