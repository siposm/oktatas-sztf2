namespace _01_graph
{
    class Graph<T>
	{
		List<List<T>> adjacencyList = new List<List<T>>();

		List<T> content = new List<T>();

		public void AddNode(T node)
		{
			content.Add(node);
			adjacencyList.Add(new List<T>());
		}
		public void AddEdge(T from, T to)
		{
			int indexfrom = content.IndexOf(from);
			int indexto = content.IndexOf(to);

			// since the graph is not directed, both sides must have the connection
			adjacencyList[indexfrom].Add(content[indexto]);
			adjacencyList[indexto].Add(content[indexfrom]);
		}
		public bool IsThereEdge(T a, T b)
		{
			int indexfrom = content.IndexOf(a);
			int indexto = content.IndexOf(b);
			return adjacencyList[indexfrom].Contains(content[indexto]);
		}
		public List<T> GetNeighbors(T node)
		{
			// we exploit the way we store the neighbors (in a list)
			// so we just simply return the corresponding list

			int index = content.IndexOf(node);
			return adjacencyList[index];
		}
		public void BreadthFirstSearch(T startelem)
		{
			Queue<T> S = new Queue<T>();
			List<T> F = new List<T>();

			S.Enqueue(startelem);
			F.Add(startelem);

			T k;

			while (S.Count != 0)
			{
				k = S.Dequeue();
				Process(k);
				foreach (T x in GetNeighbors(k))
				{
					if (!F.Contains(x))
					{
						S.Enqueue(x);
						F.Add(x);
					}
				}
			}

		}
		private void DepthFirstSearchRecursive(T k, ref List<T> F)
		{
			F.Add(k);
			Process(k);

			foreach (T x in GetNeighbors(k))
			{
				if (!F.Contains(x))
					DepthFirstSearchRecursive(x, ref F);
			}
		}
		public void DepthFirstSearch(T startelem)
		{
			List<T> F = new List<T>();
			DepthFirstSearchRecursive(startelem, ref F);
		}
		private void Process(T node)
		{
			Console.WriteLine(node);
		}
	}
}