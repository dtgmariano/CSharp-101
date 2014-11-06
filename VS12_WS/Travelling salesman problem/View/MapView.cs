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

namespace GA
{
    public partial class MapView : Form
    {
        RollingPointPairList GAPointsRPPL = new RollingPointPairList(1000); //GA Population List Points
        LineItem GAPointsLI;

        Random random;
        List<Point> myPoints;
        Model myModel;
        GA myGA;
        List<Point> champPoints;
        int generationsCounter;

        /*Constructor*/
        public MapView()
        {
            InitializeComponent();
            setGraphSettings();
            GAPointsLI = zgcMap.GraphPane.AddCurve("Cities", GAPointsRPPL, Color.Blue, SymbolType.Circle);
            GAPointsLI.Line.IsVisible = true;
        }

        /*Sets ZedGraph Scales*/
        private void setGraphSettings()
        {
            zgcMap.GraphPane.Title.Text = "TSP";
            zgcMap.GraphPane.XAxis.Title.Text = "X";
            zgcMap.GraphPane.YAxis.Title.Text = "Y";

            zgcMap.GraphPane.XAxis.Scale.Min = -100;
            zgcMap.GraphPane.XAxis.Scale.Max = 100;
            zgcMap.GraphPane.XAxis.Scale.MaxAuto = true;
            zgcMap.GraphPane.XAxis.Scale.MinorStep = 1;
            zgcMap.GraphPane.XAxis.Scale.MajorStep = 10;

            zgcMap.GraphPane.YAxis.Scale.Min = -100;
            zgcMap.GraphPane.YAxis.Scale.Max = 100;
            //zgcMap.GraphPane.YAxis.Scale.MaxAuto = true;
            zgcMap.GraphPane.YAxis.Scale.MinorStep = 1;
            zgcMap.GraphPane.YAxis.Scale.MajorStep = 10;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            random = new Random();
            myPoints = LocalStrategy.genListPoints(Convert.ToInt32(numPoints.Value), -100, 100, random);
            myGA = new GA(Convert.ToInt32(numPopulation.Value), Convert.ToInt32(numGenerations.Value), myPoints, random);

            myGA.populateProcedure();
            champPoints = ChampionStrategy.getChampionPoints(myGA.champion, myPoints);
            label3.Text = "Distance = " + Math.Round(CalculationStrategy.routeDistance(champPoints),2);
            GAPointsRPPL.Clear();
            for (int i = 0; i < myPoints.Count; i++)
                GAPointsRPPL.Add(myPoints[i].coord_x, myPoints[i].coord_y);
            zgcMap.Invalidate();
            generationsCounter = 1;
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            
            GAtimer.Interval = Convert.ToInt32(numTimer.Value);
            GAtimer.Enabled = true;
        }

        private void GAtimer_Tick(object sender, EventArgs e)
        {
            myGA.elitismProcedure();
            myGA.selectionProcedure();
            myGA.crossoverProcedure();
            myGA.mutationProcedure();
            myGA.replaceProcedure();
            champPoints = ChampionStrategy.getChampionPoints(myGA.champion, myPoints);
            generationsCounter++;
            progressBar.Value++;
            label3.Text = "Distance = " + Math.Round(CalculationStrategy.routeDistance(champPoints), 2);
            GAPointsRPPL.Clear();
            for (int i = 0; i < champPoints.Count; i++)
                GAPointsRPPL.Add(champPoints[i].coord_x, champPoints[i].coord_y);
            zgcMap.Invalidate();

            if (generationsCounter >= myGA.generationsNumber)
            {
                progressBar.Value = 0;
                GAtimer.Enabled = false;
            }
        }
    }
}
