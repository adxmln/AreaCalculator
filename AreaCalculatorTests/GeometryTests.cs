using AreaCalculatorLib;
using static AreaCalculatorLib.Triangle;

namespace AreaCalculatorTests
{
    [TestFixture]
    public class ShapeTests
    {
        [Test]
        public void CircleArea_6radius_double113returned()
        {
            // Arrange
            var circle = new Circle(6);
            var expectedArea = Math.PI * 6 * 6;

            // Act
            var actualArea = circle.CalculateArea();

            // Assert
            Assert.That(actualArea, Is.EqualTo(expectedArea).Within(1e-10), "The area calculation for the circle is incorrect.");
        }

        [Test]
        public void TriangleArea_555sides_double9returned()
        {
            // Arrange
            var triangle = new Triangle(5, 5, 5);
            var expectedArea = 10.825317547305483;

            // Act
            var actualArea = triangle.CalculateArea();

            // Assert
            Assert.That(actualArea, Is.EqualTo(expectedArea).Within(1e-10), "The area calculation for the triangle is incorrect.");
        }

        [Test]
        public void RightTriangle_345sides_TrueReturned()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);

            // Act
            var isRightTriangle = triangle.IsRightTriangle();

            // Assert
            Assert.That(isRightTriangle, Is.True, "The triangle should be a right triangle.");
        }

        [Test]
        public void TriangleTest_1210sides_IncorrectReturned()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 10), "An exception should be thrown for invalid triangle sides.");
        }

        [Test]
        public void StaticShapeCalculatorTest_Circle5Triangle345_CircleDouble78Triangle6Returned()
        {
            // Arrange
            IShape circle = new Circle(5);
            IShape triangle = new Triangle(3, 4, 5);
            var expectedCircleArea = Math.PI * 25;
            var expectedTriangleArea = 6;

            // Act
            var actualCircleArea = ShapeCalculator.CalculateArea(circle);
            var actualTriangleArea = ShapeCalculator.CalculateArea(triangle);

            // Assert
            Assert.That(actualCircleArea, Is.EqualTo(expectedCircleArea).Within(1e-10), "The area calculation for the circle via ShapeCalculator is incorrect.");
            Assert.That(actualTriangleArea, Is.EqualTo(expectedTriangleArea).Within(1e-10), "The area calculation for the triangle via ShapeCalculator is incorrect.");
        }
    }
}
