using System;
using System.Linq;

// Визначення перерахування Building
enum Building
{
    Residential,
    Religious,
    Industrial
}

// Визначення класу Architecture
class Architecture
{
    // Властивості класу
    public string BuildingName { get; set; }
    public int Capacity { get; set; }
    public DateTime ConstructionDate { get; set; }

    // Конструктор з параметрами
    public Architecture(string buildingName, int capacity, DateTime constructionDate)
    {
        BuildingName = buildingName;
        Capacity = capacity;
        ConstructionDate = constructionDate;
    }

    // Конструктор без параметрів
    public Architecture()
    {
        BuildingName = "DefaultName";
        Capacity = 0;
        ConstructionDate = DateTime.Now;
    }

    // Перевантажений метод ToString()
    public override string ToString()
    {
        return $"Building: {BuildingName}, Capacity: {Capacity}, Construction Date: {ConstructionDate}";
    }
}

// Визначення класу Foundation
class Foundation
{
    // Властивість класу
    public string FoundationType { get; set; }
}

// Визначення класу DesignElements
class DesignElements
{
    // Закриті поля класу
    private Foundation foundation;
    private Building building;
    private int wallCount;
    private Architecture[] architectures;

    // Конструктор з параметрами
    public DesignElements(Foundation foundation, Building building, int wallCount)
    {
        this.foundation = foundation;
        this.building = building;
        this.wallCount = wallCount;
        architectures = new Architecture[0];
    }

    // Конструктор без параметрів
    public DesignElements()
    {
        foundation = new Foundation { FoundationType = "DefaultFoundation" };
        building = Building.Residential;
        wallCount = 0;
        architectures = new Architecture[0];
    }

    // Властивості з методами get і set
    public Foundation Foundation
    {
        get { return foundation; }
        set { foundation = value; }
    }

    public Building BuildingType
    {
        get { return building; }
        set { building = value; }
    }

    public int WallCount
    {
        get { return wallCount; }
        set { wallCount = value; }
    }

    public Architecture[] Architectures
    {
        get { return architectures; }
        set { architectures = value; }
    }

    // Властивість для середньої чисельності споруд
    public double AverageArchitectures
    {
        get { return architectures.Length > 0 ? architectures.Length / (double)wallCount : 0; }
    }

    // Індексатор
    public bool this[Building b]
    {
        get { return building == b; }
    }

    // Метод для додавання споруд
    public void AddArchitecture(params Architecture[] archs)
    {
        architectures = architectures.Concat(archs).ToArray();
    }

    // Перевантажений метод ToString()
    public override string ToString()
    {
        string architecturesStr = architectures.Length > 0 ?
            string.Join("\n", architectures.Select(a => a.ToString())) :
            "No architectures";

        return $"Foundation: {foundation.FoundationType}, Building Type: {building}, Wall Count: {wallCount}\nArchitectures:\n{architecturesStr}";
    }

    // Віртуальний метод для формування рядка без списку споруд
    public virtual string ToShortString()
    {
        return $"Foundation: {foundation.FoundationType}, Building Type: {building}, Wall Count: {wallCount}";
    }
}

class Program
{
    static void Main()
    {
        // Створення об'єкта типу DesignElements
        DesignElements design = new DesignElements();

        // Виведення даних за допомогою методу ToShortString()
        Console.WriteLine("Data using ToShortString():");
        Console.WriteLine(design.ToShortString());

        // Виведення значень індексатора
        Console.WriteLine("\nIndexer values:");
        Console.WriteLine($"Residential: {design[Building.Residential]}");
        Console.WriteLine($"Religious: {design[Building.Religious]}");
        Console.WriteLine($"Industrial: {design[Building.Industrial]}");

        // Присвоєння значень властивостям
        design.Foundation = new Foundation { FoundationType = "NewFoundation" };
        design.BuildingType = Building.Industrial;
        design.WallCount = 5;

        // Виведення даних після присвоєння значень
        Console.WriteLine("\nData after setting properties:");
        Console.WriteLine(design.ToString());

        // Додавання елементів в список споруд
        design.AddArchitecture(
            new Architecture("Building1", 100, DateTime.Now),
            new Architecture("Building2", 200, DateTime.Now.AddDays(30))
        );

        // Виведення даних після додавання елементів
        Console.WriteLine("\nData after adding architectures:");
        Console.WriteLine(design.ToString());
    }
}
