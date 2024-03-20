namespace _02_exercise
{
    /*
        sidenote:

        We used simple 'string' and not 'Person item' because in that case
        we have to use casting inside the 'Graph' class (k as Person),
        but in this case it causes a problem, because in the datastructure
        there should be no hardcoded types, only generic types.

        Using reflection dynamic casting should be possible, but that is not
        the scope for this subject.

        https://social.msdn.microsoft.com/Forums/ie/en-US/fe14d396-bc35-4f98-851d-ce3c8663cd79/dynamic-casting-in-c-at-runtime?forum=csharplanguage
    */

    delegate void ExternalProcessor(string item);
    
    delegate void GraphEventHandler<T>(object source, GraphEventArgs<T> geargs);



    internal class Program
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

            // degree of familiarity for a given person (chain of relationship)
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
                //Lookup(startNode, traversalLog.Find(x => x.To.Equals(endNode)).From, traversalLog, ref steps); // LINQ vesion
                Lookup(startNode, GetPerson(traversalLog, endNode), traversalLog, ref steps);
            return steps;
        }

        static Person GetPerson(List<GraphDTO<Person>> traversalLog, Person person)
        {
            foreach (GraphDTO<Person> item in traversalLog)
                if (item.To.Equals(person))
                    return item.From;

            return null;
        }
    }
}