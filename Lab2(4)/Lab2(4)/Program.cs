using System;
using System.Collections.Generic;

class Program
{
    static List<Client> clients = new List<Client>();
    static List<Client> archive = new List<Client>();

    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("1. Зареєструватися");
            Console.WriteLine("2. Знайти кандидата");
            Console.WriteLine("3. Вийти");
            Console.Write("Оберіть дію: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterClient();
                    break;
                case 2:
                    FindMatch();
                    break;
                case 3:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void RegisterClient()
    {
        Console.Write("Введіть ім'я: ");
        string name = Console.ReadLine();
        Console.Write("Введіть стать (чоловік/жінка): ");
        string gender = Console.ReadLine();
        Console.Write("Введіть вік: ");
        int age = int.Parse(Console.ReadLine());

        Client newClient = new Client(name, gender, age);
        clients.Add(newClient);

        Console.WriteLine("Реєстрація успішно завершена.");
    }

    static void FindMatch()
    {
        Console.Write("Введіть своє ім'я: ");
        string name = Console.ReadLine();
        Console.Write("Введіть свою стать (чоловік/жінка): ");
        string gender = Console.ReadLine();
        Console.Write("Введіть свій вік: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Пошук кандидатів...");
        foreach (Client client in clients)
        {
            if (client.Name != name && client.Gender != gender && Math.Abs(client.Age - age) <= 5)
            {
                Console.WriteLine($"Збіг: {client.Name}, {client.Gender}, {client.Age} років.");
            }
        }

        Console.WriteLine("Пошук завершено.");
    }
}

class Client
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Age
    {
        get; set;
    }3

    public Client(string name, string gender, int age)
    {
        Name = name;
        Gender = gender;
        Age = age;
    }
}
