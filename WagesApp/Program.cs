﻿using System.Globalization;
using System.Reflection.Metadata;

namespace WagesApp;

class Program
{

    // Global variables
    static List<string> DAYS = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

    // Constant Variable
    static readonly float PAYRATE = 22.00f, TAXA = 0.075f, TAXB = 0.08f;

    // Methods or Functions

    static int CheckHoursWorked(string day)
    {
        while(true)
        {
            Console.WriteLine($"\nEnter the hours worked on {day}:");
            int hoursWorked = Convert.ToInt32(Console.ReadLine());

            if(hoursWorked >= 0 && hoursWorked <= 24)
            {
                return hoursWorked;
            }

            Console.WriteLine("ERROR: Hours worked must be between 0 and 24");

        }
    }


    static string CheckName(string name)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        return textInfo.ToTitleCase(name);
    }
    static string FormatToDollar(float value)
    {
        return string.Format("{0:0.00}", value);
    }
    static string PaySummary(string name, List<int> hrsWorked)
    {
        return "\n----- Pay Summary ----\n" +
            $"Employee Name: {name}\n" +
            $"Hours Worked: {SumHoursWorked(hrsWorked)}\n" +
            $"Bonus Owed: ${FormatToDollar(CalculateBonus(hrsWorked))}\n" +
            $"Gross Pay: ${FormatToDollar(CalculateWages(hrsWorked) + CalculateBonus(hrsWorked))}\n" +
            $"Tax Owed: ${FormatToDollar(CalculateTax(hrsWorked))}\n" +
            $"Net Pay: ${FormatToDollar(CalculateWages(hrsWorked) + CalculateBonus(hrsWorked) - CalculateTax(hrsWorked))}";

    }

    // Calculate tax (pay < 450 then tax = 7.5% else tax = 8%)
    static float CalculateTax(List<int> hrsWorked)
    {


        if (CalculateWages(hrsWorked) + CalculateBonus(hrsWorked) < 450)
        {
            return (float)Math.Round((CalculateWages(hrsWorked) + CalculateBonus(hrsWorked)) * TAXA, 2);
        }

        return (float)Math.Round((CalculateWages(hrsWorked) + CalculateBonus(hrsWorked)) * TAXB, 2);
    }

    // Determine if employee qualifies for a bonus (>30 hours for the week)
    static float CalculateBonus(List<int> hrsWorked)
    {

        if (SumHoursWorked(hrsWorked) > 30)
        {
            return (float)Math.Round(5 * PAYRATE, 2);
        }

        return 0;
    }

    // Calculate weekly wages (total hours x pay rate)
    static float CalculateWages(List<int> hrsWorked)
    {
        return (float)Math.Round(SumHoursWorked(hrsWorked) * PAYRATE, 2);
    }

    // Calculate total hours worked
    static int SumHoursWorked(List<int> hrsWorked)
    {
        int sumHoursWorked = 0;

        foreach (int hour in hrsWorked)
        {
            sumHoursWorked += hour;
        }

        return sumHoursWorked;
    }
    static void OneEmployee()
    {
        // Local variables
        string employeeName;
        List<int> hoursWorked = new List<int>();

        // Input employee name
        Console.WriteLine("Enter the employee's name:");
        employeeName = CheckName(Console.ReadLine());


        // Input the number of hours worked for each day
        foreach (var day in DAYS)
        {
            
            hoursWorked.Add(CheckHoursWorked(day));
        }

        // Display employees pay summary
        Console.WriteLine(PaySummary(employeeName, hoursWorked));
    }

    // When Run...
    static void Main(string[] args)
    {
        DAYS.AsReadOnly();

        // Call OneEmployee Method
        OneEmployee();
        Console.ReadLine();

        // Display total amount paid to all employees

        // Display highest paid employee

    }
}