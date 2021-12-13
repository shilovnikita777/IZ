using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI;

namespace MethodsOfOptimization
{
    public partial class Dichotomy : Form
    {
        int iterations1 = 0;
        int iterations2 = 0;
        double a1;
        double a2;
        double b1;
        double b2;
        public Dichotomy()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(firstIntervalTextBox.Text);
            double b = Convert.ToDouble(secondIntervalTextBox.Text);

            double L0 = Convert.ToDouble(L0TextBox.Text);
            double E = Convert.ToDouble(ETextBox.Text);

            double firstTerm = Convert.ToDouble(firstTermTextBox.Text);
            //double secondTerm = Convert.ToDouble(secondTermTextBox.Text);

            int firstDegree = Convert.ToInt32(firstDegreeTextBox.Text);
            //int secondDegree = Convert.ToInt32(secondDegreeTextBox.Text);

            double koef1 = Convert.ToDouble(koef1TextBox.Text);

            string sign = signTextBox.Text;


            myFunc func = new myFunc(firstTerm, firstDegree, koef1, sign);
            int C = 1;

            if (radioButtonMAX.Checked)
            {
                C = -1;
            }

            Pair fibonacciAnswer = calculateFibonacci(func, a, b, L0, E, C);
            Pair dichotomyAnswer = calculateDichotomy(func, a, b, L0, E, C);

            Result resForm = new Result(dichotomyAnswer,fibonacciAnswer,a1,b1,a2,b2,iterations1,iterations2);
            resForm.Show();
            iterations1 = iterations2 = 0;
        }


        private Pair calculateDichotomy(myFunc func,double a,double b,double L0,double E, int C)
        {
            double x;
            double F1, F2;

            do
            {
                iterations1++;

                x = (a + b) / 2;
                //x = Math.Round(x, 4);

                F1 = func.calculateFunc(x - E);
                F2 = func.calculateFunc(x + E);

                if (C * F1 < C * F2)
                {
                    b = x;
                }
                else
                {
                    a = x;
                }

            } while (Math.Abs(b - a) > 2*L0);

            x = (b + a) / 2;
            x = Math.Round(x, 4);
            F1 = Math.Round(func.calculateFunc(x),4);

            a1 = a;
            b1 = b;

            return new Pair(x, F1);

        }

        private Pair calculateFibonacci(myFunc func, double a, double b, double L0, double E, int C)
        {

            double x1 = 0, x2 = 0;
            double F1, F2;
            double N = (b - a) / L0;

            int n = findnByN(N);
            iterations2 = n;

            int k = 1;
            do
            {
                x1 = a + ((double)fibb(n - 1 - k) / (double)fibb(n - k + 1)) * (b - a);
                x2 = a + ((double)fibb(n - k) / (double)fibb(n - k + 1)) * (b - a);
                F1 = func.calculateFunc(x1);
                F2 = func.calculateFunc(x2);

                if (C * F1 > C * F2)
                {
                    a = x1;
                }
                else
                {
                    b = x2;
                }
                k++;
            } while (k != n - 1);
            x1 = Math.Round((a + b) / 2,4);
            F1 = Math.Round(func.calculateFunc(x1),4);
            a2 = a;
            b2 = b;
            return new Pair(x1, F1);
        }

        private int fibb(int n)
        {
            int F1 = 1;
            int F2 = 1;
            
            if (n == 0)
                return F1;
            if (n == 1)
                return F2;

            for (int i = 0; i < n - 1; ++i)
            {
                int a = F1;
                F1 = F2;
                F2 = a + F2;
            }
            return F2;
        }

        private int findnByN(double N)
        {
            int F1 = 1;
            int F2 = 1;

            int index = 1;
            while (!(F1 < N && N <= F2))
            {
                int a = F1;
                F1 = F2;
                F2 = a + F2;
                index++;
            }
            return index;
        }

    }

    public class myFunc
    {
        private double firstTerm;

        private int firstDegree;

        private double koef1;

        private string sign;

        public myFunc(double fT, int fD, double kf1,string sign1)
        {
            firstTerm = fT;
            firstDegree = fD;
            koef1 = kf1;
            sign = sign1;
        }
        public double calculateFunc(double x)
        {
            //double first = Math.Pow((koef1 * x + firstTerm), firstDegree);
            //if (sign == "-")
            //{
            //    first = -first;
            //}

            //return first;
            return x*x + -2*x+5;
        }
    }
}
