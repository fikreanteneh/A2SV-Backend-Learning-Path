



class Triangle : Shape {
    private double Base;
    private double Height;

    public Triangle(double aBase, double aHeight, string aName = "Triangle"): base(aName) {
        Base = aBase;
        Height = aHeight;
    }

    public override double CalculateArea() {
        return 0.5 * Base * Height;
    }
}