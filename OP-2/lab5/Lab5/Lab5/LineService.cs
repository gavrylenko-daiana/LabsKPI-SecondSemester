namespace Lab5;

public class LineService
{
    public TLine? FindPerpendicularToAll(TLine[] lines) // перевіряє, чи є серед усіх прямих така пряма, яка є перпендикулярною до всіх інших прямих
    {
        for (int index = 0; index < lines.Length; index++)
        {
            TLine perpendicularLine = lines[index];
            bool isPerpendicular =
                lines.Where((line, j) => index != j).All(line => lines[index].CheckPerpendicularTo(line));
            if (isPerpendicular) return perpendicularLine;
        }

        return null;
    }

    public void DisplayLines(TLine[] lines, string prefix = "") // виводить прямі на консоль
    {
        Console.WriteLine(prefix);
        Array.ForEach(lines, Console.WriteLine);
        Console.WriteLine();
    }

    public LineOnPlane GetRandomLine2D(int minRange, int maxRange) // генерує випадкові прямі на площині
    {
        Random random = new Random();
        var pointA = (random.Next(minRange, maxRange), random.Next(minRange, maxRange));
        var pointB = (random.Next(minRange, maxRange), random.Next(minRange, maxRange));
        return new LineOnPlane(pointA, pointB);
    }

    public LineInSpace GetRandomLine3D(int minRange, int maxRange) // генерує випадкові прямі в просторі
    {
        Random random = new Random();
        var pointA = (random.Next(minRange, maxRange), random.Next(minRange, maxRange), random.Next(minRange, maxRange));
        var pointB = (random.Next(minRange, maxRange), random.Next(minRange, maxRange), random.Next(minRange, maxRange));
        return new LineInSpace(pointA, pointB);
    }

    public LineOnPlane[] GenerateRandom2DLines(int count) // генерує масив
    {
        var lines = new LineOnPlane[count];
        for (int i = 0; i < count; i++)
        {
            lines[i] = GetRandomLine2D(-9, 9);
        }

        return lines;
    }

    public LineInSpace[] GenerateRandom3DLines(int count) // генерує масив
    {
        var lines = new LineInSpace[count];
        for (int i = 0; i < count; i++)
        {
            lines[i] = GetRandomLine3D(-9, 9);
        }

        return lines;
    }
}