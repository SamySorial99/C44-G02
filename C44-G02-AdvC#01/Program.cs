namespace C44_G02_AdvC_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Range<int> intRange = new Range<int>(1, 10);

            Console.WriteLine(intRange.IsInRange(5)); // true
            Console.WriteLine(intRange.Length()); // 9


            int[] arrayList = { 1, 2, 3, 4, 5 };
            ReverseArray<int>(arrayList);

            FixedSizeList<int> myList = new FixedSizeList<int>(3);

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            //myList.Add(4);//get a exception error


            Console.WriteLine(FirstNonRepeatedChar("wwwnnnssssz"));
        }


        static void ReverseArray<T>(T[] array)
        {
            int left = 0;
            int right = array.Length-1;
            while (left < right)
            {
                (array[left], array[right]) = (array[right], array[left]); // tuple swap
                left++;
                right--;
            }

        }

        //You are given a list of integers. Your task is to find and return a new list containing only the even numbers from the given list.

        static List<T> GetEvenNumbers<T>(List<T> numbers) where T : struct, IConvertible
        {
            List<T> evenNumbers = new List<T>();
            foreach (var number in numbers)
            {
                if (number.ToInt32(null) % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return evenNumbers;
        }

        //Given a string, find the first non-repeated character in it and return its index. If there is no such character, return 0.
        static public char FirstNonRepeatedChar(string s) {
            if (string.IsNullOrEmpty(s)) return '0';
            var counts = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;
            }

            // Step 2: Find the first char with count == 1
            for (int i = 0; i < s.Length; i++)
            {
                if (counts[s[i]] == 1)
                    return s[i];
            }
            return '0';

        }


    }
}
