

class Rectangle : Shape {
    double Width;
    double Height;

    public Rectangle(double aWidth, double aHeight, string aName = "Rectangle"): base(aName) { 
        Width = aWidth;
        Height = aHeight;
    }

    public override double CalculateArea() {
        return Width * Height;
    }
}