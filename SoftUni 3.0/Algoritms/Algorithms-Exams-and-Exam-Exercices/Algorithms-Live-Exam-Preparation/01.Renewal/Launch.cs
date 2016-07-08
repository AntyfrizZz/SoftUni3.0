using System;
using System.Collections.Generic;

class Launch
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        List<string> connected = new List<string>();
        List<string> buildingCosts = new List<string>();
        List<string> destroingCosts = new List<string>();

        for (int i = 0; i < N; i++)
        {
            connected.Add(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            buildingCosts.Add(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            destroingCosts.Add(Console.ReadLine());
        }

        Console.WriteLine(GetCost(connected, buildingCosts, destroingCosts));
    }

    static int GetCost(List<string> path, List<string> build, List<string> destroy)
    {
        int N = path.Count;
        int massiveCost = 0;
        int mstCost = 0;

        // get the cost of each edge + destroy all the existing edges
        List<Edge> edges = new List<Edge>();

        for (int i = 0; i < N; ++i)
            for (int j = i + 1; j < N; ++j)
            {
                if (path[i][j] == '0')
                    edges.Add(new Edge(i, j, GetCost(build[i][j])));
                else
                {
                    int val = GetCost(destroy[i][j]);
                    edges.Add(new Edge(i, j, -val));
                    massiveCost += val;
                }
            }
        // solve the MST on the graph, using Kruskal's algorithm
        edges.Sort();

        int[] color = new int[N];
        for (int i = 0; i < N; ++i)
        {
            color[i] = i;
        }            

        for (int i = 0; i < edges.Count; ++i)
        {
            Edge e = edges[i];
            // vertices of the edge are not in the same component
            if (color[e.start] != color[e.end])
            {
                mstCost += e.cost;
                // recolor the component
                int oldColor = color[e.end];
                for (int j = 0; j < N; ++j)
                {
                    if (color[j] == oldColor)
                    {
                        color[j] = color[e.start];
                    }                        
                }                    
            }
        }
        return massiveCost + mstCost;
    }

    class Edge : IComparable<Edge>
    {
        public int start;
        public int end;
        public int cost;

        public Edge(int a, int b, int cost)
        {
            this.start = a;
            this.end = b;
            this.cost = cost;
        }

        public int CompareTo(Edge e)
        {
            return cost - e.cost;
        }
    }

    static int GetCost(char c)
    {
        if (c >= 'A' && c <= 'Z')
        {
            return c - 'A';
        }
            
        return c - 'a' + 26;
    }       
}