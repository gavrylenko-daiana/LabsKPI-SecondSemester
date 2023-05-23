using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab4
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleManager consoleManager = new ConsoleManager();
            
            Time[] timeArray =
            {
                new Time(12, 30, 0),
                new Time(8, 45),
                new Time(83)
            };

            consoleManager.PrintTimeArray(timeArray, "Initial times");
            
            timeArray[0] += 17;
            timeArray[1] += 34;
            timeArray[2] += 72;

            consoleManager.PrintTimeArray(timeArray, "Modified times");

            Console.WriteLine("Time difference between the first and second times");
            Console.WriteLine($"{timeArray[0] - timeArray[1]}\n");

            Console.WriteLine("Time from time 3 to the end of the day");
            Console.WriteLine(timeArray[2].GetTimeRemainingUntilEndOfTheDay());

            Time[] userTimes = consoleManager.OutputDataOfTimes(2);

            Console.WriteLine("\nUser inputted times");
            consoleManager.PrintTimeArray(userTimes, "User times");
        }
    }
}