using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab3
{
    public class Circle
    {
        private int CenterX { get; set; }
        private int CenterY { get; set; }
        
        private int _radius;
        
        public int Radius
        {
            get => _radius;
            set => _radius = value > 0 ? value : _radius;
        } 
        
        private double Circuit => 2 * Math.PI * _radius; // Довжина кола
        private double Square => Math.PI * Math.Pow(_radius, 2); // Площа круга
        
        public Circle(int centerX = 0, int centerY = 0, int radius = 1)
        {
            CenterX = centerX;
            CenterY = centerY;
            Radius = radius;
        }

        public void PrintCircle() // Друк властивостей круга
        {
            const int printCellSize = 15;
            
            string[] circleProperties = 
            {
                $"({CenterX}, {CenterY})", $"{_radius}", $"{Math.Round(Circuit, 3)}", $"{Math.Round(Square, 3)}"
            };

            string[] headers = {"Center", "Radius", "Circuit", "Square"};

            foreach (string header in headers) // Друк заголовків
            {
                Console.Write(header + new string(' ', printCellSize - header.Length));
            }
            Console.WriteLine();
            
            foreach (string property in circleProperties) // Друк властивостей круга
            {
                Console.Write(property + new string(' ', printCellSize - property.Length));
            }
            Console.WriteLine();
        }
    }
}