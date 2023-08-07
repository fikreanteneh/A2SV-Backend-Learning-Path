// See https://aka.ms/new-console-template for more information


namespace  global
{
    class Program{
        static void Main(string[] args){

            StudentList<Student> studentList = new StudentList<Student>();
            

            while(true) {
                Console.WriteLine("0. Save and Exit Program");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Sort Students");
                Console.WriteLine("6. Update Student");


                int choice = UserInputHandler.GetIntInput("Choose a correct option", 0, 6);
                if(choice == 0){
                    Console.WriteLine("\nSaving and Exiting Program");
                    studentList.SaveChanges();
                    Console.WriteLine("Saved and Exited Program\n");
                    return;
                }
                else if(choice == 1){
                    Console.WriteLine("\nAdding Student");
                    int rollNumber = UserInputHandler.GetIntInput("Enter Roll Number");
                    string name = UserInputHandler.GetStringInput("Enter Name", 5);
                    int age = UserInputHandler.GetIntInput("Enter age", 10);
                    float grade = UserInputHandler.GetFloatInput("Enter grade", 0, 4);
                    Student student = new Student(rollNumber, name, age, grade);
                    studentList.AddStudent(student);
                }
                else if(choice == 2){
                    Console.WriteLine("\nSearching Student");
                    Console.WriteLine("1. Search By RollNumber");
                    Console.WriteLine("2. Search By Name");
                    int option = UserInputHandler.GetIntInput("Enter Search option");
                    if (option == 1){
                        int id = UserInputHandler.GetIntInput("Enter Roll Number");
                        studentList.DisplayStudents(studentList.SearchById(id));
                    }else if(option == 2){
                        string sName = UserInputHandler.GetStringInput("Enter Name", 1);
                        studentList.DisplayStudents(studentList.SearchByName(sName));
                    }                  
                }
                else if (choice == 3){
                    Console.WriteLine("\nDisplaying All Students");
                    studentList.DisplayStudents();
                }
                else if (choice == 4){
                    Console.WriteLine("\nDeleting Student");
                    int id = UserInputHandler.GetIntInput("Enter Roll Number");
                    studentList.DeleteStudent(id);
                }
                else if(choice == 5){
                    Console.WriteLine("\nSorting Students");
                    Console.WriteLine("1. Sort by Name ");
                    Console.WriteLine("2. Sort by Age");
                    Console.WriteLine("3. Sort by Grade");
                    int option = UserInputHandler.GetIntInput("Enter Sort option",1, 3);
                    if (option == 1) studentList.DisplayStudents(studentList.SortByName());
                    else if (option == 2) studentList.DisplayStudents(studentList.SortByAge());
                    else if (option == 3) studentList.DisplayStudents(studentList.SortByGrade());
                }
                else if (choice == 6){
                    Console.WriteLine("\nUpdating Student");
                    studentList.DisplayStudents();
                    List<Student> selected = new();
                    do{
                        int id = UserInputHandler.GetIntInput("Entera valid Student Roll Number");
                        selected = studentList.SearchById(id);
                    } while (
                        selected.Count == 0
                    );

                    var stu = selected[0];
                    string name =
                        UserInputHandler.GetStringInput($"Change name or leave it empty. old name >> {stu.Name}");
                    int age =
                        UserInputHandler.GetIntInput($"Change age or insert 0 to leave it. old age >> {stu.Age}");
                    float grade =
                        UserInputHandler.GetIntInput($"Change grade or insert 0 to leave it. old grade >> {stu.Age}");
                    studentList.Update(stu.RollNumber,  name, age, grade);
                }
            }
        }
    }
    
}
