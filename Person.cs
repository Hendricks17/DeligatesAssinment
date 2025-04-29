using System;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int HeightCm { get; set; }

    public Person(string firstName, string lastName, string gender, string address, string phoneNumber, int heightCm)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Address = address;
        PhoneNumber = phoneNumber;
        HeightCm = heightCm;
    }

    public string Introduce()
    {
        return $"Hi, My name is {FirstName} {LastName}, {Gender}, I reside at {Address}";
    }

    public int ConvertHeight(string unit)
    {
        if (unit.ToLower() == "meter")
            return HeightCm / 100;
        else if (unit.ToLower() == "feet")
            return (int)(HeightCm / 30.48);
        else
            throw new ArgumentException("Unit must be 'meter' or 'feet'");
    }
}