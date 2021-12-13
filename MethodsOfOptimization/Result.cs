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
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }

        public Result(Pair firstRes, Pair secondRes, double firstA, double firstB, double secondA, double secondB, double firstIter, double secondIter)
        {
            InitializeComponent();
            X1.Text = firstRes.First.ToString();
            X2.Text = secondRes.First.ToString();

            F1.Text = firstRes.Second.ToString();
            F2.Text = secondRes.Second.ToString();

            interval1.Text = "[" + Math.Round((double)firstA,4).ToString() + ";" + Math.Round((double)firstB,4).ToString() + "]";
            interval2.Text = "[" + Math.Round((double)secondA,4).ToString() + ";" + Math.Round((double)secondB,4).ToString() + "]";

            iterations1.Text = firstIter.ToString();
            iterations2.Text = secondIter.ToString();
        }
    }
}
