namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Question 1 
            for (int i = 0; i < Enum.GetNames(typeof(WeekDays)).Length; i++)
            {
                Console.WriteLine($"{i + 1} - {Enum.GetName(typeof(WeekDays), i + 1)}");
            }


            // Question 2

            Console.WriteLine("Enter season name (Spring, Summer, Autumn, Winter):");
            string input = Console.ReadLine();
            if (Enum.TryParse<Seasons>(input, true, out Seasons season))
            {
                Console.WriteLine($"You entered: {season} ({(int)season})");

                if (season == Seasons.Summer)
                {
                    Console.WriteLine("June to August");
                }
                else if (season == Seasons.Autumn)
                {
                    Console.WriteLine("September to November");
                }
                else if (season == Seasons.Winter)
                {
                    Console.WriteLine("December to February");
                }
                else if (season == Seasons.Spring)
                {
                    Console.WriteLine("March to May");
                }
            }
            else
            {
                Console.WriteLine("Invalid season name.");
            }




            // Question 3 Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable

            Permissions userPermissions = Permissions.Read | Permissions.Write; 
            Console.WriteLine($"Current Permissions: {userPermissions}");


            // question 4 
            Console.WriteLine("Enter a color to see if it's primary color or not");
            string colorInput = Console.ReadLine();
            if (Enum.TryParse<Colors>(colorInput, true, out Colors color))
            {
                switch (color)
                {
                    case Colors.Red:
                    case Colors.Green:
                    case Colors.Blue:
                        Console.WriteLine($"{color} is a primary color.");
                        break;
                    default:
                        Console.WriteLine($"{color} is not a primary color.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid color input.");
            }

        }

        #region question 1

        enum WeekDays
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        #endregion



        #region question 2

        enum Seasons
        {
            Spring = 1,
            Summer = 2,
            Autumn = 3,
            Winter = 4
        }
        #endregion

        #region question 3
        enum Permissions
        {
            Read = 1,
            Write = 2,
            Execute = 4,
            Delete = 8
        }

        #endregion

        #region question 4
        enum Colors
        {
            Red,
            Green,
            Blue
        }

        #endregion
    }
}
