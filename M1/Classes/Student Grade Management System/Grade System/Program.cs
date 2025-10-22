using GradeSystem;

List<Student> students = [];

Console.WriteLine("-----Student Grade Management System-----");

for (int i = 1; i <= 3; i++)
{
    Console.WriteLine($"----------Creating Student {i}----------");
    Console.Write("Enter student name: ");
    string? name = Console.ReadLine();
    Console.Write("Enter student id: ");
    string? id = Console.ReadLine();
    Console.Write("Enter enrollment year: ");
    int enrollmentYear = int.TryParse(Console.ReadLine(), out int value) ? value : 0;

    Student student = new(name, id, enrollmentYear);


    students.Add(student);
}


foreach (Student student in students)
{
    Console.WriteLine($"-----Adding grades for {student.Name}-----");
    for (int i = 1; i <= 4; i++)
    {
        Console.Write($"Enter grade {i} for {student.Name} : ");
        int grade = int.TryParse(Console.ReadLine(), out int value) ? value : 0;
        student.AddGrade(grade);
    }
}

foreach (Student student in students)
{
    Console.WriteLine("\n\n----------FINAL REPORT----------");
    student.DisplayInfo();
}

Console.WriteLine($"\n=== Summary ===");
Console.WriteLine($"Total students created: {Student.TotalStudents}");


Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();