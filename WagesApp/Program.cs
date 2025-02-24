using System.Reflection.Metadata;

namespace WagesApp;

    class Program
    {

    // global variables
    static List<string> DAYS = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
    // Constant Variable
    static readonly float PAYRATE = 22.00f, TAXA = 0.075f, TAXB = 0.08f;

    // methods or functions
    static float CalculateTax(List<int> hrsWorked)
    {

        if(CalculateWages(hrsWorked)+CalculateBonus(hrsWorked) < 450)
        {
            return (CalculateWages(hrsWorked) + CalculateBonus(hrsWorked)) * TAXA;
        }

        return (CalculateWages(hrsWorked) + CalculateBonus(hrsWorked)) * TAXB;
    }

    static float CalculateBonus(List<int> hrsWorked)
    { 

        if(SumHoursWorked(hrsWorked) > 30)
        {
            return 5 * PAYRATE;
        }

        return 0;
    }

    static float CalculateWages(List<int> hrsWorked)
    {
        return (float)Math.Round(SumHoursWorked(hrsWorked) * PAYRATE, 2);
    }

    static int SumHoursWorked(List<int> hrsWorked)
    {
        int SumHoursWorked = 0;

        foreach (int hour in hrsWorked)
        {
            SumHoursWorked += hour;
        }

        return SumHoursWorked;
    }

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
            hoursWorked.Add(int.Parse(Console.ReadLine()));
        }


        // Calculate total hours worked in a week
        Console.WriteLine($"Total Hours Worked: {SumHoursWorked(hoursWorked)}");


        // Calculate weekly wages (payrate_*_total hours worked)
        Console.WriteLine($"Wages for the week: ${CalculateWages(hoursWorked)}");

        // Determine if employee qualifies for a bonus(>30 hours per week)
        Console.WriteLine($"Bonus: ${CalculateBonus(hoursWorked)}");


        // If employee qualifies for a bonus, add bonus to weekly pay


        // Calculate tax (pay < 450 then 7.5% else tax = 8%)
        Console.WriteLine($"Taxes Owed: ${CalculateTax(hoursWorked)}");

        Console.ReadLine();

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