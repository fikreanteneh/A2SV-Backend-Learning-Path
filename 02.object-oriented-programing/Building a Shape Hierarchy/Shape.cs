
abstract class Shape {
    private string Name;

    protected Shape(string aName){
        Name = aName;
    }
    public virtual double CalculateArea(){
        return 0;
    }
    public string GetName => Name;
}