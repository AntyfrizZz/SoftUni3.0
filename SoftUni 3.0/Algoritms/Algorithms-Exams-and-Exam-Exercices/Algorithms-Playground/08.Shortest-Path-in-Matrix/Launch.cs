using System;
using System.Collections.Generic;
using System.Linq;

public class Launch
{
    // Dijkstra's shortest paths algorithm, implemented
    // with adjacency matrix. Running time: O(N * N)
    // Learn more at: https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm

    static List<int> Dijkstra(int[,] graph, int sourceNode, int destinationNode)
    {
        int n = graph.GetLength(0);

        // Initialize the distance[]
        int[] distance = new int[n];
        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
        }
        distance[sourceNode] = 0;

        // Dijkstra's algorithm implemented without priority queue
        var used = new bool[n];
        int?[] previous = new int?[n];
        while (true)
        {
            // Find the nearest unused node from the source
            int minDistance = int.MaxValue;
            int minNode = 0;
            for (int node = 0; node < n; node++)
            {
                if (!used[node] && distance[node] < minDistance)
                {
                    minDistance = distance[node];
                    minNode = node;
                }
            }
            if (minDistance == int.MaxValue)
            {
                // No min distance node found --> algorithm finished
                break;
            }

            used[minNode] = true;

            // Improve the distance[0…n-1] through minNode
            for (int i = 0; i < n; i++)
            {
                if (graph[minNode, i] > 0)
                {
                    int newDistance = distance[minNode] + graph[minNode, i];
                    if (newDistance < distance[i])
                    {
                        distance[i] = newDistance;
                        previous[i] = minNode;
                    }
                }
            }
        }

        if (distance[destinationNode] == int.MaxValue)
        {
            // No path found from sourceNode to destinationNode
            return null;
        }

        // Reconstruct the shortest path from sourceNode to destinationNode
        var path = new List<int>();
        int? currentNode = destinationNode;
        while (currentNode != null)
        {
            path.Add(currentNode.Value);
            currentNode = previous[currentNode.Value];
        }
        path.Reverse();
        return path;
    }

    public static void Main()
    {
        int numberOfRows = int.Parse(Console.ReadLine());
        int numberOfCols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[numberOfRows, numberOfCols];
        int[] inlineMatrixValues = new int[numberOfRows * numberOfCols];

        FillMatrix(matrix, inlineMatrixValues);

        var graph = new int[numberOfRows * numberOfCols, numberOfRows * numberOfCols];


        FillGraph(graph, matrix, inlineMatrixValues);

        FindAndPrintShortestPath(graph, 0, graph.GetLength(0) - 1, inlineMatrixValues);

    }

    private static void FillGraph(int[,] graph, int[,] matrix, int[] inlineMatrixValues)
    {
        int startRow = 0;
        int startCol = matrix.GetLength(1);
        int counter = 0;

        //Fill upper diagonal and upperMiddle diagonal
        while (startCol < graph.GetLength(1))
        {
            graph[startRow, startCol] = inlineMatrixValues[startCol];

            if (counter == 0)
            {
                counter++;
            }
            else
            {
                graph[startRow + matrix.GetLength(1) - 1, startCol] = inlineMatrixValues[startCol];
                counter++;
            }

            if (counter == matrix.GetLength(1))
            {
                counter = 0;
            }

            startCol++;
            startRow++;
        }

        startRow = matrix.GetLength(1);
        startCol = 0;
        counter = 0;

        //Fill lower diagonal and lowerMiddle diagonal
        while (startRow < graph.GetLength(0))
        {
            graph[startRow, startCol] = inlineMatrixValues[startCol];


            if (counter == matrix.GetLength(1) - 1)
            {
                counter = 0;
            }
            else
            {
                graph[startRow - matrix.GetLength(1) + 1, startCol] = inlineMatrixValues[startCol];
                counter++;
            }

            startCol++;
            startRow++;
        }

        startRow = 0;
        startCol = 1;

        //Fill final parts of the middle diagonals
        while (startCol < matrix.GetLength(1))
        {
            graph[startRow, startCol] = inlineMatrixValues[startCol];
            startCol++;
            startRow++;
        }

        startRow = graph.GetLength(0) - matrix.GetLength(1) + 1;
        startCol = graph.GetLength(0) - matrix.GetLength(1);

        while (startRow < graph.GetLength(0))
        {
            graph[startRow, startCol] = inlineMatrixValues[startCol];

            startCol++;
            startRow++;
        }
    }

    static void FindAndPrintShortestPath(
        int[,] graph, int sourceNode, int destinationNode, int[] inlineMatrixValues)
    {

        var path = Dijkstra(graph, sourceNode, destinationNode);
        if (path == null)
        {
            Console.WriteLine("no path");
        }
        else
        {
            int pathLength = 0;
            for (int i = 0; i < path.Count; i++)
            {
                pathLength += inlineMatrixValues[path[i]];
                path[i] = inlineMatrixValues[path[i]];
            }
            var formattedPath = string.Join(" ", path);
            Console.WriteLine("Length: {0}", pathLength);
            Console.WriteLine("Path: {0}", formattedPath);
        }
    }

    private static void FillMatrix(int[,] matrix, int[] inlineMatrixValues)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var tempRow = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < tempRow.Length; col++)
            {
                matrix[row, col] = tempRow[col];
                inlineMatrixValues[col + row * tempRow.Length] = tempRow[col];
            }
        }
    }

    private static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
