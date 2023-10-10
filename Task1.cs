using System;

public enum Gender
{
    Male,
    Female,
}

public class Animal
{
    public Gender Gender { get; }
    public DateTime BirthDate { get; }

    public Animal(Gender gender, DateTime birthDate)
    {
        Gender = gender;
        BirthDate = birthDate;
    }
}

public class Dog : Animal
{
    private string name;
    private string breed;

    public string Name => name;
    public string Breed => breed;

    public Dog(Gender gender, DateTime birthDate, string name, string breed) : base(gender, birthDate)
    {
        this.name = name;
        this.breed = breed;
    }
}

public class Program
{
    public static void Main()
    {
        Animal animal = new Animal(Gender.Male, new DateTime(2020, 1, 1));

        Dog dog = new Dog(Gender.Female, new DateTime(2018, 5, 5), "Buddy", "Golden Retriever");

        Console.WriteLine($"Animal Gender: {animal.Gender}");
        Console.WriteLine($"Animal BirthDate: {animal.BirthDate}");
        Console.WriteLine($"Dog Name: {dog.Name}");
        Console.WriteLine($"Dog Breed: {dog.Breed}");
    }
}
