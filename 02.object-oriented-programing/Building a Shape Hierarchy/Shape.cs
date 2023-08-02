
abstract class Shape {
    public string Name;

    protected Shape(string aName){
        Name = aName;
    }
    public virtual double CalculateArea(){
        return 0;
    }
}