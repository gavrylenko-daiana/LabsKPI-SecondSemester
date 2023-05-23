using System;
using System.Collections.Generic;
using Lab6;

public class Program
{
    static void Main(string[] args)
    {
        ConsoleManager consoleManager = new ConsoleManager();
        CircularQueue<int> circularQueue = new CircularQueue<int>(5);

        Console.WriteLine($"Queue is empty? {circularQueue.IsEmpty}");

        consoleManager.AddElementToQueue(circularQueue, 4);
        Console.WriteLine("Queue elements after adding a new element:");
        circularQueue.DisplayInternal();

        circularQueue.Dequeue();
        Console.WriteLine("Queue elements after removing element:");
        circularQueue.DisplayInternal();

        consoleManager.AddElementToQueue(circularQueue, 2);
        Console.WriteLine("Queue elements after adding a new element:");
        circularQueue.DisplayInternal();
        
        Console.WriteLine("Queue elements using iterator:");
        foreach (int item in circularQueue)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine();
        
        Console.WriteLine($"Queue is empty? {circularQueue.IsEmpty}");

        Console.WriteLine($"\nClear the queue.");
        circularQueue.Clear();
        Console.WriteLine($"Queue is empty? {circularQueue.IsEmpty}");
    }
}