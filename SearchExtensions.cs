

/// <summary>
/// This library provides a robust set of tools for searching, sorting, and graph traversal, making it a valuable resource for various algorithmic challenges.
/// </summary>
/// <remarks>
/// Author: Bilel Mnasser
/// Contact: personalhiddenmail@duck.com
/// GitHub: https://github.com/attributeyielding
/// website: https://personal-website-resume.netlify.app/#contact
/// Date: January 2025
/// Version: 1.0
/// </remarks>


using System;
using System.Collections.Generic;
using System.Linq;

public static class SearchExtensions
{
    /// <summary>
    /// Performs a linear search on a collection to find the target element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The collection to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    public static int LinearSearch<T>(this IEnumerable<T> collection, T target) where T : IComparable<T>
    {
        int index = 0; // Initialize the index counter
        foreach (var item in collection) // Iterate through each element in the collection
        {
            if (item.CompareTo(target) == 0) // Compare the current element with the target
                return index; // Return the index if the target is found
            index++; // Increment the index counter
        }
        return -1; // Return -1 if the target is not found
    }

    /// <summary>
    /// Performs a binary search on a sorted collection to find the target element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The sorted collection to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    public static int BinarySearch<T>(this IEnumerable<T> collection, T target) where T : IComparable<T>
    {
        var array = collection.ToArray(); // Convert the collection to an array for indexed access
        int left = 0, right = array.Length - 1; // Initialize the search range

        while (left <= right) // Continue searching while the range is valid
        {
            int mid = left + (right - left) / 2; // Calculate the middle index
            int comparison = array[mid].CompareTo(target); // Compare the middle element with the target

            if (comparison == 0) // If the target is found
                return mid; // Return the index of the target
            else if (comparison < 0) // If the target is in the right half
                left = mid + 1; // Adjust the search range to the right half
            else // If the target is in the left half
                right = mid - 1; // Adjust the search range to the left half
        }
        return -1; // Return -1 if the target is not found
    }

    /// <summary>
    /// Performs an interpolation search on a sorted collection to find the target element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The sorted collection to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    public static int InterpolationSearch<T>(this IEnumerable<T> collection, T target) where T : IComparable<T>
    {
        var array = collection.ToArray(); // Convert the collection to an array for indexed access
        int low = 0, high = array.Length - 1; // Initialize the search range

        while (low <= high && target.CompareTo(array[low]) >= 0 && target.CompareTo(array[high]) <= 0) // Ensure the target is within the range
        {
            int pos = low + ((dynamic)target - (dynamic)array[low]) * (high - low) / ((dynamic)array[high] - (dynamic)array[low]); // Calculate the position using interpolation formula
            if (array[pos].CompareTo(target) == 0) // If the target is found
                return pos; // Return the index of the target
            else if (array[pos].CompareTo(target) < 0) // If the target is in the right half
                low = pos + 1; // Adjust the search range to the right half
            else // If the target is in the left half
                high = pos - 1; // Adjust the search range to the left half
        }
        return -1; // Return -1 if the target is not found
    }

    /// <summary>
    /// Performs an exponential search on a sorted collection to find the target element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The sorted collection to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    public static int ExponentialSearch<T>(this IEnumerable<T> collection, T target) where T : IComparable<T>
    {
        var array = collection.ToArray(); // Convert the collection to an array for indexed access
        if (array[0].CompareTo(target) == 0) // If the first element is the target
            return 0; // Return the index of the first element

        int i = 1; // Initialize the exponential step
        while (i < array.Length && array[i].CompareTo(target) <= 0) // Double the step until the target is within the range
            i *= 2;

        // Perform binary search within the identified range
        return BinarySearch(array, target, i / 2, Math.Min(i, array.Length - 1));
    }

    /// <summary>
    /// Helper method for binary search within a specific range.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array, must implement IComparable<T>.</typeparam>
    /// <param name="array">The array to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <param name="left">The left boundary of the search range.</param>
    /// <param name="right">The right boundary of the search range.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    private static int BinarySearch<T>(T[] array, T target, int left, int right) where T : IComparable<T>
    {
        while (left <= right) // Continue searching while the range is valid
        {
            int mid = left + (right - left) / 2; // Calculate the middle index
            int comparison = array[mid].CompareTo(target); // Compare the middle element with the target

            if (comparison == 0) // If the target is found
                return mid; // Return the index of the target
            else if (comparison < 0) // If the target is in the right half
                left = mid + 1; // Adjust the search range to the right half
            else // If the target is in the left half
                right = mid - 1; // Adjust the search range to the left half
        }
        return -1; // Return -1 if the target is not found
    }

    /// <summary>
    /// Performs a jump search on a sorted collection to find the target element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The sorted collection to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    public static int JumpSearch<T>(this IEnumerable<T> collection, T target) where T : IComparable<T>
    {
        var array = collection.ToArray(); // Convert the collection to an array for indexed access
        int step = (int)Math.Sqrt(array.Length); // Calculate the jump step size
        int prev = 0; // Initialize the previous step boundary

        while (array[Math.Min(step, array.Length) - 1].CompareTo(target) < 0) // Jump ahead until the target is within the range
        {
            prev = step; // Update the previous step boundary
            step += (int)Math.Sqrt(array.Length); // Increase the step size
            if (prev >= array.Length) // If the step exceeds the array length
                return -1; // Return -1 if the target is not found
        }

        while (array[prev].CompareTo(target) < 0) // Perform linear search within the identified range
        {
            prev++; // Move to the next element
            if (prev == Math.Min(step, array.Length)) // If the end of the range is reached
                return -1; // Return -1 if the target is not found
        }

        return array[prev].CompareTo(target) == 0 ? prev : -1; // Return the index if the target is found
    }

    /// <summary>
    /// Performs a Fibonacci search on a sorted collection to find the target element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The sorted collection to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    public static int FibonacciSearch<T>(this IEnumerable<T> collection, T target) where T : IComparable<T>
    {
        var array = collection.ToArray(); // Convert the collection to an array for indexed access
        int fibMMinus2 = 0, fibMMinus1 = 1, fibM = fibMMinus1 + fibMMinus2; // Initialize Fibonacci numbers

        while (fibM < array.Length) // Generate Fibonacci numbers until fibM is greater than or equal to the array length
        {
            fibMMinus2 = fibMMinus1;
            fibMMinus1 = fibM;
            fibM = fibMMinus1 + fibMMinus2;
        }

        int offset = -1; // Initialize the offset
        while (fibM > 1) // Perform the search
        {
            int i = Math.Min(offset + fibMMinus2, array.Length - 1); // Calculate the index to check

            if (array[i].CompareTo(target) < 0) // If the target is in the right half
            {
                fibM = fibMMinus1;
                fibMMinus1 = fibMMinus2;
                fibMMinus2 = fibM - fibMMinus1;
                offset = i;
            }
            else if (array[i].CompareTo(target) > 0) // If the target is in the left half
            {
                fibM = fibMMinus2;
                fibMMinus1 = fibMMinus1 - fibMMinus2;
                fibMMinus2 = fibM - fibMMinus1;
            }
            else // If the target is found
                return i;
        }

        if (fibMMinus1 == 1 && array[offset + 1].CompareTo(target) == 0) // Check the last element
            return offset + 1;

        return -1; // Return -1 if the target is not found
    }

    /// <summary>
    /// Performs a ternary search on a sorted collection to find the target element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The sorted collection to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    public static int TernarySearch<T>(this IEnumerable<T> collection, T target) where T : IComparable<T>
    {
        var array = collection.ToArray(); // Convert the collection to an array for indexed access
        int left = 0, right = array.Length - 1; // Initialize the search range

        while (left <= right) // Continue searching while the range is valid
        {
            int mid1 = left + (right - left) / 3; // Calculate the first middle index
            int mid2 = right - (right - left) / 3; // Calculate the second middle index

            if (array[mid1].CompareTo(target) == 0) // If the target is found at mid1
                return mid1;
            if (array[mid2].CompareTo(target) == 0) // If the target is found at mid2
                return mid2;

            if (array[mid1].CompareTo(target) > 0) // If the target is in the left third
                right = mid1 - 1;
            else if (array[mid2].CompareTo(target) < 0) // If the target is in the right third
                left = mid2 + 1;
            else // If the target is in the middle third
            {
                left = mid1 + 1;
                right = mid2 - 1;
            }
        }
        return -1; // Return -1 if the target is not found
    }

    /// <summary>
    /// Performs a uniform binary search on a sorted collection to find the target element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The sorted collection to search.</param>
    /// <param name="target">The target element to find.</param>
    /// <returns>The index of the target element if found; otherwise, -1.</returns>
    public static int UniformBinarySearch<T>(this IEnumerable<T> collection, T target) where T : IComparable<T>
    {
        var array = collection.ToArray(); // Convert the collection to an array for indexed access
        int[] delta = new int[array.Length]; // Initialize the delta array
        for (int i = 0; i < array.Length; i++) // Calculate the initial delta values
            delta[i] = (array.Length + 1) / 2;

        int iDelta = 0, mid = delta[0] - 1; // Initialize the delta index and middle index
        while (true) // Perform the search
        {
            if (target.CompareTo(array[mid]) == 0) // If the target is found
                return mid;
            else if (delta[iDelta] == 0) // If the delta is zero
                return -1;
            else
            {
                if (target.CompareTo(array[mid]) < 0) // If the target is in the left half
                    mid -= delta[++iDelta];
                else // If the target is in the right half
                    mid += delta[++iDelta];
                delta[iDelta] = delta[iDelta - 1] / 2; // Update the delta value
            }
        }
    }

    /// <summary>
    /// Performs Dijkstra's algorithm to find the shortest path from a start node in a graph.
    /// </summary>
    /// <typeparam name="T">The type of nodes in the graph, must implement IComparable<T>.</typeparam>
    /// <param name="graph">The graph represented as an adjacency list.</param>
    /// <param name="start">The starting node for the algorithm.</param>
    /// <returns>A dictionary containing the shortest distance from the start node to each node.</returns>
    public static Dictionary<T, int> Dijkstra<T>(this Dictionary<T, Dictionary<T, int>> graph, T start) where T : IComparable<T>
    {
        var distances = new Dictionary<T, int>(); // Initialize the distances dictionary
        var priorityQueue = new SortedSet<(int distance, T node)>(); // Initialize the priority queue

        foreach (var node in graph.Keys) // Set initial distances to infinity
            distances[node] = int.MaxValue;
        distances[start] = 0; // Set the distance of the start node to 0
        priorityQueue.Add((0, start)); // Add the start node to the priority queue

        while (priorityQueue.Count > 0) // Continue until the priority queue is empty
        {
            var (currentDistance, currentNode) = priorityQueue.Min; // Get the node with the smallest distance
            priorityQueue.Remove(priorityQueue.Min); // Remove the node from the priority queue

            foreach (var (neighbor, weight) in graph[currentNode]) // Iterate through the neighbors of the current node
            {
                int newDistance = currentDistance + weight; // Calculate the new distance
                if (newDistance < distances[neighbor]) // If the new distance is smaller
                {
                    priorityQueue.Remove((distances[neighbor], neighbor)); // Remove the old distance from the priority queue
                    distances[neighbor] = newDistance; // Update the distance
                    priorityQueue.Add((newDistance, neighbor)); // Add the new distance to the priority queue
                }
            }
        }

        return distances; // Return the distances dictionary
    }

    /// <summary>
    /// Performs Kruskal's algorithm to find the minimum spanning tree of a graph.
    /// </summary>
    /// <typeparam name="T">The type of nodes in the graph, must implement IComparable<T>.</typeparam>
    /// <param name="edges">The list of edges in the graph.</param>
    /// <returns>A list of edges representing the minimum spanning tree.</returns>
    public static List<(T, T, int)> Kruskal<T>(this List<(T, T, int)> edges) where T : IComparable<T>
    {
        var sortedEdges = edges.OrderBy(e => e.Item3).ToList(); // Sort the edges by weight
        var parent = new Dictionary<T, T>(); // Initialize the parent dictionary
        var result = new List<(T, T, int)>(); // Initialize the result list

        foreach (var edge in sortedEdges) // Iterate through the sorted edges
        {
            if (!parent.ContainsKey(edge.Item1)) // If the first node is not in the parent dictionary
                parent[edge.Item1] = edge.Item1; // Add it to the parent dictionary
            if (!parent.ContainsKey(edge.Item2)) // If the second node is not in the parent dictionary
                parent[edge.Item2] = edge.Item2; // Add it to the parent dictionary

            T root1 = FindParent(edge.Item1, parent); // Find the root of the first node
            T root2 = FindParent(edge.Item2, parent); // Find the root of the second node

            if (!root1.Equals(root2)) // If the roots are different
            {
                result.Add(edge); // Add the edge to the result list
                parent[root2] = root1; // Union the two sets
            }
        }

        return result; // Return the result list
    }

    private static T FindParent<T>(T node, Dictionary<T, T> parent) where T : IComparable<T>
    {
        if (parent[node].Equals(node)) // If the node is its own parent
            return node; // Return the node
        return FindParent(parent[node], parent); // Recursively find the parent
    }

    /// <summary>
    /// Computes a simple hash value for a collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection to compute the hash for.</param>
    /// <returns>The computed hash value.</returns>
    public static int SimpleHash<T>(this IEnumerable<T> collection)
    {
        int hash = 0; // Initialize the hash value
        foreach (var item in collection) // Iterate through each element in the collection
            hash = (hash * 31) + item.GetHashCode(); // Update the hash value
        return hash; // Return the computed hash value
    }

    /// <summary>
    /// Performs QuickSort on a collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement IComparable<T>.</typeparam>
    /// <param name="collection">The collection to sort.</param>
    /// <returns>The sorted collection.</returns>
    public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> collection) where T : IComparable<T>
    {
        var array = collection.ToArray(); // Convert the collection to an array
        QuickSort(array, 0, array.Length - 1); // Perform QuickSort on the array
        return array; // Return the sorted array
    }

    private static void QuickSort<T>(T[] array, int low, int high) where T : IComparable<T>
    {
        if (low < high) // If the range is valid
        {
            int pi = Partition(array, low, high); // Partition the array
            QuickSort(array, low, pi - 1); // Recursively sort the left part
            QuickSort(array, pi + 1, high); // Recursively sort the right part
        }
    }

    private static int Partition<T>(T[] array, int low, int high) where T : IComparable<T>
    {
        T pivot = array[high]; // Choose the pivot element
        int i = low - 1; // Initialize the index of the smaller element

        for (int j = low; j < high; j++) // Iterate through the array
        {
            if (array[j].CompareTo(pivot) < 0) // If the current element is smaller than the pivot
            {
                i++; // Increment the index of the smaller element
                Swap(array, i, j); // Swap the elements
            }
        }
        Swap(array, i + 1, high); // Swap the pivot element with the element at i + 1
        return i + 1; // Return the partition index
    }

    private static void Swap<T>(T[] array, int i, int j)
    {
        T temp = array[i]; // Temporary variable for swapping
        array[i] = array[j]; // Swap the elements
        array[j] = temp;
    }
}