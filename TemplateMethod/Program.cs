using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorith algorith;
            Console.WriteLine("mans");
            algorith = new MensScoringAlgorith();
            Console.WriteLine(algorith.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Woman");
            algorith = new WomanScoringAlgorith();
            Console.WriteLine(algorith.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorith = new ChildrenScoringAlgorith();
            Console.WriteLine(algorith.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
        }
    }

    abstract class ScoringAlgorith
    {
        public int GenerateScore(int hits, TimeSpan time)
        {

            int score = CalculateBaseScore(hits);
            int reduction = CalculateBaseReduction(time);
            return CalculateBaseOverallScore(score, reduction);
        }

        public abstract int CalculateBaseOverallScore(int score, int reduction);

        public abstract int CalculateBaseReduction(TimeSpan time);

        public abstract int CalculateBaseScore(int hits);
    }

    class MensScoringAlgorith : ScoringAlgorith
    {
        public override int CalculateBaseOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }
    class WomanScoringAlgorith : ScoringAlgorith
    {
        public override int CalculateBaseOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }
    class ChildrenScoringAlgorith : ScoringAlgorith
    {
        public override int CalculateBaseOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }
    }
}
