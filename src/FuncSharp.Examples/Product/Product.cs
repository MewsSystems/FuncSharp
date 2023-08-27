namespace FuncSharp.Examples;

public class Point2D : Product2<float, float>
{
    public Point2D(float x, float y)
        : base(x, y)
    {
    }

    public float X { get { return ProductValue1; } }
    public float Y { get { return ProductValue2; } }
}

public class Rectangle : Product2<Point2D, Point2D>
{
    public Rectangle(Point2D a, Point2D b)
        : base(a, b)
    {
    }

    public Point2D A { get { return ProductValue1; } }
    public Point2D B { get { return ProductValue2; } }
}