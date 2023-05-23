using System;

namespace Lab4
{
    public class ConsoleManager
    {
        public void PrintTimeArray(Time[] timeArray, string prePrint = "") //Вивести масив часу
        {
            Console.WriteLine(prePrint);
            foreach (Time time in timeArray)
            {
                Console.WriteLine(time);
            }
            Console.WriteLine();
        }

        public Time[] OutputDataOfTimes(int size) //масив часу з даними з консолі
        {
            var timeArray = new Time[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter time(hh:mm:ss): ");
                string input = Console.ReadLine()!;
                timeArray[i] = Time.Parse(input)!;
            }

            return timeArray;
        }
    }
}