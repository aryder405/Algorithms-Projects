using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reference_Web_Project
{
    class AListGraph
    {
        class Node
        {
            public String name { get; set; }
            public int weight { get; set; }

            public Node(String n, int w)
            {
                name = n;
                weight = w;
            }
            public String toString()
            {
                return (name + " " + weight);
            }
            public String getStringWeight()
            {
                String s = "";
                switch (this.weight)
                {
                    case -3:
                        s= "not recommended";
                        break;
                    case 1:
                        s = "recommend";
                        break;
                    case 3:
                        s = "highly recommend";
                        break;
                }
                return s;
            }
        }
        /// <summary>
        /// Used a Dictionary as the data structure to store 
        /// all the vertices.
        /// </summary>
        private Dictionary<String, List<Node>> graph;
        public String filename { get; private set; }
        /// <summary>
        /// Constructor creates the graph with a text file.
        /// </summary>
        /// <param name="file"></param>
        public AListGraph(String file)
        {
            graph = new Dictionary<String, List<Node>>();
            filename = file;
            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        String line = reader.ReadLine().ToLower();
                        String[] input = line.Split(' ');
                        int size = input.Length;
                        String vertex1 = input[0];
                        //add 
                        if (input[0].Equals("add"))
                        {
                            //add person sam
                            if (input[1].Equals("person") && size == 3)
                            {
                                String name = input[2];
                                List<Node> nodes = new List<Node>();
                                if (!graph.Keys.Contains(input[2]))
                                {
                                    Console.WriteLine("adding person: " + name);
                                    graph.Add(input[2], nodes);
                                }
                                else
                                    Console.WriteLine("Person already exists");
                            }
                            //add reference sam joe highly recommend
                            //add reference sam joe not recommend
                            //add reference sam joe recommend
                            if (input[1].Equals("reference") && (size == 5 || size == 6) )
                            {
                                List<String> names = getAllNames();
                                String fromRef = input[2];
                                String toRef = input[3];
                                if (names.Contains(fromRef) && names.Contains(toRef))
                                {
                                    
                                    if (input[4].Equals("recommend"))
                                        addEdge(toRef, fromRef, 1);
                                    if (input[4].Equals("highly") && input[5].Equals("recommend"))
                                    {
                                        Console.WriteLine("Adding edges..");
                                        addEdge(toRef, fromRef, 3);
                                    }
                                    if (input[4].Equals("not") && input[5].Equals("recommended"))
                                        addEdge(toRef, fromRef, -3);
                                }
                                else
                                    Console.WriteLine("One of those persons doesn't exist");
                            }
                        }
                        //change reference joe sam not recommended
                        //change reference joe sam highly recommended
                        //change reference joe sam recommended
                        if (input[0].Equals("change") && input[1].Equals("reference") && size >= 5 && size <= 6)
                        {
                            List<String> allNames = getAllNames();
                            string fromRef = input[2];
                            string toRef = input[3];
                            int newWeight=0;
                            if (allNames.Contains(fromRef) && allNames.Contains(toRef))
                            {
                                if (input[4].Equals("recommend") && size == 5)
                                {
                                    newWeight = 1; 
                                }
                                else if (input[4].Equals("not") && input[4].Equals("recommended"))
                                {
                                    newWeight = -3;
                                }
                                else if (input[4].Equals("highly") && input[4].Equals("recommend"))
                                {
                                    newWeight = 3;
                                }
                                List<Node> nodes = graph[toRef];
                                foreach (Node nod in nodes)
                                {
                                    if (nod.name.Equals(fromRef))
                                    {
                                        nod.weight = newWeight;
                                        break;
                                    }
                                }
                            }
                            else
                                Console.WriteLine("One of those persons doesn't exist");

                        }
                        //delete
                        if (input[0].Equals("delete"))
                        {
                            //delete person sam
                            if (input[1].Equals("person") && size == 3)
                            {   
                                String person = input[2];
                                if(graph.Keys.Contains(person))
                                {
                                    graph.Remove(person);
                                }
                            }
                            //delete reference sam joe 
                            if (input[1].Equals("reference") && size == 4)
                            {
                                String fromRef = input[2];
                                String toRef = input[3];
                                List<Node> nodes = graph[toRef];
                                foreach (Node nod in nodes)
                                {
                                    if (nod.name.Equals(fromRef))
                                    {
                                        nodes.Remove(nod);
                                    }
                                }
                            }
                        }      
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// This prints out a representation of the graph
        /// in the form of an adjacency list.
        /// </summary>
        public String printAdjacencyList()
        {
            String name = "";
            String neighbors = "";
            String output = "";
            Console.WriteLine("Printing Graph");
            var list = graph.Keys.ToList();
            list.Sort();
            foreach (String s in list)
            {
                name = s;
                List<String> names = getNeighborsWeights(name);
                neighbors = string.Join(", ", names.ToArray()) + "\n";
                //output += pair.Key + " --> " +  String.Join(", ", pair.Value.ToArray().ToString()) + "\n";
                //Console.WriteLine(neighbors);
                output += name + " ---> " + neighbors;
            }
            return output;
        }

        /// <summary>
        /// Save to a file in a report format, sorted by
        /// person name.
        /// </summary>
        /// <param name="filename"></param>
        public void saveToFile(String filename)
        {
            String output = printAdjacencyList();
            System.IO.File.WriteAllLines(filename, output.Split('\n'));            
        }

        public List<int> getAllWeights()
        {
            int high = 0;
            int rec = 0;
            int not = 0;
            foreach(var pair in graph)
            {
                foreach (Node n in graph[pair.Key])
                {
                    switch (n.weight)
                    {
                        case 3:
                            high++;
                            break;
                        case 1:
                            rec++;
                            break;
                        case -3:
                            not++;
                            break;
                    }
                }
            }
            List<int> list = new List<int> { not, rec, high };
            return list;
        }
        /// <summary>
        /// Remove all data regarding a person
        /// </summary>
        /// <param name="person"></param>
        public void removePerson(String person)
        {
            if (graph.Keys.Contains(person))
            {
                graph.Remove(person);
            }
            foreach (var pair in graph)
            {
                foreach (Node n in graph[pair.Key])
                {
                    if (n.name.Equals(person))
                    {
                        graph[pair.Key].Remove(n);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// All references by and about one person delivered as
        /// a list of strings.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<String> reportOnOnePerson(String person)
        {
            List<String> report = new List<string>();
            if(graph.Keys.Contains(person)){
                List<Node> nodes = graph[person];
                foreach(Node n in nodes){
                    report.Add(person + "," + n.name + "," + n.getStringWeight());
                }
            }
            foreach (var pair in graph)
            {
                if (pair.Key != person)
                {
                    if(getNeighbors(pair.Key).Contains(person)){
                        foreach (Node n in graph[pair.Key])
                        {
                            if (n.name.Equals(person))
                            {
                                report.Add(pair.Key + "," + n.name + "," + n.getStringWeight());
                            }   
                        }
                    }
                }
            }
            return report;
        }

        /// <summary>
        /// This saves the graph to the same text file used to create the graph.
        /// </summary>
        public void saveGraph()
        {
            ArrayList newGraph = new ArrayList();
            List<String> allnames = getAllNames();
            //add all people to the new graph
            foreach (String s in allnames)
            {
                newGraph.Add("add person " + s);                    
            }
            foreach (var pair in graph)
            {
                String person = pair.Key;
                List<Node> list = pair.Value;
                foreach (Node n in list)
                {
                    newGraph.Add("add reference " + n.name + " " + person + " " + n.getStringWeight());
                }
            }
            System.Diagnostics.Debug.WriteLine("Saving Graph");
            System.IO.File.WriteAllLines(filename, newGraph.ToArray(typeof(String)) as String[]);
        }
        /// <summary>
        /// Counts the total number of edges in the graph.
        /// </summary>
        /// <returns>Returns the number of edges as an int</returns>
        public int countEdges()
        {
            int count = 0;
            foreach (var pair in graph)
            {
                count += pair.Value.Count();
            }
            System.Diagnostics.Debug.WriteLine("Number of edges in graph: ");
            return count;
        }
        /// <summary>
        /// Counts the number of neighbors(edges) a certain vertex has.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns>Returns the number of neighbors a vertex has, -1 if none exist</returns>
        public int countNeighbor(String vertex)
        {
            int count = 0;
            if (graph.ContainsKey(vertex))
            {
                count = graph[vertex].Count();//This gets the count in the list if the vertex is the key
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Vertex Doesn't exist");
                return -1;
            }
            System.Diagnostics.Debug.WriteLine("Number of neighbors for " + vertex + ": " + count);
            return count;
        }
        /// <summary>
        /// Determines if a certain vertex has an edge or not
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns>True if it does, else false</returns>
        public Boolean hasEdge(String vertex)
        {            
            Boolean b = false;
            if (graph.ContainsKey(vertex))//vertex is a key
            {
                if (graph[vertex].Count > 0)
                    b = true;
            }
            else//vertex isn't a key
            {
                foreach (var pair in graph)
                {
                    foreach (Node n in pair.Value)
                    {
                        if(n.name.Equals(vertex)){
                            b = true;
                        }
                    }
                    //if (pair.Value.Contains(vertex))
                    //    b = true;
                }
            }
            System.Diagnostics.Debug.WriteLine("Has Edge: " + vertex);
            return b;
        }
        /// <summary>
        /// Adds an edge to a specified vertices
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="newVertex"></param>
        /// <returns>True if successfully added, else false</returns>
        public Boolean addEdge(String vertex, String newVertex, int w)
        {            
            Boolean b = false;
            if (graph.ContainsKey(vertex))//graph contains the vertex already
            {
                if (!getNeighbors(vertex).Contains(newVertex))//newVertex isn't a neighbor, so add him
                {
                    if (!newVertex.Equals(""))
                    {
                        Node n = new Node(newVertex, w);
                        graph[vertex].Add(n);
                        b = true;
                    }
                }               
            }
            else//graph doesn't contain vertex, so have to add it and a new list
            {
                List<Node> nodes = new List<Node>();
                if (newVertex != ""){
                    Node n = new Node(newVertex, w);
                    nodes.Add(n);
                }
                System.Diagnostics.Debug.WriteLine("Adding edge from " + vertex + " to " + newVertex);
                graph.Add(vertex, nodes);
                b = true;
            }
            return b;
        }
        /// <summary>
        /// Removes an edge from the specified vertices
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns>True if removed, else false</returns>
        public Boolean removeEdge(String from, String to)
        {
            Boolean b = false;
            if (graph.ContainsKey(to))
            {
                foreach (Node n in graph[to])
                {
                    if (n.name == from)
                    {
                        graph[to].Remove(n);
                        b = true;
                        break;
                    }
                }
            }
            /*else if (graph.ContainsKey(vertex2))
            {
                if (graph[vertex2].Contains(vertex1))
                {
                    System.Diagnostics.Debug.WriteLine("Removing edge from " + vertex2 + " to " + vertex1);
                    graph[vertex2].Remove(vertex1);
                    b = true;
                }
            }*/
            return b;
        }
        /// <summary>
        /// Get all unique names in the graph.
        /// </summary>
        /// <returns></returns>
        public List<String> getAllNames()
        {
            List<String> l = new List<String>();
            foreach (var pair in graph)
            {
                String s = pair.Key;
                if (!l.Contains(s))
                    l.Add(s);
                foreach (Node x in pair.Value)
                {
                    if(!l.Contains(x.name))
                        l.Add(x.name);
                }
            }
            return l;
        }
        /// <summary>
        /// Get all reference names for a single person
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public List<String> getNeighbors(String vertex)
        {
            List<Node> l = new List<Node>();
            List<String> neighbors = new List<String>();
            if (this.hasEdge(vertex))
            {
                l = graph[vertex];                
            }
            foreach (Node n in l)
            {
                neighbors.Add(n.name);
            }
            return neighbors;
        }
        /// <summary>
        /// get all references about one person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<String> getReferencesAbout(String person)
        {
            List<Node> l = new List<Node>();
            List<String> neighbors = new List<String>();
            if (graph.Keys.Contains(person))
            {
                l = graph[person];
            }
            foreach (Node n in l)
            {
                neighbors.Add(n.name + "," + n.getStringWeight());
            }
            return neighbors;
        }
        /// <summary>
        /// get all references written by a single person.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<String> getReferencesBy(String person)
        {
            List<Node> l = new List<Node>();
            List<String> people = new List<String>();
            foreach (var pair in graph)
            {
                foreach (Node n in graph[pair.Key])
                {
                    if (n.name.Equals(person))
                    {
                        people.Add(pair.Key + "," + n.name + "," + n.getStringWeight());
                    }
                }
            }
            return people;
        }
        /// <summary>
        /// Get the top x candidates by total score
        /// of their reference weights.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<String> getTopCandidates(int x)
        {
            Dictionary<String, int> scores = new Dictionary<String, int>();
            List<String> candidates = new List<string>();
            foreach (var pair in graph)
            {
                List<String> temp = new List<String>();
                int score = 0;
                foreach (Node n in graph[pair.Key])
                {
                    score += n.weight;
                }
                scores.Add(pair.Key, score);
            }
            for(int i = 0;i<x && i<graph.Count;i++){
                int max = scores.Values.Max();
                foreach (var pair in scores)
                {
                    if (pair.Value == max)
                    {
                        candidates.Add(pair.Key + "," + pair.Value);
                        scores.Remove(pair.Key);
                        break;
                    }
                }
            }            
            return candidates;
        }
        /// <summary>
        /// Get all references names and weights in 
        /// a list of strings.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public List<String> getNeighborsWeights(String vertex)
        {
            List<Node> l = new List<Node>();
            List<String> neighbors = new List<String>();
            if (this.hasEdge(vertex))
            {
                l = graph[vertex];
            }
            foreach (Node n in l)
            {
                neighbors.Add(n.name + " (" + n.weight + ")");
            }
            return neighbors;
        }


        /// <summary>
        /// return a list that represents all references
        /// that can be input to the data table of gui.
        /// </summary>
        /// <returns></returns>
        public List<String> getWebData()
        {
            List<String> newList = new List<string>();
            foreach (var pair in graph)
            {
                foreach (Node n in pair.Value)
                {
                    newList.Add(pair.Key + "," + n.name + "," + n.getStringWeight());
                }
            }
            return newList;
        }
        public void addPerson(String name)
        {
            if (!graph.Keys.Contains(name))
            {
                graph.Add(name, new List<Node>());
            }
        }
        /// <summary>
        /// change reference of a person to a person.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="newWeight"></param>
        /// <returns></returns>
        public Boolean changeRef(String from, String to, int newWeight)
        {
            bool b = false;
            if (graph.Keys.Contains(to))
            {
                foreach (Node n in graph[to])
                {
                    if (n.name.Equals(from))
                    {
                        n.weight = newWeight;
                        b = true;
                    }
                }
            }
            return b;
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
