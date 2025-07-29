using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] EmpArr = new Employee[3];
            EmpArr[0] = new Employee(1, "Alice", Privilege.DBA, 15000, 2020, 5, 10, Gender.Female);
            EmpArr[1] = new Employee(2, "Bob", Privilege.Guest, 5000, 2022, 3, 1, Gender.Male);

            // Full permissions (Guest + Developer + Secretary + DBA)
            EmpArr[2] = new Employee(3, "Charlie",
                Privilege.Guest | Privilege.Developer | Privilege.Secretary | Privilege.DBA,
                25000, 2019, 1, 15, Gender.Male);

            Console.WriteLine("Original Order:");
            foreach (var emp in EmpArr)
            {
                Console.WriteLine(emp);
            }

            for (int i = 0; i < EmpArr.Length - 1; i++)//bubble sort takes zero boxing and unboxing 
            {
                for (int j = 0; j < EmpArr.Length - i - 1; j++)
                {
                    if (EmpArr[j].HiringDate.Date > EmpArr[j + 1].HiringDate.Date)
                    {
                        // Swap
                        Employee temp = EmpArr[j];
                        EmpArr[j] = EmpArr[j + 1];
                        EmpArr[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nSorted by Hire Date:");
            foreach (var emp in EmpArr)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
