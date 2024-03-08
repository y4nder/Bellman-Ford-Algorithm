using System;

namespace Bellman_Ford_Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            inputGraph();
            //fastGraph();
        }

        private static void inputGraph()
        {
            int V;
            int E;

            Console.Write("Input Vertex Count: ");
            V = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input Edge Count: ");
            E = Convert.ToInt32(Console.ReadLine());

            Graph graph = new Graph(V, E);

            for (int i = 0; i < E; i++)
            {
                Console.WriteLine($"Input edge {i + 1} details");
                string details = Console.ReadLine();
                string[] input = details.Split(' ');
                if (input[0] == "S")
                    graph.Edges[i].Source = Convert.ToChar(input[0]) - 'S';
                else graph.Edges[i].Source = Convert.ToChar(input[0]) - 'A' + 1;
                graph.Edges[i].Destination = Convert.ToChar(input[1]) - 'A' + 1;
                graph.Edges[i].Weight = Convert.ToInt32(input[2]);


            }

            graph.BellmanFord(graph, 0);
        }

        //FAST DEBUGGING PURPOSE ONLY
        private static void fastGraph()
        {
            Graph graph = new Graph(6, 8);

            graph.Edges[0].Source = 0;
            graph.Edges[0].Destination = 1;
            graph.Edges[0].Weight = 10;

            graph.Edges[1].Source = 0;
            graph.Edges[1].Destination = 5;
            graph.Edges[1].Weight = 8;

            graph.Edges[2].Source = 1;
            graph.Edges[2].Destination = 3;
            graph.Edges[2].Weight = 2;

            graph.Edges[3].Source = 5;
            graph.Edges[3].Destination = 4;
            graph.Edges[3].Weight = 1;

            graph.Edges[4].Source = 4;
            graph.Edges[4].Destination = 3;
            graph.Edges[4].Weight = -1;

            graph.Edges[6].Source = 4;
            graph.Edges[6].Destination = 1;
            graph.Edges[6].Weight = -4;

            graph.Edges[5].Source = 3;
            graph.Edges[5].Destination = 2;
            graph.Edges[5].Weight = -2;

            graph.Edges[7].Source = 2;
            graph.Edges[7].Destination = 1;
            graph.Edges[7].Weight = 1;

            graph.BellmanFord(graph, 0);
        }
    }
}
