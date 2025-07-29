using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Privilege
    {
        Guest = 1,
        Developer = 2,
        Secretary = 4,
        DBA = 8,
    }
    enum Gender
    {
        Male,
        Female
    }
    class Employee
    {
        public int Id { get; }               // Immutable
        private string name;
        private Privilege privilege;
        private decimal salary;
        private HiringDate hiringDate;
        private Gender gender;

        // Properties with validation in setters
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                name = value;
            }
        }

        public Privilege Privilege
        {
            get => privilege;
            set
            {
                if (!Enum.IsDefined(typeof(Privilege), value) && value == 0)
                    throw new ArgumentException("Invalid privilege value.");
                privilege = value;
            }
        }

        public decimal Salary
        {
            get => salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative.");
                salary = value;
            }
        }

        public HiringDate HiringDate
        {
            get => hiringDate;
            set
            {
                if (value == null)
                    throw new ArgumentException("Hiring date cannot be null.");
                hiringDate = value;
            }
        }

        public Gender Gender
        {
            get => gender;
            set
            {
                if (!Enum.IsDefined(typeof(Gender), value))
                    throw new ArgumentException("Invalid gender value.");
                gender = value;
            }
        }

        // Constructor with validation
        public Employee(int id, string name, Privilege privilege,
                        decimal salary, HiringDate hiringDate, Gender gender)
        {
            Id = id;
            Name = name;
            Privilege = privilege;
            Salary = salary;
            HiringDate = hiringDate;
            Gender = gender;
        }

        // Overloaded constructor for direct date input
        public Employee(int id, string name, Privilege privilege,
                        decimal salary, int year, int month, int day, Gender gender)
            : this(id, name, privilege, salary, new HiringDate(year, month, day), gender)
        {
        }

        // String representation
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Gender: {Gender}, " +
                   $"Privilege: {Privilege}, Salary: {Salary:C}, " +
                   $"Hiring Date: {HiringDate}";
        }

    }
}
