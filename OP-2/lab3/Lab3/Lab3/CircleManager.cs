using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab3
{
    public class CircleManager
    {
        public void WorkWithConsole()
        {
            int count = ReadIntFromConsole("Enter the number of circles: "); // Зчитування кількості кіл з консолі
            var arrayOfCircles = ArrayOfCircles(count, random: true); // Створення масиву кіл
            Circle? maxCircle = GetMaxCircle(arrayOfCircles); // Отримання круга з максимальним радіусом
            PrintCircles(arrayOfCircles, "Circles:");
            
            Console.WriteLine("Сircle with the largest area:");
            
            if (maxCircle != null) // Друк круга з максимальним радіусом
            {
                maxCircle.PrintCircle();
            }
            else
            {
                Console.WriteLine("No circles found.");
            }
        }

        private Circle[] ArrayOfCircles(int size, bool random = true) // Створення масиву кіл
        {
            return random ? RandomArrayOfCircles(size) : ConsoleArrayOfCircles(size);
        }

        private Circle[] RandomArrayOfCircles(int size) // Створення масиву кіл з випадковими значеннями
        {
            Random random = new Random();
            var circles = new Circle[size];
            
            for (int i = 0; i < size; i++) // Заповнення масиву кіл випадковими значеннями
            {
                int centerX = random.Next(-100, 101);
                int centerY = random.Next(-200, 201);
                int radius = random.Next(1, 101);
                circles[i] = new Circle(centerX, centerY, radius);
            }

            return circles;
        }

        private Circle[] ConsoleArrayOfCircles(int size) // Створення масиву кіл зі значеннями, введеними з консолі
        {
            var circles = new Circle[size];
            
            for (int i = 0; i < size; i++) 
            {
                int centerX = ReadIntFromConsole("Enter center X coordinate: ");
                int centerY = ReadIntFromConsole("Enter center Y coordinate: ");
                int radius = ReadIntFromConsole("Enter a radius: ");
                circles[i] = new Circle(centerX, centerY, radius);
                Console.WriteLine();
            }

            return circles;
        }

        private int ReadIntFromConsole(string prompt) // Зчитування цілого числа з консолі
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }

        private void PrintCircles(Circle[] circles, string print = "") // друк масиву кіл
        {
            Console.WriteLine(print);

            foreach (Circle circle in circles)
            {
                circle.PrintCircle();
            }

            Console.WriteLine();
        }

        private Circle GetMaxCircle(Circle[] circles) // отримання круга з максимальним радіусом
        {
            return circles.MaxBy(c => c.Radius) ?? throw new Exception();
        }
    }
}