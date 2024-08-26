namespace AreaCalculatorLib;

public interface IShape
{
    double CalculateArea();
}
public class Circle : IShape
{
    public double Radius { get; }
    public Circle(double radius)
    {
        Radius = radius;
    }
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
public class Triangle : IShape
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double sideA, double sideB, double siceC)
    {
        if (sideA <= 0 || sideB <= 0 || siceC <= 0)
            throw new ArgumentException("The sides of the triangle must be positive numbers.");
        SideA = sideA;
        SideB = sideB;
        SideC = siceC;
        if (!IsValidTriangle())
            throw new ArgumentException("A triangle with these sides does not exist.");
    }
    public double CalculateArea() // По формуле Герона
    {
        double p = (SideA + SideB + SideC) / 2; 
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC)); 
    }
    public bool IsRightTriangle() // По теореме Пифагора
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);
        return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-10;
    }
    private bool IsValidTriangle() // По свойству неравенства треугольника
    {
        return SideA + SideB > SideC && SideA + SideC > SideB && SideB + SideC > SideA;
    }

    public static class ShapeCalculator // Статический класс для рассчёта площади без знания типа фигуры
    {
        public static double CalculateArea(IShape shape)
        {
            return shape.CalculateArea();
        }
    }
}

