using System;
using System.Collections;
using System.Collections.Generic;

// Інтерфейс IDateAndCopy
public interface IDateAndCopy
{
    DateTime Date { get; set; }
    object DeepCopy();
}

// Клас Person
public class Person : IDateAndCopy
{
    static void Main()
    {
        try
        {
            // Колекції для збереження даних
            List<Student> students = new List<Student>();
            List<Exam> exams = new List<Exam>();
            List<Test> tests = new List<Test>();
            List<IDateAndCopy> examsAndTests = new List<IDateAndCopy>();

            // Створення об'єктів
            Student student = new Student("Taras", "Datskiv", new DateTime(2000, 1, 1));
            student.AddExam(new Exam("Math", 90, new DateTime(2023, 1, 10)));
            student.AddTest(new Test("Programming", Test.TestResult.Passed, new DateTime(2023, 2, 15)));

            // Додавання до колекцій
            students.Add(student);
            exams.AddRange(student.Exams);
            tests.AddRange(student.Tests);
            examsAndTests.AddRange((IEnumerable<IDateAndCopy>)student);

            // Виведення даних
            Console.WriteLine("Original Student:");
            foreach (IDateAndCopy item in student)
            {
                Console.WriteLine($"{item.GetType().Name}: {item}");
            }

            // Копіювання
            Student copiedStudent = (Student)student.DeepCopy();
            Console.WriteLine("\nCopied Student:");
            foreach (IDateAndCopy item in copiedStudent)
            {
                Console.WriteLine($"{item.GetType().Name}: {item}");
            }

            // Використання ітераторів
            Console.WriteLine("\nExams with mark above 80:");
            foreach (Exam exam in student.GetExamsWithMark(80))
            {
                Console.WriteLine($"Exam: {exam}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    protected string firstName;
    protected string lastName;
    protected DateTime birthDate;

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
    }

    public Person() : this("Unknown", "Unknown", DateTime.Now) { }

    public DateTime Date
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public override bool Equals(object obj)
    {
        if (obj is Person)
        {
            Person otherPerson = (Person)obj;
            return firstName == otherPerson.firstName &&
                   lastName == otherPerson.lastName &&
                   birthDate == otherPerson.birthDate;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(firstName, lastName, birthDate);
    }

    public virtual object DeepCopy()
    {
        return new Person(firstName, lastName, birthDate);
    }
}

// Клас Exam
public class Exam : IDateAndCopy
{
    protected string subject;
    protected int mark;
    protected DateTime examDate;

    public Exam(string subject, int mark, DateTime examDate)
    {
        this.subject = subject;
        this.mark = mark;
        this.examDate = examDate;
    }

    public Exam() : this("Unknown", 0, DateTime.Now) { }

    public DateTime Date
    {
        get { return examDate; }
        set { examDate = value; }
    }

    public override bool Equals(object obj)
    {
        if (obj is Exam)
        {
            Exam otherExam = (Exam)obj;
            return subject == otherExam.subject &&
                   mark == otherExam.mark &&
                   examDate == otherExam.examDate;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(subject, mark, examDate);
    }

    public virtual object DeepCopy()
    {
        return new Exam(subject, mark, examDate);
    }
}

// Клас Student
public class Student : Person
{
    private List<Exam> exams;
    private List<Test> tests;

    public Student(string firstName, string lastName, DateTime birthDate) : base(firstName, lastName, birthDate)
    {
        exams = new List<Exam>();
        tests = new List<Test>();
    }

    public List<Exam> Exams
    {
        get { return exams; }
    }

    public List<Test> Tests
    {
        get { return tests; }
    }

    public void AddExam(Exam exam)
    {
        exams.Add(exam);
    }

    public void AddTest(Test test)
    {
        tests.Add(test);
    }

    public new object DeepCopy()
    {
        Student copiedStudent = new Student(firstName, lastName, birthDate);
        foreach (Exam exam in exams)
        {
            copiedStudent.AddExam((Exam)exam.DeepCopy());
        }
        foreach (Test test in tests)
        {
            copiedStudent.AddTest((Test)test.DeepCopy());
        }
        return copiedStudent;
    }

    // Ітератор для послідовного перебору всіх елементів зі списків заліків та іспитів (об'єднання)
    public IEnumerator<IDateAndCopy> GetEnumerator()
    {
        foreach (Exam exam in exams)
        {
            yield return exam;
        }
        foreach (Test test in tests)
        {
            yield return test;
        }
    }

    // Ітератор з параметром для перебору іспитів з оцінкою вище заданого значення
    public IEnumerable<IDateAndCopy> GetExamsWithMark(int mark)
    {
        foreach (Exam exam in exams)
        {
            if (exam.Date.Year > mark)
                yield return exam;
        }
    }
}

// Клас Test
public class Test : IDateAndCopy
{
    public enum TestResult { Passed, NotPassed }

    protected string subject;
    protected TestResult result;
    protected DateTime testDate;

    public Test(string subject, TestResult result, DateTime testDate)
    {
        this.subject = subject;
        this.result = result;
        this.testDate = testDate;
    }

    public Test() : this("Unknown", TestResult.NotPassed, DateTime.Now) { }

    public string Subject
    {
        get { return subject; }
        set { subject = value; }
    }

    public TestResult Result
    {
        get { return result; }
        set { result = value; }
    }

    public DateTime Date
    {
        get { return testDate; }
        set { testDate = value; }
    }

    public override bool Equals(object obj)
    {
        if (obj is Test)
        {
            Test otherTest = (Test)obj;
            return subject == otherTest.subject &&
                   result == otherTest.result &&
                   testDate == otherTest.testDate;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(subject, result, testDate);
    }

    public virtual object DeepCopy()
    {
        return new Test(subject, result, testDate);
    }

    public override string ToString()
    {
        return $"{subject} - {result} ({testDate:yyyy-MM-dd})";
    }
}

// Клас для тестування
class Program
{
    static void Main()
    {
        try
        {
            // Створення об'єктів
            Student student = new Student("Taras", "Datskiv", new DateTime(2000, 1, 1));
            student.AddExam(new Exam("Math", 90, new DateTime(2023, 1, 10)));
            student.AddTest(new Test("Programming", Test.TestResult.Passed, new DateTime(2023, 2, 15)));

            // Виведення даних
            Console.WriteLine("Original Student:");
            foreach (IDateAndCopy item in student)
            {
                Console.WriteLine($"{item.GetType().Name}: {item}");
            }

            // Копіювання
            Student copiedStudent = (Student)student.DeepCopy();
            Console.WriteLine("\nCopied Student:");
            foreach (IDateAndCopy item in copiedStudent)
            {
                Console.WriteLine($"{item.GetType().Name}: {item}");
            }

            // Використання ітераторів
            Console.WriteLine("\nExams with mark above 80:");
            foreach (Exam exam in student.GetExamsWithMark(80))
            {
                Console.WriteLine($"Exam: {exam}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
