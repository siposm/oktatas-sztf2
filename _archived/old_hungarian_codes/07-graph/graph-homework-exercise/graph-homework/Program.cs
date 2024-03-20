using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace graph_homework
{
    class GraphEventArgs<T> : EventArgs
    {
        public T NodeA { get; set; }
        public T NodeB { get; set; }
    }
    /*
        ps>

        Azért nem Person item -ként van megírva, mert akkor a gráfon belül
        szükség lenne kasztolásra (k as Person), viszont ekkor sérül az az elv,
        hogy az adatszerkezetben típusfüggetlen legyen.

        Lehetne dinamikusan kasztolni, de ahhoz reflexió kellene ami még prog2-n
        nem tananyag, vagy valami eldugott convert függvény de az meg fölöslegesen
        más irányba viszi el a projektet.
        https://social.msdn.microsoft.com/Forums/ie/en-US/fe14d396-bc35-4f98-851d-ce3c8663cd79/dynamic-casting-in-c-at-runtime?forum=csharplanguage
    */
    delegate void ExternalProcessor(string item);
    delegate void GraphEventHandler<T>(object source, GraphEventArgs<T> geargs);

    class Graph<T>
    {
        private ExternalProcessor ProcessingLogic { get; set; }
        public event GraphEventHandler<T> EdgeAdded;

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
            this.ProcessingLogic(k.ToString());

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

    class GraphDTO<T>
    {
        public T From { get; set; }
        public T To { get; set; }
    }

    class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class Program
    {
        static void Proc(string item)
        {
            Console.WriteLine(item);
            using (StreamWriter sw = File.AppendText("graph_output.txt"))
            {
                sw.WriteLine(item);
            }
        }

        static void EventCheck(object source, GraphEventArgs<Person> geargs)
        {
            Console.WriteLine($"Edge has been successfully added between [ {geargs.NodeA} ] and [ {geargs.NodeB} ]");
        }

        static void Main(string[] args)
        {
            Graph<Person> g = new Graph<Person>();

            g.EdgeAdded += EventCheck;

            Person Joseph = new Person() { Name = "Joseph" };
            Person Stew = new Person() { Name = "Stew" };
            Person Marge = new Person() { Name = "Marge" };
            Person Gerald = new Person() { Name = "Gerald" };
            Person Zack = new Person() { Name = "Zack" };
            Person Peter = new Person() { Name = "Peter" };
            Person Janet = new Person() { Name = "Janet" };

            g.AddNode(Joseph);
            g.AddNode(Stew);
            g.AddNode(Marge);
            g.AddNode(Gerald);
            g.AddNode(Zack);
            g.AddNode(Peter);
            g.AddNode(Janet);

            g.AddEdge(Joseph, Stew);
            g.AddEdge(Joseph, Marge);
            g.AddEdge(Marge, Stew);

            g.AddEdge(Joseph, Zack);
            g.AddEdge(Gerald, Zack);
            g.AddEdge(Joseph, Gerald);

            g.AddEdge(Peter, Zack);
            g.AddEdge(Peter, Janet);

            Console.WriteLine("\n>> DFS\n");
            g.DFS(Janet, Proc);

            Console.WriteLine("\n>> BFS\n");
            g.BFS(Janet, Console.WriteLine);

            Console.WriteLine("\n\n");
            foreach (var item in g.TraversalLog)
                Console.WriteLine($"{item.From} : {item.To}");

            // adott X személy hányad fokú ismerettségben áll adott Y személlyel (kapcsolati lánc kiírása)
            Console.WriteLine("\n\n");
            List<Person> steps = new List<Person>();
            Lookup(Janet, Stew, g.TraversalLog, ref steps);
            steps.ForEach(x => Console.Write(x + " => "));

            Console.WriteLine("\n\n");
        }

        static List<Person> Lookup(Person startNode, Person endNode, List<GraphDTO<Person>> traversalLog, ref List<Person> steps)
        {
            steps.Add(endNode);
            if (!endNode.Equals(startNode))
                //Lookup(startNode, traversalLog.Find(x => x.To.Equals(endNode)).From, traversalLog, ref steps); // linq verzió
                Lookup(startNode, GetPerson(traversalLog, endNode), traversalLog, ref steps);
            return steps;
        }

        static Person GetPerson(List<GraphDTO<Person>> traversalLog, Person person)
        {
            foreach (GraphDTO<Person> item in traversalLog)
                if (item.To.Equals(person))
                    return item.From;

            return null; // ez az eset nem fog előfordulni, de a fordító megköveteli
        }
    }
}
