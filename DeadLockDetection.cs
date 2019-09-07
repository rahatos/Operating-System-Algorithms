using System;
using System.Collections.Generic;

namespace DeadLockDetection
{
    class Graph
    {
        public int vertices;

        public Dictionary <string, List<string> > adj;
        public Stack<string> stack = new Stack<string>();

        Dictionary<string, Boolean> visited = new Dictionary<string, bool>();
        Dictionary<string, Boolean> recStack = new Dictionary<string, bool>();

        public Graph(int vertices){
            this.vertices = vertices;
            adj = new Dictionary<string, List<string>>(); 
        }
        public void createGraph(string u, string v){
            if(adj.ContainsKey(u)){
                adj[u].Add(v); 
            }
            else{
                adj[u] = new List<string>();
                adj[u].Add(v);
            }

            visited[u] = false;
            recStack[u] = false;
                   
        }
        public Boolean isCyclicUtil(string key, Dictionary<string, Boolean> visited, Dictionary<string, Boolean> recStack){
            stack.Push(key);
            if(recStack[key])
                return true;

            if(!visited[key])
            {
                visited[key] = true;
                recStack[key] = true;

                List<string> list = adj[key];
                foreach (var x in list)
                {
                   if(isCyclicUtil(x, visited, recStack)){
                        return true;
                   }
                        
                }
                recStack[key] = false;
            }

            stack.Clear();
            return false;
        }        
        public Boolean isCyclic(){
            

            foreach(var x in adj){
                if(isCyclicUtil(x.Key, visited, recStack))
                    return true;
            }
            return false;            
        }

        static void Main(string[] args)
        {
            Graph g = new Graph(3);

            g.createGraph("Rahat", "Tokey");
            g.createGraph("Tokey", "Talha");
            g.createGraph("Talha", "Rahat");

            if(g.isCyclic()){
                System.Console.WriteLine("Cyclic");
                foreach (var x in g.stack)
                {
                    System.Console.Write($"{x} ");
                }
            }
                
            else
                System.Console.WriteLine("Not Cyclic");
            
        }
    }
}
