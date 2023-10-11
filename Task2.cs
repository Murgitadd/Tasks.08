using System;

class Person
{
    public string Name { get; }
    public string Surname { get; }
    public int Age { get; }

    public Person(string name, string surname, int age)
    {
        Name = name;
        Surname = surname;
        Age = age;
    }
}

class Student : Person
{
    public bool IsOnline { get; }

    public Student(string name, string surname, int age, bool isOnline)
        : base(name, surname, age)
    {
        IsOnline = isOnline;
    }
}

class Group
{
    public string GroupName { get; }
    public Student[] Students { get; private set; }
    private int studentCount;

    public Group(string groupName, int maxSize)
    {
        GroupName = groupName;
        Students = new Student[maxSize];
        studentCount = 0;
    }

    public void Add()
    {
        if (studentCount < Students.Length)
        {
            Console.WriteLine("Enter student details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Is online (true/false): ");
            bool isOnline = bool.Parse(Console.ReadLine());

            Student student = new Student(name, surname, age, isOnline);
            Students[studentCount] = student;
            studentCount++;
        }
        else
        {
            Console.WriteLine("The group is full. Cannot add more students.");
        }
    }

    public void GetAll()
    {
        Console.WriteLine($"Students in group {GroupName}:");
        for (int i = 0; i < studentCount; i++)
        {
            var student = Students[i];
            Console.WriteLine($"{student.Name} {student.Surname}, Age: {student.Age}, Online: {student.IsOnline}");
        }
    }

    public void GetOnlineStudents()
    {
        Console.WriteLine($"Online students in group {GroupName}:");
        for (int i = 0; i < studentCount; i++)
        {
            var student = Students[i];
            if (student.IsOnline)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, Age: {student.Age}");
            }
        }
    }

    public void GetOfflineStudents()
    {
        Console.WriteLine($"Offline students in group {GroupName}:");
        for (int i = 0; i < studentCount; i++)
        {
            var student = Students[i];
            if (!student.IsOnline)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, Age: {student.Age}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the group name: ");
        string groupName = Console.ReadLine();
        Console.Write("Enter the maximum number of students in the group: ");
        int maxSize = int.Parse(Console.ReadLine());

        Group group = new Group(groupName, maxSize);

        while (true)
        {
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Get all students");
            Console.WriteLine("3. Get online students");
            Console.WriteLine("4. Get offline students");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    group.Add();
                    break;
                case 2:
                    group.GetAll();
                    break;
                case 3:
                    group.GetOnlineStudents();
                    break;
                case 4:
                    group.GetOfflineStudents();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

