using System;
using System.Collections.Generic;
using Kraskal_basic.DSF;
using Kraskal_basic.Kruskal;

namespace Kraskal_basic
{
    public class Edge : IComparable
    {
        public int leftEdge = 0;
        public int rightEdge = 0;
        public int weightOfEdge = 0;

        public Edge(int leftEdge, int rightEdge, int weightOfEdge)
        {
            this.leftEdge = leftEdge;
            this.rightEdge = rightEdge;
            this.weightOfEdge = weightOfEdge;
        }

        public int CompareTo(object? obj)
        {
            Edge edge = (Edge)obj;
            return this.weightOfEdge.CompareTo(edge.weightOfEdge);
        }
    }
    
    class Program
    {
        private static void Kruskal(string type)
        {
            string[] size = Console.ReadLine()?.Split(null);
            if (size != null)
            {
                int verticlesCount = Convert.ToInt32(size[0]);
                List<Edge> edges = new List<Edge>();
                for (var i = 0; i < Convert.ToInt32(size[1]); i++)
                {
                    var parameters = Console.ReadLine()?.Split(null);
                    if (parameters != null)
                        edges.Add(new Edge(Convert.ToInt32(parameters[0]),
                            Convert.ToInt32(parameters[1]),
                            Convert.ToInt32(parameters[2])));
                }

                var kruskal = type == "forest" ?  new KruskalAlgorithm(new DsfForest()) : new KruskalAlgorithm(new DsfNative());
                
                List<Edge> result = kruskal.Find(verticlesCount, edges);
                Console.Out.Write(result.Count + " " + kruskal.Cost + "\n");
                foreach (var edge in result)
                    Console.Out.Write(edge.leftEdge + " " + edge.rightEdge + "\n");
            }
        }
        
        private static void DSF()
        {
            var ufds = new DsfForest();
            var result = new List<string>();
            var countItems = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < countItems; i++)
                ufds.Set(i);
            
            for (var i = 0; i < countItems - 1; i++)
            {
                string[] elems = Console.ReadLine()?.Split(null);
                if (elems != null)
                {
                    ufds.Union(Convert.ToInt32(elems[0]), Convert.ToInt32(elems[1]));
                }
                result.Add(ufds.Find(0) == ufds.Find(countItems - 1) ? "YES" : "NO");
            }
            
            foreach (var line in result)
                Console.Out.Write(line + "\n");
        }
        
        
        
        static void Main(string[] args)
        {
            //Kruskal("");
            
            DSF();
        }
    }
}