

using System.Text.Json;
using System.Text.Json.Serialization;

namespace global
{
    class Student 
    {
        private readonly int  rollNumber;
        private string name;
        private int age;
        private float grade;

        public int RollNumber {get => rollNumber; init => rollNumber = value;}
        public string Name { get { return name; } init { name = value; } }
        public float Grade { get { return grade; } init { grade = value; } }
        public int Age { get { return age; } init { age = value; } }

        public Student(int rollNumber, string name, int age, float grade){
            this.rollNumber = rollNumber;
            this.name = name;
            this.age = age;
            this.grade = grade;
        }

        public override string ToString() => $"{RollNumber}.{Name}\n\tAge: {Age}\n\tGrade: {Grade}";

        public override bool Equals(object obj){
            return obj is Student student && RollNumber == student.RollNumber;
        }

        public override int GetHashCode() => HashCode.Combine(RollNumber);

        public void Update(string name, int age, float grade){
            this.age = age;
            this.name = name;
            this.grade = grade;
        }
    }
}