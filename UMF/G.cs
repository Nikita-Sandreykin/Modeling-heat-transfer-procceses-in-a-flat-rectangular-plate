using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMF
{
    class G
    {
        private double Ly;

        private double a;

        private int n;

        public G(int n, double Ly, double a)

        {
            this.n = n;
            this.Ly = Ly;
            this.a = a;
        }

        public double g(double y, double t)

        {
            double summ = 0;
            for (int i = 0; i < n; i++)
            {
                summ += A(i) * Math.Exp(-(a * Math.PI * i / Ly) * (a * Math.PI * i / Ly) * t) * Math.Cos(Math.PI * i * y / Ly);
            }
            return summ;
        }

        private double A(int n)
        {
            if (n == 0 || n == 1 || n % 2 == 1) return 0;
            else
            {
                return 6 / (Math.PI + Math.PI * n) + 6 / (Math.PI - Math.PI * n);
            }
        }
    }
}
