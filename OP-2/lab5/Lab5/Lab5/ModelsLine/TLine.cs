namespace Lab5;

public abstract class TLine
{
    public abstract bool CheckParallelTo(TLine line);
    public abstract bool CheckPerpendicularTo(TLine line);
    public abstract bool CheckPointOnLine(Point point);
}