class MainMenu
{
    static void Main(string[] args) 
    {
        int choice;
        do{
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("[1] Store to ASEAN Phonebook");
            Console.WriteLine("[2] Edit Entry in ASEAN Phonebook");
            Console.WriteLine("[3] Search ASEAN Phonebook by country");
            Console.WriteLine("[4] Exit");

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: Console.WriteLine("1"); break;
                case 2: Console.WriteLine("2"); break;
                case 3: Console.WriteLine("3"); break;
                case 4: Console.WriteLine("Exited the program..."); break;
                default: Console.WriteLine("Invalid. Try again."); break;
            } 
        } while (choice != 4);
    }
}


