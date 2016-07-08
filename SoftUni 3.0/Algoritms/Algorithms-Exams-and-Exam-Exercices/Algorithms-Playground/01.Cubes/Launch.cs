using System;
using System.Collections.Generic;

class Launch
{
    static HashSet<Cube> isomorphicCubes;
    static int[] currentEdges;
    static int[] colorsLeftCount;
    static int cubesCount;

    static void GenerateCubes(int edgeIndex)
    {
        if (edgeIndex == Cube.EDGE_COUNT)
        {
            Cube cube = new Cube(currentEdges);
            if (isomorphicCubes.Contains(cube))
            {
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                cube.RotateXY();
                for (int j = 0; j < 4; j++)
                {
                    cube.RotateXZ();
                    for (int k = 0; k < 4; k++)
                    {
                        cube.RotateYZ();
                        isomorphicCubes.Add(new Cube(cube));
                    }
                }
            }

            cubesCount++;
            //Console.WriteLine(cube);
            return;
        }

        for (int color = 1; color <= Cube.MAX_COLOR; color++)
        {
            if (colorsLeftCount[color] > 0)
            {
                colorsLeftCount[color]--;
                currentEdges[edgeIndex] = color;
                GenerateCubes(edgeIndex + 1);
                colorsLeftCount[color]++;
            }
        }
    }

    static int NumberOfCubes(int[] sticks)
    {
        colorsLeftCount = new int[Cube.MAX_COLOR + 1];
        for (int i = 0; i < Cube.EDGE_COUNT; i++)
        {
            colorsLeftCount[sticks[i]]++;
        }

        currentEdges = new int[Cube.EDGE_COUNT];
        isomorphicCubes = new HashSet<Cube>();
        cubesCount = 0;
        GenerateCubes(0);

        return cubesCount;
    }

    static int[] ReadInput()
    {
        int[] sticks = new int[Cube.EDGE_COUNT];
        string[] sticksString = Console.ReadLine().Split(' ');
        for (int i = 0; i < Cube.EDGE_COUNT; i++)
        {
            sticks[i] = int.Parse(sticksString[i]);
        }

        return sticks;
    }

    static void Main(string[] args)
    {
        int[] sticks = ReadInput();
        Console.WriteLine(NumberOfCubes(sticks));
    }

    private class Cube
    {
        public const int EDGE_COUNT = 12;
        public const int MAX_COLOR = 6;
        public int[] edges;

        public Cube()
        {
            edges = new int[EDGE_COUNT];
        }

        public Cube(int[] newEdges)
            : this()
        {
            Array.Copy(newEdges, edges, EDGE_COUNT);
        }

        public Cube(Cube cube)
            : this()
        {
            Array.Copy(cube.edges, edges, EDGE_COUNT);
        }

        public override string ToString()
        {
            string s = "{";
            foreach (int edge in edges)
            {
                s += edge;
            }
            s += "}";

            return s;
        }

        public void RotateXY()
        {
            int[] newEdges =
                {
                    edges[1], edges[2], edges[3], edges[0],
                    edges[5], edges[6], edges[7], edges[4],
                    edges[9], edges[10], edges[11], edges[8]
                };

            edges = newEdges;
        }

        public void RotateXZ()
        {
            int[] newEdges =
                {
                    edges[4], edges[9], edges[5], edges[1],
                    edges[8], edges[10], edges[2], edges[0],
                    edges[7], edges[11], edges[6], edges[3]
                };

            edges = newEdges;
        }

        public void RotateYZ()
        {
            int[] newEdges =
                {
                    edges[2], edges[5], edges[10], edges[6],
                    edges[1], edges[9], edges[11], edges[3],
                    edges[0], edges[4], edges[8], edges[7]
                };

            edges = newEdges;
        }

        public override bool Equals(object obj)
        {
            Cube cube = obj as Cube;
            if (cube != null)
            {
                for (int i = 0; i < EDGE_COUNT; i++)
                {
                    if (edges[i] != cube.edges[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (int edge in edges)
            {
                hashCode = hashCode * 7 + edge;
            }

            return hashCode;
        }
    }
}
