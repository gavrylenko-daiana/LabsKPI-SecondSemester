namespace Lab5;

public class LineInSpace : TLine
{
    public PointInSpace A { get; private set; }
    public PointInSpace B { get; private set; }
    public PointInSpace VectorCoord => new PointInSpace(B.X - A.X, B.Y - A.Y, B.Z - A.Z);

    public LineInSpace()
    {
        A = new PointInSpace();
        B = new PointInSpace(2);
    }

    public LineInSpace(PointInSpace b)
    {
        A = new PointInSpace();
        B = b;
    }

    public LineInSpace(PointInSpace a, PointInSpace b) : this(b)
    {
        if (a != b) A = a;
    }

    public LineInSpace((int x, int y, int z) b)
    {
        A = new PointInSpace();
        B = new PointInSpace(b);
    }

    public LineInSpace((int x, int y, int z) a, (int x, int y, int z) b) : this(b)
    {
        if (a != b) 
            A = new PointInSpace(a);
    }

    public override bool CheckParallelTo(TLine line)
    {
        return line is LineInSpace line3D &&
               line3D.VectorCoord.X != 0 && line3D.VectorCoord.Y != 0 && line3D.VectorCoord.Z != 0 &&
               (decimal) VectorCoord.X / line3D.VectorCoord.X == (decimal) VectorCoord.Y / line3D.VectorCoord.Y &&
               (decimal) VectorCoord.X / line3D.VectorCoord.X == (decimal) VectorCoord.Z / line3D.VectorCoord.Z;
    }

    public override bool CheckPerpendicularTo(TLine line)
    {
        return line is LineInSpace line3D &&
               VectorCoord.X * line3D.VectorCoord.X + VectorCoord.Y * line3D.VectorCoord.Y +
               VectorCoord.Z * line3D.VectorCoord.Z == 0;
    }

    public override bool CheckPointOnLine(Point point)
    {
        if (point is not PointInSpace point3D) return false;
        LineInSpace lineWithPoint = new LineInSpace(A, point3D);
        return CheckParallelTo(lineWithPoint);
    }

    public override string ToString() => $"A {A}\tB {B}";
}