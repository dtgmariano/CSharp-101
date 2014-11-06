using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class GA
    {
        Random random;
        public int populationSize, generationsNumber;
        public double probabilityCrossover, probabilityMutation;
        public int elitismSize, selectionSize, tournamentSize;
        public List<Point> myPoints;
        public List<Chromossome> population;
        public List<Chromossome> elite;
        public List<Chromossome> parents;
        public List<Chromossome> offsprings;
        public List<Chromossome> mutants;
        public Chromossome champion;

        public GA(int _populationSize, int _generationsNumber, List<Point> _points, Random _random)
        {
            this.random = _random;
            this.populationSize = _populationSize;
            this.generationsNumber = _generationsNumber;
            this.probabilityCrossover = 1.0;
            this.probabilityMutation = 0.1;
            this.elitismSize = (int)Math.Round(((double)this.populationSize * 0.1),0);
            this.selectionSize = this.populationSize - this.elitismSize;
            this.tournamentSize = 2;
            this.myPoints = new List<Point>(_points);
        }

        public void populateProcedure()
        {
            this.population = PopulateStrategy.populate(this.populationSize, this.myPoints, this.random);
            this.champion = ChampionStrategy.getChampion(this.population);
        }

        public void elitismProcedure()
        {
            this.elite = ElitismStrategy.basicElitism(this.population, this.elitismSize);
        }

        public void selectionProcedure()
        {
            this.parents = SelectionStrategy.Tournament(this.population, this.selectionSize, this.tournamentSize, this.random);
        }

        public void crossoverProcedure()
        {
            this.offsprings = CrossoverStrategy.PMX(this.parents, this.myPoints, this.probabilityCrossover, this.random);
        }

        public void mutationProcedure()
        {
            this.mutants = MutationStrategy.Swap(this.offsprings, this.myPoints, this.probabilityMutation, this.random);
        }

        public void replaceProcedure()
        {
            this.population = ShiftStrategy.shiftGeneration(this.elite, this.mutants);
            this.champion = ChampionStrategy.getChampion(this.population);
        }

        
    }
}
