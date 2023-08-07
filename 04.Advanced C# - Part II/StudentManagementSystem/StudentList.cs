

using System.Text.Json;

namespace global{
    class StudentList<T> where T: Student
    {
        protected List<T> Students = new();
        
        public StudentList(){
            string reader = FileManager.LineReader();
            Students = JsonSerializer.Deserialize<List<T>>(reader) ?? new();
        }
        public void SaveChanges(){
            string jsonDocuments = JsonSerializer.Serialize(Students);
            _ = FileManager.LineChanger(new string[]{jsonDocuments});
        }

        public void DisplayStudents(List<T> students = null){
            List<T> aStudents = students ?? Students;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou have {0} students in this list\n", aStudents.Count);
            foreach(T student in aStudents){
                Console.WriteLine(student);
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void AddStudent(T student){
            if (this.SearchById(student.RollNumber).Count > 0){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student with this Roll Number already exists");
                Console.ResetColor();
                return;
            }
            Students.Add(student);
        }


        public List<T> SearchById (int rollNumber){
            var searchQuery = from student in Students
                              where student.RollNumber == rollNumber
                              select student;
            List<T> searchResult = searchQuery.ToList();
            return searchResult;
        }

        public List<T> SearchByName(string name){
            var searchQuery = from student in Students
                              where student.Name.Contains(name)
                              select student;
            List<T> searchResult = searchQuery.ToList();
            return searchResult;
        }
        public List<T> SortByName(){
            var searchQuery = from student in Students
                              orderby student.Name
                              select student;
            List<T> searchResult = searchQuery.ToList();
            return searchResult;
        }
        public List<T> SortByAge(){
            var searchQuery = from student in Students
                              orderby student.Age
                              select student;
            List<T> searchResult = searchQuery.ToList();
            return searchResult;
        }

        public List<T> SortByGrade(){
            var searchQuery = from student in Students
                              orderby student.Grade
                              select student;
            List<T> searchResult = searchQuery.ToList();
            return searchResult;
        }

        public void DeleteStudent(int rollNumber){
            List<T> searchResult = this.SearchById(rollNumber);
            if (searchResult.Count == 0){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student with this Roll Number does not exist");
                Console.ResetColor();
                return;
            }
            Students.Remove(searchResult[0]);
        }
        
        public void Update(int id, string name, int age, float grade){
            T selected = this.SearchById(id)[0];
            name = name.Length > 0 ? name : selected.Name;
            age = age > 0 ? age : selected.Age;
            grade = grade > 0 ? grade : selected.Grade;
            selected.Update(name, age, grade);

        }

    }
}