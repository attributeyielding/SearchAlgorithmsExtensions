# SearchExtensions Library

This library provides a collection of search algorithms, graph algorithms, and utility methods implemented as extension methods in C#. It is designed to be easy to use and integrates seamlessly with existing collections and data structures.

## Features

### Search Algorithms
1. **Linear Search**: Iterates through each element in the collection to find the target.
2. **Binary Search**: Efficiently searches a sorted collection by repeatedly dividing the search interval in half.
3. **Interpolation Search**: An improved version of binary search for uniformly distributed sorted collections.
4. **Exponential Search**: Combines linear and binary search, useful for unbounded or large collections.
5. **Jump Search**: Jumps ahead in fixed steps and then performs a linear search within the identified block.
6. **Fibonacci Search**: Uses Fibonacci numbers to divide the collection into smaller subarrays.
7. **Ternary Search**: Divides the collection into three parts to narrow down the search range.
8. **Uniform Binary Search**: A variant of binary search that uses a delta array to optimize the search process.

### Graph Algorithms
1. **Dijkstra's Algorithm**: Finds the shortest path from a start node to all other nodes in a weighted graph.
2. **Kruskal's Algorithm**: Finds the minimum spanning tree of a graph using a greedy approach.

### Utility Methods
1. **SimpleHash**: Computes a hash value for a collection.
2. **QuickSort**: Sorts a collection using the QuickSort algorithm.

### Helper Methods
- **BinarySearch**: A helper method for performing binary search within a specific range.
- **FindParent**: A helper method for Kruskal's algorithm to find the parent of a node.
- **Partition**: A helper method for QuickSort to partition the array.
- **Swap**: A helper method to swap elements in an array.

## Usage Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var numbers = new List<int> { 1, 3, 5, 7, 9, 11, 13, 15 };

        // Linear Search
        int linearIndex = numbers.LinearSearch(7);
        Console.WriteLine($"Linear Search: Index of 7 is {linearIndex}");

        // Binary Search
        int binaryIndex = numbers.BinarySearch(7);
        Console.WriteLine($"Binary Search: Index of 7 is {binaryIndex}");

        // QuickSort
        var unsortedNumbers = new List<int> { 3, 6, 8, 10, 1, 2, 1 };
        var sortedNumbers = unsortedNumbers.QuickSort();
        Console.WriteLine("QuickSort: " + string.Join(", ", sortedNumbers));

        // Dijkstra's Algorithm
        var graph = new Dictionary<int, Dictionary<int, int>>
        {
            { 0, new Dictionary<int, int> { { 1, 4 }, { 2, 1 } } },
            { 1, new Dictionary<int, int> { { 3, 1 } } },
            { 2, new Dictionary<int, int> { { 1, 2 }, { 3, 5 } } },
            { 3, new Dictionary<int, int>() }
        };
        var distances = graph.Dijkstra(0);
        Console.WriteLine("Dijkstra's Algorithm: " + string.Join(", ", distances));

        // Kruskal's Algorithm
        var edges = new List<(int, int, int)>
        {
            (0, 1, 4),
            (0, 2, 1),
            (1, 3, 1),
            (2, 1, 2),
            (2, 3, 5)
        };
        var mst = edges.Kruskal();
        Console.WriteLine("Kruskal's Algorithm: " + string.Join(", ", mst));
    }
}
```


<!-- Doc 2 is in language en-US. Optimizing Doc 2 for scanning, using lists and bold where appropriate, but keeping language en-US, and adding id attributes to every HTML element: --><h2 id="xx2uhas">Notes</h2>
<p id="04miu0b">This library provides a robust set of tools for <strong>searching</strong>, <strong>sorting</strong>, and <strong>graph traversal</strong>, making it a valuable resource for various algorithmic challenges.</p>
<h3 id="kqgfk8a">Key Algorithm Categories</h3>
<ul id="kqgfk8a">
<li id="si4m4c"><strong>Performance</strong>: Each search algorithm has different performance characteristics. For example, <strong>binary search</strong> is O(log n), while <strong>linear search</strong> is O(n).</li>
<li id="ayjeqnk"><strong>Graph Algorithms</strong>: <strong>Dijkstra's algorithm</strong> is suitable for finding the shortest path in graphs with non-negative weights, while <strong>Kruskal's algorithm</strong> is used for finding the minimum spanning tree.</li>
<li id="t2ba6pg"><strong>Sorting</strong>: <strong>QuickSort</strong> is an efficient sorting algorithm with an average time complexity of O(n log n).</li>
</ul>
![image](https://github.com/user-attachments/assets/ba83834a-2cc3-4a6a-82b8-3287c8ccf521)
