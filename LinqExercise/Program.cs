using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            //Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");
            //Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average()}");
            
            //Order numbers in ascending order and print to the console
            var ordered = numbers.OrderBy(x => x).ToList();
            Console.Write($"Ordered List: ");
            ordered.ForEach(x=>Console.Write($"{x}, "));
            
            //Order numbers in descending order and print to the console
            ordered = numbers.OrderByDescending(x=>x).ToList();
            Console.Write("\nDescending List: ");
            ordered.ForEach(x => Console.Write($"{x}, "));
            
            //Print to the console only the numbers greater than 6
            var newList = numbers.Where(x => x > 6).ToList();
            Console.Write("\nNumbers Greater Than 6: ");
            newList.ForEach(x => Console.Write($"{x}, "));

            //Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.Write("\nThe first 4 numbers in the descending list are: ");
            foreach (var number in ordered.Take(4))
                Console.Write($"{number}, ");

            //Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 40;
            Console.Write($"\nNumbers in Desc order with my name subed into index 4 of original order: ");
            ordered = numbers.OrderByDescending(x => x).ToList();
            ordered.ForEach(x => Console.Write($"{x}, "));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR
            //an S and order this in ascending order by FirstName.
            var employeesWithCorS = employees.Where(x => x.FirstName[0] == 'C' || x.FirstName[0] == 'S').ToList();
            Console.Write("\nEmployees with First Name Starting With C or S: ");
            employeesWithCorS.ForEach(x => Console.Write($"{x.FirstName} {x.LastName}, "));

            //Print all the employees' FullName and Age who are over the age 26 to the console and order this by
            //Age first and then by FirstName in the same result.
            var filteredList = employees.Where(x => x.Age > 26).OrderBy(x =>x.Age).ThenBy(x=> x.FirstName).ToList();
            Console.Write("\nEmployees over 26 ordered by age then first name: ");
            filteredList.ForEach(x => Console.Write($"{x.FirstName}-{x.Age}, "));
            
            //Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sum = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x=>x.YearsOfExperience);
            Console.WriteLine($"\nSum of YOE for employees over 35 with 10 or less YOE: {sum}");

            //Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10
            //AND Age is greater than 35.
            var average = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x=>x.YearsOfExperience);
            Console.WriteLine($"The average YOE for employees over 35 with 10 or less YOE: {average}");

            //Add an employee to the end of the list without using employees.Add()
            var ted = new Employee("Ted", "Lasto", 44, 12);
            var longerEmployeeList = employees.Append(ted).ToList();
            Console.Write("The new employee list: ");
            longerEmployeeList.ForEach(x => Console.Write($"{x.FirstName}, "));

        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
