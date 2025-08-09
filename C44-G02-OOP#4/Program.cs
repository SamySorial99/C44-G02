namespace C44_G02_OOP_4
{
    public class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Employee is working");
        }
    }

    // Derived class
    public class Manager : Employee
    {
        public override void Work()
        {
            // Call the base class Work method
            base.Work();

            // Additional behavior for Manager
            Console.WriteLine("Manager is managing");
        }
    }


    // question 5 
    public class BaseClass
    {
        public virtual void DisplayMessage()
        {
            Console.WriteLine("Message from BaseClass");
        }
    }

    public class DerivedClass1 : BaseClass
    {
        public override void DisplayMessage()
        {
            Console.WriteLine("Message from DerivedClass1");
        }
    }

    public class DerivedClass2 : BaseClass
    {
        public new void DisplayMessage()
        {
            Console.WriteLine("Message from DerivedClass2");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseClass obj1 = new DerivedClass1();
            obj1.DisplayMessage(); // Calls DerivedClass1's method

            BaseClass obj2 = new DerivedClass2();
            obj2.DisplayMessage(); // Calls BaseClass's version (new hides it)

            DerivedClass2 obj3 = new DerivedClass2();
            obj3.DisplayMessage();

        }
    }
}
