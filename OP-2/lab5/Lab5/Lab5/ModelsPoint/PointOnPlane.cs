namespace Lab5;

public class PointOnPlane : Point
{
    public int X { get; protected set; }
    public int Y { get; protected set; }

    public PointOnPlane(int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }

    public PointOnPlane((int x, int y) coordinates)
    {
        X = coordinates.x;
        Y = coordinates.y;
    }
    
    public override string ToString() => $"({X}, {Y})";
    
    public static bool operator ==(PointOnPlane point1, PointOnPlane point2) // для порівняння точок на площині
    {
        return point1.X == point2.X && point1.Y == point2.Y;
    }

    public static bool operator !=(PointOnPlane point1, PointOnPlane point2) // для порівняння точок на площині
    {
        return point1.X != point2.X || point1.Y != point2.Y;
    }

}