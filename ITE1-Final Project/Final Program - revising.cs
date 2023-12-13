using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string StudentNumber { get; set; }
    public string Surname { get; set; }
    public string Firstname { get; set; }
    public string Occupation { get; set; }
    public char Gender { get; set; }
    public int CountryCode { get; set; }
    public int AreaCode { get; set; }
    public string PhoneNumber { get; set; }

    public void InputStudentDetails()
    {
        Console.Write("Enter student number: ");
        StudentNumber = Console.ReadLine();
        Console.Write("Enter First Name: ");
        Firstname = Console.ReadLine();
        Console.Write("Enter Surname: ");
        Surname = Console.ReadLine();
        Console.Write("Enter Occupation: ");
        Occupation = Console.ReadLine();
        Gender = GetGenderInput("Enter gender (M for Male, F for Female): ");
        CountryCode = GetCountryCode("ASEAN COUNTRIES\n[60 - Federation Of Malaysia]" +
            ", [62 - Republic Of Indonesia]" +
            ", [63 - Republic of the Philippines]\n" + "[65 - Republic of Singapore]" +
            ", [66 - Kingdom Of Thailand]" + "\nEnter Country Code: ");
        Console.Write("Enter area code: ");
        AreaCode = GetAreaCode();
        Console.Write("Enter phone number: ");
        PhoneNumber = Console.ReadLine();
    }

    public void DisplayStudentDetails()
    {
        Console.WriteLine($"{Firstname} {Surname} with student number {StudentNumber} is a {Occupation}. " +
            $"-----Contact Details-----\n Country Code: {CountryCode}\n " +
            $"Area Code: {AreaCode}\n" +
            $"Phone Number: {PhoneNumber}");
    }

    public char GetGenderInput(string message)
    {
        char gender;
        do
        {
            Console.Write(message);
            char.TryParse(Console.ReadLine().ToLower(), out gender);
        } while (gender != 'm' && gender != 'f');

        return gender;
    }

    public int GetCountryCode(string message)
    {
        int ccode;
        do
        {
            Console.Write(message);
            int.TryParse(Console.ReadLine(), out ccode);
        } while (ccode != 60 && ccode != 62 && ccode != 63 && ccode != 65 && ccode != 66);

        return ccode;
    }

    public int GetAreaCode()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
        return input;
    }
}

class ASEANPhoneBook
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void EditPhonebook(string studentNumber)
    {
        Student student = students.FirstOrDefault(s => s.StudentNumber == studentNumber);
        if (student != null)
        {
            Console.WriteLine($"Here is the existing information about {student.StudentNumber}");
            student.DisplayStudentDetails();
            Console.WriteLine("Which information do you wish to change?");
            Console.WriteLine("[1] Student number");
            Console.WriteLine("[2] Surname");
            Console.WriteLine("[3] Firstname");
            Console.WriteLine("[4] Occupation");
            Console.WriteLine("[5] Gender");
            Console.WriteLine("[6] Country code");
            Console.WriteLine("[7] Area code");
            Console.WriteLine("[8] Phone number");
            Console.WriteLine("[9] Main Menu");
            Console.Write("Enter choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice.");
                return;
            }
            switch (choice)
            {
                case 1:
                    Console.Write("Edit Student Number: ");
                    student.StudentNumber = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Edit Surname: ");
                    student.Surname = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Edit First Name: ");
                    student.Firstname = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Edit Occupation: ");
                    student.Occupation = Console.ReadLine();
                    break;
                case 5:
                    student.Gender = student.GetGenderInput("Edit Gender(M for Male, F for Female): ");
                    break;
                case 6:
                    student.CountryCode = student.GetCountryCode("Edit Country Code(60, 62, 63, 65, 66): ");
                    break;
                case 7:
                    Console.Write("Edit Area Code: ");
                    student.AreaCode = student.GetAreaCode();
                    break;
                case 8:
                    Console.Write("Edit Phone Number: ");
                    student.PhoneNumber = Console.ReadLine();
                    break;
                case 9:
                    Console.WriteLine("Going back to main menu.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Student Number doesn't match in our directories.");
        }
    }
    public void SearchCountryCode(int[] countryCodes)
    {
        var selectedStudents = students.Where(s => countryCodes.Contains(s.CountryCode)).ToList();

        if (selectedStudents.Any())
        {
            foreach (var student in selectedStudents)
            {
                student.DisplayStudentDetails();
            }
        }
        else
        {
            Console.WriteLine("No students found from selected countries.");
        }
    }
    class MainMenu
    {
        static void Main(string[] args)
        {
            ASEANPhoneBook phoneBook = new ASEANPhoneBook();
            int choice;

            do
            {
                Console.Write("----- Main Menu -----\n");
                Console.WriteLine("[1] Store to ASEAN Phonebook");
                Console.WriteLine("[2] Edit entry in ASEAN Phonebook");
                Console.WriteLine("[3] Search ASEAN Phonebook by country");
                Console.WriteLine("[4] Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Student newStudent = new Student();
                        newStudent.InputStudentDetails();
                        phoneBook.AddStudent(newStudent);
                        break;
                    case 2: 
                        Console.Write("Enter student number to edit: ");
                        string studentNumber = Console.ReadLine();
                        phoneBook.EditPhonebook(studentNumber);
                        break;
                    case 3:
                        Console.WriteLine("[60 - Federation of Malaysia]" +
                            "[62 - Republic of Indonesia]" +
                            "[63 - Republic of the Philippines]\n" +
                            "[65 - Republic of Singapore]" +
                            "[66 - Kingdom of Thailand]\n Enter Country Code:");
                        int[] countryCodes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        phoneBook.SearchCountryCode(countryCodes);
                        break;
                    case 4:
                        Console.WriteLine("Exiting Program..");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 4);
        }
    }
}