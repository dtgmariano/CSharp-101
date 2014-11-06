using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GA
{
    public partial class TestView : Form
    {
        Random random;
        List<Point> myPoints;
        Model myModel;
        GA myGA;

        public TestView()
        {
            InitializeComponent();

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            random = new Random();
            myPoints = LocalStrategy.genListPoints(10, -50, 50, random);
            myGA = new GA(100, 50, myPoints, random);

            myGA.populateProcedure();

            for (int i = 0; i < myGA.populationSize; i++)
            {
                for (int j = 0; j < myGA.population[i].Gene.Count(); j++)
                {
                    richTextBox1.AppendText(myGA.population[i].Gene[j] + "");
                }
                richTextBox1.AppendText(" Fit: " + Math.Round(myGA.population[i].Fitness, 2));
                richTextBox1.AppendText("\n");
            }
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();

            myGA.elitismProcedure();

            for (int i = 0; i < myGA.elitismSize; i++)
            {
                for (int j = 0; j < myGA.elite[i].Gene.Count(); j++)
                {
                    richTextBox2.AppendText(myGA.elite[i].Gene[j] + "-");
                }
                richTextBox2.AppendText(" Fit: " + Math.Round(myGA.elite[i].Fitness, 2));
                richTextBox2.AppendText("\n");
            }

            myGA.selectionProcedure();

            for (int i = 0; i < myGA.selectionSize; i++)
            {
                for (int j = 0; j < myGA.parents[i].Gene.Count(); j++)
                {
                    richTextBox3.AppendText(myGA.parents[i].Gene[j] + "-");
                }
                richTextBox3.AppendText(" Fit: " + Math.Round(myGA.parents[i].Fitness, 2));
                richTextBox3.AppendText("\n");
            }

            myGA.crossoverProcedure();

            for (int i = 0; i < myGA.selectionSize; i++)
            {
                for (int j = 0; j < myGA.offsprings[i].Gene.Count(); j++)
                {
                    richTextBox4.AppendText(myGA.offsprings[i].Gene[j] + "-");
                }
                richTextBox4.AppendText(" Fit: " + Math.Round(myGA.offsprings[i].Fitness, 2));
                richTextBox4.AppendText("\n");
            }

            myGA.mutationProcedure();

            for (int i = 0; i < myGA.selectionSize; i++)
            {
                for (int j = 0; j < myGA.mutants[i].Gene.Count(); j++)
                {
                    richTextBox5.AppendText(myGA.mutants[i].Gene[j] + "-");
                }
                richTextBox5.AppendText(" Fit: " + Math.Round(myGA.mutants[i].Fitness, 2));
                richTextBox5.AppendText("\n");
            }

            myGA.replaceProcedure();

            for (int i = 0; i < myGA.populationSize; i++)
            {
                for (int j = 0; j < myGA.population[i].Gene.Count(); j++)
                {
                    richTextBox1.AppendText(myGA.population[i].Gene[j] + "");
                }
                richTextBox1.AppendText(" Fit: " + Math.Round(myGA.population[i].Fitness, 2));
                richTextBox1.AppendText("\n");
            }

        }
    }
}
