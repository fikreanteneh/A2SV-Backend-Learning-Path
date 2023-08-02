
class Program {
    public static void PrintShapeInfo(Shape shape) {
        Console.WriteLine("Shape name: {0}", shape.GetName);
        Console.WriteLine("Area: {0}", shape.CalculateArea());
        Console.WriteLine();
    }
    public static void Main(){
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(4, 8);
        Triangle triangle = new Triangle(4, 9);

        PrintShapeInfo(circle);
        PrintShapeInfo(rectangle);
        PrintShapeInfo(triangle);
    }

}