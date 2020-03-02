using System.Collections.Generic;
using Kraskal_basic.DSF;

namespace Kraskal_basic.Kruskal
{
    public abstract class KruskalAlg
    {
        public abstract int Cost { get; set; }
        public abstract List<Edge> Find(int vamount, List<Edge> edges);
    }

    public class KruskalAlgorithm : KruskalAlg
    {
        private Dsf dsf;

        public KruskalAlgorithm(Dsf dsf)
        {
            this.dsf = dsf;
        }
        public override int Cost { get; set; }
        public override List<Edge> Find(int vamount, List<Edge> edges)
        {
            int i = 0;
            Cost = 0;
            List<Edge> result = new List<Edge>();

            edges.Sort();

            for (i = 0; i < vamount; i++)
            {
                dsf.Set(i);
            }
            
            foreach (Edge edge in edges)
            {
                int left = edge.leftEdge;
                int right = edge.rightEdge;
                var weight = edge.weightOfEdge;
                if (dsf.Find(left) == dsf.Find(right))
                {
                    continue;
                }
                Cost += weight;
                result.Add(new Edge(left, right, 0));
                dsf.Union(left, right);
            }

            return result;
        }
    }
}