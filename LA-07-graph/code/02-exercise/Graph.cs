namespace _02_exercise
{
    class Graph<T>
    {
        private ExternalProcessor? ProcessingLogic { get; set; }
        public event GraphEventHandler<T>? EdgeAdded;

        public List<GraphDTO<T>> TraversalLog { get; set; } = new List<GraphDTO<T>>();

        private List<List<T>> adjacencyList = new List<List<T>>();
        private List<T> content = new List<T>();

        public void AddNode(T node)
        {
            content.Add(node);
            adjacencyList.Add(new List<T>());
        }

        public void AddEdge(T from, T to)
        {
            int indexFrom = content.IndexOf(from);
            int indexTo = content.IndexOf(to);

            adjacencyList[indexFrom].Add(content[indexTo]);
            adjacencyList[indexTo].Add(content[indexFrom]);

            EdgeAdded?.Invoke(this, new GraphEventArgs<T>()
            {
                NodeA = from,
                NodeB = to
            });
        }

        public bool HasEdge(T from, T to)
        {
            int indexFrom = content.IndexOf(from);
            int indexTo = content.IndexOf(to);

            return adjacencyList[indexFrom].Contains(content[indexTo]);
        }

        public List<T> Neighbors(T whichNode)
        {
            int index = content.IndexOf(whichNode);
            return adjacencyList[index];
        }

        public void DFS(T startNode, ExternalProcessor processingLogic)
        {
            this.ProcessingLogic = processingLogic;
            List<T> F = new List<T>();
            DFS(startNode, F);
        }

        private void DFS(T k, List<T> F)
        {
            F.Add(k);
            ProcessingLogic(k.ToString());

            foreach (T x in Neighbors(k))
                if (!F.Contains(x))
                    DFS(x, F);
        }

        public void BFS(T startNode, ExternalProcessor processingLogic)
        {
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();

            S.Enqueue(startNode);
            F.Add(startNode);

            T k;

            while (S.Count != 0)
            {
                k = S.Dequeue();
                processingLogic(k.ToString());
                foreach (T x in Neighbors(k))
                {
                    if (!F.Contains(x))
                    {
                        TraversalLog.Add(
                            new GraphDTO<T>()
                            {
                                From = k,
                                To = x,
                            }
                        );
                        S.Enqueue(x);
                        F.Add(x);
                    }
                }
            }
        }
    }
}