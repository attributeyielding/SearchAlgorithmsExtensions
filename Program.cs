


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

// Create a large collection for testing
using System.Diagnostics;

int size = 1_000_0; // 10 thousand elements
var collection = Enumerable.Range(1, size).ToList(); // Sorted list of integers from 1 to 1,000,000
int target = size / 2; // Target element to search for (middle of the collection)

// Measure search time for each method
MeasureSearchTime("Linear Search", () => collection.LinearSearch(target));
MeasureSearchTime("Binary Search", () => collection.BinarySearch(target));
MeasureSearchTime("Interpolation Search", () => collection.InterpolationSearch(target));
MeasureSearchTime("Exponential Search", () => collection.ExponentialSearch(target));
MeasureSearchTime("Jump Search", () => collection.JumpSearch(target));
MeasureSearchTime("Fibonacci Search", () => collection.FibonacciSearch(target));
MeasureSearchTime("Ternary Search", () => collection.TernarySearch(target));
MeasureSearchTime("Uniform Binary Search", () => collection.UniformBinarySearch(target));
    

    /// <summary>
    /// Measures the execution time of a search method.
    /// </summary>
    /// <param name="methodName">The name of the search method.</param>
    /// <param name="searchAction">The action representing the search method.</param>
     static void MeasureSearchTime(string methodName, Func<int> searchAction)
{
    Console.WriteLine("Started the "+$"{methodName}:");

    var stopwatch = Stopwatch.StartNew(); // Start the stopwatch
    int result = searchAction(); // Execute the search method
    stopwatch.Stop(); // Stop the stopwatch

    Console.WriteLine($"{methodName}:");
    Console.WriteLine($"  Result: {(result != -1 ? "Found at index " + result : "Not found")}");
    Console.WriteLine($"  Time: {stopwatch.Elapsed.TotalMilliseconds} ms");
    Console.WriteLine();
}