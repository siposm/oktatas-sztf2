namespace _02_backtracksearch
{
    enum Roles
    {
        Tervezés,
        Irányítás,
        Beszerzés,
        Ellenőrzés,
        Engedélyezés,
        Érékesítés
    }

    class Person
    {
        public string? Name { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as Person).Name.Equals(this.Name);
        }

        public override string ToString()
        {
            return this.Name.ToUpper();
        }
    }
    internal class Program
    {
        static bool Ft(int level, Person person)
        {
            return true;
        }

        static bool Fk(Person[] results, int level, Person person)
        {
            for (int i = 0; i < level; i++) // only checking UNTIL 'level'
                if (results[i].Equals(person))
                    return false;

            return true;
        }

        static void BTS(int level, ref Person[] E, ref bool isThere, int[] M, Person[,] R)
        {
            int i = -1;
            while (!isThere && i < M[level])
            {
                i++;
                if (Ft(level, R[level, i]))
                {
                    if (Fk(E, level, R[level, i]))
                    {
                        E[level] = R[level, i];
                        if (level == R.GetLength(0) - 1)
                            isThere = true;
                        else
                            BTS(level + 1, ref E, ref isThere, M, R);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Person[,] R = new Person[6, 3];

            // role/level #1
            R[0, 0] = new Person() { Name = "Miklós" };
            R[0, 1] = new Person() { Name = "Klaudia" };

            // role/level #2
            R[1, 0] = new Person() { Name = "Zsolt" };
            R[1, 1] = new Person() { Name = "Miklós" };

            // role/level #3
            R[2, 0] = new Person() { Name = "András" };

            // role/level #4
            R[3, 0] = new Person() { Name = "András" };
            R[3, 1] = new Person() { Name = "Pál" };
            R[3, 2] = new Person() { Name = "Zsolt" };

            // role/level #5
            R[4, 0] = new Person() { Name = "András" };
            R[4, 1] = new Person() { Name = "Géza" };

            // role/level #6
            R[5, 0] = new Person() { Name = "Géza" };
            R[5, 1] = new Person() { Name = "Miklós" };

            int[] M = { 1, 1, 0, 2, 1, 1 };

            Person[] E = new Person[6];

            bool isThere = false;

            BTS(0, ref E, ref isThere, M, R); // first call is with level #0





            for (int i = 0; i < E.Length; i++)
            {
                Console.WriteLine("{0}. level: {1}", i, E[i]);
            }

            string[] roles = Enum.GetNames(typeof(Roles));

            for (int i = 0; i < E.Length; i++)
            {
                Console.WriteLine($"ROLE: {roles[i]} \tPERSON: {E[i]}");
            }
        }
    }
}