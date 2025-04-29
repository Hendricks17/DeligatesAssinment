using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Person person = new Person("Frank", "Castle", "Male", "123 Street", "1234567890", 180);

        // 1. Action deligate taking only parameter
        Action<string> introduceAction = (msg) => Console.WriteLine(person.Introduce());

        introduceAction("intro");
        Console.WriteLine();
        Console.WriteLine();

        // 2. Func delegate taking one heiht parameter(string) and returning int
        Func<string, int> convertHeight = person.ConvertHeight;
        Console.WriteLine("Height in meters: " + convertHeight("meter"));
        Console.WriteLine("Height in feet: " + convertHeight("feet"));

        Console.WriteLine();
        Console.WriteLine();

        // 3. Predicate delegate returning a bool
        Predicate<string> startsWithA = s => s.StartsWith("A");
        Console.WriteLine("Starts with A? " + startsWithA("Alice"));

        Console.WriteLine();
        Console.WriteLine();

        // 4. Lambdas
        Action<string> introduceLambda = (msg) => Console.WriteLine($"Hi, I'm {person.FirstName}, {person.Gender}, living at {person.Address}");
        introduceLambda("intro");

        Func<string, int> heightLambda = unit => unit == "meter" ? person.HeightCm / 100 : (int)(person.HeightCm / 30.48);
        Console.WriteLine("Height with lambda (feet): " + heightLambda("feet"));

        Predicate<string> startsWithALambda = s => s.StartsWith("A");
        Console.WriteLine("Lambda Predicate: " + startsWithALambda("Andrew"));

        Console.WriteLine();
        Console.WriteLine();

        // List of Persons
        List<Person> people = new List<Person>
        {
            person,
            new Person("Jonathan", "Bajela", "Male", "456 Avenue", "0987654321", 165),
            new Person("Yemi", "Bajela", "Female", "789 Road", "5678901234", 175)
        };

        // Task.WhenAll
        var tasks = people.Select(p =>
            Task.Run(() =>
            {
                int heightFeet = p.ConvertHeight("feet");
                Console.WriteLine($"{p.FirstName}'s height in feet: {heightFeet}");
            })
        );

        await Task.WhenAll(tasks);
    }
}
