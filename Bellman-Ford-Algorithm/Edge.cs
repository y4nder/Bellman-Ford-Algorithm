namespace Bellman_Ford_Algorithm
{
    internal class Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public Edge() 
        { 
            this.Source = 0;
            this.Destination = 0;
            this.Weight = 0;
        }
    }
}
