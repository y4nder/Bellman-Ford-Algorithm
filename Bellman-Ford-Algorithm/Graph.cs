using System;

namespace Bellman_Ford_Algorithm
{
    internal class Graph
    {
        public int VertexCount { get; set; }
        public int EdgeCount { get; set; }
        public Edge[] Edges {get; set;}

        public Graph(int vertexCount, int edgeCount ) 
        {
            this.VertexCount = vertexCount;
            this.EdgeCount = edgeCount;
            this.Edges = new Edge[edgeCount];
            for( int i = 0; i < edgeCount; i++)
                    this.Edges[i] = new Edge();
        }

        public void BellmanFord(Graph graph, int source)
        {
            int Vertecies = graph.VertexCount;
            int Edges = graph.EdgeCount;
            int[] distances = new int[graph.VertexCount];

            //initialize distances except the source to INFINITY
            distances[source] = 0;
            for (int i = 1; i < Vertecies; i++)
            {
                distances[i] = int.MaxValue;   // int.MaxValue returns a large number close to infinity
            }
            
            //relax all edges at (V - 1) times
            for (int i = 0; i < ( Vertecies - 1 ); i++) 
            {
                for (int j = 0; j < Edges; j++)
                {
                    int curr_Source = graph.Edges[j].Source;
                    int curr_Destination = graph.Edges[j].Destination;
                    int curr_Weight = graph.Edges[j].Weight;

                    if (distances[curr_Source] != int.MaxValue && distances[curr_Source] + curr_Weight < distances[curr_Destination])
                    {
                        distances[curr_Destination] = distances[curr_Source] + curr_Weight;
                    }
                }
                
            }

            //check for a negative cycle
            for (int j = 0; j < Edges; j++)
            {
                int curr_Source = graph.Edges[j].Source;
                int curr_Destination = graph.Edges[j].Destination;
                int curr_Weight = graph.Edges[j].Weight;

                if (distances[curr_Source] != int.MaxValue && distances[curr_Source] + curr_Weight < distances[curr_Destination])
                {
                    Console.WriteLine("Graph contains a negative weight cycle");
                    Console.ReadKey();
                    return;
                }
            }

            printDistances(distances, Vertecies);
        }

        public void printDistances(int[] distances, int vertices)
        {
            Console.WriteLine("Vertex distance from source\n");
            Console.Write("\t" + "|");
            for(int i = 0; i < vertices; i++)
            {
                if (i == 0)
                    Console.Write((char)(i + 'S'));
                else
                {
                    Console.Write("|");
                    Console.Write((char)(i + 'A' - 1));
                }
            }
            Console.Write("|");
            Console.WriteLine();
            Console.WriteLine("\t" + "-------------");

            Console.Write("\t" + "|");
            for (int i = 0; i < vertices; i++)
            {
                if(i == 0)
                    Console.Write(distances[i]);
                else
                {
                    Console.Write("|");
                    Console.Write(distances[i]);
                }
            }
            Console.Write("|");


            Console.ReadKey();
        }
    }
}
