namespace _01_graph
{
    internal class Program
	{
		static void Main(string[] args)
		{
			Graph<string> g = new Graph<string>();

			g.AddNode("Józsi");
			g.AddNode("Sanyi");
			g.AddNode("Magdi");
			g.AddNode("Gizi");
			g.AddNode("Zoli");
			g.AddNode("Péter");
			g.AddNode("Jenő");

			g.AddEdge("Józsi", "Sanyi");
			g.AddEdge("Józsi", "Magdi");
			g.AddEdge("Magdi", "Sanyi");

			g.AddEdge("Józsi", "Zoli");
			g.AddEdge("Gizi", "Zoli");
			g.AddEdge("Józsi", "Gizi");

			g.AddEdge("Péter", "Zoli");
			g.AddEdge("Péter", "Jenő");

			Console.WriteLine("\n>>BFS\n");
			g.BreadthFirstSearch("Jenő");

			Console.WriteLine("\n>>DFS\n");
			g.DepthFirstSearch("Jenő");

			Console.WriteLine("\n\n");
			g.DepthFirstSearch("Gizi");


			Console.WriteLine("\n\n");
		}
	}
}