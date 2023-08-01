class Task3
{
    public static float gradeCalc(){
        Console.WriteLine("Please insert Your name");
        string? name = Console.ReadLine();
  
        Console.WriteLine("Please insert the number of subjects you want to calculate the average");
        int numberOfGrades;

        while (!int.TryParse(Console.ReadLine(), out numberOfGrades)){
            Console.WriteLine("Please Insert A Number");
        }

        if (numberOfGrades == 0) {
            return 0;
            }

        int total = 0;
        for (int i = 0; i < numberOfGrades; i++) {
            Console.WriteLine("Please insert Subject Name");
            string? subject = Console.ReadLine();
            Console.WriteLine($"Please insert {subject} grade");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark))
            {
                Console.WriteLine("Please insert am Integer");
            }
            total = total + mark;
        }
        Console.WriteLine(total / numberOfGrades);
        return total / numberOfGrades;
    }
}