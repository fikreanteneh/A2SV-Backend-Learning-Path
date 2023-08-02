

class Circle : Shape {
    private double Radius;
    public Circle(double aRadius, string aName = "Circle") : base(aName) { 
        Radius = aRadius;
    }
    public override double CalculateArea() {
        return Math.PI * Radius * Radius;
    }
}