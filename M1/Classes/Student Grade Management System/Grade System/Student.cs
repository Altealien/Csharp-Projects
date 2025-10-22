namespace GradeSystem;

public class Student
{
    private static int studentCount = 0;

    public string Name { get; set; }
    public string StudentId { get; set; }
    public int EnrollmentYear { get; set; }
    public List<int> Grades { get; set; }

    public string Status
    {
        get
        {
            double average = GetAverage();
            return average >= 50 ? "Pass" : "Fail";
        }
    }

    public static int TotalStudents
    {
         get => studentCount;
    }
    public Student(string name, string id, int enrollmentYear)
    {
        Name = name;
        StudentId = id;
        Grades = [];
        EnrollmentYear = enrollmentYear;
        studentCount++;

        Console.WriteLine($"Student '{name}' has been created succesfully");
    }

    public void AddGrade(int grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            Grades.Add(grade);
            Console.WriteLine($"The grade {grade} has been added for {Name}");
        }
        else
        {
            Console.WriteLine("Invalid grade. Grade must be in the range 0-100");
        }
    }

    public double GetAverage()
    {
        if (Grades.Count == 0)
        {
            return 0;
        }
        return Grades.Average();
    }

    public void DisplayInfo()
    {
        Console.WriteLine("--------Student Info--------");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Student Id: {StudentId}");
        Console.WriteLine($"Enrollment Year: {EnrollmentYear}");
        if (Grades.Count > 0)
        {
            Console.Write("Student Grades: ");
            foreach (int grade in Grades)
            {
                Console.Write(grade + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Student Grade Average: {GetAverage():F2}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine("---------------------------------------");
        }
        else
        {
            Console.WriteLine($"No grades have been stored for {Name}");
        }

    }
}