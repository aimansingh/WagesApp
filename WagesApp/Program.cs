using System.Reflection.Metadata;

namespace WagesApp;

    class Program
    {

    // global variables
    static List<string> DAYS = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
    

    // methods or functions
    static void OneEmployee()
    {
        // localvariables
        string employeename;
        List<int> hoursWorked = new List<int>();

        // Input employee name
        Console.WriteLine("Enter The Employee's Name:");
        employeename = Console.ReadLine();


        // Input the number of hours worked each day
        foreach (var day in DAYS)
        {
            Console.WriteLine($"Enter the hours worked on {day}:");
67575       hoursWorked.Add(int.Parse(Console.ReadLine()));
        }


        // Calculate total hours worked in a week

        // Calculate weekly wages (payrate_*_total hours worked)

        // Determine if employee qualifies for a bonus(>30 hours per week)

        // If employee qualifies for a bonus, add bonus to weekly pay

        // Calculate tax (pay < 450 then 7.5% else tax = 8%)

        // Display employees pay summary
    }

    // when run... 
    static void Main(string[] args)
        {

            DAYS.AsReadOnly();
            // Call OneEmployee Method
            OneEmployee();

            // Display total amount payed to all employees

            // Display highest paid employee


    }

        }