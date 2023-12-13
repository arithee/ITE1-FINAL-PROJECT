using System;
using System.Collections.Generic;

public class Student
{
    private string studentnumber;
    private string surname;
    private string firstname;
    private string occupation;
    private string gender;
    private int countrycode;
    private int areacode;
    private string phonenumber;

    public Student(string studentnumber, string surname, string firstname, string occupation, string gender, int countrycode,
        int areacode, string phonenumber)
    {
        this.studentnumber = studentnumber;
        this.surname = surname;
        this.firstname = firstname;
        this.occupation = occupation;
        this.gender = gender;
        this.countrycode = countrycode;
        this.areacode = areacode;
        this.phonenumber = phonenumber;
    }

    // SN GET SET
    public void SetStudentNumber(string studentnumber)
    {
        this.studentnumber = studentnumber;
    }
    public string GetStudentNumber()
    {
        return studentnumber;
    }
    // SURNAME GET SET
    public void SetSurname(string surname)
    {
        this.surname = surname;
    }
    public string GetSurname()
    {
        return surname;
    }
    // FIRSTNAME GET SET
    public void SetFirstName(string firstname)
    {
        this.firstname = firstname;
    }
    public string GetFirstName()
    {
        return firstname;
    }
    // OCCUPATION GET SET
    public void SetOccupation(string occupation)
    {
        this.occupation = occupation;
    }
    public string GetOccupation()
    {
        return occupation;
    }
    // GENDER GET SET
    public void SetGender(string gender)
    {
        this.gender = gender;
    }
    public string GetGender()
    {
        return gender;
    }
    // COUNTRYCODE GET SET
    public void SetCountryCode(int countrycode)
    {
        this.countrycode = countrycode;
    }
    public int GetCountryCode()
    {
        return countrycode;
    }
    // AREACODE GET SET
    public void SetAreaCode(int areacode)
    {
        this.areacode = areacode;
    }
    public int GetAreaCode()
    {
        return areacode;
    }
    // PHONENUMBER GET SET
    public void SetPhoneNumber(string phonenumber)
    {
        this.phonenumber = phonenumber;
    }
    public string GetPhoneNumber()
    {
        return phonenumber;
    }
}

class Phonebook
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void DisplayStudentDetails()
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Student Number: {student.GetStudentNumber()}");
            Console.WriteLine($"Surname: {student.GetSurname()}");
            Console.WriteLine($"First Name: {student.GetFirstName()}");
            Console.WriteLine($"Occupation: {student.GetOccupation()}");
            Console.WriteLine($"Gender: {student.GetGender()}");
            Console.WriteLine($"Country Code: {student.GetCountryCode()}");
            Console.WriteLine($"Area Code: {student.GetAreaCode()}");
            Console.WriteLine($"Phone Number: {student.GetPhoneNumber()}");
            Console.WriteLine();
        }
    }
}

class AddPhonebook
{
    public static Student GetStudentDetails()
    {
        Console.Write("Enter Student Number: ");
        string studentnumber = Console.ReadLine();
        Console.Write("Enter Surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter First Name: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter Occupation: ");
        string occupation = Console.ReadLine();
        Console.Write("Enter Gender: ");
        string gender = Console.ReadLine();
        Console.Write("Enter Country Code: ");
        int countrycode = int.Parse(Console.ReadLine());
        Console.Write("Enter Area Code: ");
        int areacode = int.Parse(Console.ReadLine());
        Console.Write("Enter Number: ");
        string phonenumber = Console.ReadLine();

        return new Student(studentnumber, surname, firstname, occupation, gender, countrycode, areacode, phonenumber);
    }
}

class Program
{
    static void Main()
    {
        Phonebook phonebook = new Phonebook();

        do
        {
            
            Student student = AddPhonebook.GetStudentDetails();
            phonebook.AddStudent(student);

            Console.Write("Do you want to add another entry [Y/N]?: ");
        } while (Console.ReadLine().ToUpper() == "Y");

        phonebook.DisplayStudentDetails();
    }
}