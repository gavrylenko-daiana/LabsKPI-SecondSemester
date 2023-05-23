namespace Lab5;

public class LineOnPlane : TLine
{
    public PointOnPlane A { get; private set; }
    public PointOnPlane B { get; private set; }
    public PointOnPlane VectorCoord => new PointOnPlane(B.X - A.X, B.Y - A.Y);

    public LineOnPlane()
    {
        A = new PointOnPlane();
        B = new PointOnPlane(2);
    }

    public LineOnPlane(PointOnPlane b)
    {
        A = new PointOnPlane();
        B = b;
    }

    public LineOnPlane(PointOnPlane a, PointOnPlane b) : this(b)
    {
        if (a != b) A = a;
    }

    public LineOnPlane((int x, int y) b)
    {
        A = new PointOnPlane();
        B = new PointOnPlane(b);
    }

    public LineOnPlane((int x, int y) a, (int x, int y) b) : this(b)
    {
        if(a != b) A = new PointOnPlane(a);
    }

    public override bool CheckParallelTo(TLine line)
    {
        return line is LineOnPlane planeLine && planeLine.VectorCoord.X != 0 && planeLine.VectorCoord.Y != 0 &&
               (decimal) VectorCoord.X / planeLine.VectorCoord.X == (decimal) VectorCoord.Y / planeLine.VectorCoord.Y;
    }

    public override bool CheckPerpendicularTo(TLine line)
    {
        return line is LineOnPlane planeLine &&
               VectorCoord.X * planeLine.VectorCoord.X + VectorCoord.Y * planeLine.VectorCoord.Y == 0;
    }

    public override bool CheckPointOnLine(Point point)
    {
        if (point is not PointOnPlane point2D) return false;
        LineOnPlane lineWithPoint = new LineOnPlane(A, point2D);
        return CheckParallelTo(lineWithPoint);
    }

    public override string ToString() => $"A {A}\tB {B}";
}