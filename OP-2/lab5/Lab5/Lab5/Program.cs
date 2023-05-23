namespace Lab5
{
    public class Program
    {
        public static void Main(string[] args) {
            PointOnPlane point = new PointOnPlane(new Random().Next(-9, 9), new Random().Next(-9, 9));
            LineService lineService = new LineService();
            
            TLine[] lineOnPlanes = lineService.GenerateRandom2DLines(10);
            TLine[] perpendicularToFirst = lineOnPlanes.Where(l => l.CheckPerpendicularTo(lineOnPlanes.First())).ToArray(); // знаходяться прямі, які перпендикулярні до першої прямої
            TLine[] linesWithPoint = perpendicularToFirst.Where(l => l.CheckPointOnLine(point)).ToArray(); // знаходяться прямі, які проходять через точку
            TLine[] randomLineInSpaces = lineService.GenerateRandom3DLines(10);
            TLine[] lineInSpaces =
            {
                new LineInSpace((0, 1, 2), (7, 8, 9)), 
                new LineInSpace((3, 3, -6)), 
                new LineInSpace((4, 4, -8))
            };

            lineService.DisplayLines(lineOnPlanes, "Lines on Plane");
            lineService.DisplayLines(perpendicularToFirst, "Lines Perpendicular to First");
            lineService.DisplayLines(linesWithPoint, $"Lines Perpendicular to First with Point: {point}");
            lineService.DisplayLines(randomLineInSpaces, "Random Lines in Space");
            
            Console.WriteLine($"Random Line in Space Perpendicular to All:\n{lineService.FindPerpendicularToAll(randomLineInSpaces)}"); // шукає пряму, яка перпендикулярна до всіх прямих в масиві randomLineInSpaces
            
            lineService.DisplayLines(lineInSpaces, "Lines in Space");
            
            Console.WriteLine($"Line in Space Perpendicular to All:\n{lineService.FindPerpendicularToAll(lineInSpaces)}"); // шукає пряму, яка перпендикулярна до всіх прямих в масиві lineInSpaces
        }
    }
}