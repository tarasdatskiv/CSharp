using System;
using System.Collections.Generic;
using System.Linq;

// Оголошення перерахування Education
public enum Education
{
    Specialist,
    Bachelor,
    SecondEducation
}

// Оголошення класу Exam
public class Exam
{
    public string Subject { get; set; }
    public int Grade { get; set; }
    public DateTime ExamDate { get; set; }

    // Конструктор з параметрами
    public Exam(string subject, int grade, DateTime examDate)
    {
        Subject = subject;
        Grade = grade;
        ExamDate = examDate;
    }

    // Конструктор без параметрів
    public Exam()
    {
        Subject = "Default Subject";
        Grade = 0;
        ExamDate = DateTime.Now;
    }

    // Перевизначений метод ToString
    public override string ToString()
    {
        return $"{Subject} - Grade: {Grade}, Exam Date: {ExamDate.ToShortDateString()}";
    }
}

// Оголошення класу Person
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public Person()
    {
        FirstName = "John";
        LastName = "Doe";
    }
}

// Оголошення класу Student
public class Student
{
    private Person person;
    private Education education;
    private int groupNumber;
    private List<Exam> exams; // Зміна на List<Exam>

    // Конструктор з параметрами
    public Student(Person person, Education education, int groupNumber)
    {
        this.person = person;
        this.education = education;
        this.groupNumber = groupNumber;
        this.exams = new List<Exam>(); // Ініціалізація як List<Exam>
    }

    // Конструктор без параметрів
    public Student()
    {
        this.person = new Person();
        this.education = Education.Bachelor;
        this.groupNumber = 1;
        this.exams = new List<Exam>(); // Ініціалізація як List<Exam>
    }

    // Властивість для доступу до поля з даними студента
    public Person Person
    {
        get { return person; }
        set { person = value; }
    }

    // Властивість для доступу до поля з формою навчання
    public Education Education
    {
        get { return education; }
        set { education = value; }
    }

    // Властивість для доступу до поля з номером групи
    public int GroupNumber
    {
        get { return groupNumber; }
        set { groupNumber = value; }
    }

    // Властивість для доступу до поля зі списком іспитів
    public List<Exam> Exams // Зміна на List<Exam>
    {
        get { return exams; }
        set { exams = value; }
    }

    // Властивість для обчислення середнього балу
    public double AverageGrade
    {
        get
        {
            if (exams.Count == 0) // Зміна на exams.Count
                return 0;

            double sum = 0;
            foreach (var exam in exams)
            {
                sum += exam.Grade;
            }
            return sum / exams.Count; // Зміна на exams.Count
        }
    }

    // Індексатор
    public bool this[Education edu]
    {
        get { return education == edu; }
    }

    // Метод для додавання елементів в список іспитів
    public void AddExams(params Exam[] newExams)
    {
        exams.AddRange(newExams); // Зміна на AddRange
    }

    // Перевизначений метод ToString
    public override string ToString()
    {
        string examsString = exams.Count > 0 ? string.Join("\n", exams.Select(e => e.ToString())) : "No exams"; // Зміна на exams.Count
        return $"{person.FirstName} {person.LastName} - Education: {education}, Group: {groupNumber}\nExams:\n{examsString}\nAverage Grade: {AverageGrade:F2}";
    }

    // Віртуальний метод для формування рядка без списку іспитів
    public virtual string ToShortString()
    {
        return $"{person.FirstName} {person.LastName} - Education: {education}, Group: {groupNumber}, Average Grade: {AverageGrade:F2}";
    }
}

class Program
{
    static void Main()
    {
        // Створення об'єкта типу Student
        Student student = new Student(new Person("Taras", "Datskiv"), Education.Bachelor, 101);

        // Виведення даних з використанням методу ToShortString()
        Console.WriteLine("Short Info:\n" + student.ToShortString());

        // Виведення значень індексатора
        Console.WriteLine("\nIndexer Values:");
        Console.WriteLine($"Is Specialist: {student[Education.Specialist]}");
        Console.WriteLine($"Is Bachelor: {student[Education.Bachelor]}");
        Console.WriteLine($"Is SecondEducation: {student[Education.SecondEducation]}");

        // Присвоєння значень властивостям та виведення даних з використанням методу ToString()
        student.Person = new Person("Petro", "Petrov");
        student.Education = Education.Specialist;
        student.GroupNumber = 102;

        Console.WriteLine("\nUpdated Info:\n" + student.ToString());

        // Додавання іспитів та виведення даних
        Exam[] newExams = {
            new Exam("Math", 95, new DateTime(2023, 1, 15)),
            new Exam("History", 80, new DateTime(2023, 2, 1))
        };

        student.AddExams(newExams);
        Console.WriteLine("\nUpdated Info with New Exams:\n" + student.ToString());
    }
}
