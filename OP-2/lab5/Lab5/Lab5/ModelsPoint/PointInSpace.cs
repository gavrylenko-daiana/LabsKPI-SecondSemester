namespace Lab5;

public class PointInSpace : PointOnPlane
{
    public int Z { get; protected set; }

    public PointInSpace(int x = 0, int y = 0, int z = 0) : base(x, y)
    {
        Z = z;
    }

    public PointInSpace((int x, int y, int z) coordinates)
    {
        X = coordinates.x;
        Y = coordinates.y;
        Z = coordinates.z;
    }

    public override string ToString() => $"({X}, {Y}, {Z})";

    public static bool operator ==(PointInSpace point1, PointInSpace point2) // для порівняння точок в просторі
    {
        return point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z;
    }

    public static bool operator !=(PointInSpace point1, PointInSpace point2) // для порівняння точок в просторі
    {
        return point1.X != point2.X || point1.Y != point2.Y || point1.Z != point2.Z;
    }
}