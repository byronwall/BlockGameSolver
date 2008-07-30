using System;
using System.Text;
using System.Xml.Linq;

namespace BlockGameSolver.Simulation.Core
{
    public struct PopulationSettings
    {
        private readonly double crossoverRatio;
        private readonly double filterRate;
        private readonly int initialPopulationSize;
        private readonly int maxGenerations;
        private readonly double mutateRatio;
        private readonly int populationSize;

        public PopulationSettings(int maxGenerations, int populationSize, double mutateRatio, double filterRate, int initialPopulationSize, double crossoverRatio)
        {
            this.maxGenerations = maxGenerations;
            this.crossoverRatio = crossoverRatio;
            this.initialPopulationSize = initialPopulationSize;
            this.filterRate = filterRate;
            this.mutateRatio = mutateRatio;
            this.populationSize = populationSize;
        }

        public int FilterSize
        {
            get { return (int) (populationSize*filterRate); }
        }

        public double MutateRatio
        {
            get { return mutateRatio; }
        }

        public int MaxGenerations
        {
            get { return maxGenerations; }
        }

        public int PopulationSize
        {
            get { return populationSize; }
        }

        public int InitialPopulationSize
        {
            get { return initialPopulationSize; }
        }

        public double CrossoverRatio
        {
            get { return crossoverRatio; }
        }

        public int MoveCache
        {
            get { return populationSize*2; }
        }

        public static PopulationSettings Default
        {
            get { return new PopulationSettings(15, 50, 0.01, 0.01, 50, 0.95); }
        }

        public void SaveToXML(string path)
        {
            XDocument document = new XDocument();
            XElement root = new XElement("settings");

            root.Add(new XElement("filterRate", filterRate));
            root.Add(new XElement("maxGenerations", maxGenerations));
            root.Add(new XElement("mutateRatio", mutateRatio));
            root.Add(new XElement("crossoverRatio", crossoverRatio));
            root.Add(new XElement("populationSize", populationSize));
            root.Add(new XElement("initialPopulationSize", initialPopulationSize));

            document.Add(root);

            document.Save(path);
        }

        public static PopulationSettings LoadFromXML(string path)
        {
            XDocument document = XDocument.Load(path);
            XElement root = document.Element("settings");

            if (root != null)
            {
                double filterRate = (double) root.Element("filterRate");
                int maxGenerations = (int) root.Element("maxGenerations");
                double mutateRatio = (double) root.Element("mutateRatio");
                double crossoverRatio = (double) root.Element("crossoverRatio");
                int populationSize = (int) root.Element("populationSize");
                int initialPopulationSize = (int) root.Element("initialPopulationSize");
                return new PopulationSettings(maxGenerations, populationSize, mutateRatio, filterRate, initialPopulationSize, crossoverRatio);
            }
            throw new ArgumentException("That path is not a valid source for population settings.");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\t{1}\r\n", "filterRate", filterRate);
            sb.AppendFormat("{0}\t{1}\r\n", "maxGenerations", maxGenerations);
            sb.AppendFormat("{0}\t{1}\r\n", "mutateRatio", mutateRatio);
            sb.AppendFormat("{0}\t{1}\r\n", "crossoverRatio", crossoverRatio);
            sb.AppendFormat("{0}\t{1}\r\n", "populationSize", populationSize);
            sb.AppendFormat("{0}\t{1}\r\n", "initialPopulationSize", initialPopulationSize);

            return sb.ToString();
        }
    }
}